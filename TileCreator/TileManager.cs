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
    public byte MoveCount { get; set; }
    //public byte TileCount { get; set; }
    public IList<Cell> occupiedCells;
    public IEnumerable<Position> movementSequence;
    public TileManager()
    {
      MoveCount = 0;
      //TileCount = 0;
      occupiedCells = new List<Cell>();
      movementSequence = new List<Position>
        {
          Position.Right, Position.Down, Position.Left,Position.Right, Position.Left,Position.Left,Position.Down,
          Position.Right,Position.Up,Position.Down,Position.Left
        };
    }

    public IEnumerable<Position> GetMovementSequence()
    {
      return movementSequence;
    }

    public bool ValidateOccupiedCells(Cell tilePosition)
    {
      return !occupiedCells.Any(x => x.Column == tilePosition.Column && x.Row == tilePosition.Row);
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

    public byte CreateTile(Cell tilePosition, byte tileCount)
    {
      if (ValidateOccupiedCells(tilePosition))
      {
        tileCount++;
        occupiedCells.Add(new Cell(tilePosition));
        Console.WriteLine("=> Created tile #" + tileCount + " at Row " + tilePosition.Row + ", Col " + tilePosition.Column);
      }
      return tileCount;
    }

    public void ShowCurrent(Cell tilePosition)
    {
      Console.WriteLine("Current tile at Row " + tilePosition.Row + ", Col " + tilePosition.Column);
    }

    public Cell Move(Position item, Cell tilePosition)
    {
      Console.WriteLine("\nAttempting to move " + item.ToString());
      MoveCount++;
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

  }
}
