using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_2022.Classes.Entities
{
    public static class Game_Manager
    {
        public static Pacman pacman;
        public static List<Ghost> ghosts_List;
        public static bool isGameOver = false;
        public static bool gameWinner = false;

        public static void Start_Game()
        {
            Map.Load_Data();
            Game_Manager.pacman = new Pacman(Map.Max_Rows - 2, Map.Max_Columns - 2);
            Create_Ghosts();
        }

        private static void Create_Ghosts()
        {
            Game_Manager.ghosts_List = new List<Ghost>();
            //create the ghosts
            for (int i = 0; i < 4; i++)
            {
                Ghost_Room random_room;
                do
                {
                    int random_index = RNG.Get_Instance().Next(0, Map.ghost_rooms.Count);
                    random_room = Map.ghost_rooms[random_index];
                } while (!random_room.IsEmpty);
                random_room.IsEmpty = false;

                Ghost obj_ghost = new Ghost(random_room.Row, random_room.Column, (Ghost_Color)i);
                Game_Manager.ghosts_List.Add(obj_ghost);
                Game_Manager.pacman.InitializeEvents(obj_ghost);
            }
            //Reset the GhostRoom.Empty = true
            Map.Set_Empty_GhostRooms();
        }

        public static void Restart_Game()
        {
            Game_Manager.pacman.Row = Map.Max_Rows - 2;
            Game_Manager.pacman.Column = Map.Max_Columns - 2;
            Game_Manager.pacman.Current_direction = Direction.NONE;
            Game_Manager.pacman.ClearEvents();
            Create_Ghosts();
        }

        public static void Game_Over()
        {
            if (!isGameOver)
            {
                isGameOver = true;
                Form_Exit gameOverForm = new Form_Exit();
                gameOverForm.Show();
            }            
        }
    }
}
