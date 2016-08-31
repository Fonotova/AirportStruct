using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_08_2016
{
    class Program
    {
        enum NFlight { C2089, FD24, RD, VC4333, SD7654, LK4521, QS432, MN9076, HG3245, YE215 }
        enum AirLane { TuiFly, Eurowings, TurkishAirlines, Germania, Luxair, Baltic, Pegas, WindRose, FlyDubai, TailWind }
        enum StatusE { Departed, Checkin, Landed, Expected, Canceled, Boarding, OnTime, Unknown }
        enum TerminalE { first, second, third, fourth, fifth, sixth };
        enum GateE { G1, G2, G3, G4, G5, G6 };

        struct Flight
        {
            public NFlight NumberFlight;
            public AirLane AirLine;
            public TerminalE Terminal;
            public StatusE FlightStatus;
            public GateE Gate;
            public string City;
            public DateTime TimeDate;
        }

        static void PrintFlying(Flight[] Plane)
        {
            Console.WriteLine();

            Console.WriteLine(" N_flight____Air line________City________Date_______Time____Gate____Terminal____Status___");

            Console.WriteLine("|       |              |            |           |         |       |         |            | ");
            for (int i = 0; i < Plane.Length; i++)
            {
                Console.WriteLine("|{0,6} |   {1,10} | {2,10} | {3,15} | {4,5} | {5,7} |   {6,8} |",
                Plane[i].NumberFlight, Plane[i].AirLine, Plane[i].City, Plane[i].TimeDate, Plane[i].Gate, Plane[i].Terminal, Plane[i].FlightStatus);
            }
        }

        static void InitialArrivalsStructure(Flight[] Plane)
        {
            Plane[0].NumberFlight = NFlight.C2089;
            Plane[0].AirLine = AirLane.Baltic;
            Plane[0].Terminal = TerminalE.fifth;
            Plane[0].FlightStatus = StatusE.Unknown;
            Plane[0].Gate = GateE.G1;
            Plane[0].City = "Amman";
            Plane[0].TimeDate = DateTime.Today + new TimeSpan(19, 30, 0); ;

            Plane[1].NumberFlight = NFlight.FD24;
            Plane[1].AirLine = AirLane.Eurowings;
            Plane[1].Terminal = TerminalE.first;
            Plane[1].FlightStatus = StatusE.Unknown;
            Plane[1].Gate = GateE.G2;
            Plane[1].City = "Amman";
            Plane[1].TimeDate = DateTime.Today + new TimeSpan(7, 30, 0); ;

            Plane[2].NumberFlight = NFlight.HG3245;
            Plane[2].AirLine = AirLane.FlyDubai;
            Plane[2].Terminal = TerminalE.fourth;
            Plane[2].FlightStatus = StatusE.Unknown;
            Plane[2].Gate = GateE.G3;
            Plane[2].City = "Batumi";
            Plane[2].TimeDate = DateTime.Today + new TimeSpan(19, 0, 0); ;

            Plane[3].NumberFlight = NFlight.LK4521;
            Plane[3].AirLine = AirLane.Germania;
            Plane[3].Terminal = TerminalE.second;
            Plane[3].FlightStatus = StatusE.Unknown;
            Plane[3].Gate = GateE.G4;
            Plane[3].City = "Frankfurt";
            Plane[3].TimeDate = DateTime.Today + new TimeSpan(6, 30, 0); ;

            Plane[4].NumberFlight = NFlight.MN9076;
            Plane[4].AirLine = AirLane.Germania;
            Plane[4].Terminal = TerminalE.second;
            Plane[4].FlightStatus = StatusE.Unknown;
            Plane[4].Gate = GateE.G4;
            Plane[4].City = "Frankfurt";
            Plane[4].TimeDate = DateTime.Today + new TimeSpan(5, 30, 0); ;

            SortByTime(Plane);
        }

        static void InitialDeparturesStructure(Flight[] Plane)
        {
            Plane[0].NumberFlight = NFlight.QS432;
            Plane[0].AirLine = AirLane.Baltic;
            Plane[0].Terminal = TerminalE.fifth;
            Plane[0].FlightStatus = StatusE.Unknown;
            Plane[0].Gate = GateE.G1;
            Plane[0].City = "Amman";
            Plane[0].TimeDate = DateTime.Today + new TimeSpan(15, 30, 0); ;

            Plane[1].NumberFlight = NFlight.RD;
            Plane[1].AirLine = AirLane.Eurowings;
            Plane[1].Terminal = TerminalE.first;
            Plane[1].FlightStatus = StatusE.Unknown;
            Plane[1].Gate = GateE.G2;
            Plane[1].City = "Antalya";
            Plane[1].TimeDate = DateTime.Today + new TimeSpan(12, 30, 0); ;

            Plane[2].NumberFlight = NFlight.SD7654;
            Plane[2].AirLine = AirLane.FlyDubai;
            Plane[2].Terminal = TerminalE.fourth;
            Plane[2].FlightStatus = StatusE.Unknown;
            Plane[2].Gate = GateE.G3;
            Plane[2].City = "Batumi";
            Plane[2].TimeDate = DateTime.Today + new TimeSpan(10, 30, 0); ;

            Plane[3].NumberFlight = NFlight.VC4333;
            Plane[3].AirLine = AirLane.Germania;
            Plane[3].Terminal = TerminalE.second;
            Plane[3].FlightStatus = StatusE.Unknown;
            Plane[3].Gate = GateE.G4;
            Plane[3].City = "Frankfurt";
            Plane[3].TimeDate = DateTime.Today + new TimeSpan(8, 30, 0); ;

            Plane[4].NumberFlight = NFlight.YE215;
            Plane[4].AirLine = AirLane.Germania;
            Plane[4].Terminal = TerminalE.second;
            Plane[4].FlightStatus = StatusE.Unknown;
            Plane[4].Gate = GateE.G4;
            Plane[4].City = "Frankfurt";
            Plane[4].TimeDate = DateTime.Today + new TimeSpan(13, 30, 0); ;

            SortByTime(Plane);

        }

        static void SortByTime(Flight[] Plane)
        {
            Flight plane;
            for (int i = 0; i < (Plane.Length - 1); i++)
            {
                for (int j = i + 1; j < Plane.Length; j++)
                {
                    if ((Plane[j].TimeDate).CompareTo(Plane[i].TimeDate) == -1)
                    {
                        plane = Plane[j];
                        Plane[j] = Plane[i];
                        Plane[i] = plane;
                    }
                }
            }
        }

        static void SetStatusDeparting(Flight[] Plane, DateTime todayTime)
        {

            int timeChekin = 120;
            int endTimeChekin = 30;
            int minutInHour = 60;
            int countMinutePlane = 0;
            int countMinuteToday = 0;
            for (int i = 0; i < Plane.Length; i++)
            {
                countMinutePlane = Plane[i].TimeDate.Hour * minutInHour + Plane[i].TimeDate.Minute;// Time of Departed in minute
                countMinuteToday = todayTime.Hour * minutInHour + todayTime.Minute;

                if (Plane[i].TimeDate < todayTime)
                {
                    Plane[i].FlightStatus = StatusE.Departed;
                }
                else
                    if ((countMinutePlane - countMinuteToday) > timeChekin)
                {
                    Plane[i].FlightStatus = StatusE.Expected;
                }
                else
                        if (((countMinutePlane - countMinuteToday) < timeChekin) && ((countMinutePlane - countMinuteToday) > endTimeChekin))
                {
                    Plane[i].FlightStatus = StatusE.Checkin;
                }
                else
                    if ((countMinutePlane - countMinuteToday) < endTimeChekin)
                {
                    Plane[i].FlightStatus = StatusE.Boarding;
                }

            }
        }

        static void SetStatusArrivals(Flight[] Plane, DateTime todayTime)
        {

            for (int i = 0; i < Plane.Length; i++)
            {
                if (todayTime < Plane[i].TimeDate)
                {
                    Plane[i].FlightStatus = StatusE.Expected;
                }

                else if (todayTime >= Plane[i].TimeDate)
                {
                    Plane[i].FlightStatus = StatusE.Landed;
                }
            }

        }

        static void SearchCity(Flight[] Plane)
        {
            bool flag = false;

            for (int i = 0; i < Plane.Length; i++)
            {
                Console.Write(Plane[i].City + " ;");
            }
            Console.WriteLine();
            Console.WriteLine("Input City: ");

            string Town = Console.ReadLine();

            Console.WriteLine(" N_flight____Air line________City________Date_______Time____Gate____Terminal____Status___");

            Console.WriteLine("|       |              |            |           |         |       |         |            | ");
            for (int i = 0; i < Plane.Length; i++)
            {
                if (Town == Plane[i].City)
                {
                    flag = true;
                    Console.WriteLine("|{0,6} |   {1,10} | {2,10} | {3,15} | {4,5} | {5,7} |   {6,8} |",
                    Plane[i].NumberFlight, Plane[i].AirLine, Plane[i].City, Plane[i].TimeDate, Plane[i].Gate, Plane[i].Terminal, Plane[i].FlightStatus);
                }
            }
            if (!flag)
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = System.ConsoleColor.Yellow;
                Console.WriteLine("This flight is not");
                Console.ForegroundColor = System.ConsoleColor.White;
            }
        }

        static void SearchByNumber(Flight[] Plane)
        {
            Console.Write("Input number flight: ");
            for (int i = 0; i < Plane.Length; i++)
                Console.Write(Plane[i].NumberFlight + " ; ");
            Console.WriteLine();
            string numbFlight = Console.ReadLine();
            bool flag = false;

            Console.WriteLine(" N_flight____Air line________City________Date_______Time____Gate____Terminal____Status___");
            for (int i = 0; i < Plane.Length; i++)
            {
                NFlight j = Plane[i].NumberFlight;
                if ((j).ToString() == numbFlight)
                {
                    flag = true;
                    Console.WriteLine("|{0,6} |   {1,10} | {2,10} | {3,15} | {4,5} | {5,7} |   {6,8} |",
                    Plane[i].NumberFlight, Plane[i].AirLine, Plane[i].City, Plane[i].TimeDate, Plane[i].Gate, Plane[i].Terminal, Plane[i].FlightStatus);

                }
            }
            if (!flag)
            {
                Console.ForegroundColor = System.ConsoleColor.Yellow;
                Console.WriteLine("  This flight is not");
                Console.ForegroundColor = System.ConsoleColor.White;
            }
        }

        static Flight[] SetStatusCanceled(Flight[] Plane)
        {
            Console.Write("Numbers flights  :");
            for (int i = 0; i < Plane.Length; i++)
            {
                Console.Write(Plane[i].NumberFlight + " ; ");
            }
            Console.WriteLine();
            Console.ForegroundColor = System.ConsoleColor.Yellow;
            Console.WriteLine("Input number flight for canceled: ");
            Console.ForegroundColor = System.ConsoleColor.White;

            string numbFlight = Console.ReadLine();

            for (int i = 0; i < Plane.Length; i++)
            {
                NFlight j = Plane[i].NumberFlight;
                if ((j).ToString() == numbFlight)
                {
                    Plane[i].FlightStatus = StatusE.Canceled;
                }
            }
            return Plane;
        }

        static Flight[] EditStruct(Flight[] Plane)
        {
            bool temp;

            Console.WriteLine();
            Console.ForegroundColor = System.ConsoleColor.Yellow;
            Console.Write("Input number flight: ");
            Console.ForegroundColor = System.ConsoleColor.White;
            for (int i = 0; i < Plane.Length; i++)
            {
                Console.Write(Plane[i].NumberFlight + " ; ");
            }
            Console.WriteLine();
            string numbFlight = Console.ReadLine();
            for (int i = 0; i < Plane.Length; i++)
            {
                NFlight j = Plane[i].NumberFlight;
                if ((j).ToString() == numbFlight)
                {
                    Console.ForegroundColor = System.ConsoleColor.Yellow;
                    Console.Write("Input new city:");
                    Console.ForegroundColor = System.ConsoleColor.White;
                    Console.WriteLine();
                    Plane[i].City = Console.ReadLine();
                    Console.WriteLine();

                    Console.ForegroundColor = System.ConsoleColor.Yellow;
                    Console.Write("Input new Air Line : ");
                    Console.ForegroundColor = System.ConsoleColor.White;

                    foreach (var value in Enum.GetValues(typeof(AirLane))) // List of AirLane
                    {
                        Console.Write((AirLane)value + " ;");
                    }

                    AirLane airlane = Plane[i].AirLine;
                    temp = Enum.TryParse(Console.ReadLine(), out airlane);
                    Plane[i].AirLine = airlane;

                    Console.ForegroundColor = System.ConsoleColor.Yellow;
                    Console.Write("Input new terminal : ");
                    Console.ForegroundColor = System.ConsoleColor.White;

                    foreach (var value in Enum.GetValues(typeof(TerminalE))) // List of Terminal
                    {
                        Console.Write((TerminalE)value + " ;");
                    }
                    Console.WriteLine();
                    TerminalE terminal = Plane[i].Terminal;
                    temp = Enum.TryParse(Console.ReadLine(), out terminal);
                    Plane[i].Terminal = terminal;
                }
            }
            return Plane;

        }

        static void SearchFlightsHour(Flight[] Plane, DateTime todayTime)
        {
            bool flag = false;

            Console.WriteLine(" N_flight____Air lane________City________Date_______Time____Gate____Terminal____Status___");
            for (int i = 0; i < Plane.Length; i++)
            {
                if (Plane[i].TimeDate.Hour == todayTime.Hour)
                {
                    flag = true;
                    Console.WriteLine("|{0,6} |   {1,10} | {2,10} | {3,15} | {4,5} | {5,7} |   {6,8} |",
                    Plane[i].NumberFlight, Plane[i].AirLine, Plane[i].City, Plane[i].TimeDate, Plane[i].Gate, Plane[i].Terminal, Plane[i].FlightStatus);
                }
            }
            if (!flag)
            {
                Console.WriteLine();
                Console.ForegroundColor = System.ConsoleColor.Yellow;
                Console.WriteLine("There flights are not in this hour ");
                Console.ForegroundColor = System.ConsoleColor.White;
            }
        }

        static void SearchTimeArrival(Flight[] Plane)
        {
            bool flag = false;
            Console.WriteLine();
            Console.Write("Input time of arrival to format hh:mm  - ");

            DateTime time = (DateTime.Parse(Console.ReadLine()));

            Console.WriteLine(" N_flight____Air lane________City________Date_______Time____Gate____Terminal____Status___");
            for (int i = 0; i < Plane.Length; i++)
            {
                if ((Plane[i].TimeDate.Hour == time.Hour) && (Plane[i].TimeDate.Minute == time.Minute))
                {
                    flag = true;
                    Console.WriteLine("|{0,6} |   {1,10} | {2,10} | {3,15} | {4,5} | {5,7} |   {6,8} |",
                    Plane[i].NumberFlight, Plane[i].AirLine, Plane[i].City, Plane[i].TimeDate, Plane[i].Gate, Plane[i].Terminal, Plane[i].FlightStatus);
                }
            }
            if (!flag)
            {
                Console.ForegroundColor = System.ConsoleColor.Yellow;
                Console.WriteLine("This flight is't");
                Console.ForegroundColor = System.ConsoleColor.White;
            }
        }

        static void Menu(Flight[] PlaneArrival, Flight[] PlaneDeparted, DateTime todayTime)
        {
            Console.WriteLine();
            Console.ForegroundColor = System.ConsoleColor.Yellow;
            Console.WriteLine("    Make a choice, please");
            Console.ForegroundColor = System.ConsoleColor.White;
            Console.WriteLine("____________________________________________");
            Console.WriteLine("  a | Print table of arrivals and departures");
            Console.WriteLine("  b | Set Status for arrivals- Canceled");
            Console.WriteLine("  c | Set Status for  departures - Canceled");
            Console.WriteLine("  d | Search by number for arrivals");
            Console.WriteLine("  e | Search by number for  departures");
            Console.WriteLine("  f | Search by city for arrivals");
            Console.WriteLine("  g | Search by city for  departures");
            Console.WriteLine("  h | Search all flights in this hour for arrivals");
            Console.WriteLine("  i | Search all flights in this hour for  departures");
            Console.WriteLine("  j | Search by time of arrival");
            Console.WriteLine("  k | Edit table arrivals (City, Tervinal, Air line)");
            Console.WriteLine("  l | Edit table departed (City, Tervinal, Air line)");
            Console.ForegroundColor = System.ConsoleColor.Yellow;
            Console.ForegroundColor = System.ConsoleColor.White;

            char n;
            n = char.Parse(Console.ReadLine());

            switch (n)
            {
                case 'a':
                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine("    Arrivals table");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        PrintFlying(PlaneArrival);
                        Console.WriteLine();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine("    Departure table");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        PrintFlying(PlaneDeparted);
                    }
                    break;
                case 'b':
                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine(" Arrivals planes");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        SetStatusCanceled(PlaneArrival); PrintFlying(PlaneArrival);
                    }
                    break;
                case 'c':

                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine("    Departed planes");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        Console.WriteLine();
                        SetStatusCanceled(PlaneDeparted); PrintFlying(PlaneDeparted);
                    }
                    break;
                case 'd':
                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine("Search by number for arrivals");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        Console.WriteLine();
                        SearchByNumber(PlaneArrival);
                    }
                    break;
                case 'e':
                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine("Search by number for departures");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        Console.WriteLine(); SearchByNumber(PlaneDeparted);
                    }
                    break;
                case 'f':
                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine("Search by city for arrivals");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        Console.WriteLine();
                        SearchCity(PlaneArrival);
                    }
                    break;
                case 'g':
                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine("Search by city for arrivals");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        Console.WriteLine();
                        SearchCity(PlaneDeparted);
                    }
                    break;
                case 'h':
                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine("Search all flights in this hour for arrivals");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        Console.WriteLine();
                        SearchFlightsHour(PlaneArrival, todayTime);
                    }
                    break;
                case 'i':
                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine("Search all flights in this hour for departures");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        Console.WriteLine();
                        SearchFlightsHour(PlaneDeparted, todayTime);
                    }
                    break;
                case 'j':
                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine("Search by time of arrival");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        Console.WriteLine();
                        SearchTimeArrival(PlaneArrival);
                    }
                    break;
                case 'k':
                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine(" Edit table arrivals (City, Tervinal, Air line)");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        Console.WriteLine();
                        EditStruct(PlaneArrival); PrintFlying(PlaneArrival);
                    }
                    break;
                case 'l':
                    {
                        Console.Clear();
                        Console.ForegroundColor = System.ConsoleColor.Yellow;
                        Console.WriteLine(" Edit table departed (City, Tervinal, Air line)");
                        Console.ForegroundColor = System.ConsoleColor.White;
                        Console.WriteLine();
                        EditStruct(PlaneDeparted); PrintFlying(PlaneDeparted);
                    }
                    break;

                case ' ': break;
                default:
                    Console.ForegroundColor = System.ConsoleColor.Yellow;
                    Console.WriteLine("You have not made a choice");
                    Console.ForegroundColor = System.ConsoleColor.White;
                    break;

            }
        }

        static void Main(string[] args)
        {

            Flight[] PlaneArrival = new Flight[5];

            Flight[] PlaneDeparted = new Flight[5];

            ConsoleKeyInfo key = new ConsoleKeyInfo();

            DateTime todayTime = DateTime.Now;

            InitialArrivalsStructure(PlaneArrival);

            SetStatusArrivals(PlaneArrival, todayTime);

            InitialDeparturesStructure(PlaneDeparted);

            SetStatusDeparting(PlaneDeparted, todayTime);

            do
            {
                Menu(PlaneArrival, PlaneDeparted, todayTime);
                Console.WriteLine();
                Console.ForegroundColor = System.ConsoleColor.Red;
                Console.WriteLine("To exit, press Escape");
                Console.ForegroundColor = System.ConsoleColor.White;
                key = Console.ReadKey();
                Console.Clear();
            } while (key.Key != ConsoleKey.Escape);
            Console.ReadKey();
        }
    }
}
