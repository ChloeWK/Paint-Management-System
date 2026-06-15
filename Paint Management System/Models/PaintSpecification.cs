using System;
using System.Drawing;

namespace Paint_Management_System.Models;

public class PaintSpecification
{
    public string Color { get; private set; }
    public int SizeLiter { get; private set; }
    public PaintSpecification(string color, int sizeLiter)
    {
        Color = color;
        SizeLiter = sizeLiter;
    }

    public void DisplaySpecification()
    {
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Size: {SizeLiter}");
    }
}
