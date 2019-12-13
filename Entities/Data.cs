using System;
using System.Collections.Generic;
using Entities.Fields;

namespace Entities
{
    public class Data
    {
        public int Id { get; set; }
        public List<FieldValue> Values { get; set; }
    }
}
