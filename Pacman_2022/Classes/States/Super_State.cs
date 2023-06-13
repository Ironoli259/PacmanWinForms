using Pacman_2022.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_2022.Classes.States
{
    public class Super_State : IState
    {
        #region Singleton Design Pattern

        private static Super_State instance = new Super_State();

        private Super_State() { }

        public static Super_State Get_Instance()
        {
            return instance;
        }

        #endregion

        private static int nbr_eaten_ghosts = 0;

        public bool Can_Eat(Ghost ghost)
        {
            return true;
        }

        public void Ghost_Collision(Ghost ghost, Pacman player)
        {
            //ghost 1 = 200 , ghost 2 = 400 , ghost 3 = 600, ghost 4 = 800
            nbr_eaten_ghosts++;
            player.Score += (nbr_eaten_ghosts * ghost.Score);
            player.Eat_Ghost(ghost);
            
        }
    }
}
