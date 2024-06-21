using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR.ECCI.PI.ThemePark_UCR.Domain.Shared.ValueObjects;

namespace UCR.ECCI.PI.ThemePark_UCR.Domain.LearningComponents.ValueObjects;

public class Dimension
{
    public Size Width { get; }
    public Size Height { get; }

    private Dimension(Size width, Size height)
    {
        Width = width;
        Height = height;
    }

    public static Dimension Create(double widthValue, double heightValue)
    {
        Size width;
        Size height;
        try
        {
            width = Size.Create(widthValue);
            height = Size.Create(heightValue);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException("Invalid width or height value.", ex);
        }

        return new Dimension(width, height);
    }
}