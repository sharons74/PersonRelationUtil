using System;
using System.Collections.Generic;
using System.Text;

namespace PersonRelations.Entities
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }

        public override string ToString() => $"{City}-{Street}";
    }
}
