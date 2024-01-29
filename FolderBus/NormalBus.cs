using Buss.Enums;
using Buss.FolderBus;

namespace Buss.FolderBus
{
    public class NormalBus : Bus
    {
        
        public NormalBus(string name) : base(name)
        {
            Seats = new();
        }

        public string Type { get; set; }
        public int BusID { get; set; } = 0;
        public EnumTypeBus type { get; set; }
        public int Capacity { get; set; }
        public int Availability { get; set; } = 0;
        public void SetId()
        {
            BusID += 1;

        }
        public List<SeatsBus> Seats { get; set; }

        public override void AddSeatToBus()
        {
            for (int i = 0; i < 44; i++)
            {
                Seats.Add(new SeatsBus(i));
            }
        }
        public void BookSeat()
        {
            Availability += 1;
        }

        public void CancelSeat()
        {
            Availability -= 1;
        }


        public override void SetType(string type)
        {
            Type = type;
        }
    }
}
