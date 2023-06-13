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
    public class Follow_Behaviour : IBehaviour
    {
        #region Singleton Design Pattern
        private static Follow_Behaviour instance = new Follow_Behaviour();

        private Follow_Behaviour() { }

        public static Follow_Behaviour Get_Instance()
        {
            return instance;
        }
        #endregion

        public List<Node> Find_Path(Ghost ghost)
        {
            // Goal Node = Position of Pacman
            Node goalNode = new Node(row: Game_Manager.pacman.Row, column: Game_Manager.pacman.Column, null, null);

            // Start Node = Position of Ghost
            Node startNode = new Node(ghost.Row, ghost.Column, goalNode, null);

            return AStar.FindPath(startNode, goalNode);
        }
    }
}
