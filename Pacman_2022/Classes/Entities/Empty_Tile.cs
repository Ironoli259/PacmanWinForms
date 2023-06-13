using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_2022.Classes.Entities
{
    public class Empty_Tile : Abstract_Entity
    {
        public Empty_Tile(int row, int column) : base(row, column, 0, Map.Background_Color)
        {

        }
        public override void Draw(Graphics graphics)
        {
            base.Draw_Background(graphics);
        }
    }
}
