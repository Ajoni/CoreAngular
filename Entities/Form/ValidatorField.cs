using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Entities.Fields;
using Validator = Entities.Fields.Validator;

namespace Entities.Form
{
    public class ValidatorField
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Field")]
        public string FieldId { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Validator")]
        public string ValidatorId { get; set; }
        public Field Field { get; set; }
        public Validator Validator { get; set; }
    }
}
