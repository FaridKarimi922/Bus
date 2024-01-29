using Buss.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Buss.FolderBus
{
    public abstract class Bus
    {

        
        protected Bus( string name)
        {
            Name = name;



        }

        public string Name { get; set; }
        public int BusID { get; set; } = 0;
        public EnumTypeBus Type { get; set; }
        public int Capacity { get; set; }
        public int Availability { get; set; } = 0;
        public void SetId()
        {
            BusID += 1;

        }
        public int Price { get; set; }

        public abstract void AddSeatToBus();

        public abstract void SetType(string type);

        public void BookSeat()
        {
            Availability += 1;
        }

        public void CancelSeat()
        {
            Availability -= 1;
        }



    }
}
