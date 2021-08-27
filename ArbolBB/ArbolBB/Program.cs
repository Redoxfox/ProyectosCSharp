using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ArbolBB
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolBB arbol = new ArbolBB();
            CnodoBB Raiz = arbol.insert(98, 14, 7, "", null);
            arbol.insert(1, 1, 1, "", Raiz);
            arbol.insert(100, 2, 1, "", Raiz);
            arbol.insert(2, 3, 1, "", Raiz);
            arbol.insert(102, 4, 1, "", Raiz);
            arbol.insert(3, 5, 1, "", Raiz);
            arbol.insert(109, 6, 1, "", Raiz);
            arbol.insert(7, 7, 1, "", Raiz);
            arbol.insert(120, 8, 1, "", Raiz);
            arbol.insert(16, 9, 1, "", Raiz);
            arbol.insert(112, 10, 1, "", Raiz);
            arbol.insert(99, 9, 1, "", Raiz);
            arbol.insert(129, 10, 1, "", Raiz);
            arbol.insert(149, 10, 1, "", Raiz);
            arbol.insert(119, 10, 1, "", Raiz);

            arbol.tranversa(Raiz);

            string ConnectionString = ConfigurationManager.AppSettings["DefaulfConnection"];
            string query = @"select Id, Nombre from Activo";
            try
            {

                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {

                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");


                    using (SqlCommand command = new SqlCommand(query, sql))
                    {
                        sql.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetInt32(0), reader.GetString(1));
                            }
                        }
                    }
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
