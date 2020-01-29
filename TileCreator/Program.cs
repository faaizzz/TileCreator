﻿using System;

namespace TileCreator
{
  public class Program
  {
    static byte tileCount = 0;
    static void Main(string[] args)
    {
      try
      {
        IGrid grid = new Grid();
        grid.ReadWidthAndHeight();
        grid.ReadStartPosition();

        ITileManager tileManager = new TileManager();
        tileCount = tileManager.CreateTile(new Cell(grid.CellPosition), tileCount);
        tileManager.MoveCount++;
        tileManager.ShowCurrent(grid.CellPosition);

        do
        {
          foreach (var item in tileManager.GetMovementSequence())
          {
            if (tileManager.ValidateMaxMovementCompleted())
            {
              break;
            }
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
