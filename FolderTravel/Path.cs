using Buss.FolderBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buss.FolderTravel
{
    public abstract class Path
    {
        public Path(string origin,string destination)
        {
            
            Origin =origin;
            Destination=destination;
            buses = new();
        }
       

        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Price { get; set; }
        public int PathId { get; set; } = 0;
        public void SetId()
        {
            PathId += 1;

        }
        public List<Bus> buses { get; set; }
        
        public virtual void SetPrice(int price)
        {
            Price = price;
        }
        
    }
}
