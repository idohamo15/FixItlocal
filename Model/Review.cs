using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Review : BaseEntity
    {
        public Review() { }

        public Review(int callID, int providerID, int rating, string comment, DateTime createdAt)
        {
            CallID = callID;
            ProviderID = providerID;
            Rating = rating;
            Comment = comment;
            CreatedAt = createdAt;
        }

        public Review(int reviewID, int callID, int providerID, int rating, string comment, DateTime createdAt)
        {
            Id = reviewID;
            CallID = callID;
            ProviderID = providerID;
            Rating = rating;
            Comment = comment;
            CreatedAt = createdAt;
        }

        public int ReviewID
        {
            get => Id;
            set => Id = value;
        }

        public int CallID { get; set; }
        public int ProviderID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

