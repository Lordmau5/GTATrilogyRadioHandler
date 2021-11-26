using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTATrilogyRadioHandler
{
    public class VolumeMixer
    {
        public static float? GetApplicationVolume(int pid)
        {
            List<SimpleAudioVolume> volumes = GetVolumeObjects(pid);
            if (volumes.Count == 0)
                return null;

            return volumes.First().Volume * 100;
        }

        public static bool? GetApplicationMute(int pid)
        {
            List<SimpleAudioVolume> volumes = GetVolumeObjects(pid);
            if (volumes.Count == 0)
                return null;
            
            return volumes.First().Mute;
        }

        public static void SetApplicationVolume(int pid, float level)
        {
            List<SimpleAudioVolume> volumes = GetVolumeObjects(pid);
            if (volumes.Count == 0)
                return;

            foreach (var volume in volumes)
            {
                volume.Volume = level / 100;
            }
        }

        public static void SetApplicationMute(int pid, bool mute)
        {
            List<SimpleAudioVolume> volumes = GetVolumeObjects(pid);
            if (volumes.Count == 0)
                return;

            foreach (var volume in volumes)
            {
                volume.Mute = mute;
            }
        }

        public static void ToggleApplicationMute(int pid)
        {
            List<SimpleAudioVolume> volumes = GetVolumeObjects(pid);
            if (volumes.Count == 0)
                return;

            foreach (var volume in volumes)
            {
                volume.Mute = !volume.Mute;
            }
        }

        public static void SetProgramsMuted(List<string> programs, bool state)
        {
            List<int> processes = new List<int>();
            foreach (var process in System.Diagnostics.Process.GetProcesses())
            {
                if (programs.Contains(process.ProcessName, StringComparer.OrdinalIgnoreCase))
                {
                    if (process.MainWindowHandle != IntPtr.Zero)
                    {
                        processes.Add(process.Id);
                    }
                }
            }

            if (processes.Count == 0)
            {
                return;
            }

            foreach (var pID in processes)
            {
                SetApplicationMute(pID, state);
            }
        }

        private static List<SimpleAudioVolume> GetVolumeObjects(int pid)
        {
            List<SimpleAudioVolume> volumeControls = new List<SimpleAudioVolume>();

            var deviceEnumerator = new MMDeviceEnumerator();

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                var device = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)[i];
                var mgr = device.AudioSessionManager;

                for (int j = 0; j < mgr.Sessions.Count; j++)
                {
                    var ctl = mgr.Sessions[j];

                    if (ctl.GetProcessID == pid)
                    {
                        volumeControls.Add(ctl.SimpleAudioVolume);
                        break;
                    }
                }
            }
            return volumeControls;
        }
    }
}
