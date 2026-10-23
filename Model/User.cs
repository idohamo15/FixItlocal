using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseEntity
    {
        public User() { }

        public User(string fullName, string email, string passwordHash, string phone, string userType)
        {
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
            Phone = phone;
            UserType = userType;
            CreatedAt = DateTime.Now;
        }

        public User(int id, string fullName, string email, string passwordHash, string phone, string userType, DateTime createdAt)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
            Phone = phone;
            UserType = userType;
            CreatedAt = createdAt;
        }

        public int UserId
        {
            get => Id;
            set => Id = value;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
