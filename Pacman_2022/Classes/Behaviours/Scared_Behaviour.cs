using Pacman_2022.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Pacman_2022.Classes.Pathfinding;
using Pacman_2022.Classes.Dijkstra;

namespace Pacman_2022.Classes.Behaviours
{
    public class Scared_Behaviour : IBehaviour
    {
        #region Singleton Design Pattern
        private static Scared_Behaviour instance = new Scared_Behaviour();

        private Scared_Behaviour() { }

        public static Scared_Behaviour Get_Instance()
        {
            return instance;
        }
        #endregion

        public List<Node> Find_Path(Ghost ghost)
        {
            Ghost_Room random_room = Get_Random_GhostRoom();
            Node goalNode = new Node(row: random_room.Row, column: random_room.Column, null, null);
            // Start Node = Position of Ghost
            Node startNode = new Node(row: ghost.Row, column: ghost.Column, goalNode, null);

            return AStar.FindPath(startNode, goalNode);
        }

        private Ghost_Room Get_Random_GhostRoom()
        {
            Ghost_Room random_room;
            int random_index;
            do
            {
                random_index = RNG.Get_Instance().Next(0, Map.ghost_rooms.Count);
                random_room = Map.ghost_rooms[random_index];
            } while (!random_room.IsEmpty);

            random_room.IsEmpty = false;

            return random_room;
        }
    }
}
