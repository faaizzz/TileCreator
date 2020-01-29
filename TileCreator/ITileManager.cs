using System.Collections.Generic;

namespace TileCreator
{
  internal interface ITileManager
  {
    byte MoveCount { get; set; }
    byte CreateTile(Cell tilePosition, byte tileCount);
    Cell Move(TileManager.Position item, Cell tilePosition);
    void ShowCurrent(Cell tilePosition);
    bool ValidateOccupiedCells(Cell tilePosition);
    IEnumerable<TileManager.Position> GetMovementSequence();
    bool ValidateMaxMovementCompleted();
  }
}