using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProviders
{
    class FooObject
    { 
 
        public List<Product> CreateData(int _max)
        {
            return Enumerable.Range(1, _max).Select(i=>new Product() { Name = i.ToString() }).ToList();
         }

    }

    class Product
    {
        public string Name { get; set; }
    }
}
