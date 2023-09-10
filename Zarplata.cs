using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_3
{
    internal class Zarplata
    {
        public string zarplataName;
        public string zarplataPozition; // должность
        public double zarplataOklad; // оклад
        public double zarplataCost; // ставка 0,25-1,75
        public double zarplataStaj; // стаж 0-50
        public double zarplataWorking; // отработанные часы 0-240
        public double zarplataMedical; // больничный 25 р/день
        private object get;

        void Print()
        {
            Console.WriteLine("zarplataName: " + zarplataName);
            Console.WriteLine("zarplataPozition" + zarplataPozition);
            Console.WriteLine("zarplataOklad" + zarplataOklad);
            Console.WriteLine("zarplataCost" + zarplataCost);
            Console.WriteLine("zarplataStaj" + zarplataStaj);
            Console.WriteLine("zarplataWorking" + zarplataWorking);
            Console.WriteLine("zarplataMedical" + zarplataMedical);
        }
        public override string ToString()
        {
            return $"" +
                $"Сотрудник {zarplataName} " +
                $"| занимающий должность {zarplataPozition} " +
                $"| стаж работы {zarplataStaj} лет " +
                $"| оклад {zarplataOklad} рублей " +
                $"| ставка {zarplataCost} " +
                $"| количество часов почасовой оплаты " +
                $"{zarplataWorking} " +
                $"| количество дней оплаченных по больничному листу {zarplataMedical} " +
                $"| начислена зарплата {formatDouble(Raschet())} рублей";
        }
        public double Raschet() //расчет зарплаты
        {

            const int SREDNEE_KOLICHESTWO_DNEY = 22;
            const int RABOCHIY_DEN_CHASOW = 8;
            double okladZaDen = zarplataOklad / (double)SREDNEE_KOLICHESTWO_DNEY;
            double otrabotanoDney = zarplataWorking / (double)RABOCHIY_DEN_CHASOW;
            double zarplataBezBolnichnogo = okladZaDen * otrabotanoDney * zarplataCost;

            if (zarplataStaj > 15)
            {
                zarplataBezBolnichnogo = zarplataBezBolnichnogo * 1.2;
            }
            else if (zarplataStaj <= 10)
            {
                zarplataBezBolnichnogo = zarplataBezBolnichnogo * 1.0;
            }
            else
            {
                zarplataBezBolnichnogo = zarplataBezBolnichnogo * 1.1;
            }

            const double ZARPLATA_ZA_DEN_BOLNICHNOGO = 25.0;
            double zarplataZaBolnichiy = ZARPLATA_ZA_DEN_BOLNICHNOGO * zarplataMedical;


            return zarplataBezBolnichnogo + zarplataZaBolnichiy;
        }

        public static string formatDouble(double number)
        {
            return String.Format("{0:0.##}", number);
        }

        public double ZarplataMedical
        {
            get
            {
                return zarplataMedical;
            }
            
            set
            {
                zarplataMedical = value >= 0 ? value : 0;
            }
        }

        /**
         * Болеет ли работник больше 20 дней
         */
        public bool isLongSick()
        {
            return zarplataMedical > 20;
        }

        /**
         * Уволить
         */
        public void dismiss()
        {
            zarplataOklad = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Работник {zarplataName} уволен!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Уволить, если долго болеет (больше 20 дней)
        /// </summary>
        public void dismissIfLongSick()
        {
            if ( this.isLongSick() )
            {
                this.dismiss();
            }
        }


        public static int moreOklad(Zarplata left, Zarplata right)
        {
            return (int)(left.Raschet() - right.Raschet());
        }

        /// <summary>
        /// Является ли зарплата сотрудника больше, чем у его коллеги
        /// </summary>
        public bool isMoreSalary(Zarplata collegue)
        {
            return 0 < Zarplata.moreOklad(this, collegue);
        }


        /// <summary>
        /// Самый высокооплачиваемый сотрудник из трёх
        /// </summary>
        public static Zarplata richest(Zarplata first, Zarplata second, Zarplata third)
        {
            var list = new List<Zarplata> { first, second, third };
            list.Sort(Zarplata.moreOklad);

            return list.Last();
        }
    }
}