using Memory;

namespace GTATrilogyRadioHandler
{
    class GameHandler
    {
        public static string Game = "LibertyCity";
        public static Mem m = new Mem();
        public static IntPtr Player = IntPtr.Zero;

        public static EventHandler? OnGameExit;

        /*
            0f b6 05 ? ? ? ? 
            ? 8d 0d ? ? ? ? 
            ? 69 c0 ? ? ? ? 
            ? 8b 04 ?
        */
        //private static readonly IMemoryPattern PlayerPointer = new DwordPattern("0f b6 05 ? ? ? ? ? 8d 0d ? ? ? ? ? 69 c0 ? ? ? ? ? 8b 04 ?");
        private static readonly string PlayerPointer = "0f b6 05 ? ? ? ? ? 8d 0d ? ? ? ? ? 69 c0 ? ? ? ? ? 8b 04 ?";
        //private static PatternScanner? PatternScanner = null;

        public static async Task<bool> Initialize()
        {
            if (m.pHandle == IntPtr.Zero)
            {
                if (!GetGameProcess())
                {
                    return false;
                }

                //Process.ProcessExited += (_sender, _e) =>
                //{
                //    ClearReferences();
                //};

                //Process.OnDispose += (_sender, _e) =>
                //{
                //    ClearReferences();
                //};
            }

            if (Player == IntPtr.Zero)
            {
                Player = await GetPlayerPointer();
                if (Player == IntPtr.Zero)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool GetGameProcess()
        {
            var processes = System.Diagnostics.Process.GetProcessesByName(Game);
            if (processes.Length == 0) return false;

            var process = m.OpenProcess(processes.First().Id);

            return process;
        }

        public static void Unhook()
        {
            //Process?.Dispose();

            m.CloseProcess();
            m.pHandle = IntPtr.Zero;
            Player = IntPtr.Zero;

            OnGameExit?.Invoke(null, EventArgs.Empty);
        }

        private async static Task<long> GetLongFromPattern(string pattern, int offset = 0, int ripOffset = 4)
        {
            if (m.pHandle == IntPtr.Zero) return default;

            var results = await m.AoBScan(pattern);

            var address = results.FirstOrDefault();

            var middleOffset = m.ReadInt((address + offset).ToString("X"));

            var pointer = address + middleOffset + (offset + ripOffset);

            return m.ReadLong(pointer.ToString("X"));
        }

        private async static Task<IntPtr> GetPlayerPointer()
        {
            IntPtr.TryParse((await GetLongFromPattern(PlayerPointer, 10)).ToString(), out IntPtr playerPointer);

            return playerPointer;
        }

        public static bool GetIsPlayerInVehicle()
        {
            try
            {
                if (m.pHandle == IntPtr.Zero)
                {
                    Unhook();
                    return false;
                }

                if (Game == "LibertyCity")
                {
                    return m.ReadByte((Player + 0x498).ToString("X")) == 1;
                }
                else if (Game == "ViceCity")
                {
                    return m.ReadByte((Player + 0x548).ToString("X")) == 1;
                }
                else if (Game == "SanAndreas")
                {
                    int fiveCC = m.ReadInt((Player + 0x5CC).ToString("X"));
                    return (fiveCC & 0x100) > 0;
                }
            }
            catch { }

            return false;
        }
    }
}
