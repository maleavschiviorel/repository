namespace WorkwithArrays
{
  
        public class MatrixOfInt : MyMatrix<int>
        {
            public MatrixOfInt(MyList<MyList<int>> arr) : base(arr)
            {
            }
            public MatrixOfInt(int[][] arr) : base(arr)
            { }
            public MatrixOfInt() : base()
            { }
        }

 
}
