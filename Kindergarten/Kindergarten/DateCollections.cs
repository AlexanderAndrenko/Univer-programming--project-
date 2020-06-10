using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten
{
    public class DateCollections
    {
        public static List<string> Day { get; private set; } = new List<string>()
        {
            "*",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"
        };
        public static List<string> Mounth { get; private set; } = new List<string>()
        {
            "*",
            "январь",
            "февраль",
            "март",
            "апрель",
            "май",
            "июнь",
            "июль",
            "август",
            "сентябрь",
            "октябрь",
            "ноябрь",
            "декабрь"
        };
        public static List<string> Year { get; private set; } = new List<string>()
        {
            "*",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"
        };

        public static string ConvertDayToSqlFormat(string day)
        {
            if (day.Length != 1 || day == "*")
                return day;
            day.Insert(0, "0");
            return day;
        }
        public static string ConvertMounthToSqlFormat(string mounth)
        {
            if (mounth == "*")
                return mounth;

            for (int index = 0; index < Mounth.Count; index++)
            {
                if (Mounth[index] ==  mounth)
                {
                    return  Convert.ToString(index);
                }
            }

            return null;
        }
    }
}
