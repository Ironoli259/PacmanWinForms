using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Pacman_2022.Classes.States;
using Pacman_2022.Classes.Behaviours;

namespace Pacman_2022.Classes.Entities
{
    
    public class Pacman : Living_Entity
    {
        public event Update_Ghost_Behaviour Pacman_Moved;
        public event Update_Ghost_Behaviour Pacman_Boosted;
        public event Update_Ghost_Behaviour Pacman_Normal;
        public event Update_Ghost_Behaviour Boosted_Collision;
      
        private static string[] imageFiles = { "Pacman_None.png", "Pacman_UP.png", "Pacman_Down.png", "Pacman_Left.png", "Pacman_Right.png" };

        private int lives;
        private IState current_State;
        private DateTime start_Boost_Time;
        private const int BOOST_DURATION = 10;//10 seconds
        private bool isBoosted = false;

        public int Lives { get => lives; set => lives = value; }
        public IState Current_State { get => current_State; set => current_State = value; }

        public Pacman(int row, int column) : base(row, column)
        {
            this.lives = 3;
            this.current_State = Normal_State.Get_Instance();
        }

        public void ClearEvents()
        {
            this.Pacman_Boosted = null;
            this.Pacman_Normal = null;
            this.Boosted_Collision = null;
            this.Pacman_Moved = null;
        }

        public void InitializeEvents(Ghost obj)
        {
            this.Pacman_Boosted += obj.Set_Scared_Behaviour;
            this.Pacman_Normal  += obj.Reset_Behaviour;
            this.Boosted_Collision += obj.Set_Dead_Behaviour;
            if(obj.Default_Behaviour is Chase_Behaviour)
            {
                this.Pacman_Moved += obj.Update_Path;
            }
        }
        public override void Draw(Graphics graphics)
        {
            //Draw the background
            base.Draw_Background(graphics);

            Rectangle myRectangle = base.GetRectangle();

            //Pick a picture from the array
            int index = (int)base.Current_direction;
            string myFileName = imageFiles[index];

            using (Image myImage = Image.FromFile(Map.Path + myFileName))
            {
                graphics.DrawImage(myImage, myRectangle);
            }
        }
        
        //returns false if entity is instance of Wall or Gost_Room
        public override bool CanPassThrough(Abstract_Entity entity)
        {            
            return !(entity is Wall) && !(entity is Ghost_Room);
        }
        public override bool CanEat(Abstract_Entity entity)
        {
            return (entity is Fruit) || (entity is Dot) || (entity is Booster);
        }
        public override void Eat(Abstract_Entity entity)
        {       
            this.Score += entity.Score;
            Empty_Tile floor = new Empty_Tile(entity.Row, entity.Column);
            Map.abstract_Entities[entity.Row, entity.Column] = floor;
            Map.Count_Eatable_Entities--;
            if(Map.Count_Eatable_Entities == 0)
            {
                MessageBox.Show("YOU WON !");
            }
              
            if(entity is Booster)
            {
                //PACMAN BOOSTED
                this.current_State = Super_State.Get_Instance();
                start_Boost_Time = DateTime.Now;
                this.isBoosted = true;

                if(this.Pacman_Boosted != null)
                {
                    this.Pacman_Boosted.Invoke();
                }
            }
        }
        public bool Is_Boost_TimeOut()
        {
            if (DateTime.Now.Subtract(start_Boost_Time).TotalSeconds < BOOST_DURATION)
            {
                return false;
            }
            return true;
        }
        public void Check_Boost_Duration()
        {
            if(this.current_State is Super_State)
            {
                if (Is_Boost_TimeOut())
                {
                    this.current_State = Normal_State.Get_Instance();
                    this.Pacman_Normal.Invoke();
                    this.isBoosted = false;
                }
            }
        }
        public Ghost Check_Ghost_Collision()
        {
            foreach(Ghost obj in Game_Manager.ghosts_List)
            {
                if(obj.Row == this.Row && obj.Column == this.Column)
                {
                    return obj;
                }
            }
            return null;
        }
        public void Eat_Ghost(Ghost obj)
        {
            if (this.current_State is Super_State)
            {
                int index = Game_Manager.ghosts_List.IndexOf(obj);
                this.Boosted_Collision.GetInvocationList().ElementAt(index).DynamicInvoke();
            }
        }
        public override void Move()
        {
            Point velocity = this.GetVelocity();
            int next_Row = base.Row + velocity.Y;
            int next_Column = base.Column + velocity.X;

            Abstract_Entity next_Entity = Map.abstract_Entities[next_Row, next_Column];
           
            if(this.CanPassThrough(next_Entity))
            {
                this.Row = next_Row;
                this.Column = next_Column;

                //Red Ghost
                if(!this.isBoosted && this.Pacman_Moved != null)
                {
                    this.Pacman_Moved.Invoke();
                }
                
                Ghost obj = Check_Ghost_Collision();
                if(obj != null)
                {
                    this.current_State.Ghost_Collision(obj, this);
                }
                
                if (this.CanEat(next_Entity))
                {
                    this.Eat(next_Entity);
                }
            }
        }
    }
}
