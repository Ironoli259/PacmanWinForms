using Pacman_2022.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Pacman_2022.Classes.Pathfinding;
using Pacman_2022.Classes.Dijkstra;

namespace Pacman_2022.Classes.Behaviours
{
    //State of Ghosts
    public interface IBehaviour
    {
        List<Node> Find_Path(Ghost ghost);
    }
}
