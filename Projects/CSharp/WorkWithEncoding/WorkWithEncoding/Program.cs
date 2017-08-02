using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithEncoding
{
    public class UsingEncodings
    {
        private string _rootPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public void WriteForEachEncodingIndifferentFiles(Encoding encoding)
        {
            System.IO.StreamWriter st = null;
            //System.IO.BinaryWriter st = null;
            try
            {
                //System.IO.FileStream f = new System.IO.FileStream(System.IO.Path.Combine(_rootPath, encoding.ToString().Split(new char[] { '.' }).Last() + ".txt"), System.IO.FileMode.Create);
                //st = new System.IO.BinaryWriter(f, encoding, false);
                st = new System.IO.StreamWriter(System.IO.Path.Combine(_rootPath, encoding.ToString().Split(new char[] { '.' }).Last() + ".html"), false, encoding);


                for (int i = 0; i < 100000; i++)
                {
                    //byte[] arrofbyte = BitConverter.GetBytes(i);// 
                    //byte[] converted = Encoding.Convert(Encoding.Unicode, encoding, arrofbyte);
                    //st.Write(arrofbyte);

                    st.Write((char)i);
                }
                st.Close();
                st.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                if (st != null)
                    st.Dispose();
            }
        }
        public void OpenStreams()
        {
            System.IO.StreamWriter st = null;
            List<System.IO.StreamWriter> arrl = new List<System.IO.StreamWriter>();
            System.Diagnostics.Process pr = System.Diagnostics.Process.GetCurrentProcess();
            try
            {
                long l = 1;
                while (true)
                {
                    st = new System.IO.StreamWriter(System.IO.Path.Combine(_rootPath, (l++).ToString() + ".txt"), false);
                    arrl.Add(st);

                    //for (int i = 0; i < 100000; i++)
                    //{
                    //    st.Write((char)i);
                    //}
                    System.Diagnostics.Debug.WriteLine("Memory used {0}", pr.PagedMemorySize64);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
            finally
            {
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UsingEncodings usingEncodings = new UsingEncodings();
            usingEncodings.WriteForEachEncodingIndifferentFiles(System.Text.Encoding.ASCII);
            usingEncodings.WriteForEachEncodingIndifferentFiles(System.Text.Encoding.BigEndianUnicode);
            usingEncodings.WriteForEachEncodingIndifferentFiles(System.Text.Encoding.Unicode);
            usingEncodings.WriteForEachEncodingIndifferentFiles(System.Text.Encoding.UTF32);
            usingEncodings.WriteForEachEncodingIndifferentFiles(System.Text.Encoding.UTF7);
            usingEncodings.WriteForEachEncodingIndifferentFiles(System.Text.Encoding.UTF8);

            //usingEncodings.OpenStreams();
        }
    }
}

