# Лабораторная работа №2 по ЯП ПГНИУ, задание 7
## Постановка задачи
Реализовать определение класса (поля, свойства, конструкторы, перегрузка метода ToString() для вывода полей, заданный метод согласно варианту). Протестировать все методы, включая конструкторы, не забывайте проверять вводимые пользователем данные на корректность!
Реализовать класс Time.
Поля:

byte hours

byte minutes

Вычитание переменной типа Time (учесть, что возможен переход в предыдущие сутки). Результат должен быть типа Time.

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

*Вывод*
```
t1 - t2 = 13:18:24
```

Все работает верно
