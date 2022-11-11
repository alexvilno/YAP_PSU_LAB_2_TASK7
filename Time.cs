using System;
using System.Diagnostics.Metrics;

namespace YAP_PSU_LAB2_TASK7
{
    public class Time
    {
        private byte hours; //часы
        private byte minutes; //минуты
        private byte seconds; //секунды

        public Time() //конструктор по умолчанию
        {
            this.hours = 0;
            this.minutes = 0;
            this.seconds = 0;
        }

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

        public void RemoveMinutes(uint minutes) //вычитание uint минут из объекта типа Time
        {
            uint hrs_roverflow = (minutes - this.minutes) / 60;
            if (this.minutes < minutes)
            {
                if (hrs_roverflow * 60 + this.minutes != minutes)
                {
                    hrs_roverflow++;
                }

                if (this.hours < hrs_roverflow)
                {
                    this.hours = (byte)(24 - (hrs_roverflow - this.hours));
                    this.minutes = (byte)(hrs_roverflow * 60 + this.minutes - minutes);
                }
                else
                {
                    this.hours -= (byte)(hrs_roverflow);
                    this.minutes = (byte)(hrs_roverflow * 60 + this.minutes - minutes);
                }
            }
            else
            {
                this.minutes -= (byte)(minutes);
            }
        }

        public void AddMinutes(uint minutes) //добавление uint минут к объекту типа Time
        {
            uint hrs_oveflow = (minutes + this.minutes) / 60;

            if (this.hours + hrs_oveflow >= 24)
            {
                throw new OutOfTimeRangeException("Hours out of range");
            }

            this.minutes = (byte)(minutes + this.minutes - 60 * hrs_oveflow);
            this.hours = (byte)(this.hours + hrs_oveflow);
        }

        public void AddHours(byte hours)
        {
            if(this.hours + hours >= 24)
            {
                throw new OutOfTimeRangeException("Hours out of range");
            }

            this.hours += hours;
        }

        public void AddSeconds(uint seconds) //добавление uint секунд
        {
            uint mins_overflow = (seconds + this.seconds) / 60;
            uint hrs_overflow = (mins_overflow + this.minutes) / 60;

            if (this.hours + hrs_overflow >= 24)
            {
                throw new OutOfTimeRangeException("Hours out of range");
            }

            this.seconds = (byte)(seconds + this.seconds - 60 * mins_overflow);
            this.minutes = (byte)(this.minutes + mins_overflow - 60 * hrs_overflow);
            this.hours = (byte)(this.hours + hrs_overflow);
        }

        public int toMinutes() //перевод в минуты (секунды отбрасываются)
        {
            return (int)(this.hours * 60 + this.minutes);
        }

        public static implicit operator int(Time time) //неявное приведение к int
        {
            return time.seconds / 60 + time.minutes + time.hours * 60;
        }

        public static explicit operator bool(Time time) //явное приведение к bool
        {
            if (time.seconds != 0 || time.minutes != 0 || time.hours != 0)
            {
                return true;
            }
            return false;
        }

        public static Time operator ++(Time time) //постфиксный инкремент
        {
            time.AddMinutes(1);
            return time;
        }
        
        public static Time operator --(Time time) //постфиксный декремент
        {
            time.RemoveMinutes(1);
            return time;
        }

        public static bool operator<(Time t1, Time t2) // <
        {
            if (t1.toMinutes() < t2.toMinutes())
            {
                return true;
            }
            return false;
        }

        public static bool operator >(Time t1, Time t2) // >
        {
            if (t1.toMinutes() > t2.toMinutes())
            {
                return true;
            }
            return false;
        }

        public static Time operator-(Time t1, Time t2) // -
        {
            int hours = -1, minutes = -1, seconds;
            seconds = 60 + (int)t1.seconds - (int)t2.seconds;
            minutes += seconds / 60 + 60 + (int)t1.minutes - (int)t2.minutes;
            hours += minutes / 60 + 24 + (int)t1.hours - (int)t2.hours;
            return new Time((byte)(hours % 24), (byte)(minutes % 60), (byte)(seconds % 60));
        }


        public override string ToString() //конвертация в строку вида HH:MM:SS
        {
            return $"{hours:d2}:{minutes:d2}:{seconds:d2}";
        }
    }
}
