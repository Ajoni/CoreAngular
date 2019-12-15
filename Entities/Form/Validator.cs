using System.Collections.Generic;
using Entities.Form;

namespace Entities.Fields
{
    public enum ValidationType
    {
        None, Regex, Range
    }

    public class Validator
    {
        public int Id { get; set; }
        public ValidationType Type { get; set; }
        public List<ValidatorField> ValidatedFields { get; set; }
    }
    public class RegexValidator : Validator
    {
        public string Regex { get; set; }
    }
    public class RangeValidator : Validator
    {
        public int Start{ get; set; }
        public int End{ get; set; }
    }
    public class FloatRangeValidator : Validator
    {
        public float Start { get; set; }
        public float End { get; set; }
    }
    public class PreciseFloatRangeValidator : Validator
    {
        public decimal Start { get; set; }
        public decimal End { get; set; }
    }
}
