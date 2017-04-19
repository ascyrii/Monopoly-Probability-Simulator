using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolySimulator
{
    public class SimPlayer
    {
        public BoardSpace currentSpace;

        public SimPlayer()
        {
            currentSpace.location = BoardSpace.Location.GO;
        }
    }
}
