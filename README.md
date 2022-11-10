# Лабораторная работа №2 по ЯП ПГНИУ, задание 7
## Постановка задачи
Реализовать определение класса (поля, свойства, конструкторы, перегрузка метода ToString() для вывода полей, заданный метод согласно варианту). Протестировать все методы, включая конструкторы, не забывайте проверять вводимые пользователем данные на корректность!
Реализовать класс Time.
Поля:

byte hours

byte minutes

Вычитание переменной типа Time (учесть, что возможен переход в предыдущие сутки). Результат должен быть типа Time.

Унарные операции:
++ добавление минуты к объекту типа Time.
-- вычитание минуты из объекта типа Time
Операции приведения типа:
int (неявная) – результатом является количество минут (время переводится в минуты);
bool (явная) – результатом является true, если часы и минуты не равны нулю, и false в противном случае. Бинарные операции:
 < Time t1, Time t2 – время переводится в минуты, результатом является true, если количество минут в левом операнде меньше, чем количество минут в правом операнде, и false – в противном случае.
 > Time t1, Time t2 — время переводится в минуты, результатом является true, если количество минут в левом операнде больше, чем количество минут в правом операнде, и false – в противном случае.

*UML диаграмма класса:*


# Класс Time
## Поля
Класс содержит поля:
```c#
private byte hours; //часы
private byte minutes; //минуты
private byte seconds; //секунды
```

## Конструкторы
Конструктор **по умолчанию** инициализирует точку в начале системы координат:

```c#
 public Time() //конструктор по умолчанию
 {
     this.hours = 0;
     this.minutes = 0;
     this.seconds = 0;
 }
```

Конструктор **от трех параметров типа byte** инициализирует время в формате HH:MM:SS соответственно:

```c#
public Time(byte hours, byte minutes, byte seconds) //конструктор от трёх byte
{
    if(hours >= 24)
    {
        throw new OutOfTimeRangeException("Hours out of range"); //исключение (вне диапазона)
    }

    if(minutes >= 60)
    {
        throw new OutOfTimeRangeException("Minutes out of range");
    }

    if(seconds >= 60)
    {
        throw new OutOfTimeRangeException("Seconds out of range");
    }

    this.hours = hours;
    this.minutes = minutes;
    this.seconds = seconds;
}
```

Внутри него происходит обработка исключений. Если какой-либо параметр выходит за рамки условий задачи выбрасывается исключение:

```c#
throw new OutOfTimeRangeException("Hours out of range");
```

## Методы

Ниже преставлены реализованные **методы** класса **Time**:

```c#
public void AddSeconds(uint seconds); //добавление секунд к объекту типа Time
public void AddMinutes(uint minutes); //добавление минут к объекту типа Time
public void AddHours(byte hours); //добавление часов к объекту типа Time
public int toMinutes(); //переводит объект time в целое число &mdash минуты в пересчете(секунды отбрасываются)
public void RemoveMinutes(uint minutes);  //вычитание минут из объекта типа Time
public override string ToString(); //конвертирует объект типа Time в строку вида: HH:MM:SS
```

## Приведение типов
Реализовано неявное приведение типа ```Time``` к ```int```:
```c#
public static implicit operator int(Time time) 
{
    return time.seconds / 60 + time.minutes + time.hours * 60;
}
```

И явное приведение типа ```Time``` к ```bool```:
```c#
public static explicit operator bool(Time time) //явное приведение к bool
{
    if (time.seconds != 0 || time.minutes != 0 || time.hours != 0)
    {
        return true;
    }
    return false;
}
```

## Перегруженные операторы
```c#
public static Time operator ++(Time time); //постфиксный инкремент
public static Time operator --(Time time); //постфиксный декремент
public static bool operator<(Time t1, Time t2); //<
public static bool operator>(Time t1, Time t2); //>
public static Time operator-(Time t1, Time t2) // - бинарный
```

## Тесты
*Рассмотрим примеры:*
```c#
Time t1 = new Time(); //создаем объект t1 класса Time
Console.WriteLine("Время t1 = " + t1.ToString());
```
*Вывод:*
```
Время t1 = 00:00:00
```
Так как никаких параметров при создании объекта не передали, будет вызван **коснтруктор по умолчанию**. Все поля объекта *t1* будут инициализированы нулями, в соответсвтии с реализацией конструктора по умолчанию.

```c#
Time t2 = new Time(10, 41, 36); //создаем объект t2 класса Time
Console.WriteLine("Время t2 = " + t2.ToString());
```
*Вывод:*
```
Время t2 = 10:41:36
```
В этом случае вызовется конструктор от трех параметров типа ```byte```. В соответсвтии с ним будет создан объект. ```ToString()``` сконвертирует объект в строку вида HH:MM:SS

Проверим коррекность работы бинарного оператора '-':

```c#
Console.WriteLine("t1 - t2 = " + (t1 - t2));
```

*Вывод*:
```
t1 - t2 = 13:18:24
```

Все работает верно.

Проверим коррекность неявного приведения к ```int```

```c#
int a = t2;
Console.WriteLine("a = " + a);
```

*Вывод*:
```
a = 641 
```

Проверим коррекность неявного приведения к ```bool```

```c#
bool b = (bool)t1;
Console.WriteLine("b = " + b);
```

*Вывод*:
```
b = False
```

Проверим перегруженный постфиксный инкремент:

```c#
t1++;
Console.WriteLine("Время t1++ = " + t1.ToString());
```

*Вывод*:
```
Время t1++ = 00:01:00
```

Проверим перегруженный оператор < :

```c#
Console.WriteLine("01:00:01 < 01:00:00 ? " + (new Time(1, 0, 1) < new Time(1, 0, 0)));
```

*Вывод*:
```
01:00:01 < 01:00:00 ? False
```

Проверим перегруженный оператор > :

```c#
Console.WriteLine("01:00:01 > 01:00:00 ? " + (new Time(1, 0, 1) > new Time(1, 0, 0)));
```

*Вывод*:
```
01:00:01 > 01:00:00 ? True
```

Тесты вспомогательных методов: 
```c#
t1.RemoveMinutes(500);
Console.WriteLine("Время t1 - 500 MIN = " + t1.ToString());
t1.AddMinutes(123);
Console.WriteLine("Время t1 + 123 MIN = " + t1.ToString());
Console.WriteLine("Время t1 в минутах = " + t1.toMinutes());
```
*Вывод:*

```
Время t1 - 500 MIN = 15:41:00
Время t1 + 123 MIN = 17:44:00
Время t1 в минутах = 1064
```

Все работает верно.
