using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman_2022.Classes.Entities;

namespace Pacman_2022.Classes.States
{
    public interface IState
    {
        bool Can_Eat(Ghost ghost);
        void Ghost_Collision(Ghost ghost, Pacman player);
    }
}
