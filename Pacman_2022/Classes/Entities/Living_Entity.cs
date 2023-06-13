using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman_2022.Classes.Entities
{
    public abstract class Living_Entity: Abstract_Entity
    {
        private Direction current_direction;
        public Direction Current_direction { get => current_direction; set => current_direction = value; }

        protected Living_Entity(int row, int column):base(row, column, 0, Color.White)
        {
            this.Current_direction = Direction.NONE;
        }
       
        public abstract bool CanPassThrough(Abstract_Entity entity);
        public abstract void Move();

        public abstract bool CanEat(Abstract_Entity entity);
        public abstract void Eat(Abstract_Entity entity);
        
        public Point GetVelocity()
        {
            Point velocity = new Point(0, 0);

            switch (this.current_direction)
            {
                case Direction.UP:
                    velocity = new Point(0, -1);
                    break;
                case Direction.DOWN:
                    velocity = new Point(0, 1);
                    break;
                case Direction.LEFT:
                    velocity = new Point(-1, 0);
                    break;
                case Direction.RIGHT:
                    velocity = new Point(1, 0);
                    break;
                case Direction.NONE:
                    velocity = new Point(0, 0);
                    break;
            }

            return velocity;
        }
    }
}
