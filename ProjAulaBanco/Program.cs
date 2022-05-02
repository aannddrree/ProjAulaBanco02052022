using System;
using System.Data.SqlClient;

namespace ProjAulaBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //String Conexão 
            string strCon = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=D:\Banco\dbclient.mdf;";

            //Abre a conexão
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            Console.WriteLine("Conectou!");

            //Exemplo Insert
            string strInsert = "insert into Client (Id, Name, Telephone) values (@Id, @Name, @Telephone)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Id", 7));
            commandInsert.Parameters.Add(new SqlParameter("@Name", "Ana"));
            commandInsert.Parameters.Add(new SqlParameter("@Telephone", "(32) 9876-3333"));
          
            //Insere no Banco!
            commandInsert.ExecuteNonQuery();

            Console.WriteLine("Inserido no Banco de dados!");
          
            //Exemplo Consultar
            string strSelect = "select * from Client";
            SqlCommand commandSelect = new SqlCommand(strSelect, conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("Id: " + dr["Id"] + "\nNome: " + dr["Name"] + "\nTelefone: " + dr["Telephone"]);
            }

            conn.Close();
            Console.WriteLine("Fim");
        }
    }
}
