using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Pacman_2022.Classes.Entities
{
    public static class Map
    {
        public static int Tile_Size = 25;
        public static Color Background_Color = Color.Black;
        public static Color Wall_Color = Color.Blue;
        public static string Path = "../../Classes/resources/";
        public static string Map_File = "Map.txt";

        public static Abstract_Entity[,] abstract_Entities = null;
        public static List<Ghost_Room> ghost_rooms = new List<Ghost_Room>();
        public static List<Empty_Tile> empty_Tiles = new List<Empty_Tile>();

        public static int Max_Rows = 0;
        public static int Max_Columns = 0;
        public static int Count_Eatable_Entities = 0;

        public static void Load_Data()
        {
            string[] lines = File.ReadAllLines(Map.Path + Map_File);

            Map.Max_Rows = lines.Length;
            Map.Max_Columns = lines[0].Length;
            Map.abstract_Entities = new Abstract_Entity[Map.Max_Rows, Map.Max_Columns];

            int row = 0;

            foreach (string line in lines)
            {
                char[] chars = line.ToCharArray();
                int column = 0;

                foreach (char character in chars)
                {
                    Abstract_Entity obj = null;
                    switch (character)
                    {
                        case 'W'://create a Wall
                            obj = new Wall(row, column);
                            break;
                        case 'D'://create a Dot
                            obj = new Dot(row, column);
                            Map.empty_Tiles.Add(new Empty_Tile(row, column));
                            Count_Eatable_Entities++;
                            break;
                        case 'B'://create a Booster
                            obj = new Booster(row, column);
                            Map.empty_Tiles.Add(new Empty_Tile(row, column));
                            Count_Eatable_Entities++;
                            break;
                        case 'R'://create a Ghost Room
                            obj = new Ghost_Room(row, column);
                            Map.ghost_rooms.Add((Ghost_Room)obj);                            
                            break;
                        case 'F'://create a Fruit
                            obj = new Fruit(row, column);
                            Map.empty_Tiles.Add(new Empty_Tile(row, column));
                            Count_Eatable_Entities++;
                            break;
                        case 'T'://create a Empty tile
                            obj = new Empty_Tile(row, column);
                            Map.empty_Tiles.Add(new Empty_Tile(row, column));
                            break;
                        default:
                            obj = new Empty_Tile(row, column);
                            break;
                    }
                    Map.abstract_Entities[row, column] = obj;
                    column++;
                }//End of chars array
                row++;
            }//End of lines array
        }//End of Method Load

        public static bool Is_Valid_Tile(int row, int column)
        {
            int maxRows = Map.abstract_Entities.GetUpperBound(0);
            int maxColumns = Map.abstract_Entities.GetUpperBound(1);

            if (row >= 0 && column >= 0 && row < maxRows && column < maxColumns)
            {
                Abstract_Entity tile = Map.abstract_Entities[row, column];
                return !(tile is Wall);
            }
            return false;
        }

        public static void Set_Empty_GhostRooms()
        {
            foreach (Ghost_Room obj in Map.ghost_rooms)
            {
                obj.IsEmpty = true;
            }
        }

        public static List<Ghost_Room> Get_Ghost_Rooms()
        {
            List<Ghost_Room> list = new List<Ghost_Room>();
            foreach (Ghost_Room obj in Map.ghost_rooms)
            {
                list.Add(obj);
            }

            return list;
        }
    }
}
