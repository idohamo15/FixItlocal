using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProviderCity : BaseEntity
    {
        public int ProviderID { get; set; }
        public int CityID { get; set; }

        public ProviderCity(int providerID, int cityID)
        {
            ProviderID = providerID;
            CityID = cityID;
        }

        public ProviderCity(int id, int providerID, int cityID)
        {
            Id = id;
            ProviderID = providerID;
            CityID = cityID;
        }

        public int ID
        {
            get => Id;
            set => Id = value;
        }

        public ProviderCity()
        {
        }
    }
}
