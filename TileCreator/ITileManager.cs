namespace TileCreator
{
  interface ITileManager
  {
    byte MoveCount { get; set; }

    byte CreateTile(Cell tilePosition, byte tileCount);
    Cell Move(TileManager.Position item, Cell tilePosition);
    void ShowCurrent(Cell tilePosition);
    bool ValidateOccupiedCells(Cell tilePosition);
  }
}