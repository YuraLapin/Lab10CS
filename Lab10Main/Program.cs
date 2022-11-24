using Lab9Main;
using System.Collections.Immutable;
using System.Net;

namespace Lab10Main
{
    public class Program
    {            
        public static Random rand = new Random();

        public static void PrintArray(in IRandomInit[] arr)
        {
            Console.Write("[\n");
            if (arr.GetLength(0) > 0 && arr[0] != null)
            {
                for (int i = 0; i < arr.GetLength(0); ++i)
                {
                    Console.Write(arr[i].ConvertToString() + "\n");
                }
            }
            else
            {
                Console.Write("-\n");
            }
            Console.Write("]\n");
        }        

        public static void PrintArrayNonVirtual(in Transport[] arr)
        {
            Console.Write("[\n");
            if (arr.GetLength(0) > 0)
            {
                for (int i = 0; i < arr.GetLength(0); ++i)
                {
                    Console.Write(arr[i].ConvertToStringNonVirtual() + "\n");
                }
            }
            else
            {
                Console.Write("-\n");
            }
            Console.Write("]\n");
        }

        public static Transport FindMaxPower(in Transport [] arr)
        {
            var max = new Transport();
            if (arr.GetLength(0) > 0 && arr[0] != null)
            {
                max = arr[0];
                for (int i = 1; i < arr.GetLength(0); ++i)
                {
                    if (arr[i].power > max.power)
                    {
                        max = arr[i];
                    }
                }
            }
            return max;
        }

        public static int FindAvgPower(in List<Transport> list)
        {
            int avg = 0;
            foreach(Transport t in list)
            {
                avg += t.power;
            }
            return avg / list.Count();
        }        

        public static void Request47()
        {
            Console.WriteLine("Запрос 47. Самый мощный автомобиль в данной организации");
            int size1 = 4;
            int size2 = 5;
            var org1 = new Automobile[size1];
            org1[0] = new Automobile("automobile1", 90, 4);
            org1[1] = new Automobile("automobile2", 120, 4);
            org1[2] = new Automobile("automobile3", 120, 4);
            org1[3] = new Automobile("automobile4", 110, 6);
            var org2 = new Automobile[size2];
            org2[0] = new Automobile("automobile5", 500, 8);
            org2[1] = new Automobile("automobile6", 1, 4);
            org2[2] = new Automobile("automobile7", 500, 6);
            org2[3] = new Automobile("automobile8", 490, 4);
            org2[4] = new Automobile("automobile9", 13, 4);
            Console.WriteLine("Автомобили организации 1:");
            PrintArray(org1);
            Console.WriteLine("Автомобили организации 2:");
            PrintArray(org2);

            var userInteractor = new UserInteractor();
            int usrAns;
            do
            {
                usrAns = userInteractor.GetIntFromUser("Введите номер организации для поиска самого мощного автомобиля");
                if (usrAns != 1 && usrAns != 2)
                {
                    Console.WriteLine("Введен неверный номер");
                }
            }
            while (usrAns != 1 && usrAns != 2);

            Console.WriteLine("Самый мощный автомобиль:");
            if (usrAns == 1)
            {
                FindMaxPower(org1).Print();
            }
            else if (usrAns == 2)
            {
                FindMaxPower(org2).Print();
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public static void Request32()
        {
            Console.WriteLine("\n\nЗапрос 32. Средняя мощность всех транспортных средств заданного типа в организации");
            int size = 5;
            var vehicles = new Transport[size];
            vehicles[0] = new Automobile("automobile1", 100, 4);
            vehicles[1] = new Automobile("automobile2", 200, 6);
            vehicles[2] = new Train("train1", 100, 4);
            vehicles[3] = new Train("train2", 300, 12);
            var stations = new List<string>();
            stations.Add("station1");
            stations.Add("station2");
            vehicles[4] = new Express("express1", 500, 10, stations);
            Console.WriteLine("Транспортные средства:");
            PrintArray(vehicles);

            Console.WriteLine("1 - Automobile");
            Console.WriteLine("2 - Train");
            Console.WriteLine("3 - Express");
            var userInteractor = new UserInteractor();
            int usrAns;
            do
            {
                usrAns = userInteractor.GetIntFromUser("Введите номер типа транспортного средства для поиска средней мощности");
                if (usrAns != 1 && usrAns != 2 && usrAns != 3)
                {
                    Console.WriteLine("Введен неверный номер");
                }
            }
            while (usrAns != 1 && usrAns != 2 && usrAns != 3);

            var toFind = new List<Transport>();
            for (int i = 0; i < size; ++i)
            {
                if (usrAns == 1 && vehicles[i] is Automobile)
                {
                    toFind.Add(vehicles[i]);
                }
                else if (usrAns == 2 && vehicles[i] is Train && vehicles[i] is not Express)
                {
                    toFind.Add(vehicles[i]);
                }
                else if (usrAns == 3 && vehicles[i] is Express)
                {
                    toFind.Add(vehicles[i]);
                }
            }

            Console.WriteLine("Средняя мощность объектов заданного типа - " + FindAvgPower(toFind));
        }

        public static void Request24()
        {
            Console.WriteLine("\n\nЗапрос 24. Количество указанного транспортного средства в автопарке");
            int size = 5;
            var vehicles = new Transport[size];
            vehicles[0] = new Automobile("automobile1", 100, 4);
            vehicles[1] = new Automobile("automobile2", 200, 6);
            vehicles[2] = new Train("train1", 100, 4);
            vehicles[3] = new Train("train2", 300, 12);
            var stations = new List<string>();
            stations.Add("station1");
            stations.Add("station2");
            vehicles[4] = new Express("express1", 500, 10, stations);
            Console.WriteLine("Транспортные средства:");
            PrintArray(vehicles);

            Console.WriteLine("1 - Automobile");
            Console.WriteLine("2 - Train");
            Console.WriteLine("3 - Express");
            var userInteractor = new UserInteractor();
            int usrAns;
            do
            {
                usrAns = userInteractor.GetIntFromUser("Введите номер типа транспортного средства для подсчета количества");
                if (usrAns != 1 && usrAns != 2 && usrAns != 3)
                {
                    Console.WriteLine("Введен неверный номер");
                }
            }
            while (usrAns != 1 && usrAns != 2 && usrAns != 3);

            int count = 0;
            for (int i = 0; i < size; ++i)
            {
                if (usrAns == 1 && vehicles[i] is Automobile)
                {
                    ++count;
                }
                else if (usrAns == 2 && vehicles[i] is Train && vehicles[i] is not Express)
                {
                    ++count;
                }
                else if (usrAns == 3 && vehicles[i] is Express)
                {
                    ++count;
                }
            }

            Console.WriteLine("Количество объектов заданного типа - " + count);
        }

        public static void Task1()
        {
            Console.WriteLine("Задание 1");
            int size = 4;
            Transport[] arr = new Transport[size];
            arr[0] = new Transport("transport", 50);
            arr[1] = new Automobile("automobile", 100, 4);
            arr[2] = new Train("train", 150, 5);
            var stations = new List<string>();
            stations.Add("station1");
            stations.Add("station2");
            arr[3] = new Express("express", 200, 10, stations);

            Console.WriteLine("С виртуальным методом:");
            PrintArray(arr);
            Console.WriteLine("\nБез виртуальных методов:");
            PrintArrayNonVirtual(arr);
        }

        public static void Task2()
        {
            Console.WriteLine("\n\n\n\nЗадание 2");
            Request47();
            Request32();
            Request24();
        }

        public static void Task3()
        {
            Console.WriteLine("\n\n\n\nЗадание 3");
            int size = 5;
            var arr = new IRandomInit[size];

            arr[0] = new Person();
            arr[1] = new Transport();
            arr[2] = new Automobile();
            arr[3] = new Train();
            arr[4] = new Express();

            foreach (IRandomInit iri in arr)
            {
                iri.RandomInit();
            }

            Console.WriteLine("Наш массив");
            PrintArray(arr);

            Array.Sort(arr);
            Console.WriteLine("\nОтсортированный массив:");
            PrintArray(arr);
        }

        public static int Main()
        {
            Task1();
            Task2();
            Task3();            
            return 0;
        }
    }
}