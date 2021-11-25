using System;
using System.Windows.Forms;

using CrossThreadExtensions;

namespace GTATrilogyRadioHandler
{
    public partial class GTATrilogyRadioHandler : Form
    {
        // TODO: Dynamic list of programs, perhaps also a process selector with checkboxes?
        private string[] programs =
        {
            "spotify",
            "musicbee",
            "winamp"
        };

        private bool Initialized { get; set; }
        private System.Timers.Timer timer;

        public GTATrilogyRadioHandler()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            GameHandler.OnGameExit += (_sender, _e) =>
            {
                this.PerformSafely(() =>
                {
                    Initialized = false;
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
            if (!Initialized)
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

            Initialized = true;
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

            Initialized = true;
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

            Initialized = true;
        }
    }
}
