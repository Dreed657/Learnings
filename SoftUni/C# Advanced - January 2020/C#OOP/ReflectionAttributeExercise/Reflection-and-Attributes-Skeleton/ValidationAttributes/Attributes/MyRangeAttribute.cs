namespace ValidationAttributes.Attributes
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            ValidateRange(minValue, maxValue);
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj is Int32)
            {
                int value = (int)obj;
                
                if (value > this.minValue && value < this.maxValue)
                {
                    return true;
                }

                return false;
            }
            else
            {
                throw new ArgumentException("Cannot validate given data type!");
            }
        }
        
        public void ValidateRange(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("Invalid range!");
            }
        }
    }
}
