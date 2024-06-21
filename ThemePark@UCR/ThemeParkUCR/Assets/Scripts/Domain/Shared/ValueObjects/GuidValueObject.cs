using System;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Shared.ValueObjects
{
    public class GuidValueObject
    {
        public Guid Value { get; }

        public static GuidValueObject Invalid => new(Guid.Empty);

        private GuidValueObject(Guid value)
        {
            Value = value;
        }

        private static bool TryCreate(Guid? value, out GuidValueObject guidValueObject)
        {
            if (value is null)
            {
                guidValueObject = Invalid;
                return false;
            }

            guidValueObject = new GuidValueObject(value.Value);

            return true;
        }

        public static GuidValueObject Create(Guid? guidValue)
        {
            var validation = TryCreate(guidValue, out var guidValueObject);
            if (!validation)
            {
                throw new ArgumentException("Guid value is invalid");
            }
            return guidValueObject;
        }
    }
}
