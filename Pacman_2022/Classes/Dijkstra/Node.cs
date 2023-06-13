using Pacman_2022.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_2022.Classes.Dijkstra
{
    public class Node
    {
        private int row;
        private int column;
        private Node goal_Node;
        private Node previous_Node;
        private int g; //distance between the current Node and previous Node

        public Node(int row, int column, Node goal_Node, Node previous_Node, int cost = 1)
        {
            this.row = row;
            this.column = column;
            this.goal_Node = goal_Node;
            this.previous_Node = previous_Node;
            this.g = cost;
        }

        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
        public Node Goal_Node { get => goal_Node; set => goal_Node = value; }
        public Node Previous_Node { get => previous_Node; set => previous_Node = value; }
        public int Total_G { get => (this.previous_Node != null) ? this.previous_Node.Total_G + this.g : this.g; }
        //Heuristic value
        //public double H { get => Manhattan(); }
        public double H { get => Euclidean(); }
        //F = H + Total_G
        public double F { get => this.Total_G + this.H; }

        //Heuristics
        private double Manhattan()
        {
            double dx = this.goal_Node.column - this.column;
            double dy = this.goal_Node.row - this.row;

            return Math.Abs(dx) + Math.Abs(dy);
        }

        private double Euclidean()
        {
            double dx = this.goal_Node.column - this.column;
            double dy = this.goal_Node.row - this.row;

            return Math.Sqrt((dx * dx) + (dy * dy));
        }

        //Method to find the neighbors
        public List<Node> Get_Neighbors()
        {
            List<Node> neighborsList = new List<Node>();
            //UPPER TILE: this.row-1 , this.column
            if (Map.Is_Valid_Tile(this.row - 1, this.column))
            {
                Node upperNode = new Node(this.row - 1, this.column, this.goal_Node, this);
                if (!upperNode.Equals(this.previous_Node))
                {
                    neighborsList.Add(upperNode);
                }
            }
            //LOWER TILE: this.row + 1 , this.column
            if (Map.Is_Valid_Tile(this.row + 1, this.column))
            {
                Node lowerNode = new Node(this.row + 1, this.column, this.goal_Node, this);
                if (!lowerNode.Equals(this.previous_Node))
                {
                    neighborsList.Add(lowerNode);
                }
            }
            //LEFT TILE: this.row , this.column - 1
            if (Map.Is_Valid_Tile(this.row, this.column - 1))
            {
                Node leftNode = new Node(this.row, this.column - 1, this.goal_Node, this);
                if (!leftNode.Equals(this.previous_Node))
                {
                    neighborsList.Add(leftNode);
                }
            }
            //RIGHT TILE: this.row , this.column + 1
            if (Map.Is_Valid_Tile(this.row, this.column + 1))
            {
                Node rightNode = new Node(this.row, this.column + 1, this.goal_Node, this);
                if (!rightNode.Equals(this.previous_Node))
                {
                    neighborsList.Add(rightNode);
                }
            }

            return neighborsList;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj is Node)
                {
                    return (this.row == (obj as Node).row) && (this.column == (obj as Node).column);
                }
            }
            return false;
        }
    }
}
