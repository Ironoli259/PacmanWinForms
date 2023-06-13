using Pacman_2022.Classes.Behaviours;
//using Pacman_2022.Classes.Pathfinding;
using Pacman_2022.Classes.Dijkstra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_2022.Classes.Entities
{
    public enum Ghost_Color { BLUE, ORANGE, PINK, RED }

    public class Ghost : Living_Entity
    {
        private static string[,] imageFiles = { { "Blue_Ghost_None.png", "Blue_Ghost_UP.png", "Blue_Ghost_Down.png", "Blue_Ghost_Left.png", "Blue_Ghost_Right.png" },
                                                { "Orange_Ghost_None.png", "Orange_Ghost_UP.png", "Orange_Ghost_Down.png", "Orange_Ghost_Left.png", "Orange_Ghost_Right.png" },
                                                { "Pink_Ghost_None.png", "Pink_Ghost_UP.png", "Pink_Ghost_Down.png", "Pink_Ghost_Left.png", "Pink_Ghost_Right.png" },
                                                { "Red_Ghost_None.png", "Red_Ghost_UP.png", "Red_Ghost_Down.png", "Red_Ghost_Left.png", "Red_Ghost_Right.png" },
                                                { "Dead_Ghost_None.png", "Dead_Ghost_UP.png", "Dead_Ghost_Down.png", "Dead_Ghost_Left.png", "Dead_Ghost_Right.png" },
                                                { "Scared_Ghost_None.png", "Scared_Ghost_UP.png", "Scared_Ghost_Down.png", "Scared_Ghost_Left.png", "Scared_Ghost_Right.png" }
                                              };
        private Ghost_Color myGhost_Color;

        private readonly IBehaviour default_Behaviour;
        private IBehaviour current_Behaviour;
        private List<Node> path = new List<Node>();

        public IBehaviour Default_Behaviour => default_Behaviour;

        public Ghost(int row, int column, Ghost_Color color) : base(row, column)
        {
            myGhost_Color = color;
            base.Score = 200;

            switch (color)
            {
                case Ghost_Color.BLUE:
                    base.Entity_Color = Color.Blue;
                    this.default_Behaviour = Follow_Behaviour.Get_Instance();
                    this.current_Behaviour = Follow_Behaviour.Get_Instance();
                    break;
                case Ghost_Color.ORANGE:
                    base.Entity_Color = Color.Orange;
                    this.default_Behaviour = Random_Behaviour.Get_Instance();
                    this.current_Behaviour = Random_Behaviour.Get_Instance();
                    break;
                case Ghost_Color.PINK:
                    base.Entity_Color = Color.Pink;
                    this.default_Behaviour = Random_Behaviour.Get_Instance();
                    this.current_Behaviour = Random_Behaviour.Get_Instance();
                    break;
                case Ghost_Color.RED:
                    base.Entity_Color = Color.Red;
                    this.default_Behaviour = Chase_Behaviour.Get_Instance();
                    this.current_Behaviour = Chase_Behaviour.Get_Instance();
                    break;
            }
        }

        public override bool CanEat(Abstract_Entity entity)
        {
            return false;
        }

        // Ghosts cannot pass through the Walls
        //Returns false if entity is instance of Wall
        public override bool CanPassThrough(Abstract_Entity entity)
        {
            return !(entity is Wall);
        }
        public void Set_Scared_Behaviour()
        {
            this.current_Behaviour = Scared_Behaviour.Get_Instance();
            this.Update_Path();
        }
        public void Set_Dead_Behaviour()
        {
            this.current_Behaviour = Dead_Behaviour.Get_Instance();
            this.Update_Path();
        }
        public void Reset_Behaviour()
        {
            if (this.current_Behaviour is Scared_Behaviour)
            {
                this.current_Behaviour = default_Behaviour;
                this.Update_Path();
                Map.Set_Empty_GhostRooms();
            }
            //Dead ghost continue his current path to the ghost_room
            if (this.current_Behaviour is Dead_Behaviour)
            {
                this.current_Behaviour = default_Behaviour;
            }
        }
        public void Update_Path()
        {
            this.path = this.current_Behaviour.Find_Path(this);
            if (this.path.Count > 0)
            {
                this.path.RemoveAt(0);//remove the start node (current position of ghost)
            }
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw_Background(graphics);

            int index1 = (int)this.myGhost_Color;

            if (this.current_Behaviour is Dead_Behaviour)
            {
                index1 = 4;
            }
            if (this.current_Behaviour is Scared_Behaviour)
            {
                index1 = 5;
            }

            int index2 = (int)this.Current_direction;
            string imageName = imageFiles[index1, index2];

            using (Image myImage = Image.FromFile(Map.Path + imageName))
            {
                Rectangle myRectangle = base.GetRectangle();
                graphics.DrawImage(myImage, myRectangle);
            }
        }

        public override void Eat(Abstract_Entity entity)
        {
            if (entity is Pacman)
            {
                if ((entity as Pacman).Lives > 1)
                {
                    ((Pacman)entity).Lives--;
                    Game_Manager.Restart_Game();
                }
                else
                {
                    Game_Manager.Game_Over();
                }
            }
        }

        public override void Move()
        {
            if (this.path.Count > 0)
            {
                Node nextNode = this.path[0];
                this.path.RemoveAt(0);
                this.Current_direction = Next_Direction(nextNode);

                this.Row = nextNode.Row;
                this.Column = nextNode.Column;
            }
            else
            {
                if (this.current_Behaviour is Scared_Behaviour || this.current_Behaviour is Dead_Behaviour)
                {
                    int index = Map.ghost_rooms.FindIndex(IsEmptyRoom);
                    if (index == -1)
                    {
                        Map.Set_Empty_GhostRooms();
                    }
                }
                Update_Path();
            }
        }

        public bool IsEmptyRoom(Ghost_Room room)
        {
            return room.IsEmpty;
        }

        public Direction Next_Direction(Node nextNode)
        {
            if (this.Row == nextNode.Row && this.Column == nextNode.Column)
            {
                return Direction.NONE;
            }
            else
            {
                if (this.Row == nextNode.Row)
                {
                    return (this.Column > nextNode.Column) ? Direction.LEFT : Direction.RIGHT;
                }
                else
                {
                    return (this.Row > nextNode.Row) ? Direction.UP : Direction.DOWN;
                }
            }
        }

        //HINT BUTTON
        public void Draw_Path(Graphics graphics)
        {
            for (int i = 0; i < this.path.Count - 1; i++)
            {
                Node startNode = this.path[i];
                Node endNode = this.path[i + 1];

                int startX = (startNode.Column * Map.Tile_Size) + (Map.Tile_Size / 2);
                int startY = (startNode.Row * Map.Tile_Size) + (Map.Tile_Size / 2);
                Point startPoint = new Point(startX, startY);

                int endX = (endNode.Column * Map.Tile_Size) + (Map.Tile_Size / 2);
                int endY = (endNode.Row * Map.Tile_Size) + (Map.Tile_Size / 2);
                Point endPoint = new Point(endX, endY);

                Pen myPen = new Pen(base.Entity_Color, 5);
                graphics.DrawLine(myPen, startPoint, endPoint);

                myPen.Dispose();
            }
        }
    }
}
