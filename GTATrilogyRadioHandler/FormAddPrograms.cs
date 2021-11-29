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
    public partial class FormAddPrograms : Form
    {
        public EventHandler<AddProgramsEventArgs>? OnProgramsAdded;
        private readonly List<string> AddedPrograms;

        public FormAddPrograms(List<string> addedPrograms)
        {
            InitializeComponent();

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            AddedPrograms = addedPrograms;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            checkedListBoxPrograms.Items.Clear();

            foreach (var process in System.Diagnostics.Process.GetProcesses())
            {
                if (AddedPrograms.Contains(process.ProcessName))
                {
                    continue;
                }

                if (!checkedListBoxPrograms.Items.Contains(process.ProcessName))
                {
                    if (process.MainWindowHandle != IntPtr.Zero && process.MainWindowTitle != String.Empty)
                    {
                        checkedListBoxPrograms.Items.Add(new CheckBoxProgram(process));
                    }
                }
            }
        }

        private void ButtonAddSelectedPrograms_Click(object sender, EventArgs e)
        {
            List<string> programs = new List<string>();
            foreach (CheckBoxProgram checkbox in checkedListBoxPrograms.CheckedItems)
            {
                programs.Add(checkbox.GetProcessName());
            }

            OnProgramsAdded?.Invoke(this, new AddProgramsEventArgs(programs));

            this.Close();
        }
    }

    class CheckBoxProgram
    {
        private readonly System.Diagnostics.Process process;

        public CheckBoxProgram(System.Diagnostics.Process process)
        {
            this.process = process;
        }

        public string GetProcessName()
        {
            return process.ProcessName;
        }

        public override string ToString()
        {
            return process.ProcessName + " - " + process.MainWindowTitle;
        }
    }

    public class AddProgramsEventArgs : EventArgs
    {
        public List<string> Programs { get; set; }

        public AddProgramsEventArgs(List<string> programs)
        {
            Programs = programs;
        }
    }
}
