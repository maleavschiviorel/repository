using MyListGeneric;  
namespace WorkwithArrays
{
    public class ArrOfInt : MyList<int>
    {
        public ArrOfInt(MyList<int> arr) : base(arr)
        { }
        public ArrOfInt(int[] arr) : base(arr)
        { }
        public ArrOfInt() : base()
        { }
        public int IndexOf(int tofind)
        {
            for (int i = 0; i < this.Arr.Length; i++)
                if (this.Arr[i] == tofind)
                    return i;
            return -1;
        }
        public int IndexOf(int fromindex, int tofind)
        {
            for (int i = fromindex; i < this.Arr.Length; i++)
                if (this.Arr[i] == tofind)
                    return i;
            return -1;
        }
    }
}
