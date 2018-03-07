using System;
using System.Collections.Generic;
using System.Text;

namespace PersonRelations.Entities
{
    public class Person
    {
        public Name FullName { get; set; }
        public Address Address { get; set; }

        /// <summary>
        /// Check if two persnos gas same full name and/or same address
        /// </summary>
        /// <param name="personB"></param>
        /// <returns></returns>
        public bool DirectlyRelated(Person personB)
        {
            return (this.FullName.FirstName == personB.FullName.FirstName && this.FullName.LastName == personB.FullName.LastName)
                || (this.Address.City == personB.Address.City && this.Address.Street == personB.Address.Street);
        }

        public override string ToString() => $"{FullName} from {Address}";
    }
}
