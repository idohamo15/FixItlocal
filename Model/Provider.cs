using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Provider : User
    {
        public Provider() : base() { }

        public Provider(int userId, string bio, double hourlyRate, string serviceArea, string profileImagePath, bool isVerified)
        {
            Id = userId;
            Bio = bio;
            HourlyRate = hourlyRate;
            ServiceArea = serviceArea;
            ProfileImagePath = profileImagePath;
            IsVerified = isVerified;
        }

        public Provider(int userId, string fullName, string email, string passwordHash, string phone, string userType, DateTime createdAt,
                        string bio, double hourlyRate, string serviceArea, string profileImagePath, bool isVerified)
            : base(userId, fullName, email, passwordHash, phone, userType, createdAt)
        {
            Bio = bio;
            HourlyRate = hourlyRate;
            ServiceArea = serviceArea;
            ProfileImagePath = profileImagePath;
            IsVerified = isVerified;
        }

        public string Bio { get; set; }
        public double HourlyRate { get; set; }
        public string ServiceArea { get; set; }
        public string ProfileImagePath { get; set; }
        public bool IsVerified { get; set; }
    }
}