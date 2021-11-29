using CrossThreadExtensions;

namespace GTATrilogyRadioHandler
{
    public partial class FormMain : Form
    {
        private bool initialized;
        private bool paused;
        private readonly System.Timers.Timer timer;

        public FormMain()
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

            foreach (var program in Config.Instance().Programs)
            {
                // TODO: Custom List Box Item with faint red background if program isn't open
                listBoxPrograms.Items.Add(program);
            }
        }

        private void OnTimerTick(object? sender, System.Timers.ElapsedEventArgs e)
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

        private void HookGame(string game)
        {
            FormHookGame formHookGame = new FormHookGame(game);

            initialized = false;
            SetInitializeButtonStates(false);

            formHookGame.OnGameHooked += (_sender, _e) =>
            {
                this.PerformSafely(() =>
                {
                    initialized = true;
                    buttonUnhook.Enabled = true;
                    buttonPauseResume.Enabled = true;

                    formHookGame.Close();
                });
            };

            formHookGame.FormClosed += (_sender, _e) =>
            {
                this.PerformSafely(() =>
                {
                    if (!initialized)
                    {
                        SetInitializeButtonStates(true);
                    }
                });
            };

            formHookGame.ShowDialog();
        }

        private void ButtonGTA3_Click(object sender, EventArgs e)
        {
            HookGame("LibertyCity");
        }

        private void ButtonGTAViceCity_Click(object sender, EventArgs e)
        {
            HookGame("ViceCity");
        }

        private void ButtonGTASanAndreas_Click(object sender, EventArgs e)
        {
            HookGame("SanAndreas");
        }

        private void ButtonUnhook_Click(object sender, EventArgs e)
        {
            GameHandler.Unhook();
        }

        private void ButtonPauseResume_Click(object sender, EventArgs e)
        {
            paused = !paused;

            buttonPauseResume.Text = paused ? "Unpause" : "Pause";

            if (!paused)
            {
                VolumeMixer.SetProgramsMuted(Config.Instance().Programs, false);
            }
        }

        private void ButtonAddPrograms_Click(object sender, EventArgs e)
        {
            FormAddPrograms formAddPrograms = new FormAddPrograms(Config.Instance().Programs);

            buttonAddPrograms.Enabled = false;

            formAddPrograms.OnProgramsAdded += (_sender, _e) =>
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

            formAddPrograms.FormClosed += (_sender, _e) =>
            {
                this.PerformSafely(() =>
                {
                    buttonAddPrograms.Enabled = true;
                });
            };

            formAddPrograms.ShowDialog();
        }

        private void ListBoxPrograms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Shift)
            {
                if (listBoxPrograms.SelectedIndex == -1)
                {
                    return;
                }

                string program = (string)listBoxPrograms.SelectedItem;

                Config.Instance().Programs.Remove(program);

                VolumeMixer.SetProgramsMuted(new List<string>() { program }, false);

                listBoxPrograms.Items.RemoveAt(listBoxPrograms.SelectedIndex);

                Config.SaveConfig();
            }
        }
    }
}