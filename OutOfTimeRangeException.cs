using System;
namespace YAP_PSU_LAB2_TASK7
{
    public class OutOfTimeRangeException : Exception
    { 
        public OutOfTimeRangeException(string message) : base(message) { }
    }
}
