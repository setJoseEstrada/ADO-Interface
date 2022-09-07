using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace introduccion_a_ADO
{
    public class ADOEstatus : ICRUDEstatus
    {

        string _ccnString = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;

         List<Estatus> _listEstatus = new List<Estatus>();
        Estatus valores = new Estatus();
        SqlCommand command;

        public ADOEstatus()
        {

        }

        public void Actualizar(Estatus estatus)
        {
            string query = $"AgregarEstatus";
            using (SqlConnection con = new SqlConnection(_ccnString))
            {
                command = new SqlCommand(query, con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", estatus.Id);
                command.Parameters.AddWithValue("@clave", estatus.Clave);
                command.Parameters.AddWithValue("@Nombre",estatus.Nombre);

                con.Open();
                command.ExecuteNonQuery();  
                con.Close();

                Console.WriteLine("\nRegistro Actualizado con exito\n");

            }

        }

        public int Agregar(Estatus estatus)
        {
        
           string  query = $"AEstatus";
            using (SqlConnection con = new SqlConnection(_ccnString))
            {
                command = new SqlCommand(query, con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Clave",estatus.Clave);
                command.Parameters.AddWithValue("@Nombre", estatus.Nombre);
                con.Open();
                estatus.Id=(Int32)command.ExecuteScalar();
                con.Close();

            }


            return estatus.Id;
        }
        
        public Estatus Consultar(int id)
        {
            string query = $"select * from EstatusAlumnos where id={id}";
            using (SqlConnection con = new SqlConnection(_ccnString))
            {
                command = new SqlCommand(query, con);
                command.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                  valores= new Estatus()
                    {

                        Nombre = reader["nombre"].ToString(),
                        Clave = reader["clave"].ToString()
                    };
                        
                }
                con.Close();
            }
            return valores;
        }

        public  List<Estatus> ConsultarTodo()
        {
            string query = $"select * from EstatusAlumnos";
            using (SqlConnection con = new SqlConnection(_ccnString))
            {
                command = new SqlCommand(query,con);
                command.CommandType = CommandType.Text; 
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _listEstatus.Add(
                        new Estatus()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre= reader["nombre"].ToString(),
                            Clave= reader["clave"].ToString()
                        }
                        );
                }
                con.Close();
            }
            return _listEstatus;
        }

        public void Eliminar(int id)
        {
            string query = $"delete EstatusAlumnos  where id={id}";
            using (SqlConnection con = new SqlConnection(_ccnString))
            {
                command = new SqlCommand(query, con);
                command.CommandType=CommandType.Text;
                con.Open();
                command.ExecuteNonQuery();
                con.Close();


                Console.WriteLine("\nRegistro Actualizado con exito\n");


            }
        }
    }

}
