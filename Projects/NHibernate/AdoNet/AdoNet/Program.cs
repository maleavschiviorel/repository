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
            cnn = new SqlConnection(constr);
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
                    Clmn_Id.AutoIncrementSeed = 0;
                    Clmn_Id.AutoIncrementStep = -1;
                    Clmn_Id.AutoIncrement = true;//nu va coincide cu cel din DB
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
            string cmdstr =
                " begin try " +
                " drop table Orders " +
                " end try " +
                " begin catch" +
                " end catch; " +

                " create table Orders(Id int identity(1,1)  primary key, Material nvarchar(20), Quantity decimal default 0, UnitPrice decimal default 0, Persons_id int  )" +
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
                Clmn_Id.AutoIncrementSeed = 0;
                Clmn_Id.AutoIncrementStep = -1;
                Clmn_Id.AutoIncrement = true;//nu va coincide cu cel din DB

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

        public void InsertPersonData()
        {
            adapPers = new SqlDataAdapter("select * from Persons", cnn);
            adapPers.InsertCommand = new SqlCommand(
                "insert into Persons(FirstName,LastName,BirthDate) values (@FirstName,@LastName,@BirthDate);" +
                " select Id,FirstName,LastName,BirthDate from Persons where Id= SCOPE_IDENTITY();", cnn);// "
            adapPers.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20, "FirstName");
            adapPers.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 20, "LastName");
            adapPers.InsertCommand.Parameters.Add("@BirthDate", SqlDbType.DateTime, 8, "BirthDate");
            adapPers.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            adapPers.Fill(dst, "Persons");

            adapPers.RowUpdated += AdapPers_RowUpdated;


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

            DataSet dst1 = dst.GetChanges();
            adapPers.Update(dst1, "Persons");
            dst.Merge(dst1);
            dst.AcceptChanges();
        }

        private void AdapPers_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                SqlCommand cmdNewID = new SqlCommand("SELECT @@IDENTITY",
                    cnn);
                // Retrieve the Autonumber and store it in the CategoryID column.
                object o = cmdNewID.ExecuteScalar();
                int.TryParse(o.ToString(), out int ret);
                int id = ret;
                e.Row["Id"] = id;

                e.Status = UpdateStatus.SkipCurrentRow;
            }

        }

        public void InsertOrdersData()
        {
            SqlDataAdapter adapOrder = new SqlDataAdapter("select * from Orders", cnn);
            adapOrder.InsertCommand = new SqlCommand(
                "insert into Orders(Material,Quantity,UnitPrice,Persons_Id) values (@Material,@Quantity,@UnitPrice,@Persons_Id)", cnn);
            adapOrder.InsertCommand.Parameters.Add("@Material", SqlDbType.NVarChar, 20, "Material");
            adapOrder.InsertCommand.Parameters.Add("@Quantity", SqlDbType.Decimal, 9, "Quantity");
            adapOrder.InsertCommand.Parameters.Add("@UnitPrice", SqlDbType.Decimal, 9, "UnitPrice");
            adapOrder.InsertCommand.Parameters.Add("@Persons_Id", SqlDbType.Int, 4, "Persons_Id");

            adapOrder.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;

            adapOrder.RowUpdated += AdapPers_RowUpdated;

            adapOrder.Fill(dst, "Orders");





            DataRow r = dst.Tables["Orders"].NewRow();
            r["Material"] = "f";
            r["Quantity"] = 2;
            r["UnitPrice"] = 123.3;
            r["Persons_Id"] = 2;
            dst.Tables["Orders"].Rows.Add(r);

            r = dst.Tables["Orders"].NewRow();
            r["Material"] = "h";
            r["Quantity"] = 3;
            r["UnitPrice"] = 11.7;
            r["Persons_Id"] = 2;
            dst.Tables["Orders"].Rows.Add(r);


            DataSet dst1 = dst.GetChanges();
            adapOrder.Update(dst1, "Orders");
            dst.Merge(dst1);
            dst.AcceptChanges();
        }
        public void UpdatePersonData()
        {

            adapPers.UpdateCommand = new SqlCommand(
                "update Persons set FirstName=@FirstName,LastName=@LastName,BirthDate=@BirthDate where  Id =@Id", cnn);//  
            adapPers.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20, "FirstName");
            adapPers.UpdateCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 20, "LastName");
            adapPers.UpdateCommand.Parameters.Add("@BirthDate", SqlDbType.DateTime, 8, "BirthDate");
            adapPers.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            adapPers.FillSchema(dst, SchemaType.Source);

            DataRow r = dst.Tables["Persons"].Rows[0];
            r["FirstName"] = "f11";
            r["LastName"] = "l11";
            r["BirthDate"] = new DateTime(1978, 12, 1);

            adapPers.Update(dst, "Persons");
            dst.AcceptChanges();
        }
        public void DeletePersonData()
        {
            adapPers.DeleteCommand = new SqlCommand(
                "delete from  Persons where Id =@Id", cnn);// 
            adapPers.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            dst.Tables["Persons"].Rows[0].Delete(); ;
            adapPers.Update(dst, "Persons");
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

            q.InsertPersonData();
            q.UpdatePersonData();
            q.InsertOrdersData();
            q.DeletePersonData();

        }
    }
}
