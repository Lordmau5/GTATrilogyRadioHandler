using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CrossThreadExtensions;

namespace GTATrilogyRadioHandler
{
    public partial class GTATrilogyRadioHandler : Form
    {
        private bool initialized;
        private bool paused;
        private readonly System.Timers.Timer timer;

        public GTATrilogyRadioHandler()
        {
            InitializeComponent();

            Text += $" ({Config.Version})";

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            Config.TryLoadConfig();

            ResetListBox();

            GameHandler.OnGameExit += (_sender, _e) =>
            {
                this.PerformSafely(() =>
                {
                    ResetComponents();
                });
            };

            timer = new System.Timers.Timer(250)
            {
                AutoReset = true,
                Enabled = true
            };

            timer.Elapsed += OnTimerTick;
        }

        private void ResetComponents()
        {
            initialized = false;

            paused = false;
            buttonPauseResume.Text = paused ? "Unpause" : "Pause";

            SetInitializeButtonStates(true);
            VolumeMixer.SetProgramsMuted(Config.Instance().Programs, false);

            buttonUnhook.Enabled = false;
            buttonPauseResume.Enabled = false;
        }

        private void ResetListBox()
        {
            listBoxPrograms.Items.Clear();

            foreach(var program in Config.Instance().Programs)
            {
                listBoxPrograms.Items.Add(program);
            }
        }

        private void OnTimerTick(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!initialized)
            {
                return;
            }

            bool mute = !GameHandler.GetIsPlayerInVehicle();

            if (paused)
            {
                mute = false;
            }

            VolumeMixer.SetProgramsMuted(Config.Instance().Programs, mute);
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            VolumeMixer.SetProgramsMuted(Config.Instance().Programs, false);
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

            buttonUnhook.Enabled = true;
            buttonPauseResume.Enabled = true;
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

            buttonUnhook.Enabled = true;
            buttonPauseResume.Enabled = true;
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

            buttonUnhook.Enabled = true;
            buttonPauseResume.Enabled = true;
        }

        private void buttonUnhook_Click(object sender, EventArgs e)
        {
            GameHandler.Unhook();
        }

        private void buttonPauseResume_Click(object sender, EventArgs e)
        {
            paused = !paused;

            buttonPauseResume.Text = paused ? "Unpause" : "Pause";

            if (!paused)
            {
                VolumeMixer.SetProgramsMuted(Config.Instance().Programs, false);
            }
        }

        private void buttonAddPrograms_Click(object sender, EventArgs e)
        {
            FormAddProgram formAddProgram = new FormAddProgram(Config.Instance().Programs);

            buttonAddPrograms.Enabled = false;

            formAddProgram.OnProgramsAdded += (_sender, _e) =>
            {
                this.PerformSafely(() =>
                {
                    foreach (var program in _e.Programs)
                    {
                        if (!Config.Instance().Programs.Contains(program))
                        {
                            Config.Instance().Programs.Add(program);
                        }
                    }

                    Config.SaveConfig();

                    ResetListBox();
                });
            };

            formAddProgram.FormClosed += (_sender, _e) =>
            {
                this.PerformSafely(() =>
                {
                    buttonAddPrograms.Enabled = true;
                });
            };

            formAddProgram.ShowDialog();
        }

        private void buttonRemoveSelectedProgram_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {
                if (listBoxPrograms.SelectedIndex == -1)
                {
                    return;
                }

                string program = (string) listBoxPrograms.SelectedItem;

                Config.Instance().Programs.Remove(program);

                VolumeMixer.SetProgramsMuted(new List<string>() { program }, false);

                listBoxPrograms.Items.RemoveAt(listBoxPrograms.SelectedIndex);

                Config.SaveConfig();
            }
        }
    }
}
