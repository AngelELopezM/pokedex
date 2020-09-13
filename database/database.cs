using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace database
{
    
    public class database
    {
        private SqlConnection connection;
        public database()
        {
            var connectionstring = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            connection = new SqlConnection(connectionstring);
        }

        #region servicios a tipos de pokemon
        /*Aqui voy a poner todo lo relacionado con manejar los tipos de pokemos*/
        public void agregar_tipo(string nombre_tipo)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO tipo_pokemon VALUES(@tipo_poke)", connection);
            command.Parameters.AddWithValue("@tipo_poke",nombre_tipo);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void editar_tipo(int index, string nombre_tipo)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE tipo_pokemon SET tipo = @nombre_tipo "+
                " WHERE id_tipo = @id_tipo",connection);
            command.Parameters.AddWithValue("@nombre_tipo", nombre_tipo);
            command.Parameters.AddWithValue("@id_tipo",index);
            command.ExecuteNonQuery();
            
            connection.Close();
        }
        public void eliminar(int index)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM tipo_pokemon WHERE id_tipo = @id_tipo", connection);
            command.Parameters.AddWithValue("@id_tipo",index);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable Get_tipos()
        {
            /*Aqui lo que hacemos en que ejecutamos el comando, despues de eso lo convertimos con el dataadapter
             y despues llenamos el datatable con el data adapter de esa manera extrana pero que funciona
             y retornamos el data table que es lo que va a usar el grid para llenarse*/
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT id_tipo as [ID], tipo as [Tipo de pokemon] FROM tipo_pokemon", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            
            connection.Close();
            return dt;
        }
        #endregion

        #region sevicios a regiones
        public void agregar_region(string region)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO regiones VALUES (@region)",connection);
            command.Parameters.AddWithValue("@region",region);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void editar_region(int index,string region)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE regiones SET region = @region "+
                " WHERE id_region = @id_region",connection);
            command.Parameters.AddWithValue("@region",region);
            command.Parameters.AddWithValue("@id_region",index);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void eliminar_region(int index)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE regiones WHERE id_region = @id_region",connection);
            command.Parameters.AddWithValue("@id_region",index);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable Get_reion()
        {
            /*Aqui lo que hacemos en que ejecutamos el comando, despues de eso lo convertimos con el dataadapter
             y despues llenamos el datatable con el data adapter de esa manera extrana pero que funciona
             y retornamos el data table que es lo que va a usar el grid para llenarse*/
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT id_region as ID, region as Region from regiones",connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        #endregion

    }
}
