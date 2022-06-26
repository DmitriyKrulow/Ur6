using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ur6
{
    struct EmployeesList
    {
        public Worker[] Workers;
        public int LastID;
        public int NumberRecordsSave;
        public int NumberRows;
        /// <summary>
        /// Отображение записи по указанному номеру строки записи
        /// </summary>
        /// <param name="id">Номер из первого столбца строки</param>
        public void PrintWorkerID(int id)
        {
            Console.WriteLine($"{this.Workers[id].Id} " +
                                          $"{this.Workers[id].Date} " +
                                          $"{this.Workers[id].Name} " +
                                          $"{this.Workers[id].Age} " +
                                          $"{this.Workers[id].Height} " +
                                          $"{this.Workers[id].DateBirthday} " +
                                          $"{this.Workers[id].CityBirt}");
        }
        /// <summary>
        /// Отображение строки по присвоенному удентификатору
        /// </summary>
        /// <param name="id"></param>
        public void PrintWorkerNumber(int id)
        {
            for (int i = 0; i < this.Workers.Length; i++)
            {
                if (this.Workers[i].Id == id)
                {
                    Console.WriteLine($"{this.Workers[i].Id} " +
                                          $"{this.Workers[i].Date} " +
                                          $"{this.Workers[i].Name} " +
                                          $"{this.Workers[i].Age} " +
                                          $"{this.Workers[i].Height} " +
                                          $"{this.Workers[i].DateBirthday} " +
                                          $"{this.Workers[i].CityBirt}");
                }
            }

        }

        public int PrintAll()
        {
            int nemberLine = 0;
            for (int i = 0; i < Workers.Length; i++)
            {
                if (Workers[i].Id != 0)
                {
                    PrintWorkerNumber(Workers[i].Id);
                    nemberLine++;
                }

            }
            return nemberLine;
        }
        /// <summary>
        /// Добавление записи в память без сохранения
        /// </summary>
        /// <returns></returns>
        public bool AddWorker()
        {
            Console.WriteLine($"Добавить записть {LastID + 1}");
            DateTime date = DateTime.Now;
            DateTime dateBirthday;
            int yardateBirthday;
            int monatdateBirthday;
            int daydateBirthday;
            this.Workers[NumberRows].Id = LastID + 1;
            //// Определение даты и времени создания записи.
            this.Workers[NumberRows].Date = date;
            //// Ввод фамилии имени и отчества
            Console.WriteLine("Введите Фамилию");
            this.Workers[NumberRows].Name += Console.ReadLine() + " ";
            Console.WriteLine("Введите Имя");
            this.Workers[NumberRows].Name += Console.ReadLine() + " ";
            Console.WriteLine("Введите Отчество");
            this.Workers[NumberRows].Name += Console.ReadLine();
            Console.WriteLine("Введите рост");
            int.TryParse(Console.ReadLine(), out int rezHeight);
            this.Workers[NumberRows].Height += rezHeight;
            Console.WriteLine("Введите место рождения");
            this.Workers[NumberRows].CityBirt += "город " + Console.ReadLine();
            Console.WriteLine("Ввведите год рождения");
            int.TryParse(Console.ReadLine(), out yardateBirthday);
            Console.WriteLine("Ввведите месяц рождения");
            int.TryParse(Console.ReadLine(), out monatdateBirthday);
            Console.WriteLine("Ввведите день рождения");
            int.TryParse(Console.ReadLine(), out daydateBirthday);
            dateBirthday = new DateTime(yardateBirthday, monatdateBirthday, daydateBirthday);
            this.Workers[NumberRows].DateBirthday = dateBirthday;
            var age = DateTime.Now.Year - dateBirthday.Year;
            if (DateTime.Now.DayOfYear < date.DayOfYear) //на случай, если день рождения уже прошёл
                age++;
            this.Workers[NumberRows].Age = age;
            return true;
        }
        /// <summary>
        /// Устанавливает идентификатор в 0 строка с данным идентификатаром небудет сохранятся
        /// </summary>
        /// <param name="id">идентификатор строки для удаления</param>
        /// <returns></returns>
        public bool RemovalWorkerID(int id)
        {
            Console.WriteLine($"Удалить запись {id}");

            for (int i = 0; i < this.Workers.Length; i++)
            {
                if (this.Workers[i].Id == id)
                {
                    this.Workers[i].Id = 0;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Редактирование записи путем её ввода
        /// </summary>
        /// <param name="id">номер идентификатора для изменения</param>
        /// <returns></returns>
        public bool EditingWorkerID(int id)
        {
            Console.WriteLine($"Редактировать запись{id}");
            for (int i = 0; i < this.Workers.Length; i++)
            {
                if (this.Workers[i].Id == id)
                {
                    // Переписывание строки путем ввода параметров
                    DateTime date = DateTime.Now;
                    DateTime dateBirthday;
                    int yardateBirthday;
                    int monatdateBirthday;
                    int daydateBirthday;
                    //// Определение даты и времени создания записи.
                    this.Workers[i].Date = date;
                    //// Ввод фамилии имени и отчества
                    this.Workers[i].Name = "";
                    Console.WriteLine("Введите Фамилию");
                    this.Workers[i].Name += Console.ReadLine() + " ";
                    Console.WriteLine("Введите Имя");
                    this.Workers[i].Name += Console.ReadLine() + " ";
                    Console.WriteLine("Введите Отчество");
                    this.Workers[i].Name += Console.ReadLine();
                    Console.WriteLine("Введите рост");
                    int.TryParse(Console.ReadLine(), out int rezHeight);
                    this.Workers[i].Height = rezHeight;
                    Console.WriteLine("Введите место рождения");
                    this.Workers[i].CityBirt = "город " + Console.ReadLine();
                    Console.WriteLine("Ввведите год рождения");
                    int.TryParse(Console.ReadLine(), out yardateBirthday);
                    Console.WriteLine("Ввведите месяц рождения");
                    int.TryParse(Console.ReadLine(), out monatdateBirthday);
                    Console.WriteLine("Ввведите день рождения");
                    int.TryParse(Console.ReadLine(), out daydateBirthday);
                    dateBirthday = new DateTime(yardateBirthday, monatdateBirthday, daydateBirthday);
                    this.Workers[i].DateBirthday = dateBirthday;
                    var age = DateTime.Now.Year - dateBirthday.Year;
                    if (DateTime.Now.DayOfYear < date.DayOfYear) //на случай, если день рождения уже прошёл
                        age++;
                    this.Workers[i].Age = age;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Сортировка по дате создания записи между двух дат
        /// </summary>
        /// <param name="startingdate">Начальная дата</param>
        /// <param name="enddate">конечная дата</param>
        /// <returns></returns>
        public bool LoadingRecordsDateRange(DateTime startingdate, DateTime enddate)
        {
            Console.WriteLine($"Начальная дата {startingdate} конечная дата {enddate}");
            for (int i = 0; i < this.Workers.Length; i++)
            {
                if ((this.Workers[i].Date >= startingdate) && (this.Workers[i].Date <= enddate))
                {
                    PrintWorkerID(i);
                }
            }
            return true;
        }
        /// <summary>
        /// Сортировка по возрастанию и убыванию даты создания записи
        /// </summary>
        /// <param name="flag">true по возрастанию false по убыванию</param>
        public void SortAscendingDescendingDates(bool flag)
        {
            List<Worker> ListWorkers = Workers.ToList<Worker>();
            ListWorkers.Sort();
            if (flag)
            {
                Console.WriteLine("Возрастание.");
                foreach (Worker worker in ListWorkers)

                {
                    if (worker.Id != 0)
                    {
                        PrintWorkerNumber(worker.Id);
                    }

                }
            }
            else
            {
                Console.WriteLine("Убывание.");
                for (int i = ListWorkers.Capacity - 1; i >= 0; i--)
                {
                    if (ListWorkers[i].Id != 0)
                    {
                        PrintWorkerNumber(ListWorkers[i].Id);
                    }
                }
            }
        }
        /// <summary>
        /// Запись изменений в файл
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool WritingChangesFile(string filename)
        {
            Console.WriteLine($"Сохранение {filename}");
            string[] addLines = new string[7];
            int numberLine = 0;
            for (int i = 0; i < Workers.Length; i++)
            {
                if (Workers[i].Id != 0)
                {
                    numberLine++;
                }
            }
            string[] rezultStr = new string[numberLine];
            numberLine = 0;
            for (int i = 0; i < Workers.Length; i++)
            {
                if (Workers[i].Id != 0)
                {
                    //Формирование записи.
                    rezultStr[numberLine] = $"{this.Workers[i].Id}#" +
                                          $"{this.Workers[i].Date}#" +
                                          $"{this.Workers[i].Name}#" +
                                          $"{this.Workers[i].Age}#" +
                                          $"{this.Workers[i].Height}#" +
                                          $"{this.Workers[i].DateBirthday}#" +
                                          $"{this.Workers[i].CityBirt}";
                    numberLine++;
                }
            }

            if (File.Exists(filename))
            {
                File.WriteAllLines(@"Worker.txt", rezultStr);
                Console.WriteLine("Сохранено.");
                Console.ReadLine();
            }
            else
            {
                return false;
            }
            return true;
        }
        #region Конструктор
        /// <summary>
        /// Конструктор списка сотрудников
        /// </summary>
        /// <param name="workers">Массив сотрудников</param>
        /// <param name="lastID">Последний ID  в файле</param>
        /// <param name="numberRecordsSave">количество записей без сохранения</param>
        /// <param name="numberRows">количсество строк в файле</param>
        public EmployeesList(Worker[] workers, int lastID, int numberRecordsSave, int numberRows)
        {
            this.Workers = workers;
            this.LastID = lastID;
            this.NumberRecordsSave = numberRecordsSave;
            this.NumberRows = numberRows;
        }
        #endregion
    }
}
