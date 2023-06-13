using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_2022.Classes.Dijkstra
{
    public static class AStar
    {
        //LIKE A GOOD NEIGHBOR
        public static List<Node> FindPath(Node node_start, Node node_goal)
        {
            List<Node> path_Solution = new List<Node>();
            List<Node> open_List = new List<Node>();
            List<Node> closed_List = new List<Node>();

            open_List.Add(node_start);

            while (open_List.Count > 0)
            {
                Node current_Node = Remove_Min_Node(open_List);
                //Step 1 : Check if goal is found
                if (current_Node.Equals(node_goal))
                {
                    node_goal.Previous_Node = current_Node.Previous_Node;
                    break; //Exit the loop
                }
                //Step 2 : Explore the neighbors
                List<Node> neighborsList = current_Node.Get_Neighbors();
                foreach (Node neighbor in neighborsList)
                {
                    //Check if neighbor already exist in Open List
                    int index_OpenList = open_List.IndexOf(neighbor);
                    //If neighbor is Found in the OpenList
                    if (index_OpenList >= 0)
                    {
                        if (open_List[index_OpenList].F <= neighbor.F)
                            continue; //Skip the current neighbor
                        else
                        {
                            //Update the F value and the previous Node
                            open_List.RemoveAt(index_OpenList);
                            open_List.Add(neighbor);
                        }
                    }
                    else
                    {
                        //Neighbor is not found in OpenList
                        //Check if neighbor does not exist in the ClosedList
                        if (!closed_List.Contains(neighbor))
                            open_List.Add(neighbor);
                    }
                }
                //Step 3: Add the currentNode to the ClosedList
                closed_List.Add(current_Node);
            }//End While Loop

            //Backtacking from the goal to start
            Node node = node_goal;
            while (node != null)
            {
                path_Solution.Insert(0, node);
                node = node.Previous_Node;
            }

            return path_Solution;
        }

        private static Node Remove_Min_Node(List<Node> list)
        {
            if (list.Count > 0)
            {
                Node min_Node = list[0];
                foreach (Node obj in list)
                {
                    if (obj.F < min_Node.F)
                        min_Node = obj;
                }
                list.Remove(min_Node);
                return min_Node;
            }
            return null;
        }
    }
}
