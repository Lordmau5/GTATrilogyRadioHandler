using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTATrilogyRadioHandler
{
    public partial class FormHookGame : Form
    {
        private readonly System.Timers.Timer timer;
        private bool initialized;

        public EventHandler OnGameHooked;

        public FormHookGame(string game)
        {
            InitializeComponent();

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            GameHandler.Game = game;
            Text = $"Hooking {game}...";

            timer = new System.Timers.Timer(500)
            {
                AutoReset = true,
                Enabled = true
            };

            timer.Elapsed += OnTimerTick;
        }

        private void OnTimerTick(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (initialized)
            {
                timer.Enabled = false;
                return;
            }

            if (initialized || GameHandler.Initialize())
            {
                initialized = true;
                timer.Enabled = false;

                OnGameHooked?.Invoke(this, EventArgs.Empty);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;

            this.Close();
        }
    }
}
