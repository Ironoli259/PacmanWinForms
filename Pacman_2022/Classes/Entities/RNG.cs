using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_2022.Classes.Entities
{
    public class RNG : Random
    {
        private static RNG instance = new RNG();
        private RNG() : base() { }

        public static RNG Get_Instance()
        {
            return instance;
        }
    }
}
