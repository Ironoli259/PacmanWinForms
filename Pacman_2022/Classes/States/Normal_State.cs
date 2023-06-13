using Pacman_2022.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_2022.Classes.States
{
    public class Normal_State : IState
    {
        #region Singleton Design Pattern 
        // Step 1 : Create a private instance
        private static Normal_State instance = new Normal_State();

        //Step 2: Make the constructor private
        private Normal_State() { }

        //Step 3: Define method to get instance
        public static Normal_State Get_Instance()
        {
            return instance;
        }
        #endregion

        public bool Can_Eat(Ghost ghost)
        {
            return false;
        }

        public void Ghost_Collision(Ghost ghost, Pacman player)
        {
            ghost.Eat(player);
        }
    }
}
