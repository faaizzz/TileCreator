using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileCreator
{
    class Program
    {
        enum Position
        {
            Right,
            Left,
            Up,
            Down
        }
        static void Main(string[] args)
        {
            uint gridwidth, gridHeight, sRow, sColumn;

            try
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("Application Started - Tile Creator");
                Console.WriteLine("==========================================");
                Console.WriteLine("Enter the size of the grid dimensions => ");
                Console.Write("Width : ");
                gridwidth = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Height : ");
                gridHeight = Convert.ToUInt32(Console.ReadLine());
                Console.WriteLine("Width is "+ gridwidth + " and gridHeight is " + gridHeight);

                Console.WriteLine("Enter the size of the starting location => ");
                Console.Write("Row : ");
                sRow = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Column : ");
                sColumn = Convert.ToUInt32(Console.ReadLine());
                Console.WriteLine("sRow is " + sRow + " and sColumn is " + sColumn);

                IEnumerable<int> movementSequence = new List<int>();



            }

            catch (Exception exception)
            {
                if (exception is FormatException || exception is OverflowException)
                {
                    Console.WriteLine("You have entered an invalid positive integer");
                    return;
                }
                else
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Feel free to contact abc@def.com for support.");
                }
                throw;
            }
            finally
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("Execution Completed. Press Any Key To Exit");
                Console.WriteLine("==========================================");
                Console.ReadKey();
            }
        }

    }
}
