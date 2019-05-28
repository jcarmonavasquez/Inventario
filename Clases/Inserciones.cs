using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProyectoInventario.Clases
{
    class Inserciones
    {
        public static bool Ejecucion(string comando)
        {
            try
            {
                string ConnString = Clases.Variables.conexion;
                SqlConnection conn = new SqlConnection(ConnString);
                SqlCommand cmd = new SqlCommand(comando, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error inesperado" + e.ToString());
                //Clases.Variables.Error = e.ToString();
                return false;
            }
        }
        public static void BEjecucion(string comando)
        {
            try
            {
                string ConnString = Clases.Variables.conexion;
                SqlConnection conn = new SqlConnection(ConnString);
                SqlCommand cmd = new SqlCommand(comando, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //Clases.Variables.ErrorB = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error inesperado \n" + e.ToString());
                Clases.Variables.ErrorB = true;
            }
        }
    }
}
