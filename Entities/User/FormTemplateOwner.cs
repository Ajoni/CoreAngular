using System.Collections.Generic;
using Entities.Fields;

namespace Entities.User
{
    public class FormTemplateOwner
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<FormTemplate> FormTemplates { get; set; }
    }
}
