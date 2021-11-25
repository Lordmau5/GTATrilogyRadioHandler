using System;
using System.Windows.Forms;

using CrossThreadExtensions;

namespace GTATrilogyRadioHandler
{
    public partial class GTATrilogyRadioHandler : Form
    {
        private static string Version = "v1.1";

        // TODO: Dynamic list of programs, perhaps also a process selector with checkboxes?
        private readonly string[] programs =
        {
            "spotify",
            "musicbee",
            "winamp"
        };

        private bool initialized;
        private readonly System.Timers.Timer timer;

        public GTATrilogyRadioHandler()
        {
            InitializeComponent();

            Text += $" ({Version})";

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            foreach(var process in System.Diagnostics.Process.GetProcesses())
            {
                if (!checkListPrograms.Items.Contains(process.ProcessName))
                {
                    // TODO: Dynamic list in new window so you can add programs.
                    // Either that, or dynamically tick boxes on launch and refresh every X seconds / with refresh button
                    if (process.MainWindowHandle != IntPtr.Zero && process.MainWindowTitle != String.Empty)
                    {
                        checkListPrograms.Items.Add(process.ProcessName + " - " + process.MainWindowTitle);
                    }
                }
            }

            GameHandler.OnGameExit += (_sender, _e) =>
            {
                this.PerformSafely(() =>
                {
                    initialized = false;
                    SetInitializeButtonStates(true);
                    VolumeMixer.SetProgramsMuted(programs, false);
                });
            };

            timer = new System.Timers.Timer(250)
            {
                AutoReset = true,
                Enabled = true
            };

            timer.Elapsed += OnTimerTick;
        }

        private void OnTimerTick(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!initialized)
            {
                return;
            }

            VolumeMixer.SetProgramsMuted(programs, !GameHandler.GetIsPlayerInVehicle());
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            VolumeMixer.SetProgramsMuted(programs,  false);
        }

        private void SetInitializeButtonStates(bool state)
        {
            buttonGTA3.Enabled = state;
            buttonGTAViceCity.Enabled = state;
            buttonGTASanAndreas.Enabled = state;
        }

        private void buttonGTA3_Click(object sender, EventArgs e)
        {
            SetInitializeButtonStates(false);

            GameHandler.Game = "LibertyCity";
            if (!GameHandler.Initialize())
            {
                SetInitializeButtonStates(true);
                return;
            }

            initialized = true;
        }

        private void buttonGTAViceCity_Click(object sender, EventArgs e)
        {
            SetInitializeButtonStates(false);

            GameHandler.Game = "ViceCity";
            if (!GameHandler.Initialize())
            {
                SetInitializeButtonStates(true);
                return;
            }

            initialized = true;
        }

        private void buttonGTASanAndreas_Click(object sender, EventArgs e)
        {
            SetInitializeButtonStates(false);

            GameHandler.Game = "SanAndreas";
            if (!GameHandler.Initialize())
            {
                SetInitializeButtonStates(true);
                return;
            }

            initialized = true;
        }
    }
}
