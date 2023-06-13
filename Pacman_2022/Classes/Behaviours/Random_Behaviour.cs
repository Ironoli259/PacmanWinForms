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
    public class Random_Behaviour : IBehaviour
    {
        #region Singleton Design Pattern
        private static Random_Behaviour instance = new Random_Behaviour();

        private Random_Behaviour() { }

        public static Random_Behaviour Get_Instance()
        {
            return instance;
        }
        #endregion

        public List<Node> Find_Path(Ghost ghost)
        {
            Empty_Tile random_Tile = this.GetRandomTile();

            Node goalNode = new Node(row: random_Tile.Row, column: random_Tile.Column, null, null);
            // Start Node = Position of Ghost
            Node startNode = new Node(row: ghost.Row, column: ghost.Column, goalNode, null);

            return AStar.FindPath(startNode, goalNode);
        }

        private Empty_Tile GetRandomTile()
        {
            int random_index = RNG.Get_Instance().Next(0, Map.empty_Tiles.Count);
            return Map.empty_Tiles[random_index];
        }
    }
}
