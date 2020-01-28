namespace TileCreator
{
  class Cell : ICell
  {
    public Cell(Cell cell)
    {
      Row = cell.Row;
      Column = cell.Column;
    }

    public Cell(uint row, uint column)
    {
      Row = row;
      Column = column;
    }

    public uint Row { get; set; }
    public uint Column { get; set; }
  }
}
