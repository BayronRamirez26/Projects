using System;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects
{
    public class Angle
    {
        public double Value { get; }

        public static Angle Invalid => new(double.NaN);

        private Angle(double value)
        {
            Value = value;
        }

        public static bool TryCreate(double? value, out Angle angleOutput)
        {
            angleOutput = Invalid;

            if (!value.HasValue)
            {
                return false;
            }
            if (double.IsNaN(value.Value))
            {
                return false;
            }
            if (value.Value < 0 || value.Value > 360)
            {
                return false;
            }

            angleOutput = new Angle(value.Value);

            return true;
        }

        public static Angle Create(double? angleValue)
        {
            var validation = TryCreate(angleValue, out var angleOutput);
            if (!validation)
            {
                throw new ArgumentException("Invalid angle.");
            }
            return angleOutput;
        }
    }
}
