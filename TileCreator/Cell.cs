namespace TileCreator
{
  class Cell
  {
    public Cell(uint row, uint column)
    {
      Row = row;
      Column = column;
    }

    public uint Row { get; set; }
    public uint Column { get; set; }
  }
}
