using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Infrastructure.Identity
{
    public class ApplicationUser<TKey> : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName,
            string firstName,
            string lastName) : base(userName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ApplicationUser(
            string userName,
            string email) : base(userName)
        {
            Email = email;
        }

        public ApplicationUser(string userName,
            string firstName,
            string lastName,
            string address,
            DateTime? birthDate) : base(userName)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            BirthDate = birthDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; }
        public DateTime? BirthDate { get; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class ApplicationUser : ApplicationUser<Guid>
    {
        public ApplicationUser(string userName,
            string firstName,
            string lastName)
            : base(userName,
                  firstName,
                  lastName)
        {
        }

        public ApplicationUser(string userName,
            string firstName,
            string lastName,
            string address,
            DateTime? birthDate)
            : base(userName,
                  firstName,
                  lastName,
                  address,
                  birthDate)
        {
        }

        public ApplicationUser() : base()
        {
        }
    }
}