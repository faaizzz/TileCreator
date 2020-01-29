namespace TileCreator
{
  internal interface IGrid
  {
    Cell CellPosition { get; set; }
    Cell ReadStartPosition();
    void ReadWidthAndHeight();
    bool ValidateCell();
  }
}