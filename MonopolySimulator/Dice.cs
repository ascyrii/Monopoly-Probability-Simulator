using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolySimulator
{
    public class Dice
    {
        public int[] timesRolled = new int[6];
        public Random modnar;

        public Dice(Random seed)
        {
            for (int i = 0; i < timesRolled.Length; i++)
            {
                modnar = seed;
                timesRolled[i] = 0;
            }
        }

        public int RollDice()
        {
            int ret = modnar.Next(1, 7);
            timesRolled[ret-1]++;
            return ret;
        }
    }
}
