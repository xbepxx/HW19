using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19
{
    /*1.    Модель компьютера  характеризуется кодом  и названием  марки компьютера, типом  процессора,  частотой работы  процессора,  
     * объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством экземпляров, 
     * имеющихся в наличии.Создать список, содержащий 6-10 записей с различным набором значений характеристик.
Определить:
- все компьютеры с указанным процессором.Название процессора запросить у пользователя;
- все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
- вывести весь список, отсортированный по увеличению стоимости;
- вывести весь список, сгруппированный по типу процессора;
- найти самый дорогой и самый бюджетный компьютер;
- есть ли хотя бы один компьютер в количестве не менее 30 штук?*/
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computer = new List<Computer>()
            {
                new Computer() {code=1, marc="r1d1", type_proc="intel", proc_freq=2.7, ozu=8, d_value=200, v_value=2, price=25, quan=5},
                new Computer() {code=2, marc="r2d2", type_proc="AMD", proc_freq=2.5, ozu=6, d_value=250, v_value=3, price=35, quan=25},
                new Computer() {code=3, marc="r3d3", type_proc="AMD", proc_freq=2.7, ozu=4, d_value=100, v_value=4, price=25, quan=10},
                new Computer() {code=4, marc="r4d4", type_proc="intel", proc_freq=2.2, ozu=8, d_value=120, v_value=1, price=25, quan=15},
                new Computer() {code=5, marc="r5d5", type_proc="intel", proc_freq=1.5, ozu=8, d_value=220, v_value=2, price=55, quan=40},
                new Computer() {code=6, marc="r6d6", type_proc="AMD", proc_freq=2.2, ozu=2, d_value=100, v_value=4, price=45, quan=25},
                new Computer() {code=7, marc="r7d7", type_proc="intel", proc_freq=2.7, ozu=4, d_value=500, v_value=2, price=25, quan=35}
            };
            /*все компьютеры с указанным процессором.Название процессора запросить у пользователя*/
            {
                Console.WriteLine("Введите название процессора");
                string proc = Console.ReadLine();
                Console.WriteLine("Вам подходят следующие компьютеры");
                List<Computer> computers = computer
                    .Where(d => d.type_proc == proc)
                    .ToList();
                foreach (Computer d in computer)
                {
                    Console.WriteLine($"{d.code}, {d.marc}, {d.type_proc}, {d.proc_freq}, {d.ozu}, {d.d_value}, {d.price}, {d.quan}");
                }
                Console.WriteLine("=================================");
            }
            /*===================================================*/
            /* все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя */
            {
                Console.WriteLine("Введите объём оперативной памяти");
                int ozu_vol = int.Parse(Console.ReadLine());
                Console.WriteLine("Вам подходят следующие компьютеры");
                List<Computer> computers = computer
                    .Where(p => p.ozu <= ozu_vol)
                    .ToList();
                foreach (Computer p in computer)
                {
                    Console.WriteLine($"{p.code}, {p.marc}, {p.type_proc}, {p.proc_freq}, {p.ozu}, {p.d_value}, {p.price}, {p.quan}");
                }
                Console.WriteLine("=================================");
            }
            /*===================================================*/
            /* вывести весь список, отсортированный по увеличению стоимости */
            {
                Console.WriteLine("Список компьютеров по стоимости");
                var computers = computer
                    .OrderBy(d => d.price)
                    .ToList();
                foreach (var d in computers)
                {
                    Console.WriteLine($"{d.code}, {d.marc}, {d.type_proc}, {d.proc_freq}, {d.ozu}, {d.d_value}, {d.price}, {d.quan}");
                }
                Console.WriteLine("=================================");
            }
            /*===================================================*/
            /* вывести весь список, сгруппированный по типу процессора */
            {
                Console.WriteLine("Список компьютеров сгрупированный по типу процессора");
                var computers_gr = computer
                    .GroupBy(d => d.type_proc);
                foreach (IGrouping<string, Computer> data in computers_gr)
                {
                    Console.WriteLine(data.Key);
                    foreach (var t in data)
                    {
                        Console.WriteLine(t.marc);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("=================================");
            }
            /*===================================================*/
            /* найти самый дорогой и самый бюджетный компьютер*/
            {
                Console.WriteLine("Самый дорогой и самый дешевый процессор");
                var max = computer
                    .Max(d => d.price);
                Console.WriteLine(max);
                Console.WriteLine("Самый дорогой и самый дешевый процессор");
                var min = computer
                    .Min(s => s.price);
                Console.WriteLine(min);
                Console.WriteLine("=================================");
            }
            /* есть ли хотя бы один компьютер в количестве не менее 30 штук?*/
            {
                Console.WriteLine("Каких компьютеров не менее 30 штук?");
                var any = computer
                    .Any(d => d.quan >= 30);
                if (any==true)
                {
                    Console.WriteLine("Такой компбютер есть в списке");
                }
            }
            Console.ReadKey();
        }
    }
    class Computer
    {
        /*код компьютера*/
        public int code { set; get; }
        /*марка компьютера*/
        public string marc { set; get; }
        /*тип роцессора*/
        public string type_proc { set; get; }
        /*частота процессора*/
        public double proc_freq { set; get; }
        /*ОЗУ*/
        public int ozu { set; get; }
        /*объём диска*/
        public int d_value { set; get; }
        /*объём памяти видеокарты*/
        public int v_value { set; get; }
        /*стоимость*/
        public double price { set; get; }
        /*количество*/
        public int quan { set; get; }
    }
}
