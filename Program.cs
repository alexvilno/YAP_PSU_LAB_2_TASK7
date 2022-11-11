using YAP_PSU_LAB2_TASK7;

class Program
{
    public static void Main(String[] args)
    {
        Time t1 = new Time();
        Time t2 = new Time(10, 41, 36);
        Console.WriteLine("Время t1 = " + t1.ToString());
        Console.WriteLine("Время t2 = " + t2.ToString());
        Console.WriteLine("t1 - t2 = " + (t1 - t2));

        int a = t2;
        Console.WriteLine("a = " + a);

        bool b = (bool)t1;
        Console.WriteLine("b = " + b);

        t1++;
        Console.WriteLine("Время t1++ = " + t1.ToString());
        Console.WriteLine("01:00:01 < 01:00:00 ? " + (new Time(1, 0, 1) < new Time(1, 0, 0)));
        Console.WriteLine("01:00:01 > 01:00:00 ? " + (new Time(1, 0, 1) > new Time(1, 0, 0)));
        t1.RemoveMinutes(500);
        Console.WriteLine("Время t1 - 500 MIN = " + t1.ToString());
        t1.AddMinutes(123);
        Console.WriteLine("Время t1 + 123 MIN = " + t1.ToString());
        Console.WriteLine("Время t1 в минутах = " + t1.toMinutes());
    }
}
