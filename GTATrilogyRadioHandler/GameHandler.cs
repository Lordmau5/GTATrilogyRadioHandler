﻿using Process.NET;
using Process.NET.Memory;
using Process.NET.Patterns;
using System;
using System.Linq;

namespace GTATrilogyRadioHandler
{
    class GameHandler
    {
        public static string Game = "LibertyCity";
        public static ProcessSharp Process = null;
        public static IntPtr Player = IntPtr.Zero;

        public static EventHandler OnGameExit;

        public static bool Initialize()
        {
            if (Process == null)
            {
                Process = GetGameProcess();
                if (Process == null)
                {
                    return false;
                }

                Process.ProcessExited += (_sender, _e) =>
                {
                    Process = null;
                    Player = IntPtr.Zero;

                    OnGameExit.Invoke(_sender, _e);
                };
            }

            if (Player == IntPtr.Zero)
            {
                Player = GetPlayerPointer();
                if (Player == null || Player == IntPtr.Zero)
                {
                    return false;
                }
            }

            return true;
        }

        private static T GetFromPattern<T>(ProcessSharp m, IMemoryPattern pattern, int offset = 0, int ripOffset = 4)
        {
            var module = m.ModuleFactory.MainModule;
            var scanner = new PatternScanner(module);

            var scan = scanner.Find(pattern);

            var address = scan.BaseAddress;
            var middleOffset = m[address].Read<int>(offset);

            var pointer = address + middleOffset + (offset + ripOffset);

            return m[pointer].Read<T>(0x0);
        }

        private static ProcessSharp GetGameProcess()
        {
            var processes = System.Diagnostics.Process.GetProcessesByName(Game);
            if (processes.Length == 0) return null;

            var process = new ProcessSharp(processes.First(), MemoryType.Local);
            process.Memory = new ExternalProcessMemory(process.Handle);

            return process;
        }

        private static IntPtr GetPlayerPointer()
        {
            /*
                0f b6 05 ? ? ? ? 
                ? 8d 0d ? ? ? ? 
                ? 69 c0 ? ? ? ? 
                ? 8b 04 ?
            */
            IMemoryPattern PlayerPointer = new DwordPattern("0f b6 05 ? ? ? ? ? 8d 0d ? ? ? ? ? 69 c0 ? ? ? ? ? 8b 04 ?");

            return GetFromPattern<IntPtr>(Process, PlayerPointer, 10);
        }

        public static bool GetIsPlayerInVehicle()
        {
            try
            {
                if (Game == "LibertyCity")
                {
                    return Process[Player].Read<bool>(0x498);
                }
                else if (Game == "ViceCity")
                {
                    return Process[Player].Read<bool>(0x548);
                }
                else if (Game == "SanAndreas")
                {
                    int fiveCC = Process[Player].Read<int>(0x5CC);
                    return (fiveCC & 0x100) > 0;
                }
            }
            catch { }

            return false;
        }
    }
}
