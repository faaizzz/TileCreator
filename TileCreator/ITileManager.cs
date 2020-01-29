using System.Collections.Generic;

namespace TileCreator
{
  internal interface ITileManager
  {
    void CreateTile(Cell tilePosition);
    Cell Move(TileManager.Position item, Cell tilePosition);
    void ShowCurrent(Cell tilePosition);
    bool ValidateOccupiedCells(Cell tilePosition);
    IEnumerable<TileManager.Position> GetMovementSequence();
    bool ValidateMaxMovementCompleted();
    void IncrementMoveCount();
    void Build(IGrid grid);
  }
}