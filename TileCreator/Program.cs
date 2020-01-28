using System;
using System.Collections.Generic;
using System.Linq;

namespace TileCreator
{
  partial class Program
  {
    static byte moveCount = 0, tileCount = 1;
    static uint gridwidth, gridHeight;
    static IList<Cell> occupiedCells;
    static void Main(string[] args)
    {
      uint sRow, sColumn;
      Cell tilePosition;
      occupiedCells = new List<Cell>();
      IEnumerable<Position> movementSequence = new List<Position>
        {
          Position.Right, Position.Down, Position.Left,Position.Right, Position.Left,Position.Left,Position.Down,
          Position.Right,Position.Up,Position.Down,Position.Left
        };

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
        //Console.WriteLine("Width is " + gridwidth + " and gridHeight is " + gridHeight);

        Console.WriteLine("Enter the size of the starting location => ");
        Console.Write("Row : ");
        sRow = Convert.ToUInt32(Console.ReadLine());
        Console.Write("Column : ");
        sColumn = Convert.ToUInt32(Console.ReadLine());
        //Console.WriteLine("sRow is " + sRow + " and sColumn is " + sColumn);
        tilePosition = new Cell(sRow, sColumn);

        occupiedCells.Add(new Cell(tilePosition.Row, tilePosition.Column));
        Console.WriteLine("=> Created tile #" + tileCount + " at Row " + tilePosition.Row + ", Col " + tilePosition.Column);
        moveCount++;
        Console.WriteLine("Current tile at Row " + tilePosition.Row + ", Col " + tilePosition.Column);

        do
        {
          foreach(var item in movementSequence)
          {
            if(tileCount > 25)
            {
              Console.WriteLine("\nTraversal is complete");
              break;
            }
            Console.WriteLine("\nAttempting to move " + item.ToString());

            TileManager(item, tilePosition, occupiedCells);
            Console.WriteLine("Current tile at Row " + tilePosition.Row + ", Col " + tilePosition.Column);
          }
        }
        while (moveCount <= 25);


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

    public static bool ValidateTraversal(Cell tilePosition, uint gridwidth, uint gridHeight)
    {
      bool isValid = (tilePosition.Column > 0 && tilePosition.Row > 0 && tilePosition.Column < gridwidth &&  tilePosition.Row < gridHeight);
      if(!isValid)
      {
        Console.WriteLine("\nUnable to traverse the tile any further");
      }
      return isValid;
    }

    public static bool ValidateOccupiedCells(Cell tilePosition)
    {
      return occupiedCells.Any(x => x.Column == tilePosition.Column && x.Row == tilePosition.Row);
    }

    public static void TileManager(Position item, Cell tilePosition, IList<Cell> occupiedCells)
    {
      switch (item)
      {
        case Position.Right:
          {
            moveCount++;
            tilePosition.Column++;

            if (ValidateTraversal(tilePosition, gridwidth, gridHeight))
            {
              tileCount++;
              occupiedCells.Add(new Cell(tilePosition.Row, tilePosition.Column));
              Console.WriteLine("=> Created tile #" + tileCount + " at Row " + tilePosition.Row + ", Col " + tilePosition.Column);
            }
            else
            {
              return;
            }
            break;
          }
        case Position.Left:
          {
            moveCount++;
            tilePosition.Column--;
            if (ValidateTraversal( tilePosition, gridwidth, gridHeight))
            {
              tileCount++;
              occupiedCells.Add(new Cell(tilePosition.Row, tilePosition.Column));
              Console.WriteLine("=> Created tile #" + tileCount + " at Row " + tilePosition.Row + ", Col " + tilePosition.Column);
            }
            else
            {
              return;
            }
            break;
          }
        case Position.Up:
          {
            moveCount++;
            tilePosition.Row--;
            if (ValidateTraversal(tilePosition, gridwidth, gridHeight))
            {
              tileCount++;
              occupiedCells.Add(new Cell(tilePosition.Row, tilePosition.Column));
              Console.WriteLine("=> Created tile #" + tileCount + " at Row " + tilePosition.Row + ", Col " + tilePosition.Column);
            }
            else
            {
              return;
            }
            break;
          }
        case Position.Down:
          {
            moveCount++;
            tilePosition.Row++;
            if (ValidateTraversal( tilePosition, gridwidth, gridHeight))
            {
              tileCount++;
              occupiedCells.Add(new Cell(tilePosition.Row, tilePosition.Column));
              Console.WriteLine("=> Created tile #" + tileCount + " at Row " + tilePosition.Row + ", Col " + tilePosition.Column);
            }
            else
            {
              return;
            }
            break;
          }
        default:
          {
            break;
          }
      }
      return;
    }

  }
}
