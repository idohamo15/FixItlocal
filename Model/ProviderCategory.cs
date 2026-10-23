using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProviderCategory : BaseEntity
    {
        public ProviderCategory() { }

        public ProviderCategory(int providerID, int categoryID)
        {
            ProviderID = providerID;
            CategoryID = categoryID;
        }

        public ProviderCategory(int id, int providerID, int categoryID)
        {
            Id = id; 
            ProviderID = providerID;
            CategoryID = categoryID;
        }

        public int ID
        {
            get => Id;
            set => Id = value;
        }

        public int ProviderID { get; set; }
        public int CategoryID { get; set; }
    }
}
