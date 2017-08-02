using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace WorkWithAngles
{
    public class AngleComparer : IComparer<Angle>
    {
        public int Compare(Angle x, Angle y)
        {
            return ((IComparable<Angle>)x).CompareTo(y);
            // return x.CompareTo(y);
        }
    }
    public class Angle : IComparable<Angle>, ICloneable<Angle>
    {
        private int getInSeconds
        {
            get { return (int)(Hours * 60 * 60 + Minutes * 60 + Seconds) * (Positive ? 1 : -1); }
        }
        public bool Positive { get; set; }
        public uint Hours { get; private set; }
        public uint Minutes { get; private set; }
        public uint Seconds { get; private set; }

        private Angle(int allInSeconds)
        {
            Positive = allInSeconds >= 0;
            Hours = (uint)allInSeconds / 3600;
            Minutes = ((uint)allInSeconds - Hours * 3600) / 60;
            Seconds = (uint)allInSeconds - Hours * 3600 - Minutes * 60;
        }
        public Angle()
        { }
        public Angle(uint hours, uint minutes, uint seconds, bool positive = true)
        {
            if (minutes > 59)
                throw new MinuteException("Minutes exceed 59");
            if (seconds > 59)
                throw new MinuteException("Seconds exceed 59");

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Positive = positive;
        }

        public static Angle operator +(Angle angleObject1, Angle angleObject2)
        {
            Angle angleTempObjec = new Angle(angleObject1.getInSeconds + angleObject2.getInSeconds);
            return angleTempObjec;
        }
        public static Angle operator *(int scalarValue, Angle angleObject)
        {
            Angle angleTempObjec = new Angle(scalarValue * angleObject.getInSeconds);
            return angleTempObjec;
        }
        public static Angle operator *(Angle angleObject, int scalarValue)
        {
            Angle angleTempObjec = new Angle(scalarValue * angleObject.getInSeconds);
            return angleTempObjec;
        }
        public static Angle operator -(Angle angleObject1, Angle angleObject2)
        {
            Angle angleTempObjec = new Angle(angleObject1.getInSeconds - angleObject2.getInSeconds);
            return angleTempObjec;
        }
        public static bool operator >(Angle angleObject1, Angle angleObject2)
        {
            return angleObject1.getInSeconds > angleObject2.getInSeconds;
        }
        public static bool operator <(Angle angleObject1, Angle angleObject2)
        {
            return angleObject1.getInSeconds < angleObject2.getInSeconds;
        }
        public static bool operator >=(Angle angleObject1, Angle angleObject2)
        {
            return angleObject1.getInSeconds >= angleObject2.getInSeconds;
        }
        public static bool operator <=(Angle angleObject1, Angle angleObject2)
        {
            return angleObject1.getInSeconds <= angleObject2.getInSeconds;
        }
        public static bool operator ==(Angle angleObject1, Angle angleObject2)
        {
            return angleObject1.getInSeconds == angleObject2.getInSeconds;
        }
        public static bool operator !=(Angle angleObject1, Angle angleObject2)
        {
            return angleObject1.getInSeconds != angleObject2.getInSeconds;
        }


        public override string ToString()
        {
            return String.Format("{0} Angle with Hours={1} Minutes={2} Seconds={3}", Positive ? "positive" : "negative", Hours, Minutes, Seconds);
        }

        int IComparable<Angle>.CompareTo(Angle other)
        {
            if (this.getInSeconds > other.getInSeconds)
            { return 1; }
            else if (this.getInSeconds < other.getInSeconds)
                return -1;
            else
                return 0;

        }

        public Angle Clone()
        {
            return (Angle)MemberwiseClone();
        }

        //public  int CompareTo(Angle other)
        // {
        //     if (this.GetInSeconds > other.GetInSeconds)
        //     { return -1; }
        //     else if (this.GetInSeconds < other.GetInSeconds)
        //         return 1;
        //     else
        //         return 0;

        // }


        public uint this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Hours;
                    case 1:
                        return Minutes;
                    case 2:
                        return Seconds;
                    default: throw new IndexOutOfRangeException(string.Format("index={0}", index));

                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        { Hours = value; break; }
                    case 1:
                        {
                            if (value > 59)
                                throw new MinuteException("Minutes exceed 59");
                            Minutes = value; break;
                        }
                    case 2:
                        {
                            if (value > 59)
                                throw new MinuteException("Seconds exceed 59");
                            Seconds = value; break;
                        }
                    default: throw new IndexOutOfRangeException(string.Format("index={0}", index));

                }

            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Angle angle1 = new Angle(minutes: 2, hours: 1, seconds: 10);
                Angle angle2 = new Angle(2, 57, 10, false);
                Angle angle3 = angle1 - angle2;
                Angle angle22 = angle2.Clone();
                angle2[2] = 9;
                Angle angle4 = angle1 - angle2;
                List<Angle> listOfAngles = new List<Angle>() { angle4, angle3, angle2, angle1 };

                if (angle1 > angle2)
                    Console.WriteLine(" '{0}' \r\n is grater then \r\n'{1}'", angle1, angle2);
                else if (angle1 < angle2)
                    Console.WriteLine(@" '{0}'\r\n is less then \r\n'{1}'", angle1, angle2);
                else
                    Console.WriteLine(@" '{0}'\r\n is equall to \r\n'{1}'", angle1, angle2);

                var newlistOfAngles = listOfAngles.Where(x => x.Hours > 0).Select(x => new { H = x.Hours.ToString(), M = x.Minutes.ToString(), S = x.Seconds.ToString() });

                var newlistOfAngles1 = listOfAngles.OrderBy(x => x, new AngleComparer());

                listOfAngles.Sort(new AngleComparer());



            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                ReadLine();
            }
        }
    }
}
