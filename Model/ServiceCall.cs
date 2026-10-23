using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ServiceCall : BaseEntity
    {
        public ServiceCall() { }

        public ServiceCall(int clientID, int providerID, int categoryID, string description, string imagePath, DateTime scheduledDate, string status, double priceOffer)
        {
            ClientID = clientID;
            ProviderID = providerID;
            CategoryID = categoryID;
            Description = description;
            ImagePath = imagePath;
            ScheduledDate = scheduledDate;
            Status = status;
            PriceOffer = priceOffer;
        }

        public ServiceCall(int id, int clientID, int providerID, int categoryID, string description, string imagePath, DateTime scheduledDate, string status, double priceOffer)
        {
            Id = id;
            ClientID = clientID;
            ProviderID = providerID;
            CategoryID = categoryID;
            Description = description;
            ImagePath = imagePath;
            ScheduledDate = scheduledDate;
            Status = status;
            PriceOffer = priceOffer;
        }

        public int ServiceCallID
        {
            get => Id;
            set => Id = value;
        }

        public int ClientID { get; set; }
        public int ProviderID { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Status { get; set; }
        public double PriceOffer { get; set; }
    }
}
