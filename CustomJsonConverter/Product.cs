using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomJsonConverter
{
    public class Product
    {
        public Product() { }
        public int Id { get; set; }
        public string Name{ get; set; }
        public decimal Price { get; set; }
        public int UnitId { get; set; }
        public virtual Unit[] Units { get; set; }
        public virtual int[] Numbers { get; set; }
    }
}
