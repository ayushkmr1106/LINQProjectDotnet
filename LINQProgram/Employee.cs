using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProgram
{
    internal class Employee : IEquatable<Employee>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public bool Equals(Employee other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Id.Equals(other.Id) && FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName) && Email.Equals(other.Email);
        }
        public override int GetHashCode()
        {
            int idHashCode = Id.GetHashCode();
            int firstNameHashCode = FirstName == null ? 0 : FirstName.GetHashCode();
            int lastNameHashCode = LastName == null ? 0 : LastName.GetHashCode();
            int emailHashCode = Email == null ? 0 : Email.GetHashCode();

            return idHashCode ^ firstNameHashCode ^ lastNameHashCode ^ emailHashCode;
        }
    }
}
