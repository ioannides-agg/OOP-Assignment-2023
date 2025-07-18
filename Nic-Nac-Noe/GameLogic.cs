using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Nic_Nac_Noe
{
    internal class GameLogic
    {
        public static int round = 0;
        public Block[,] nxn;
        int[] nRows;
        int[] nCols;
        int positiveDiagonal = 0;
        int negativeDiagonal = 0;
        readonly int n;
        public GameLogic(int num)
        {
            this.n = num;
            nxn = new Block[n, n];
            nRows = new int[n];
            nCols = new int[n];
        }

        public void calculate()
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    if (nxn[i, j].getButton().Text == "X")
                    {
                        nRows[j]++;
                        nCols[i]++;
                    } else if (nxn[i, j].getButton().Text == "O")
                    {
                        nRows[j]--;
                        nCols[i]--;
                    }
                }

                if (nxn[i, n - i - 1].getButton().Text == "X")
                {
                    negativeDiagonal++;
                }
                else if (nxn[i, n - i - 1].getButton().Text == "O")
                {
                    negativeDiagonal--;
                }

                if (nxn[i, i].getButton().Text == "X")
                {
                    positiveDiagonal++;
                }
                else if (nxn[i, i].getButton().Text == "O")
                {
                    positiveDiagonal--;
                }
            }
        }

        public void reset()
        {
            for (int i = 0; i < this.n; i++)
            {
                nRows[i] = 0;
                nCols[i] = 0;
            }
            negativeDiagonal = 0;
            positiveDiagonal = 0;
        }


        public void test()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("row " + i + ": " + nRows[i]);
                Console.WriteLine("col " + i + ": " + nCols[i]);
            }

            Console.WriteLine(positiveDiagonal.ToString() + " " + negativeDiagonal.ToString());
        }
    }
}
