using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman_2022.Classes.Entities
{
    public class Booster : Abstract_Entity
    {
        public Booster(int row, int column) : base(row, column, 50, Color.White)
        {

        }
        public override void Draw(Graphics graphics)
        {
            //Draw Background
            base.Draw_Background(graphics);

            //Draw Circle
            int pointX = (base.Column * Map.Tile_Size) + (Map.Tile_Size / 4);
            int pointY = (base.Row * Map.Tile_Size) + (Map.Tile_Size / 4);
            int width = Map.Tile_Size / 2;
            int height = Map.Tile_Size / 2;

            Rectangle circleRectangle = new Rectangle(pointX, pointY, width, height);
            Brush myBrush = new SolidBrush(base.Entity_Color);
            graphics.FillEllipse(myBrush, circleRectangle);

            //Release the memory
            myBrush.Dispose();
        }
    }
}
