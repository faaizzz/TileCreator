using System;

namespace TileCreator
{
  public class TileBuilder
  {
    public static byte tileCount = 0;
    static void Main(string[] args)
    {
      try
      {
        IGrid grid = new Grid();
        grid.ReadWidthAndHeight();
        grid.ReadStartPosition();

        ITileManager tileManager = new TileManager();
        tileManager.CreateTile(new Cell(grid.CellPosition));
        tileManager.IncrementMoveCount();
        tileManager.ShowCurrent(grid.CellPosition);
        tileManager.Build(grid);

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
