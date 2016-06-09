using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DB
{
    class Program
    {
        static void Main(string[] args)
        {
            ////DataContext db = new DataContext(@"c:\Northwnd.mdf");
            //DataContext db = new DataContext(@"D:\relay\DB\DB\relay_database.mdf");
            //Table<Switches> mytable = db.GetTable<Switches>();

            

            //var queryAll = from swtch in mytable
            //                        select swtch;
            //foreach (var nowsw in queryAll)
            //{
            //    Console.WriteLine("Now switch: '{0}' '{1}' '{2}'.", nowsw.Id, nowsw.Date, nowsw.Switch);
            //}
            //Console.ReadLine();

            try
            {
                SqlConnection conn = new SqlConnection();
                                    //Console.WriteLine("SqlConnection conn = new SqlConnection();");
                conn.ConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\relay_database.mdf;Integrated Security=True";
                                    //Console.WriteLine("conn.ConnectionString = \"Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\relay_database.mdf;Integrated Security=True\";");
                SqlCommand command = new SqlCommand("SELECT * FROM SwitchTable ORDER BY Date DESC", conn);
                                    //Console.WriteLine("SqlCommand command = new SqlCommand(\"SELECT * FROM  SwitchTable\", conn);");
                conn.Open();
                                    //Console.WriteLine("conn.Open();");
                SqlDataReader reader = command.ExecuteReader();
                                    //Console.WriteLine("SqlDataReader reader = command.ExecuteReader();");

                if (reader.Read())
                {
                    Console.WriteLine("Current: {0} ({1} {2} {3})", reader["Switch"], reader[0], reader[1], reader[2]);
                }
                else Console.WriteLine("Kakaya-to phignja");

                conn.Close();
                                    //Console.WriteLine("conn.Close();");
                Console.ReadLine();
                                    //Console.WriteLine("Console.ReadLine();");
                conn.Dispose();
                // remember, there is no method to flush a connection.
            }
            catch (Exception ex)
            {
                string exstr = "";
                exstr += "EXCEPTION in method \"static void Main(string[] args) { }\"!\n";
                exstr += ex.Message;
                exstr += "\nSorry!";
                System.Windows.Forms.MessageBox.Show(exstr);
            }
        }
    }
}
