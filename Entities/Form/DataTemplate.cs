using System.Collections.Generic;

namespace Entities.Fields
{
    public class DataTemplate
    {
        public string Id { get; set; }
        public List<Field> Fields { get; set; }
        public DataTemplate BasedOn { get; set; }
    }
}
