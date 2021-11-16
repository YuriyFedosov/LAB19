using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp1
{

    class Program
    {
        /*1.    Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  
         * частотой  работы  процессора,  объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, 
         * стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии. Создать
         * список, содержащий 6-10 записей с различным набором значений характеристик.
Определить:
- все компьютеры с указанным процессором. Название процессора запросить у пользователя;
- все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
- вывести весь список, отсортированный по увеличению стоимости;
- вывести весь список, сгруппированный по типу процессора;
- найти самый дорогой и самый бюджетный компьютер;
- есть ли хотя бы один компьютер в количестве не менее 30 штук?*/
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>()  //Создание списка компьютеров на основе класса
            {
                new Computer(){pcKod="4842394", pcName="MateBook D14", pcProcType="i5",pcProcFreq=1600, pcMemCap=8, pcHDDCap=256, pcVidCap=2, pcCost=49999, pcInStock = 78 },
                new Computer(){pcKod="4769003", pcName="MateBook D16", pcProcType="Ryzen 5",pcProcFreq=3000, pcMemCap=16, pcHDDCap=512, pcVidCap=2, pcCost=67699, pcInStock = 5},
                new Computer() { pcKod = "4841525", pcName = "MateBook D15", pcProcType = "i3", pcProcFreq = 2100, pcMemCap = 8, pcHDDCap = 256, pcVidCap = 2, pcCost = 47999, pcInStock = 41},
                new Computer() { pcKod = "4713589", pcName = "MateBooK 14", pcProcType = "i5",pcProcFreq = 2400, pcMemCap = 16, pcHDDCap = 512, pcVidCap = 4, pcCost = 84999, pcInStock = 24},
                new Computer() { pcKod = "4458965", pcName = "MateBook D15", pcProcType = "i5",pcProcFreq = 1600, pcMemCap = 16, pcHDDCap = 512, pcVidCap =  1, pcCost = 69999, pcInStock = 20},
                new Computer() { pcKod = "4568954", pcName = "MateBook X Pro", pcProcType = "i7",pcProcFreq = 2800, pcMemCap = 16, pcHDDCap = 1024, pcVidCap = 8,pcCost = 115899, pcInStock = 4}
    };
            Console.Write("Для поиска позиций введите требуемую марку процессора: "); // все компьютеры с указанным процессором
            string procType = Console.ReadLine();
            
            List<Computer> computers = (from d in listComputer
                                        where d.pcProcType == procType
                                        select d).ToList();
            if (computers.Count > 0)
            {
                foreach (Computer comp in computers)
                {
                Console.WriteLine($"Код: {comp.pcKod} Наименование: {comp.pcName} Стоимость: {comp.pcCost} В наличии: {comp.pcInStock} шт.");
                }
            }
            else
            {
                Console.WriteLine("\nПозиции с требуемым запросом отсутствуют");
            }

           
            Console.Write("\nДля продолжения нажмите любую клавишу ... ");
            Console.ReadKey();
            
            Console.Clear();
            Console.Write("Для поиска позиций введите требуемый объем оперативной память (не менее): "); //все компьютеры с объемом ОЗУ не ниже, чем указано.
            int capacMem = Convert.ToInt32(Console.ReadLine());

            computers = (from d in listComputer
                         where d.pcMemCap >= capacMem
                         select d).ToList();

            if (computers.Count > 0)
            {
                foreach (Computer comp in computers)
                {
                    Console.WriteLine($"Код: {comp.pcKod} Наименование: {comp.pcName} Объем памяти: {comp.pcMemCap} Стоимость: {comp.pcCost} В наличии: {comp.pcInStock} шт.");
                }
            }
            else
            {
                Console.WriteLine("\nПозиции с требуемым запросом отсутствуют");
            }
            Console.Write("\nДля продолжения нажмите любую клавишу ... ");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("Сортировка позиций списка по цене"); //вывести весь список, отсортированный по увеличению стоимости

            computers = (from d in listComputer
                         orderby d.pcCost ascending
                         select d).ToList();

            foreach (Computer comp in computers)
            {
                Console.WriteLine($"Код: {comp.pcKod} Наименование: {comp.pcName} Стоимость: {comp.pcCost} В наличии: {comp.pcInStock} шт.");
            }
            Console.Write("Для продолжения нажмите любую клавишу ... ");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Группировка позиций списка по типу процессора:"); //вывести весь список, сгруппированный по типу процессора
            var groupComputers = (from d in listComputer
                                  group d by d.pcProcType).ToList();

            foreach (var i in groupComputers)
            {
                Console.WriteLine(i.Key);
                foreach (var x in i)
                {
                    Console.WriteLine($"Код: {x.pcKod} Наименование: {x.pcName} Цена: {x.pcCost} В наличии: {x.pcInStock} шт.");
                }
            }
            Console.Write("Для продолжения нажмите любую клавишу ... ");
            Console.ReadKey();
            Console.Clear();

            double maxCost = listComputer.Max(m => m.pcCost); //найти самый дорогой компьютер
            computers = (from d in listComputer
                         where d.pcCost == maxCost
                         select d).ToList();

            Console.WriteLine("Выбор самого дорогого товара из списка:"); 
            foreach (Computer compMax in computers)
            {
                Console.WriteLine($"Код: {compMax.pcKod} Наименование: {compMax.pcName} Стоимость: {compMax.pcCost} В наличии: {compMax.pcInStock} шт.");
            }
            Console.Write("Для продолжения нажмите любую клавишу ... ");
            Console.ReadKey();
            Console.Clear();


            double minCost = listComputer.Min(m => m.pcCost); //найти самый бюджетный компьютер
            computers = (from d in listComputer
                         where d.pcCost == minCost
                         select d).ToList();

            Console.WriteLine("Выбор самого бюджетного товара из списка:"); 
            foreach (Computer compMin in computers)
            {
                Console.WriteLine($"Код:  {compMin.pcKod}  Наименование:  {compMin.pcName}  Стоимость:  {compMin.pcCost}  В наличии:  {compMin.pcInStock}  шт.");
            }
            Console.Write("Для продолжения нажмите любую клавишу ... ");
            Console.ReadKey();
            Console.Clear();

            Console.Write("Модели от 30 штук на складе "); //есть ли хотя бы один компьютер в количестве не менее 30 штук?
            bool countTh = listComputer.Any(c => c.pcInStock >= 30);
            if (countTh)
            {
                Console.WriteLine("в наличии");
            }
            else
            {
                Console.WriteLine("отсутствуют");
            }

            Console.Write("\nДля завершения нажмите любую клавишу ... ");
            Console.ReadKey();
        }
    }
    class Computer
    {
        public string pcKod { get; set; }
        public string pcName { get; set; }
        public string pcProcType { get; set; }
        public double pcProcFreq { get; set; }
        public int pcMemCap { get; set; }
        public int pcHDDCap { get; set; }
        public int pcVidCap { get; set; }
        public double pcCost { get; set; }
        public int pcInStock { get; set; }
    }

}
