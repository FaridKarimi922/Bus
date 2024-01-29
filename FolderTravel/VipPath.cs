namespace Buss.FolderTravel
{
    public class VipPath : Path
    {
        public VipPath( string origin, string destination) : base( origin, destination)
        {
        }

        public override void SetPrice(int price)
        {
            if (price < 100)
            {
                throw new Exception("The price is low for vip!!!");
            }
            base.SetPrice(price);
        }
    }
}
