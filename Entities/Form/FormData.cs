using System.Collections.Generic;

namespace Entities.Fields
{
    public class FormData
    {
        public int Id { get; set; }
        public List<FieldValue> Values { get; set; }
        public DataTemplate DataTemplate { get; set; }
    }
}
