namespace TileCreator
{
  internal interface IGrid
  {
    Cell CellPosition { get; set; }
    uint Height { get; set; }
    uint Width { get; set; }
    Cell ReadStartPosition();
    void ReadWidthAndHeight();
    bool ValidateCell();
  }
}