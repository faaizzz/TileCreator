using System;

namespace TileCreator
{
  public class Program
  {
    static byte tileCount = 0;
    static void Main(string[] args)
    {
      try
      {
        Grid grid = new Grid();
        grid.ReadWidthAndHeight();
        grid.ReadStartPosition();

        TileManager tileManager = new TileManager();
        tileCount = tileManager.CreateTile(new Cell(grid.CellPosition),tileCount);
        tileManager.MoveCount++;
        tileManager.ShowCurrent(grid.CellPosition);

        do
        {
          foreach (var item in tileManager.movementSequence)
          {
            if (tileManager.MoveCount > 25)
            {
              Console.WriteLine("\nTraversal is complete\n");
              break;
            }
            Console.WriteLine("\nAttempting to move " + item.ToString());

            grid.CellPosition = tileManager.Move(item, grid.CellPosition);
            if (grid.ValidateCell())
            {
              tileCount = tileManager.CreateTile(grid.CellPosition, tileCount);
            }
            else
            {
              return;
            }
            tileManager.ShowCurrent(grid.CellPosition);
          }
        }
        while (tileManager.MoveCount <= 25);
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception.Message);
        Console.WriteLine("Feel free to contact abc@def.com for support.");
      }
      finally
      {
        if (tileCount > 0)
        {
          Console.WriteLine("Active Count = " + tileCount);
        }
        Console.ReadKey();
      }
    }
  }
}
