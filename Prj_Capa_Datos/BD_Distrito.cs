using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Prj_Capa_Datos
{
    public class BD_Distrito : BDConexion
    {
        public void BD_Registrar_Distrito(string nomDist)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_addDistrito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@distrito", nomDist);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El Ditrito se ha registrado Exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State==ConnectionState.Open)
                {
                   cn.Close();
                //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //editar
        public void BD_Editar_Distrito(int idDist, string nomDist)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Editar_Distrito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDis", idDist);
                cmd.Parameters.AddWithValue("@nomdis", nomDist);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El Distrito se ha editado Exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();                    
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void BD_Eliminar_Distrito(int idDistr)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_distrito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDis", idDistr);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El distrito se ha eliminado Exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();  
                }
                MessageBox.Show("Error al Eliminar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //mostrar
        public DataTable Bd_Mostar_Todas_Distrito()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Distritos", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data = new DataTable();
                da.Fill(data);
                da = null;
                return data;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Eliminar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }


    }
}
