using System;
using System.Diagnostics;

namespace Counter_of_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            // Introduction
            DisplayMessage(ConsoleColor.Green, "Application name: Counter of Days\nAuthor: Nemanja Stepanović\nInfo: Find out how many days have past since your birthday or any other important date to you.\n");
            
            short year = GettingYear(0, true);
            sbyte month = GettingMonth(0, true);
            sbyte day = GettingDay(0, year, month, true);
            
            DateTime date = new DateTime(year, month, day);
            TimeSpan daysPast = DateTime.Now.Subtract(date);
            
            DisplayMessage(ConsoleColor.Yellow, "\nNumber of days: " + (long)daysPast.TotalDays);

            Console.ReadLine();
        }


        public static void DisplayMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static short GettingYear(short aYear, bool repeat)
        {
            do
            {
                Console.Write("Please enter a year (e.g. 1994): ");
                try
                {
                    aYear = Convert.ToInt16(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Year is in incorrect format. Only numbers can be entered for a year. Try again.");
                    Debug.WriteLine(e.GetType() + ": " + e.Message);
                    continue;
                }
                catch(OverflowException e)
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Number you entered is too large. Try again.");
                    Debug.WriteLine(e.GetType() + ": " + e.Message);
                    continue;
                }

                if(aYear <= 0)
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Year cannot be less than or equal to 0. Try again.");
                    continue;
                }
                else if(aYear > DateTime.Today.Year)
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Year cannot be greater than the current year. Try again.");
                    continue;
                }
                else
                {
                    repeat = false;
                }
            }
            while(repeat);

            return aYear;
        }


        public static sbyte GettingMonth(sbyte aMonth, bool repeat)
        {
            do
            {
                Console.Write("Please enter a month (e.g. 1): ");
                try
                {
                    aMonth = Convert.ToSByte(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Month is in incorrect format. Only numbers can be entered for a month. Try again.");
                    Debug.WriteLine(e.GetType() + ": " + e.Message);
                    continue;
                }
                catch(OverflowException e)
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Number you entered is too large. Try again.");
                    Debug.WriteLine(e.GetType() + ": " + e.Message);
                    continue;
                }

                if(aMonth < 1)
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Month cannot be less than 1. Try again.");
                    continue;
                }
                else if(aMonth > 12)
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Month cannot be greater than 12. Try again.");
                    continue;
                }
                else
                {
                    repeat = false;
                }
            }
            while(repeat);

            return aMonth;
        }


        enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            Jun,
            July,
            August,
            September,
            October,
            November,
            December
        }


        public static sbyte GettingDay(sbyte aDay, short aYear, sbyte aMonth, bool repeat)
        {
            do
            {
                Console.Write("Please enter a day (e.g. 10): ");
                try
                {
                    aDay = Convert.ToSByte(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Day is in incorrect format. Only numbers can be entered for a day. Try again.");
                    Debug.WriteLine(e.GetType() + ": " + e.Message);
                    continue;
                }
                catch(OverflowException e)
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Number you entered is too large. Try again.");
                    Debug.WriteLine(e.GetType() + ": " + e.Message);
                    continue;
                }

                if(aDay < 1)
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Day cannot be less than 1. Try again.");
                    continue;
                }
                else if(aDay > DateTime.DaysInMonth(aYear, aMonth))
                {
                    Console.Beep();
                    DisplayMessage(ConsoleColor.Red, "Day in " + (Month)aMonth + " " + aYear  + " cannot be greater than " + DateTime.DaysInMonth(aYear, aMonth) + ". Try again.");
                    continue;
                }
                else
                {
                    repeat = false;
                }
            }
            while(repeat);

            return aDay;
        }
    }
}
