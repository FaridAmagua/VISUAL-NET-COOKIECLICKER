using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CookieClic
{
    public class AccesoDatos
    {
        //Campos Privados
        public string connectionStr = "Server=127.0.0.1;Port=3306;Database=cookieclic;Uid=root;password=1234;";
        
        //Propiedades Publicas
        public MySqlConnection conn;
       
        //Constructor(es)
        public AccesoDatos()
        {
            conn = new MySqlConnection(connectionStr);
        }
        //Metodos

        public int LlamarPARegistrar(string nuevoUsuario, string nuevaPass)
        {
            try
            {
                conn = ConectarmeABaseDatos();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "RegistrarUsuario";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@_usuario", nuevoUsuario);
                cmd.Parameters["@_usuario"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@_pass", nuevaPass);
                cmd.Parameters["@_pass"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@_res", MySqlDbType.Int32);
                cmd.Parameters["@_res"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                //MessageBox.Show("Resultado de ejecucion del PA: " + cmd.Parameters["@_res"].Value);
                DesconectarmeDeBaseDatos();
                return int.Parse(cmd.Parameters["@_res"].Value.ToString());
            }
            catch(Exception e)
            {
                //MessageBox.Show("Error al lanzar la llamada al PA: " + e.Message);
                return -99;
            }
        }

        public MySqlConnection ConectarmeABaseDatos()
        {
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                MessageBox.Show("Algo ha fallado " + e.Message);
                return null;
            }
        }
        public void DesconectarmeDeBaseDatos()
        {
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Algo ha fallado al cerrar la conexion " + e.Message);
            }
        }
    }
}
