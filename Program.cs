namespace Buss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Run();
                }
                catch (Exception exeption)
                {

                    Console.WriteLine(exeption.Message);
                }

            } while (true);
            void Run()
            {
                Boolean isRuning = true;
                
                var optionMenu = GetIntegerValid("1. Bus " +
                    "\n2. Path " +
                    "\n3. Trip " +
                    "\n4. Payment " +
                    "\n5. Income Of Path " +
                    "\n6. Exit Menu");
                                                
                switch (optionMenu)             
                {                               
                    case 1:                     
                        {                       
                            BusMenuView();
                            break;
                        }

                    case 2:
                        {
                            PathMenuView();
                            break;
                        }

                    case 3:
                        {
                            TripMenuView();
                            break;
                        }

                    case 4:
                        {
                            PaymentMenuView();
                            break;
                        }

                    case 5:
                        {
                            IncomeMenuview();
                            break;
                        }

                    case 6:
                        {
                            isRuning = false;
                            Console.WriteLine("Welcome, We are waiting for your return");
                            break;
                        }

                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Enter a number from 1 to 6 to choose correctly");
                            Console.ReadKey();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;

                            break;
                        }
                }

            }

        }
        public static int GetIntegerValid(string message)
        {
            int value;
            bool integerValid;
            do
            {
                Console.WriteLine(message);
                integerValid = int.TryParse(Console.ReadLine(), out value);



            } while (!integerValid);
            return value;
        }
        public static string GetStringValid(string message)
        {
            string? value;
            do
            {
                Console.WriteLine(message);
                value = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(value));
            return value;
        }
       
        private static void BusMenuView()
        {
            Boolean isRuning = true;

            while (isRuning)
            {
                Console.WriteLine("1. Add  Bus");
                Console.WriteLine("2. show All Buses");
                Console.WriteLine("3. Menu");

                int optionBus = GetIntegerValid(Console.ReadLine()!);
               

                switch (optionBus)
                {
                    case 1:
                        {
                            var nameBus = GetStringValid("enter name bus");
                            var typeBus = GetStringValid("enter type bus\n.normal :\n.vip :");
                            Company.AddBus(nameBus, typeBus);
                            break;
                        }
                    case 2:
                        {
                            Company.PrintBuses();
                            break;
                        }

                    case 3:
                        {
                            isRuning = false;
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Enter a number from 1 to 3 to choose correctly");

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                }
            }

        }

        private static void PathMenuView()
        {
            Boolean isRuning = true;

            while (isRuning)
            {
                Console.WriteLine("1. Add  Path");
                Console.WriteLine("2. Show All Paths");
                Console.WriteLine("3. Menu");

                var optionPath = GetIntegerValid(Console.ReadLine()!);
               

                switch (optionPath)
                {
                    case 1:
                        {
                            var type = GetIntegerValid("1. Normal 2. Vip");
                            var origin = GetStringValid("enter origin :");
                            var destimation = GetStringValid("enter destimation :");
                            var price = GetIntegerValid("enter price :");
                            Company.AddPath(type, origin, destimation, price);
                            break;
                        }
                    case 2:
                        {
                            Company.PrintPaths();
                            break;
                        }

                    case 3:
                        {
                            isRuning = false;
                            break;
                        }

                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Enter a number from 1 to 3 to choose correctly");

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                }
            }
        }
        private static void TripMenuView()
        {
            Boolean isRuning = true;

            while (isRuning)
            {
                Console.WriteLine("1. Add  Trip");
                Console.WriteLine("2. Show Bus In Trip");
                Console.WriteLine("3. Show Trips");
                Console.WriteLine("4. Menu");

                var optiomTrip = GetIntegerValid(Console.ReadLine()!);
                

                switch (optiomTrip)
                {
                    case 1:
                        {
                           Company.AddTrip();
                            break;
                        }
                    case 2:
                        {
                           Company.PrintBusTripOfPath();
                            break;
                        }
                    case 3:
                        {
                           Company.PrintTrips();
                            break;
                        }

                    case 4:
                        {
                            isRuning = false;
                            break;
                        }

                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Enter a number from 1 to 4 to choose correctly");

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                }
            }
        }
        private static void PaymentMenuView()
        {
            Boolean isRuning = true;

            while (isRuning)
            {
                Console.WriteLine("1. Reservation");
                Console.WriteLine("2. Buy");
                Console.WriteLine("3. cancel");
                Console.WriteLine("4. Status Conversion Reservation To Buy");
                Console.WriteLine("5. Show Payments");
                Console.WriteLine("6. Menu");

                var optionPayment = GetIntegerValid(Console.ReadLine()!);
                

                switch (optionPayment)
                {
                    case 1:
                        {
                           Company.Reservation();
                            break;
                        }
                    case 2:
                        {
                           Company.Buy();
                            break;
                        }
                    case 3:
                        {
                           Company.Canceled();
                            break;
                        }

                    case 4:
                        {
                           Company.ConvertReservationToBuy();
                            break;
                        }

                    case 5:
                        {
                           Company.PrintPayment();
                            break;
                        }

                    case 6:
                        {
                            isRuning = false;
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Enter a number from 1 to 6 to choose correctly");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                }
            }
        }
        private static void IncomeMenuview()
        {

            {
                Boolean isRuning = true;

                while (isRuning)
                {
                    Console.WriteLine("1. Income Of Path");
                    Console.WriteLine("2. Menu");

                    var optionIncom =GetIntegerValid(Console.ReadLine()!);
                   

                    switch (optionIncom)
                    {
                        case 1:
                            {
                               Company.IncomeOfPath();
                                break;
                            }

                        case 2:
                            {
                                isRuning = false;
                                break;
                            }
                        default:
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Enter a number from 1 to 2 to choose correctly");

                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                    }
                }
            }
        }

    }

}
