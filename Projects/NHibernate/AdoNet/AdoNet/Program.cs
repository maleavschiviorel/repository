using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AdoNet
{
    public class WorkWithAdo
    {
        private SqlDataAdapter adapPers;
        private SqlConnection cnn;
        static private string constr = ConfigurationManager.ConnectionStrings["ACDB"].ConnectionString;

        public DataSet dst = new DataSet("ACDB");

        public WorkWithAdo()
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
        }

        public void CreateTablePerson()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                string cmdstr =
                    " begin try " +
                    " drop table Orders " +
                    " end try " +
                    " begin catch" +
                    " end catch; " +

                    " begin try " +
                    " drop table Persons " +
                    " end try " +
                    " begin catch" +
                    " end catch; " +

                    " create table Persons(Id int identity(1,1) primary key, FirstName nvarchar(20), LastName nvarchar(20), BirthDate datetime )";
                using (SqlCommand cmd = new SqlCommand(cmdstr, cnn))
                {
                    cmd.ExecuteNonQuery();
                    if (dst.Tables.Contains("Persons"))
                    {
                        dst.Tables.Remove("Persons");
                    }
                    DataTable tbl = new DataTable("Persons");
                    DataColumn Clmn_Id = tbl.Columns.Add("Id", typeof(int));
                    Clmn_Id.AutoIncrement = true;
                    tbl.Columns.Add("FirstName", typeof(string));
                    tbl.Columns.Add("LastName", typeof(string));
                    tbl.Columns.Add("BirthDate", typeof(SqlDateTime));

                    tbl.Constraints.Add("PK_Orders", Clmn_Id, true);

                    dst.Tables.Add(tbl);

                }

            }
        }

        public void CreateTableOrders()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                string cmdstr =
                    " begin try " +
                    " drop table Orders " +
                    " end try " +
                    " begin catch" +
                    " end catch; " +

                    " create table Orders(Id int identity(1,1) primary key, Material nvarchar(20), Quantity decimal default 0, UnitPrice decimal default 0, Persons_id int  )" +
                    " alter table Orders add constraint FK_Orders foreign key (Persons_id) references Persons(id) on update no action";
                using (SqlCommand cmd = new SqlCommand(cmdstr, cnn))
                {
                    cmd.ExecuteNonQuery();
                    if (dst.Tables.Contains("Orders"))
                    {
                        dst.Tables.Remove("Orders");
                    }
                    DataTable tbl = new DataTable("Orders");
                    DataColumn Clmn_Id = tbl.Columns.Add("Id", typeof(int));
                    tbl.Columns.Add("Material", typeof(string));
                    tbl.Columns.Add("Quantity", typeof(decimal));
                    tbl.Columns.Add("UnitPrice", typeof(decimal));
                    DataColumn persClmn_Id = tbl.Columns.Add("Persons_id", typeof(int));
                    tbl.Constraints.Add("PK_Orders", Clmn_Id, true);
                    dst.Tables.Add(tbl);
                    dst.Relations.Add("PersonsOrders", dst.Tables["Persons"].Columns["Id"], persClmn_Id);
                    //tbl.Constraints.Add("FK_Orders", dst.Tables["Persons"].Columns["Id"], persClmn_Id);


                }
            }
        }

        public void InsertData()
        {
            //using (
                 cnn = new SqlConnection(constr);
                //)

            {
                cnn.Open();
                adapPers = new SqlDataAdapter("select * from Persons", cnn);
                adapPers.InsertCommand = new SqlCommand(
                    "insert into Persons(FirstName,LastName,BirthDate) values (@FirstName,@LastName,@BirthDate)", cnn);
                adapPers.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20, "FirstName");
                adapPers.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 20, "LastName");
                adapPers.InsertCommand.Parameters.Add("@BirthDate", SqlDbType.DateTime, 8, "BirthDate");
                adapPers.FillSchema(dst, SchemaType.Source);



                DataRow r = dst.Tables["Persons"].NewRow();
                r["FirstName"] = "f";
                r["LastName"] = "l";
                r["BirthDate"] = new DateTime(1978, 12, 1);
                dst.Tables["Persons"].Rows.Add(r);

                r = dst.Tables["Persons"].NewRow();
                r["FirstName"] = "fq";
                r["LastName"] = "lq";
                r["BirthDate"] = new DateTime(1978, 1, 1);
                dst.Tables["Persons"].Rows.Add(r);

                adapPers.Update(dst, "Persons");
            }
        }
        public void UpdateData()
        {
           // using (SqlConnection cnn = new SqlConnection(constr))
            {
             //   cnn.Open();
                //adapPers = new SqlDataAdapter("select * from Persons", cnn);

                adapPers.UpdateCommand = new SqlCommand(
                    "update Persons set FirstName=@FirstName,LastName=@LastName,BirthDate=@BirthDate where  Id =@Id ", cnn);
                adapPers.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20, "FirstName");
                adapPers.UpdateCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 20, "LastName");
                adapPers.UpdateCommand.Parameters.Add("@BirthDate", SqlDbType.DateTime, 8, "BirthDate");
                adapPers.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
                //adapPers.FillSchema(dst, SchemaType.Source);

                DataRow r = dst.Tables["Persons"].Rows[0];
                r["FirstName"] = "f11";
                r["LastName"] = "l11";
                r["BirthDate"] = new DateTime(1978, 12, 1);
                
                adapPers.Update(dst, "Persons");
            }
        }
        public void DeleteData()
        {
            //using (SqlConnection cnn = new SqlConnection(constr))
            {
             //   cnn.Open();
               // adapPers = new SqlDataAdapter("select * from Persons", cnn);
                adapPers.DeleteCommand = new SqlCommand(
                    "delete from  Persons where Id =@Id", cnn);// 
                adapPers.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");

                dst.Tables["Persons"].Rows[0].Delete(); ;
                adapPers.Update(dst, "Persons");
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            WorkWithAdo q = new WorkWithAdo();
            q.CreateTablePerson();
            q.CreateTableOrders();
            DataSet dst = q.dst;

            q.InsertData();
            q.UpdateData();
            q.DeleteData();

        }
    }
}
