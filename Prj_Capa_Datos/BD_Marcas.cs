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
    public class BD_Marcas : BDConexion
    {
        //registrar Marca
        public void BD_Registrar_Marcas(string nomMarca)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_addMarca", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@marca", nomMarca);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La Marca se ha registrado Exitosamente");
            }
            catch (Exception ex)
            {
                //   if (cn.State==ConnectionState.Open)
                //  {
                //      cn.Close();
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Marca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //  }
            }
        }


        //editar
        public void BD_Editar_Marca(int idMarca, string nomMarca)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Editar_Marca", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmar", idMarca);
                cmd.Parameters.AddWithValue("@nom_marca", nomMarca);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La Marca se ha editado Exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Marca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //mostrar
        public DataTable Bd_Mostar_Todas_Marcas()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todas_Marcas", cn);
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
                    MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Dato Marcas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return null;
            }

        }


    }
}
