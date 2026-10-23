using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProviderList : List<Provider>
    {
        public ProviderList()
        {
        }

        public ProviderList(IEnumerable<Provider> list) : base(list)
        {
        }

        public ProviderList(IEnumerable<BaseEntity> list) : base(list.Cast<Provider>().ToList())
        {
        }
    }
}