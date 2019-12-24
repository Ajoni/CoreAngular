using System.Collections.Generic;
using Entities.Form;

namespace Entities.Fields
{
    public enum FieldType
    {
        Text,Int,Float
    }

    public class Field
    {
        public string Id { get; set; }
        public FieldType FieldType{ get; set; }
        public List<ValidatorField> Validators { get; set; }
        public string Name { get; set; }
    }
}
