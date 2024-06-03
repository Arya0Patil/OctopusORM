using System.Data;
using Microsoft.Data.SqlClient;

namespace Diconn2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet();
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=dickDb;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Select * from bbc", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            Console.WriteLine("Running");
            da.Fill(dataSet, "bbc");
            foreach(DataRow dr in dataSet.Tables["bbc"].Rows) {
                Console.WriteLine(dr["size"]);
                Console.WriteLine(dr["color"]);
            }
            #region insert
            //DataRow row1 = dataSet.Tables["bbc"].NewRow();
            //Console.WriteLine("Enter your size");
            //row1["size"] = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter color");
            //row1["color"] = Console.ReadLine();

            //dataSet.Tables["bbc"].Rows.Add(row1);

            //da.Update(dataSet, "bbc");

            #endregion


            Console.WriteLine("Enter size");
            int size = Convert.ToInt32(Console.ReadLine());
            foreach (DataRow item in dataSet.Tables["bbc"].Rows)
            {
                if ((int)item["size"]==size)
                {
                    Console.WriteLine("size: "+ item["size"]+", color: "+ item["color"]);
                    Console.WriteLine("ENter new color");
                    item["color"]= Console.ReadLine();
                

                }
            }
            da.Update();






        }
    }
}