using System;
using System.IO;

namespace Ur6
{
    class Program
    {
        /// <summary>
        /// Проверяет наличие файла со списком сотрудников
        /// </summary>
        /// <returns>возвращает true если файл существует</returns>
        private static bool CheckingFile(string filename)
        {
            if (File.Exists(filename)) // @"Worker.txt"
            {
                return true;
            }
            else
            {
                Console.WriteLine("Файл не существует.\nСначала над создать запись хотябы на одного работника.");
                return false;
            }
        }
        /// <summary>
        /// Запрос на выбор действия у пользователя.
        /// </summary>
        /// <returns>Выдает значение 0,1 или 2</returns>
        private static int SelectionScreenSaver()
        {
            int numberRows = 1;
            int limitation = 2;
            bool checkFlag = false;

            while (!checkFlag || numberRows > limitation)
            {
                Console.Clear();
                Console.WriteLine("Чтобы вывести данные на экран нажмите [1]\n" +
                  "Чтобы заполнить данные и добавить новую запись" +
                  "нажмите [2]\n" +
                  "Просто выйти нажми [0]");
                Console.ForegroundColor = ConsoleColor.Green;
                checkFlag = int.TryParse(Console.ReadLine().Trim(), out numberRows);
                Console.ResetColor();
            }
            return numberRows;
        }
        /// <summary>
        /// Вывод файла на экран
        /// </summary>
        private static int EditorScreenSaver(EmployeesList employeesList, string filename, int AddID)
        {
            Console.Clear();
            Console.WriteLine("Редактирование.");
            Console.WriteLine($"Количество строк {employeesList.PrintAll()}\n" +
                              $"Для продолжения нажмите ENTER.");
            Console.ReadLine();
            int numberRows = 1;
            int limitation = 8;
            bool checkFlag = false;
            while (!checkFlag || numberRows > limitation)
            {
                Console.Clear();
                Console.WriteLine("Просмотр записи [1]\n" +
                                  "Создание записи [2]\n" +
                                  "Удаление записи [3]\n" +
                                  "Редактирование записи [4]\n" +
                                  "Загрузка записей в выбранном диапазоне дат [5]\n" +
                                  "Сортировка по возрастанию [6]\n" +
                                  "Сортировка по убыванию [7]\n" +
                                  "Сохранение [8]\n" +
                                  "Просто выйти нажми [0]");
                Console.ForegroundColor = ConsoleColor.Green;
                checkFlag = int.TryParse(Console.ReadLine().Trim(), out numberRows);
                Console.ResetColor();
            }
            return numberRows;
        }
        /// <summary>
        /// Отображение списка из файла
        /// </summary>
        /// <param name="filename"></param>
        private static void DisplayDataScreen(string filename)
        {
            Console.Clear();
            if (CheckingFile(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                string[] words;
                foreach (var item in lines)
                {
                    words = item.Split('#');
                    foreach (var item2 in words)
                    {
                        Console.Write($"{item2} ");
                    }
                    Console.WriteLine("\n--------------------------------------------------------------------");
                }
            }
        }
        /// <summary>
        /// Получение количест записей в файле
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static int CountingRecords(string filename)
        {
            if (CheckingFile(filename))
            {
                int rezult;
                string[] lines = File.ReadAllLines(filename);
                string[] words;
                words = lines[lines.Length - 1].Split('#');
                int.TryParse(words[0], out rezult);

                return rezult;
            }
            return -1;
        }
        /// <summary>
        /// Получение числа строк.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static int CountingLines(string filename)
        {
            if (CheckingFile(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                return lines.Length;
            }
            return -1;
        }
        /// <summary>
        /// Формирование и запись в файл данных о сотруднике.
        /// </summary>
        private static void CreateEmployeeDirectory(EmployeesList employeesList, string filename, int AddID)
        {
            bool endFlag = true;
            int numberRows;
            Console.Clear();
            Console.WriteLine("Редактирование.");
            LoadingEmployeesList(employeesList, filename, AddID);
            Console.WriteLine($"Количество строк {employeesList.NumberRows}\n" +
                              $"Для продолжения нажмите ENTER.");
            Console.ReadLine();
            while (endFlag)
            {
                switch (EditorScreenSaver(employeesList, filename, AddID))
                {
                    case 0:
                        Console.WriteLine("Редактирование завершено. Чтобы выйти в основное меню нажмите Enter.");
                        endFlag = false;
                        Console.ReadLine();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Ввведите ID записи  для просмотра, хотя они и так видны ;)");
                        int.TryParse(Console.ReadLine().Trim(), out numberRows);
                        employeesList.PrintWorkerNumber(numberRows);
                        Console.ReadKey();
                        break; ;
                    case 2:
                        Console.Clear();
                        employeesList.AddWorker();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Ввведите ID записи  для удаления");
                        int.TryParse(Console.ReadLine().Trim(), out numberRows);
                        employeesList.RemovalWorkerID(numberRows);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Ввведите ID записи  для редактиования");
                        int.TryParse(Console.ReadLine().Trim(), out numberRows);
                        employeesList.EditingWorkerID(numberRows);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Введите сначала начальную и конечную дату для вывода строк" +
                                          "в формата год.месяц.день :");
                        employeesList.LoadingRecordsDateRange(DateTime.Parse(Console.ReadLine()), DateTime.Parse(Console.ReadLine()));
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        employeesList.SortAscendingDescendingDates(true);
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        employeesList.SortAscendingDescendingDates(false);
                        Console.ReadLine();
                        break;
                    case 8:
                        Console.Clear();
                        employeesList.WritingChangesFile(filename);
                        break;
                    default:
                        Console.WriteLine("Ошибка: Некорректное значение!");
                        endFlag = false;
                        Console.ReadKey();
                        break;
                }
            }
        }
        /// <summary>
        /// Загрузка в память записей и файлов для отображения и редактирования
        /// </summary>
        /// <param name="loadingList">Структура для записей</param>
        /// <param name="filename">Название файлы</param>
        /// <param name="AddID">Сколько было загружено записей</param>
        /// <returns></returns>
        private static int LoadingEmployeesList(EmployeesList loadingList, string filename, int AddID)
        {
            if (CheckingFile(filename))
            {
                Console.WriteLine("Загрузка записей ...");
                if (loadingList.Workers != null)
                {
                    int rezult;
                    string[] lines = File.ReadAllLines(filename);
                    string[] words;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        words = lines[i].Split('#');
                        // ID пользователей
                        int.TryParse(words[0], out rezult);
                        loadingList.Workers[i].Id = rezult;
                        // Дата создания записи
                        loadingList.Workers[i].Date = DateTime.Parse(words[1]);
                        // ФИО
                        loadingList.Workers[i].Name = words[2];
                        // Возраст
                        int.TryParse(words[3], out int rezAge);
                        loadingList.Workers[i].Age = rezAge;
                        // Рост
                        int.TryParse(words[4], out int rezHeight);
                        loadingList.Workers[i].Height = rezHeight;
                        // Дата рождения
                        loadingList.Workers[i].DateBirthday = DateTime.Parse(words[5]);
                        // Город рождения
                        loadingList.Workers[i].CityBirt = words[6];

                        Console.WriteLine($"Worker >>> {loadingList.Workers[i].Id} " +
                                          $"{loadingList.Workers[i].Date} " +
                                          $"{loadingList.Workers[i].Name} " +
                                          $"{loadingList.Workers[i].Age} " +
                                          $"{loadingList.Workers[i].Height} " +
                                          $"{loadingList.Workers[i].DateBirthday} " +
                                          $"{loadingList.Workers[i].CityBirt} <");
                        AddID = rezult;
                    }
                    Console.WriteLine("Список загружен.");
                    return AddID;
                }
                else
                {
                    Console.WriteLine("Невыделено паматяи под записи...");
                    return -2;
                }

            }
            else
            {
                Console.WriteLine("Файл для чтения отсутствует...");
                return -1;
            }
        }
        static void Main(string[] args)
        {
            string FileName = @"Worker.txt";
            if (!CheckingFile(FileName))
            {
                string[] Strings = new String[1];
                Strings[0] = "0#20.12.2021 0:12:00#Иванов Иван Иванович#25#176#05.05.1992 0:00:00#город Москва";
                File.WriteAllLines(FileName, Strings);
            }

            bool EndFlag = true;
            int NumberAdded = 20;
            int RezultID = CountingLines(FileName);
            int EndID = CountingRecords(FileName);
            EmployeesList employeesList = new EmployeesList(new Worker[RezultID + NumberAdded], EndID, NumberAdded, RezultID);
            while (EndFlag)
            {
                switch (SelectionScreenSaver())
                {
                    case 0:
                        Console.WriteLine("Приложение остановлено чтобы выйти просто нажмите  Enter.");
                        EndFlag = false;
                        Console.ReadKey();
                        break;
                    case 1:
                        DisplayDataScreen(FileName);
                        Console.ReadKey();
                        break;
                    case 2:
                        CreateEmployeeDirectory(employeesList, FileName, RezultID);
                        break;
                    default:
                        Console.WriteLine("Ошибка: Некорректное значение!");
                        EndFlag = false;
                        Console.ReadKey();
                        break;
                }
            }
            Console.Clear();
        }
    }
}