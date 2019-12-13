using System.Collections.Generic;

namespace Entities.Fields
{
    public enum FieldType
    {
        Text,Int,Float
    }

    public class Field
    {
        public int Id { get; set; }
        public FieldType FieldType{ get; set; }
        public List<Validator> Validators { get; set; }
        public string Name { get; set; }
    }
}
