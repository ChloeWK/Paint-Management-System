using System;
using System.Drawing;

namespace Paint_Management_System.Models;

public class PaintSpecification
{
    public string Color { get; private set; }
    public int SizeLiters { get; private set; }
    public PaintSpecification(string Color, int SizeLiters)
    {

    }

    public void DisplaySpecification()
    {
        Console.WriteLine($"The Color is: {Color}; the size is: {SizeLiters}");
    }
}
