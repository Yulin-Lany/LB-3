namespace LB_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zarplata Ob1 = new Zarplata();
            Ob1.zarplataName = "Левин Б.Л.";
            Ob1.zarplataPozition = "главный инженер";
            Ob1.zarplataStaj = 25;
            Ob1.zarplataOklad = 1500.53;
            Ob1.zarplataCost = 1.0;
            Ob1.zarplataWorking = 196.7;
            Ob1.zarplataMedical = 0;
            var ob1Zp = Ob1.Raschet();
            

            Zarplata Ob2 = new Zarplata();
            Ob2.zarplataName = "Кузьмин А.Б.";
            Ob2.zarplataPozition = "начальник отдела";
            Ob2.zarplataStaj = 18;
            Ob2.zarplataOklad = 1300.97;
            Ob2.zarplataCost = 1.25;
            Ob2.zarplataWorking = 172.7;
            Ob2.zarplataMedical = 3;

            Zarplata Ob3 = new Zarplata();
            Ob3.zarplataName = "Савина М.Е.";
            Ob3.zarplataPozition = "ведущий инженер";
            Ob3.zarplataStaj = 15;
            Ob3.zarplataOklad = 1000.15;
            Ob3.zarplataCost = 1.25;
            Ob3.zarplataWorking = 176.0;
            Ob3.zarplataMedical = 0;

            Zarplata Ob4 = new Zarplata();
            Ob4.zarplataName = "Лисова Е.И.";
            Ob4.zarplataPozition = "инженер 1-ой категории";
            Ob4.zarplataStaj = 10;
            Ob4.zarplataOklad = 900.27;
            Ob4.zarplataCost = 1.0;
            Ob4.zarplataWorking = 136.0;
            Ob4.zarplataMedical = 5;

            Zarplata Ob5 = new Zarplata();
            Ob5.zarplataName = "Коваленок Е.А.";
            Ob5.zarplataPozition = "инженер 2-ой категории";
            Ob5.zarplataStaj = 8;
            Ob5.zarplataOklad = 850.74;
            Ob5.zarplataCost = 1.1;
            Ob5.zarplataWorking = 176.0;
            Ob5.zarplataMedical = 0;

            Zarplata Ob6 = new Zarplata();
            Ob6.zarplataName = "Липницкий И.В.";
            Ob6.zarplataPozition = "инженер 2-ой категории";
            Ob6.zarplataStaj = 5;
            Ob6.zarplataOklad = 850.74;
            Ob6.zarplataCost = 1.0;
            Ob6.zarplataWorking = 8.0;
            Ob6.ZarplataMedical = 21;

            Zarplata Ob7 = new Zarplata();
            Ob7.zarplataName = "Сыткина И.В.";
            Ob7.zarplataPozition = "инженер";
            Ob7.zarplataStaj = 2;
            Ob7.zarplataOklad = 680.32;
            Ob7.zarplataCost = 0.8;
            Ob7.zarplataWorking = 140.8;
            Ob7.zarplataMedical = 0;

            Console.WriteLine(Ob1);
            Console.WriteLine();
            Console.WriteLine(Ob2);
            Console.WriteLine();
            Console.WriteLine(Ob3);
            Console.WriteLine();
            Console.WriteLine(Ob4);
            Console.WriteLine();
            Console.WriteLine(Ob5);
            Console.WriteLine();
            Console.WriteLine(Ob6);
            Console.WriteLine();
            Console.WriteLine(Ob7);
            Console.WriteLine();

            Ob6.dismissIfLongSick();
            Ob7.dismissIfLongSick();
            Console.WriteLine();

            if ( Ob1.isMoreSalary(Ob7) )
            {
                Console.WriteLine($"У работника {Ob1.zarplataName}({Ob1.Raschet()}) зарплата больше, чем у работника {Ob7.zarplataName}({Ob7.Raschet()})");
            }
            else
            {
                Console.WriteLine($"У работника {Ob1.zarplataName}({Ob1.Raschet()}) зарплата не больше, чем у работника {Ob7.zarplataName}({Ob7.Raschet()})");
            }
            
            var richest = Zarplata.richest(Ob2, Ob5, Ob3);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Самая большая зарплата:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Ob2.zarplataName}({Ob2.Raschet()})");
            Console.WriteLine($"{Ob5.zarplataName}({Ob5.Raschet()})");
            Console.WriteLine($"{Ob3.zarplataName}({Ob3.Raschet()})");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Сотрудник с самой высокой зарплатой: {richest.zarplataName}({richest.Raschet()})");

            Console.ReadKey();
        }


        public static string formatDouble(double number)
        {
            return String.Format("{0:0.##}", number);
        }

    }
}