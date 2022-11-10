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
throw new OutOfTimeRangeException("Hours out of range")
```
