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

Конструктор **от трех целочисленных параметров** инициализирует точку с координатами (x,y,z) соответственно:

```c#
public Point(int x, int y, int z) //конструктор от трех целочисленных параметров
  {
  this.x = x;
  this.y = y;
  this.z = z;
}
```
