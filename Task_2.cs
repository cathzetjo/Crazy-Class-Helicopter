using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Task_2
    {

        public static void Run()

        {
            List<Helicopter> helList = new List<Helicopter>(capacity: 0);

            //Helicopter temp = null;

            Helicopter crazyBird = new Helicopter();

            Helicopter killer = new Helicopter("Boeing Sikorsky RAH - 66 Comanche", 4218.56, 324);

            Helicopter heavyGuy = new Helicopter("McDonnell Douglas AH-64 Apache", 5165.80, 293,
                                                  true, Helicopter.basePosition, 0, 0, "Heavy Guy", 0, 0, 0, false);

                        
            helList.Add(crazyBird);
            helList.Add(killer);
            helList.Add(heavyGuy);

            int index = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\tPress:\n\n\t1 -> Choose helicopter \n\t2 -> Get info about current helicopter" +
                                   " \n\t3 -> Choose flying options \n\t4 -> Make actions on base\n\t5 -> Create new helicopter\n\t6 -> Exit");
                //short choise = Convert.ToInt16(Console.ReadLine());                                 // user choose action
                short choise;
                string choiseTemp = Console.ReadLine();                                 // user choose action

                if (Int16.TryParse(choiseTemp, out choise))
                {
                    Console.Clear();

                    switch (choise)
                    {
                        case 1:

                            Console.WriteLine("\n");

                            for (int i = 0; i < helList.Count; i++)
                            {
                                Console.Write("\t\t\t" + i + "  ->  " + helList[i].Name + "\n");
                            }

                            if (helList.Count != 0)
                            {
                                short choise2 = Convert.ToInt16(Console.ReadLine());                                 // user choose helicopter
                                if (choise2 >= 0 && choise2 < helList.Count)
                                {
                                    index = choise2;

                                    Console.Clear();
                                }
                            }
                            break;

                        case 2 when index!=-1:

                            Console.Write("\n\tInformation about currant helicopter: \n\n");

                            Thread.Sleep(500);
                            Console.WriteLine("\t\t\tPress:\n\n\t\t1 -> Get general info \n\t\t2 -> Get Battle info ");
                            short choise3 = Convert.ToInt16(Console.ReadLine());                                 // user choose action
                            Thread.Sleep(500);

                            switch (choise3)

                            {

                                case 1:

                                    helList[index].GetInfo();

                                    Console.ReadKey();

                                    Console.Clear();

                                    break;

                                case 2:

                                    helList[index].GetBattleInfo();

                                    Console.ReadKey();

                                    Console.Clear();

                                    break;
                            }
                            break;

                        case 3 when index != -1:

                            Console.WriteLine("\n\t\t      Fly options: \n\n\t\t\tPress:\n\n\t\t1 -> Choose new position \n\t\t2 -> " +
                                "Destroy target \n\t\t3 -> Back to the base ");
                            short choise4 = Convert.ToInt16(Console.ReadLine());                                 // user choose action
                            Thread.Sleep(500);

                            switch (choise4)
                            {
                                case 1:

                                    Console.Write("Enter coordinate of latitude for final point: ");
                                    short choiceLatitude = Convert.ToInt16(Console.ReadLine());                        // user choose where to fly
                                    Console.Write("Enter coordinate of longitude for final point: ");
                                    short choiseLongitude = Convert.ToInt16(Console.ReadLine());

                                    Coords toPos = new Coords(choiceLatitude, choiseLongitude);

                                    helList[index].Fly(toPos);

                                    Console.ReadKey();

                                    Console.Clear();

                                    break;

                                case 2:

                                    Console.Write("Enter coordinate of latitude for tagret: ");
                                    short choiceLatitude2 = Convert.ToInt16(Console.ReadLine());                        // user choose where to fly
                                    Console.Write("Enter coordinate of longitude for target: ");
                                    short choiseLongitude2 = Convert.ToInt16(Console.ReadLine());

                                    Coords toPos2 = new Coords(choiceLatitude2, choiseLongitude2);

                                    helList[index].DestroyTarget(toPos2);

                                    if (helList[index].Armed == true)
                                    {
                                        helList[index].BattleCounter();

                                        helList[index].VictimsCounter();
                                    }

                                    Console.ReadKey();

                                    Console.Clear();

                                    break;

                                case 3:

                                    helList[index].BacktoBase();

                                    //Console.WriteLine("\n\t\t      Action: \n\n\t\t\tPress:\n\n\t\t1 -> Arm");
                                    //short choise5 = Convert.ToInt16(Console.ReadLine());                                 // user choose action
                                    //Thread.Sleep(500);

                                    //switch (choise5)
                                    //{
                                    //    case 1:
                                    //        helList[index].Arm();
                                    //        break;

                                    //    case 2:
                                    //        helList[index].Refuel();
                                    //        break;

                                    //}

                                    //Console.Clear();
                                    break;
                            }

                            break;

                        case 4 when index != -1:

                            Console.WriteLine("\n\t\t      Action: \n\n\t\t\tPress:\n\n\t\t1 -> Arm \n\t\t2 -> Refuel");
                            short choise6 = Convert.ToInt16(Console.ReadLine());                                 // user choose action
                            Thread.Sleep(500);

                            switch (choise6)
                            {
                                case 1:
                                    helList[index].Arm();
                                    break;

                                case 2:
                                    helList[index].Refuel();
                                    break;
                            }

                            break;

                        case 5:                           
                                                      
                            Helicopter temp=Helicopter.CreateHelicopter();
                            helList.Add(temp);
                            break;

                        case 6:

                            Environment.Exit(0);
                            break;

                        default:

                            if (index == -1)
                            {
                                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\t\t\tChoose helicopter first...");
                                Console.ReadKey();
                            }

                            break;
                    }
                }

                if ((index!=-1) && (helList[index].DestroyedHel == true))
                {

                    helList.RemoveAt(index);
                    index = -1;
                }
            }

            while (true);
        }
    }
}
