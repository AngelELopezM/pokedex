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

        #region servicios a tipos 
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
        public bool verificar_tipo_en_uso(int id_tipo)
        {
            /*Esto aqui lo vamos a utilizar para verificar si la region que queremos eliminar esta siendo
             utilizada por algun poquemon, si retorna un verdadero entonces no debemos permitir que el usuario
             borre la region*/
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM pokemones WHERE tipo1 = @id or tipo2=@id", connection);
            command.Parameters.AddWithValue("@id", id_tipo);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
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
        public bool verificar_region_en_uso(int id_region)
        {
            /*Esto aqui lo vamos a utilizar para verificar si la region que queremos eliminar esta siendo
             utilizada por algun poquemon, si retorna un verdadero entonces no debemos permitir que el usuario
             borre la region*/
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM pokemones WHERE region = @id", connection);
            command.Parameters.AddWithValue("@id",id_region);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
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

        #region servicios pokemones
        public List<repositorio_regiones> Getregiones()
        {
            List<repositorio_regiones> regiones = new List<repositorio_regiones>();
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM regiones",connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    regiones.Add(new repositorio_regiones
                    {
                        id = reader.GetInt32(0),
                        region = reader.GetString(1)

                    });
                }
            }

            connection.Close();
            return regiones;

        }
        public List<repositorio_tipos_pokemon> GetTipos_Pokemons()
        {
            List<repositorio_tipos_pokemon> tipos = new List<repositorio_tipos_pokemon>();
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM tipo_pokemon",connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tipos.Add(new repositorio_tipos_pokemon
                    {
                        id = reader.GetInt32(0),
                        tipo = reader.GetString(1)
                    }) ;
                }

            }
            connection.Close();
            return tipos;
        }

        public int Getid_pokemon(string nombre)
        {
            /*Aqui conseguimos el id del pokemon que hemos seleccionado para poder realizar las ediciones*/
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT id FROM pokemones WHERE nombre=@nombre", connection);
            command.Parameters.AddWithValue("@nombre",nombre);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                int id = reader.GetInt32(0);
                connection.Close();
                return id;

            
            
        }
        public string Get_foto(int index)
        {
            /*Esto lo utilizamos para jalar el destino de la imagen que tenemos guardada desde la BD
             y despues pasarsela al picture box para que la cargue*/
            connection.Open();
            SqlCommand command = new SqlCommand("select foto from pokemones where id=@id",connection);
            command.Parameters.AddWithValue("@id",index);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string destination = reader.GetString(0);

            connection.Close();
            return destination;
        }
        public void agregar_pokemon(repositorio_pokemon pokemon)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO pokemones VALUES (@nombre, @foto,"+
                "@tipo1, @tipo2,@region )",connection);
            command.Parameters.AddWithValue("@nombre",pokemon.nombre);
            command.Parameters.AddWithValue("@foto","");
            command.Parameters.AddWithValue("@tipo1",pokemon.tipo1);
            command.Parameters.AddWithValue("@tipo2",pokemon.tipo2);
            command.Parameters.AddWithValue("@region",pokemon.region);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void guardar_foto(int id, string destination)
        {
            /*Este es para guardar la foto del pokemon en la base de datos*/
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE pokemones SET foto = @foto WHERE id=@id", connection);
            command.Parameters.AddWithValue("@id",id);
            command.Parameters.AddWithValue("@foto",destination);
            command.ExecuteNonQuery();

            connection.Close();
        }
        public void editar_pokemon(int index, repositorio_pokemon pokemon)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE pokemones SET nombre = @nombre, foto = @foto,"
                +"tipo1 = @tipo1, tipo2=@tipo2,region=@region WHERE id=@id",connection);
            command.Parameters.AddWithValue("@id",index);
            command.Parameters.AddWithValue("@nombre", pokemon.nombre);
            command.Parameters.AddWithValue("@foto", pokemon.foto);
            command.Parameters.AddWithValue("@tipo1", pokemon.tipo1);
            command.Parameters.AddWithValue("@tipo2", pokemon.tipo2);
            command.Parameters.AddWithValue("@region", pokemon.region);
            command.ExecuteNonQuery();

            connection.Close();
        }
        public void eliminar_pokemon(int index)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE pokemones WHERE id=@id",connection);
            command.Parameters.AddWithValue("@id",index);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public DataTable Getpokemones()
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("EXEC ST_getpokemones", connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
                connection.Close();
                return dt;
            }


            
            
        }
        public int Getlastid()
        {
            /*esta funcion es para poder encontrar el id del ultimo pokemon agregado*/
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT MAX(id) FROM pokemones",connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    int id = reader.GetInt32(0);
                    connection.Close();
                    return id;
                }
            }
            
            
        }

        #endregion

    }
}
