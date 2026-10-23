using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category : BaseEntity
    {
        public Category() { }

        public Category(string categoryName, string description)
        {
            CategoryName = categoryName;
            Description = description;
        }

        public Category(int categoryID, string categoryName, string description)
        {
            Id = categoryID;
            CategoryName = categoryName;
            Description = description;
        }

        public int CategoryID
        {
            get => Id;
            set => Id = value;
        }

        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
