using System.Numerics;
using System.Xml.Schema;

namespace da
{
    class Proga
    {
        public class Program
        {
            static void Main()
            {
                Start:
                try
                {
                    Console.WriteLine($"Введите часы");
                    int a = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Введите минуты");
                    int b = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Введите секунды");
                    int c = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Введите часы второй временной точки");
                    int d = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Введите минуты второй временной точки");
                    int e = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Введите секунды второй временной точки");
                    int f = int.Parse(Console.ReadLine());
                    Time time1 = new Time(a, b, c);
                    Time time2 = new Time(d, e, f);
                    Time result = time1.AddSeconds(10);
                    Time result2 = time1.SubtractSeconds(5);
                    Console.WriteLine($"time1: {time1}");
                    Console.WriteLine($"time2: {time2}");
                    Console.WriteLine($"time1 + 10 seconds: {result}");
                    Console.WriteLine($"time1 - 5 seconds: {result2}");
                    Console.WriteLine($"time1 in seconds: {time1.ToSeconds()}");
                    Console.WriteLine($"time1 in minutes: {time1.ToMinutes()}");
                    Console.WriteLine($"Разница временных точек:{(time1 - time2).ToSeconds()} секунд");
                    Console.WriteLine("Результат сравнения:");
                    time1.Sravn(time2);
                }
                catch
                {
                    Console.WriteLine("Неверный формат");
                    Console.WriteLine();
                    goto Start;
                }
            }
        }
        public class Time
        {
            
            private TimeSpan time;
            public Time(int hours, int minutes, int seconds)
            {
                time = new TimeSpan(hours, minutes, seconds);
            }
            public Time AddSeconds(int seconds)
            {
                return new Time(time.Hours, time.Minutes, time.Seconds + seconds);
            }
            public Time SubtractSeconds(int seconds)
            {
                return new Time(time.Hours, time.Minutes, time.Seconds - seconds);
            }
            public int ToSeconds()
            {
                return (int)time.TotalSeconds;
            }
            public int ToMinutes()
            {
                return (int)time.TotalMinutes;
            }
            public override string ToString()
            {
                return $"{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}";
            }
            public static Time operator -(Time t1, Time t2)
            {
                return t1.SubtractSeconds(t2.ToSeconds()) ;
            }
            public static Time operator +(Time t1, Time t2)
            {
                return t1.AddSeconds(t2.ToSeconds());
            }
            public void Sravn(Time t2)
            {
                int a = this.ToSeconds();
                int b = t2.ToSeconds(); 
                if(a > b)
                {
                    Console.WriteLine("time1>time2");
                }
                else if(a < b)
                {
                    Console.WriteLine("time1<time2");
                }
                else
                {
                    Console.WriteLine("time1=time2");
                }
            }
        }
    }
}