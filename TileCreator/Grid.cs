using System;

namespace TileCreator
{
  class Grid
  {
    public uint Width { get; set; }
    public uint Height { get; set; }
    public Cell CellPosition { get; set; }
    public Grid()
    {
    }

    public Grid(uint width, uint height)
    {
      Width = width;
      Height = height;
    }

    public bool ValidateCell()
    {
      bool isValid = (CellPosition.Column > 0 && CellPosition.Row > 0 && CellPosition.Column < Width && CellPosition.Row < Height);
      if (!isValid)
      {
        Console.WriteLine("\nUnable to traverse the tile any further\n");
      }
      return isValid;
    }

    public void ReadWidthAndHeight()
    {
      ReadWidth();
      ReadHeight();
    }

    private uint ReadHeight()
    {
      string str;
      uint height;
      Console.Write("Enter the grid height (Positive integor greator than zero) : ");
      str = Console.ReadLine();
      while (!uint.TryParse(str, out height))
      {
        Console.WriteLine("Invalid Entry!");
        return ReadHeight();
      }
      if (height == 0)
      {
        Console.WriteLine("Invalid Entry!");
        return ReadHeight();
      }
      Height = height;
      return Height;
    }

    private uint ReadWidth()
    {
      string str;
      uint width;
      Console.Write("Enter the grid width  (Positive integor greator than zero) : ");
      str = Console.ReadLine();
      while (!uint.TryParse(str, out width))
      {
        Console.WriteLine("Invalid Entry!");
        return ReadWidth();
      }
      if (width == 0)
      {
        Console.WriteLine("Invalid Entry!");
        return ReadWidth();
      }
      Width = width;
      return Width;
    }

    public Cell ReadStartPosition()
    {
      CellPosition = new Cell(ReadStartRow(), ReadStartColumn());
      return CellPosition;
    }

    private uint ReadStartRow()
    {
      string str;
      uint row;
      Console.Write("Enter the starting Row (Positive integor) : ");
      str = Console.ReadLine();
      while (!uint.TryParse(str, out row))
      {
        Console.WriteLine("Invalid Entry!");
        return ReadStartRow();
      }
      if (row >= Height)
      {
        Console.WriteLine("Invalid Entry! Starting row must not be greater than or equal to Grid Height");
        return ReadStartRow();
      }
      return row;
    }

    private uint ReadStartColumn()
    {
      string str;
      uint column;
      Console.Write("Enter the starting Column (Positive integor) : ");
      str = Console.ReadLine();
      while (!uint.TryParse(str, out column))
      {
        Console.WriteLine("Invalid Entry!");
        return ReadStartColumn();
      }
      if (column >= Width)
      {
        Console.WriteLine("Invalid Entry! Starting row must not be greater than or equal to Grid Width");
        return ReadStartColumn();
      }
      return column;
    }


  }
}
