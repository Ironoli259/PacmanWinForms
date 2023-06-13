using Pacman_2022.Classes.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_2022
{
    public partial class Form_Exit : Form
    {
        public Form_Exit()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ReplayButton_Click(object sender, EventArgs e)
        {
            Game_Manager.Start_Game();
            this.Close();
        }
    }
}
