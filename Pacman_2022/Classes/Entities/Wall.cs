using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_2022.Classes.Entities
{
    internal class Wall : Abstract_Entity
    {
        public Wall(int row, int column) : base(row, column, 0, Color.Blue)
        {

        }

        public override void Draw(Graphics graphics)
        {
            using (Brush myBrush = new SolidBrush(Map.Wall_Color))
            {
                Rectangle myRectangle = base.GetRectangle();
                graphics.FillRectangle(myBrush, myRectangle);
            }
        }
    }
}
