using System.Collections.Generic;

namespace Entities.Fields
{
    public class FormTemplate
    {
        public string Id { get; set; }
        public List<Field> Fields { get; set; }
        public FormTemplate BasedOn { get; set; }
    }
}
