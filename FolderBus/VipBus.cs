using Buss.Enums;

namespace Buss.FolderBus
{
    public class VipBus : Bus
    {
        public VipBus(string name) : base(name)
        {
            Seats = new();
        }
        public int BusID { get; set; } = 0;
        public void SetId()
        {
            BusID += 1;

        }
        public List<SeatsBus> Seats { get; set; }
        public EnumTypeBus type { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Availability { get; set; } = 0;

        public override void AddSeatToBus()
        {
            for (int i = 0; i < 30; i++)
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
