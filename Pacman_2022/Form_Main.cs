using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacman_2022.Classes.Entities;

namespace Pacman_2022
{
    public partial class Form_Main : Form
    {
        public bool DISPLAY_PATH = false;

        public Form_Main()
        {
            InitializeComponent();

            Game_Manager.Start_Game();

            this.pictureBox_Map.Width = Map.Max_Columns * Map.Tile_Size;
            this.pictureBox_Map.Height = Map.Max_Rows * Map.Tile_Size;

            int width = this.pictureBox_Map.Width;
            int height = this.pictureBox_Map.Height + this.pictureBox_Map.Location.Y;
            this.ClientSize = new Size(width, height);

        }

        private void pictureBox_Map_Paint(object sender, PaintEventArgs e)
        {
            //Drawing the Tiles : Walls, Floors, Dots, Boosters, Fruits
            foreach (Abstract_Entity obj in Map.abstract_Entities)
            {
                obj.Draw(e.Graphics);
            }
            
            //Drawing the ghosts
            foreach (Ghost obj in Game_Manager.ghosts_List)
            {
                obj.Draw(e.Graphics);
                if (DISPLAY_PATH)
                {
                    obj.Draw_Path(e.Graphics);
                }
            }

            //Drawing pacman
            Game_Manager.pacman.Draw(e.Graphics);

            this.label_Lives.Text = Game_Manager.pacman.Lives.ToString();
            this.label_Score.Text = Game_Manager.pacman.Score.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    Game_Manager.pacman.Current_direction = Direction.UP;
                    break;
                case Keys.Down:
                case Keys.S:
                    Game_Manager.pacman.Current_direction = Direction.DOWN;
                    break;
                case Keys.Left:
                case Keys.A:
                    Game_Manager.pacman.Current_direction = Direction.LEFT;
                    break;
                case Keys.Right:
                case Keys.D:
                    Game_Manager.pacman.Current_direction = Direction.RIGHT;
                    break;
            }
        }

        //Timers
        private void timer_Pacman_Tick(object sender, EventArgs e)
        {
            if (!Game_Manager.isGameOver)
            {
                Game_Manager.pacman.Move();
                Game_Manager.pacman.Check_Boost_Duration();
                this.Refresh();
            }                                                                       
        }

        private void timer_Ghosts_Tick(object sender, EventArgs e)
        {
            if (!Game_Manager.isGameOver)
            {
                foreach (Ghost ghost in Game_Manager.ghosts_List)
                {
                    ghost.Move();
                }
                this.Refresh();
            }
        }

        private void timer_Ghost_Collision_Tick(object sender, EventArgs e)
        {
            if (!Game_Manager.isGameOver)
            {
                Ghost obj = Game_Manager.pacman.Check_Ghost_Collision();
                if (obj != null)
                {
                    Game_Manager.pacman.Current_State.Ghost_Collision(obj, Game_Manager.pacman);
                }
                this.Refresh();
            }
        }

        private void HintButton_Click(object sender, EventArgs e)
        {
            DISPLAY_PATH = !DISPLAY_PATH;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DISPLAY_PATH = !DISPLAY_PATH;
        }
    }
}
