using System;
using System.Collections.Generic;
using System.Linq;

namespace TileCreator
{
  internal class TileManager : ITileManager
  {
    public enum Position
    {
      Right,
      Left,
      Up,
      Down
    }
    private byte MoveCount { get; set; }
    public IList<Cell> OccupiedCells;
    public IEnumerable<Position> MovementSequence;
    public TileManager()
    {
      MoveCount = 0;
      OccupiedCells = new List<Cell>();
      MovementSequence = new List<Position>
        {
          Position.Right, Position.Down, Position.Left,Position.Right, Position.Left,Position.Left,Position.Down,
          Position.Right,Position.Up,Position.Down,Position.Left
        };
    }

    public IEnumerable<Position> GetMovementSequence()
    {
      return MovementSequence;
    }

    public void IncrementMoveCount()
    {
      MoveCount++;
    }

    public bool ValidateOccupiedCells(Cell tilePosition)
    {
      return !OccupiedCells.Any(x => x.Column == tilePosition.Column && x.Row == tilePosition.Row);
    }

    public bool ValidateMaxMovementCompleted()
    {
      if (MoveCount > 25)
      {
        Console.WriteLine("\nTraversal is complete\n");
        return true;
      }
      return false;
    }

    public void CreateTile(Cell tilePosition)
    {
      if (ValidateOccupiedCells(tilePosition))
      {
        TileBuilder.tileCount++;
        OccupiedCells.Add(new Cell(tilePosition));
        Console.WriteLine("=> Created tile #" + TileBuilder.tileCount + " at Row " + tilePosition.Row + ", Col " + tilePosition.Column);
      }
    }

    public void ShowCurrent(Cell tilePosition)
    {
      Console.WriteLine("Current tile at Row " + tilePosition.Row + ", Col " + tilePosition.Column);
    }

    public Cell Move(Position item, Cell tilePosition)
    {
      Console.WriteLine("\nAttempting to move " + item.ToString());
      IncrementMoveCount();
      switch (item)
      {
        case Position.Right:
          {
            tilePosition.Column++;
            break;
          }
        case Position.Left:
          {
            tilePosition.Column--;
            break;
          }
        case Position.Up:
          {
            tilePosition.Row--;
            break;
          }
        case Position.Down:
          {
            tilePosition.Row++;
            break;
          }
        default:
          {
            break;
          }
      }
      return tilePosition;
    }
    public void Build(IGrid grid)
    {
      do
      {
        foreach (var item in GetMovementSequence())
        {
          if (ValidateMaxMovementCompleted())
          {
            break;
          }
          grid.CellPosition = Move(item, grid.CellPosition);
          if (grid.ValidateCell())
          {
            CreateTile(grid.CellPosition);
          }
          else
          {
            return;
          }
          ShowCurrent(grid.CellPosition);
        }
      }
      while (MoveCount <= 25);
    }
  }
}
