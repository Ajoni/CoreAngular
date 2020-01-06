using Entities.Fields;
using System.Collections.Generic;

namespace Entities.User
{
    public class FormTemplateUser
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<FormTemplate> FormTemplates { get; set; }
    }
}