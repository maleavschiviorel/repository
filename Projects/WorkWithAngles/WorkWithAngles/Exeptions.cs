using System;

namespace WorkWithAngles
{
    public class MinuteException:Exception
    {
        public MinuteException()
        { }
        public MinuteException(string message):base(message) 
        { }
    }
    public class SecondExcreption : Exception
    {
        public SecondExcreption()
        { }
        public SecondExcreption(string message):base(message) 
        { }
    }
    public class HourExcreption : Exception
    {
        public HourExcreption()
        { }
        public HourExcreption(string message):base(message) 
        { }
    }
  
}
