using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman_2022.Classes.Entities
{
    public class Ghost_Room : Abstract_Entity
    {
        private bool isEmpty = true;

        public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
        public Ghost_Room(int row, int column) : base(row, column, 0, Map.Background_Color)
        {
            this.IsEmpty = true;
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw_Background(graphics);
        }
    }
}
