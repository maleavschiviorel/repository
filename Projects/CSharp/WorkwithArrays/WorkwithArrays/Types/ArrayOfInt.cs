using MyListGeneric;  
namespace WorkwithArrays
{
    public class ArrayOfInt : MyList<int>
    {
        public ArrayOfInt(MyList<int> arr) : base(arr)
        { }
        public ArrayOfInt(int[] arr) : base(arr)
        { }
        public ArrayOfInt() : base()
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
