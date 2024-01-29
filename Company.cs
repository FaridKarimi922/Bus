using Buss.Enums;
using Buss.FolderBus;
using Buss.FolderTicket;
using Buss.FolderTravel;
using System.Runtime.InteropServices.JavaScript;
using Path = Buss.FolderTravel.Path;

namespace Buss
{
    public static class Company
    {
        private static List<Bus> _buses = new List<Bus>();
        private static List<Bus> _busesVip = new List<Bus>();
        private static List<Bus> _busesNormal = new List<Bus>();
        private static List<FolderTravel.Path> _paths = new List<FolderTravel.Path>();
        private static List<Trip> _trips = new List<Trip>();

        private static List<Traveler> _travelers = new List<Traveler>();
        private static List<InfoTraveler> _infoTravelers = new List<InfoTraveler>();

       public static Trip trip = new Trip(); 
        public static int busId = 0;
        public static int pathId = 0;
        public static int tripId = 0;
        public static int paymentId = 0;





        public static void AddBus(string name, string type)
        {
            if (type == "normal")
            {
                NormalBus normalBus = new NormalBus(name);
                normalBus.AddSeatToBus();
                normalBus.SetType(type);
                normalBus.SetId();
                _buses.Add(normalBus);
                _busesNormal.Add(normalBus);

                Console.WriteLine($"Bus {name} with capacity 44 Seats added");
            }
            else if (type == "vip")
            {
                VipBus vipBus = new VipBus(name);
                vipBus.AddSeatToBus();
                vipBus.SetType(type);
                vipBus.SetId();
                _buses.Add(vipBus);
                _busesVip.Add(vipBus);

                Console.WriteLine($"Bus {name} with capacity 30 Seats added");
            }
            else
            {
                throw new Exception("Number is Not Valid!!!");
            }
        }


        public static List<Bus> GetListBuses()
        {
            return _buses;

        }
        public static List<Bus> GetListBusesVip()
        {
            return _busesVip;

        }
        public static List<Bus> GetListBusesNormal()
        {
            return _busesNormal;
        }

        public static void AddPath(int type, string origin, string destination, int Price)
        {

            if (type == 1)
            {

                NormalPath normalTravel = new NormalPath(origin, destination);
                normalTravel.SetPrice(Price);
                normalTravel.SetId();
                _paths.Add(normalTravel);
            }
            else if (type == 2)
            {
                VipPath vipTravel = new VipPath(origin, destination);
                vipTravel.SetPrice(Price);
                _paths.Add(vipTravel);
            }
            else
            {
                throw new Exception("not valid!!!");
            }
        }
       
        public static void AddTraveler(string firstName, string lastName, int gender)
        {
            Traveler traveler = new Traveler(firstName, lastName);
            traveler.SetGender(gender);
            _travelers.Add(traveler);

        }
        public static void PrintBuses()
        {
            if (!_buses.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\"No Bus has been Added Yet\"\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("BusNumber   BusName    Type    Capacity");

                _buses.ForEach(_ => Console.WriteLine(_));
            }

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintPaths()
        {
            if (!_paths.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\"No path has been added yet\"\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (_paths.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("********** paths **********");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PathNumber   PathOrigin    PathDestination        PathPrice");

                _paths.ForEach(_ => Console.WriteLine(_));

                Console.Write(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void AddTrip()
        {
            PrintPaths();

            if (_paths.Any())
            {
                Console.Write("Enter a path number: ");
                int pathId = Convert.ToInt32(Console.ReadLine());
                

                var resultPath = _paths.FirstOrDefault(_ => _.PathId == pathId);

                if (resultPath is null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The Path is not available\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    AddTrip();
                }

                if (resultPath is not null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"********** buses **********");


                    bool resultCheck = CheckingBusInTrip();

                    if (resultCheck is true)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Choose your desired bus number: ");
                        int buschoice = Convert.ToInt32(Console.ReadLine());

                        Bus resultBus = _buses.FirstOrDefault(p =>
                        p.BusID == buschoice);

                        if (resultBus is null)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\"The bus is not available\"");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            AddTrip();
                        }

                        if (resultBus is not null)
                        {
                            tripId += 1;

                            _trips.Add(new Trip
                            {
                                TripId = tripId,
                                PathId = resultPath,
                                BusId = resultBus
                            });

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nYour trip has been added.\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                        }
                    }

                    if (resultCheck is false)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\"The bus is not available\"");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                    }
                }
            }
        }
        private static bool CheckingBusInTrip()
        {
            if (!_buses.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\"No Bus has been Added Yet\"\n");
            }

            if (_buses.Any())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("BusNumber   BusName    Type    Capacity");

                List<Bus> s = new List<Bus>();

                _trips.ForEach(t =>
                {
                    var a = _buses.Where(b =>
                    b.BusID == t.BusId.BusID)
                    .FirstOrDefault();
                    s.Add(a);
                });

                var exceptResult = _buses.Except(s).ToList();
                exceptResult.ForEach(_ => Console.WriteLine(_));

                return exceptResult.Any();
            }

            Console.Write(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.White;

            return false;
        }
        public static void PrintBusTripOfPath()
        {
            PrintPaths();
            if (_paths.Any())
            {
                Console.Write("Enter a path number: ");
                int pathId = Convert.ToInt32(Console.ReadLine());
               

                var resultTrip = _trips.Where(_ => _.PathId.PathId == pathId).ToList();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("BusNumber   BusName    Type    Capacity");

                resultTrip.ForEach(_ => Console.WriteLine(_.BusId));

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }
        public static void PrintTrips()
        {
            _trips.ForEach(_ => Console.WriteLine(_));

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        private static int GetTrip()
        {
            PrintTrips();

            Console.Write("Enter a trip number: ");
            int tripId = Convert.ToInt32(Console.ReadLine());
           

            return tripId;
        }
        public static void Reservation()
        {
            if (_trips.Any())
            {
                int tripId = GetTrip();

                Trip resultTrip = _trips.FirstOrDefault(t => t.TripId == tripId);

                Path path = resultTrip.PathId;
                Bus bus = resultTrip.BusId;


                bool resultCheckCapacity = CheckingFullCapacity(bus);

                if (resultCheckCapacity is true)
                {

                    paymentId += 1;

                    double price = path.Price;
                    double zaribVip = .4;
                    double priceTicket = 0;

                    if (bus.Type.ToString() == "normal")
                    {
                        priceTicket = (price * 30) / 100;
                    }

                    if (bus.Type.ToString() == "vip")
                    {
                        price = price + (price * zaribVip);
                        priceTicket = (price * 30) / 100;
                    }

                    bus.BookSeat();
                    bus.Capacity -= 1;
                   
                    trip.payments.Add(new Payment
                    {
                        PaymentID = paymentId,
                        Status = StatusType.r,
                        Price = priceTicket,
                        TripID = resultTrip
                    });

                    Console.WriteLine($"Price ticket: {priceTicket}");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"Your reservation has been made\"");
                    Console.ForegroundColor = ConsoleColor.White;
                  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"The bus capacity is full\"");
                    Console.ForegroundColor = ConsoleColor.White;
                  
                }

                if (!_trips.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"No trip available\"");
                    Console.ForegroundColor = ConsoleColor.White;
                   
                }
            }
        }
        private static bool CheckingFullCapacity(Bus bus)
        {
            if (bus.Availability <= (bus.Capacity + 2))
            {
                return true;
            }
            return false;
        }
        public static void Buy()
        {
            if (_trips.Any())
            {
                int tripId = GetTrip();

                Trip resultTrip = _trips.FirstOrDefault(t => t.TripId == tripId);

                Path path = resultTrip.PathId;
                Bus bus = resultTrip.BusId;


                bool resultCheckCapacity = CheckingFullCapacity(bus);

                if (resultCheckCapacity is true)
                {

                    paymentId += 1;

                    double price = path.Price;
                    double zaribVip = .4;
                    double priceTicket = 0;

                    if (bus.Type.ToString() == "normal")
                    {
                        priceTicket = price;
                    }

                    if (bus.Type.ToString() == "vip")
                    {
                        price = price + (price * zaribVip);
                        priceTicket = price;
                    }

                    bus.BookSeat();
                    bus.Capacity -= 1;
                   
                    trip.payments.Add(new Payment
                    {
                        PaymentID = paymentId,
                        Status = StatusType.b,
                        Price = priceTicket,
                        TripID = resultTrip
                    });

                    Console.WriteLine($"Price ticket: {priceTicket}");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"Your buy has been made\"");
                    Console.ForegroundColor = ConsoleColor.White;
                  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"The bus capacity is full\"");
                    Console.ForegroundColor = ConsoleColor.White;
                   
                }

                if (!_trips.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"No trip available\"");
                    Console.ForegroundColor = ConsoleColor.White;
                   
                }
            }
        }
        private static int GetPayment()
        {
            int tripId = GetTrip();

            Trip resultTrip = _trips.FirstOrDefault(t => t.TripId == tripId);

            Path path = resultTrip.PathId;
            Bus bus = resultTrip.BusId;
            
            var resultPaymentsTrip = trip.payments.Where(_ => _.TripID.TripId == resultTrip.TripId).ToList();

            var resultStatusPayment = resultPaymentsTrip.Where(p => p.Status == StatusType.b || p.Status == StatusType.r).ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("paymentId    status    price");

            resultStatusPayment.ForEach(_ => Console.WriteLine($"{_.PaymentID}    {_.Status,10}   {_.Price,8}"));

            Console.ForegroundColor = ConsoleColor.White;
            
            Console.Write("Enter a payment number: ");
            string input = Console.ReadLine();
            

            if (int.TryParse(input, out int paymentId))
            {
                bus.CancelSeat();
                bus.Capacity += 1;

                return paymentId;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\"Enter a number\"");
                Console.ForegroundColor = ConsoleColor.White;
              

                GetPayment();
            }


            return 0;
        }
        public static void Canceled()
        {
           
            var resultStatusBuyOrReserv = trip.payments.Any(_ => _.Status == StatusType.b || _.Status == StatusType.r);

            if (trip.payments.Any() && resultStatusBuyOrReserv)
            {
                int paymentId = GetPayment();

                var a = trip.payments.FirstOrDefault(_ => _.PaymentID == paymentId);

                double finalPrice = 0.0;

                if (a.Status == StatusType.b)
                {
                    finalPrice = (a.Price * 10) / 100;
                }

                if (a.Status == StatusType.r)
                {
                    finalPrice = (a.Price * 20) / 100;
                }

                a.Status = StatusType.c;
                a.Price = finalPrice;
                Console.WriteLine($"Price ticket: {finalPrice}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\"The cancellation was successful\"");
                Console.ForegroundColor = ConsoleColor.White;
               
            }
            if (!trip.payments.Any() || !resultStatusBuyOrReserv)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\"No buy or reservation has been made for this bus\"");
                Console.ForegroundColor = ConsoleColor.White;
             
            }
        }
        private static int GetReserv()
        {

            {
                int tripId = GetTrip();

                Trip resultTrip = _trips.FirstOrDefault(t => t.TripId == tripId);

                Path path = resultTrip.PathId;
                Bus bus = resultTrip.BusId;

                var resultStatusPayment = trip.payments.Where(p => p.Status == StatusType.r).ToList();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("paymentId    status    price");

                resultStatusPayment.ForEach(_ => Console.WriteLine($"{_.PaymentID}    {_.Status,10}   {_.Price,8}"));

                Console.ForegroundColor = ConsoleColor.White;
               
                Console.Write("Enter a payment number: ");
                string input = Console.ReadLine();
               

                if (int.TryParse(input, out int paymentId))
                {
                    return paymentId;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\"Enter a number\"");
                    Console.ForegroundColor = ConsoleColor.White;
               

                    GetPayment();
                }


                return 0;
            }
        }
        public static void ConvertReservationToBuy()
        {
            var aa = trip.payments.Any(_ => _.Status == StatusType.r);

            if (trip.payments.Any() && aa)
            {
                int paymentId = GetReserv();

                var a = trip.payments.FirstOrDefault(_ => _.PaymentID == paymentId);

                double finalPrice = a.TripID.PathId.Price;
                double zaribVip = 0.4;

                if (a.TripID.BusId.Type == EnumTypeBus.vip)
                {
                    finalPrice += (finalPrice * zaribVip);
                }

                a.Status = StatusType.b;
                a.Price = finalPrice;
                Console.WriteLine($"Price ticket: {finalPrice}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\"Your reservation status has changed to Buy status\"");
                Console.ForegroundColor = ConsoleColor.White;
               
            }
            if (!trip.payments.Any() || !aa)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\"No buy has been made for this bus\"");
                Console.ForegroundColor = ConsoleColor.White;
                
            }

        }
        public static void PrintPayment()
        {
            if (trip.payments.Any())
            {
                int tripId = GetTrip();

                Trip resultTrip = _trips.FirstOrDefault(t => t.TripId == tripId);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("paymentId    status    price");

                var resultPaymentsTrip = trip.payments.Where(_ => _.TripID.TripId == resultTrip.TripId).ToList();

                resultPaymentsTrip.ForEach(_ => Console.WriteLine($"{_.PaymentID}    {_.Status,10}   {_.Price,8}"));

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.NewLine);
            }

            if (!trip.payments.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\"No payment has been made yet\"");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        public static void IncomeOfPath()
        {
            PrintTrips();

            Console.Write("Enter a trip number: ");
            int tripId = Convert.ToInt32(Console.ReadLine());
            

            var resultTrip = trip.payments.Where(_ => _.TripID.TripId == tripId).ToList();

            double priceFinal = 0;
            resultTrip.ForEach(_ => priceFinal += _.Price);
            Console.WriteLine($"Price{tripId} is : {priceFinal}");
        }

    }
}
