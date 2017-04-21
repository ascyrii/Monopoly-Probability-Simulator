using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolySimulator
{
    public class Program
    {
        private static bool showDice = false;
        public static Random rng;
        private static BoardSpace[] boardLocation = new BoardSpace[40];
        private static Dice[] dicePair = new Dice[2];
        private static int rounds = 0;
        private static int amountPlayers = 4;

        static void Main(string[] args)
        {
            rng = new Random();
            Console.Title = "Monopoly Simulator";
            Console.WriteLine("Monopoly Simulator: Enter turns to simulate.");
            for (int d = 0; d < 2; d++)
            {
                dicePair[d] = new Dice(rng);
            }

            for (int i = 0; i < boardLocation.Length; i++)
            {
                boardLocation[i] = new BoardSpace((BoardSpace.Location)i);
            }

            string val = Console.ReadLine();
            if(!int.TryParse(val, out rounds))
            {
                Console.WriteLine("Invalid Input - Must be numerical value.");
                Main(null);
                return;
            }
            else
            {
                SetPlayers();
            }
        }

        static void SetPlayers()
        {
            Console.WriteLine("Monopoly Simulator: Enter amount of players.");
            string playerz = Console.ReadLine();

            int plyCount;
            if (!int.TryParse(playerz, out plyCount))
            {
                Console.WriteLine("Invalid Input - Must be a numerical value.");
                SetPlayers();
                return;
            }
            else
            {
                plyCount = amountPlayers;
                RunSimulation(rounds);
            }
        }

        static void RunSimulation(int turns)
        {
            SimPlayer[] players = new SimPlayer[amountPlayers];
            for(int p = 0; p < amountPlayers; p++)
            {
                players[p] = new SimPlayer();
            }

            //Run amount of turns
            for (int i = 0; i < turns; i++)
            {
                //Amount of players (static at 4)
                for(int player = 0; player < players.Length; player++)
                {
                    
                    int spacemove = 0;
                    int diceA = dicePair[0].RollDice();
                    int diceB = dicePair[1].RollDice();
                    spacemove = diceA + diceB;
                    MovePlayer(players[player], spacemove);
                    if(showDice) Console.WriteLine("Total: {0} - A {1} - B {2} - Loc: {3}", spacemove, diceA, diceB, (int)players[player].currentSpace.location);
                }
            }

            ReportSimulation();
        }

        static void MovePlayer(SimPlayer p, int amount)
        { 
            if (Convert.ToInt32(p.currentSpace.location) + amount > boardLocation.Length - 1)
            {
                int location = Convert.ToInt32(p.currentSpace.location);
                int difference = (location + amount) - 39;
                amount -= difference;

                BoardSpace plySpc = p.currentSpace;

                p.currentSpace.location = BoardSpace.Location.GO;
                p.currentSpace.location += amount;
                boardLocation[(int)p.currentSpace.location].timesLanded++;
            }
            else
            {
                p.currentSpace.location += amount;
                boardLocation[(int)p.currentSpace.location].timesLanded++;
            }
        }

        static void ReportSimulation()
        {
            StringBuilder outp = new StringBuilder();
            //string date = String.Format(@"C:/{0}.txt", DateTime.Now.ToFileTimeUtc());
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //Console.WriteLine(path);
            string date = String.Format(@"{0}/Monopoly_Simulator.txt", path);

            System.IO.StreamWriter writer = new System.IO.StreamWriter(date);
            writer.AutoFlush = true;

            string response;

            int totalMoves = rounds * amountPlayers;
            for (int i = 0; i < boardLocation.Length; i++)
            {
                double percentage = (Convert.ToDouble(boardLocation[i].timesLanded) / Convert.ToDouble(totalMoves)) * 100;
                //Console.WriteLine("{0}", percentage);
                response = String.Format("{0}: {1} - {2,2:N2}%", boardLocation[i].ToString(), boardLocation[i].timesLanded, percentage);
                outp.AppendLine(response);
                writer.WriteLine(response);
                Console.WriteLine(response);          
            }

            response = String.Format("\nTotal Moves: {0}", totalMoves);

            outp.AppendLine(response);
            writer.WriteLine(response);

            Console.WriteLine(response);

            for (int d = 0; d < 6; d++)
            {
                int maths = dicePair[0].timesRolled[d] + dicePair[1].timesRolled[d];
                response = String.Format("\nTimes Dice Rolled {0}: {1}", d + 1, maths);

                outp.AppendLine(response);
                writer.WriteLine(response);

                Console.WriteLine(response);
                
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
