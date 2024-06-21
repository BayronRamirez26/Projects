using System;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects
{
    public class Coordinate
    {
        public double Value { get; }

        public static Coordinate Invalid => new Coordinate(double.NaN);

        private Coordinate(double value)
        {
            Value = value;
        }

        public static bool TryCreate(double? value, out Coordinate coordinateOutput)
        {
            coordinateOutput = Invalid;

            if (!value.HasValue)
            {
                return false;
            }
            if (double.IsNaN(value.Value))
            {
                return false;
            }
            if (double.IsInfinity(value.Value))
            {
                return false;
            }
            if (value.Value < 0)
            {
                return false;
            }

            coordinateOutput = new Coordinate(value.Value);

            return true;
        }

        public static Coordinate Create(double? value)
        {
            var validation = TryCreate(value, out var coordinateOutput);
            if (!validation)
            {
                throw new ArgumentException("Invalid coordinate.");
            }
            return coordinateOutput;
        }
    }
}
