using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_2022.Classes.Entities
{
    public class Fruit : Abstract_Entity
    {
        private static string[] imageFiles = { "Fruit_Apple.png", "Fruit_Cherry.png", "Fruit_Strawberry.png" };
        private string myFileName;

        public Fruit(int row, int column) : base(row, column, 150, Map.Background_Color)
        {
            int randomIndex = RNG.Get_Instance().Next(0, imageFiles.Length);
            myFileName = imageFiles[randomIndex];
        }
        public override void Draw(Graphics graphics)
        {
            //Draw Background
            base.Draw_Background(graphics);

            //Draw Image
            using (Image myImage = Image.FromFile(Map.Path + this.myFileName))
            {
                Rectangle myRectangle = base.GetRectangle();
                graphics.DrawImage(myImage, myRectangle);
            }
        }
    }
}
