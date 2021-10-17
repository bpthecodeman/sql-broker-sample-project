using System;
using System.Data.SqlClient;
using TableDependency.SqlClient;

namespace BrokerTest
{
    class Program
    {
        // Enter the correct connection string
        public static readonly string connectionString = "Server=.;Database=BrokerSampleDatabase;Integrated Security=true;";

        static void Main(string[] args)
        {
            SqlTableDependency<Person> person_table_dependecy = new SqlTableDependency<Person>(connectionString);
            SqlTableDependency<Order> order_table_dependecy = new SqlTableDependency<Order>(connectionString);

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                person_table_dependecy.OnChanged += Person_table_dependecy_OnChanged;
                order_table_dependecy.OnChanged += Order_table_dependecy_OnChanged;

                person_table_dependecy.Start();
                order_table_dependecy.Start();

                connection.Open();

                Console.WriteLine("Connection started!");
                Console.WriteLine();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();

                person_table_dependecy.Stop();
                order_table_dependecy.Stop();

                Console.WriteLine("Connection ended!");
            }
        }

        private static void Order_table_dependecy_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Order> e)
        {
            Console.WriteLine(e.Entity.Print(e.ChangeType));
            Console.WriteLine();
        }

        private static void Person_table_dependecy_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Person> e)
        {
            Console.WriteLine(e.Entity.Print(e.ChangeType));
            Console.WriteLine();
        }
    }
}