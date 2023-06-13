using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman_2022.Classes.Entities
{
    public abstract class Abstract_Entity
    {
        private int row;
        private int column;
        private int score;
        private Color entity_Color;

        protected Abstract_Entity(int row, int column, int score, Color entity_Color)
        {
            this.row = row;
            this.column = column;
            this.score = score;
            this.entity_Color = entity_Color;
        }

        #region Properties
        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
        public int Score { get => score; set => score = value; }
        public Color Entity_Color { get => entity_Color; set => entity_Color = value; }
        #endregion

        public abstract void Draw(Graphics graphics);

        public Rectangle GetRectangle()
        {
            int pointX = this.column * Map.Tile_Size;
            int pointY = this.row * Map.Tile_Size;
            int width = Map.Tile_Size;
            int height = Map.Tile_Size;

            return new Rectangle(pointX, pointY, width, height);
        }

        public void Draw_Background(Graphics graphics)
        {
            Rectangle myRectangle = this.GetRectangle();
            Brush myBrush = new SolidBrush(Map.Background_Color);
            graphics.FillRectangle(myBrush, myRectangle);

            myBrush.Dispose();
        }
    }
}
