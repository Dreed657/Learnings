using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class CustomTuple<T1, T2, T3>
    {
        public T1 Key { get; set; }

        public T2 Value { get; set; }

        public T3 SecondValue { get; set; }

        public CustomTuple(T1 key, T2 value, T3 secondValue)
        {
            this.Key = key;
            this.Value = value;
            this.SecondValue = secondValue;
        }

        public override string ToString()
        {
            return $"{Key} -> {Value} -> {SecondValue}";
        }
    }
}
