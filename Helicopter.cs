using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie2

{
    public class Coords
    {
        public double Latitude;
        public double Longitude;

        public Coords(double la, double lo)

        {
            this.Latitude = la;
            this.Longitude = lo;
        }
    }

    public class Helicopter
    {
        private double weight;
        private int maxSpeed;
        private bool armed;
        public static readonly Coords basePosition = new Coords(0, 0); //start point to fly FROM
        private int battleNum;
        private int destroyedNum;
        private int rocketNum;
        private int gunNum;
        private int fuel;


        public string Model { get; set; }
        public Coords Position { get; set; }
        public string Name { get; set; }
        public bool DestroyedHel { get; set; }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value > 5)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int MaxSpeed
        {
            get
            {
                return this.maxSpeed;
            }
            set
            {
                if (value >= 0)
                {
                    this.maxSpeed = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public bool Armed
        {
            get
            {
                return this.armed;
            }

            set
            {
                this.armed = value;
            }
        }

        public int BattleNum
        {
            get
            {
                return this.battleNum;
            }
            set
            {
                if (value >= 0)
                {
                    this.battleNum = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
                     
        public int DestroyedNum
        {
            get
            {
                return this.destroyedNum;
            }
            set
            {
                if (value >= 0)
                {
                    this.destroyedNum = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int RocketNum
        {
            get
            {
                return this.rocketNum;
            }

            set
            {
                if (Armed == true)
                {
                    if (value >= 0)
                    {
                        this.rocketNum = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public int GunNum
        {
            get
            {
                return this.gunNum;
            }
            set
            {
                if (Armed == true)
                {
                    if (value >= 0)
                    {
                        this.gunNum = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public int Fuel
        {
            get
            {
                return this.fuel;
            }
            set
            {
                if (value >= 0 && value <= 500)
                {
                    this.fuel = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        


        public Helicopter()
        {
            Model = "Lockheed AH-56 Cheyenne";
            Weight = 4708.11;
            MaxSpeed = 324;
            Armed = true;
            Position = basePosition;
            BattleNum = 0;
            DestroyedNum = 0;
            Name = "Crazy Bird";
            RocketNum = 0;
            GunNum = 0;
            Fuel = 0;
            DestroyedHel = false;
        }

        public Helicopter(string m, double w, int ms)
        {
            Model = m;
            Weight = w;
            MaxSpeed = ms;
            Armed = false;
            Position = basePosition;
            BattleNum = 0;
            DestroyedNum = 0;
            Name = "Killer";
            RocketNum = 0;
            GunNum = 0;
            Fuel = 0;
            DestroyedHel = false;
        }

        public Helicopter(string m, double w, int ms, bool a, Coords p, int bn,
            int dn, string n, int rn, int gn, int f, bool dh) : this(m, w, ms)
        {
            Armed = a;
            Position = p;
            BattleNum = bn;
            DestroyedNum = dn;
            Name = n;
            RocketNum = rn;
            GunNum = gn;
            Fuel = f;
            DestroyedHel = dh;
        }


        public bool Fly(Coords newPos)

        {
            const int distance = 1;                                      // length of 1 distance
            Console.WriteLine("\nHelicopter is going to fly from position ({0} х {1}) to position ({2} х {3})",
                Position.Latitude, Position.Longitude, newPos.Latitude, newPos.Longitude);


            if (Fuel == 0 && Coords.Equals(Position, basePosition))
            {
                Console.WriteLine("\n \t\tNo fuel!! Refuel to be able to fly! \n");
                return false;
            }
            Thread.Sleep(1000);


            if (Coords.Equals(Position, newPos))
            {
                Console.WriteLine("\n \t\tYou  stay on the same position!\n");
                return false;

            }

            else
            {

                do
                {
                    if (Fuel == 0)
                    {
                        Console.WriteLine("\n ~~~~~~~~~~~~~~~~~~~ Asta la Vista, baby! ~~~~~~~~~~~~~~~\n");

                        DestroyedHel = true;

                        Console.WriteLine("\n ~~~~~ Helicopter was exploded! Next time check your fuel tank ~~~~~ \n");
                        return false;


                    }
                    double x = newPos.Latitude - Position.Latitude;
                    double y = newPos.Longitude - Position.Longitude;
                    double g = Math.Sqrt(x * x + y * y);
                    double kx = distance * Math.Abs(x) / g;
                    double ky = distance * Math.Abs(y) / g;

                    double yn = Position.Longitude + ky * Math.Sign(y);
                    double xn = Position.Latitude + kx * Math.Sign(x);

                    if (Math.Sign(y) == Math.Sign(newPos.Longitude - yn) && Math.Sign(x) == Math.Sign(newPos.Latitude - xn))
                    {
                        Position.Latitude = xn;
                        Position.Longitude = yn;
                    }

                    else
                    {
                        Position.Latitude = newPos.Latitude;
                        Position.Longitude = newPos.Longitude;
                    }

                    Console.WriteLine();

                    if (this.Model == "Lockheed AH-56 Cheyenne")
                    {
                        Console.WriteLine("Br gr ggr gggrrrrrrrr");
                    }

                    else if (this.Model == "Boeing Sikorsky RAH - 66 Comanche")
                    {
                        Console.WriteLine("Dzhhhhhhh dhzhh dzhhhhh");
                    }

                    else if (this.Model == "McDonnell Douglas AH-64 Apache")
                    {
                        Console.WriteLine("Trrrr trrr trrr trrrrrrrr");
                    }

                    else 
                    {
                        Console.WriteLine("Drrrrrrrrrrrrrrrrrrrrrrrrrrrrr");
                    }

                    Thread.Sleep(2500);
                    Console.WriteLine("Current position is: ({0} x {1})\n", Position.Latitude, Position.Longitude);


                    int tempFuel = Fuel - (Convert.ToInt32(Math.Abs(x)) * 2 + Convert.ToInt32(Math.Abs(y)) * 2);     // burning of fuel
                    Fuel = tempFuel < 0 ? 0 : tempFuel; // fuel not -

                }

                while (Position.Latitude != newPos.Latitude && Position.Longitude != newPos.Longitude);

                Console.WriteLine("Helicopter on position!\n");
            }

            return true;
        }

        public void DestroyTarget(Coords target)

        {
            Console.WriteLine($"\nLets destroy target {target.Latitude} x {target.Longitude}!!!!!");
            Thread.Sleep(500);
                      
            bool temp2 = Fly(target);

            if (temp2==false)
            {

                return;

            }


            Thread.Sleep(2000);
            Console.WriteLine($"\t\tChoose how to attack:\n\n\t\t1 -> With rockets \n\t\t2 -> With rokets and machine gun");

            Thread.Sleep(500);

            short choise = Convert.ToInt16(Console.ReadLine());

            Console.Write($"\nChoose number of shots: ");

            Thread.Sleep(500);

            short choise2 = Convert.ToInt16(Console.ReadLine());

            if (choise2 <= RocketNum && choise2 <= GunNum)
            {
                bool wasShot = false;

                switch (choise)
                {
                    case 1:

                        wasShot = this.Shoot(choise2);
                        this.RocketNum = this.RocketNum - choise2;

                        break;

                    case 2:

                        wasShot = this.Shoot(choise2, true);
                        this.RocketNum = this.RocketNum - choise2;
                        this.GunNum = this.GunNum - choise2;

                        break;
                }

                if (wasShot == true)
                {

                    Random randShot = new Random();
                    int randNumber = randShot.Next(0, 10);
                    if (BattleNum < 3)
                    {
                        if (randNumber > 5)
                        {
                            Thread.Sleep(1000);

                            Console.WriteLine("\nHooray! Target was destroyed!\n");
                            this.BattleNum++;
                            this.DestroyedNum++;



                        }

                        else
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("\nUgh.. Target wasn`t destroyed :(\n");
                            this.BattleNum++;
                            this.RocketNum = this.RocketNum - choise2;
                            this.GunNum = this.GunNum - choise2;
                        }
                    }

                    else

                    {

                        if (randNumber >= 2)
                        {
                            Thread.Sleep(1000);

                            Console.WriteLine("\nHooray! Target was destroyed!\n");
                            this.BattleNum++;
                            this.DestroyedNum++;
                        }

                        else
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("\nUgh.. Target wasn`t destroyed :(\n");
                            this.BattleNum++;
                        }
                    }

                }
            }

            else
            {
                Console.WriteLine("\nUgh.. No weapons avaliable. Target wasn`t destroyed :(\n");
                this.BattleNum++;
            }
        }

        public void BacktoBase()

        {
            if (Coords.Equals(Position, basePosition))
            {
                Console.WriteLine("Wipe your glasses, dude! You are already on base!");
            }

            else
            {
                Console.WriteLine("\nLets go back to the base!");
                Console.ReadKey();
                this.Fly(basePosition);
                Console.WriteLine("\nHelicopter was successfully landed on base!");
            }
        }

        public bool Shoot(int numshots)

        {
            Console.WriteLine();

            if (this.Armed == true)
            {
                for (int i = 0; i < numshots; ++i)
                {

                    Console.WriteLine("Bang! ");
                    Thread.Sleep(500);
                }

                return true;
            }

            else
            {
                return false;
            }
        }

        public bool Shoot(int numshots, bool gun)

        {
            Console.WriteLine();

            if (this.Armed == true)
            {
                for (int i = 0; i < numshots; ++i)
                {

                    if (gun == true)

                    {
                        Console.WriteLine("Pif paf!  ");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine("Bang! ");
                    Thread.Sleep(500);
                }

                return true;
            }

            else
            {
                return false;
            }
        }


        public void Arm()

        {
            if (Armed == true)
            {

                if (Coords.Equals(Position, basePosition))
                {
                    Console.Write("\nChoose how many rockets you want to load: ");

                    RocketNum = Convert.ToInt32(Console.ReadLine());

                    Console.Write("\nChoose how many machine guns queue you want to load: ");

                    GunNum = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"\n{RocketNum} rockets and {GunNum} machine guns queue are avaliable now");

                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("\nYou have to come back to base to get arm!");
                    Thread.Sleep(1000);
                    this.Fly(basePosition);
                    Console.WriteLine("\nHelicopter was successfully landed on base!");
                    RocketNum = 20;
                    GunNum = 5;    // const

                    Console.WriteLine($"{RocketNum} rockets and {GunNum} machine guns queue are avaliable now");

                    Console.ReadKey();
                }

            }


        }


        public void Refuel()

        {
            if (Coords.Equals(Position, basePosition))
            {

                Console.Write($"Enter how many litres you need (till 500):");
                this.Fuel = this.Fuel+Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"\nHelicopter was refueled on {Fuel} litres!");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("\nYou have to come back to base to refuel!");
                Thread.Sleep(1000);
            }


        }

        public void GetInfo()

        {
            Thread.Sleep(500);
            Console.WriteLine($"\t\t________ General Info: _________\n\n\t\tName: {Name} \n\t\tModel: {Model}"+
                $"\n\t\tWeight: {Weight} \n\t\tMaxSpeed: {MaxSpeed} \n\t\tCurrent coordinates: " +
                $"{Position.Latitude}x{Position.Longitude}\n\t\tFuel: {Fuel} liters \n\t\t________________________________");
            Thread.Sleep(1000);
        }

        public void GetBattleInfo()

        {
            Thread.Sleep(500);
            Console.WriteLine($"\n\n\t\t________ Battle Info: __________\n\n\t\tName: {Name}\n\t\tModel: {Model} " +
                $"\n\t\t________________________________\n\n\t\tArmed: {Armed} \n\t\tNumber of battles: {BattleNum} " +
                $"\n\t\tNumber of destroyed targets: {DestroyedNum} \n\t\tCurrent coordinates: " +
                $"{ Position.Latitude}x{ Position.Longitude}\n\t\tNumber of rockets: {RocketNum}\n\t\tNumber of machine gun queue: " +
                $"{GunNum}\n\t\tFuel: {Fuel} liters\n\t\t________________________________");
            Thread.Sleep(1000);
        }

        public void BattleCounter()

        {
            Thread.Sleep(500);
            Console.Write($"Current number of battles: {this.BattleNum} \n");
            Thread.Sleep(1000);
        }

        public void VictimsCounter()

        {
            Thread.Sleep(500);
            Console.Write($"Current number of destroyed targets: {this.DestroyedNum} \n");
            Thread.Sleep(1000);
        }

        public static Helicopter CreateHelicopter()

        {
            Thread.Sleep(500);
            Console.Write($" \t\tHelicopter creating process was started \n\n");
            Thread.Sleep(1000);

            Helicopter temp = new Helicopter();

            Console.Write($" \n\t\tEnter name:  ");

            temp.Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine();
            Console.Write($" \t\tEnter model:  ");
            temp.Model = Convert.ToString(Console.ReadLine());
            Console.WriteLine();
            Console.Write($" \t\tEnter color:  ");
            Console.WriteLine();
            Console.Write($" \t\tEnter weight:  ");
            temp.Weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.Write($" \t\tEnter Maximum Speed:  ");
            temp.MaxSpeed = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write($" \t\tIs it Armed (choose true or false):  ");
            temp.Armed = Convert.ToBoolean(Console.ReadLine());

            temp.Position = new Coords(0, 0);

            temp.BattleNum = 0;

            temp.DestroyedNum = 0;

            temp.RocketNum = 0;
            temp.GunNum = 0;
            temp.Fuel = 0;
            Console.WriteLine("\n\t\tWas created next helicopter: \n");
            temp.GetInfo();
            temp.GetBattleInfo();
            Console.ReadKey();

            return temp;
        }


        ~Helicopter()                  /* finalize*/

        {
            Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($" \n\tHelicopter \"{Name}\" was avaliable in this session\n");
        }
    }
}
