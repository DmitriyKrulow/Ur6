using System;

namespace Ur6
{
    struct Worker : IComparable
    {
        //поля
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }//1 Идентификатор
        public DateTime date { get; set; }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }//2 Дата и время создания записи
        public string Name { set; get; }// 3 ФИО
        public int Age { set; get; }// 4 возраст лет
        public int Height { set; get; }// 5 рост сантиметры
        public DateTime DateBirthday { set; get; }//6 Дата рождения
        public string CityBirt { set; get; }// 7 город рождения
        int IComparable.CompareTo(object obj)
        {
            Worker temp = (Worker)obj;
            if (this.date > temp.date) return 1;
            if (this.date < temp.date) return -1;
            else return 0;
        }
        public Worker(int Id, DateTime Date, string Name, int Age, int Height, DateTime DateBirthday, string CityBirt)
        {
            this.id = Id;
            this.date = Date;
            this.Name = Name;
            this.Age = Age;
            this.Height = Height;
            this.DateBirthday = DateBirthday;
            this.CityBirt = CityBirt;
        }

    }
}
