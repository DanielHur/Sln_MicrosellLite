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
    public class BD_Categoria : BDConexion
    {
        public void BD_Registrar_Categoria(string nomCate)
        {
            SqlConnection cn = new SqlConnection();
            try 
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_categoria", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nomCate);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La categoria se ha registrado Exitosamente");
            }
            catch (Exception ex) 
            { 
                if (cn.State==ConnectionState.Open)
                {
                    cn.Close();
                    MessageBox.Show("Error al Guardar: "+ex.Message,"Capa Dato Categoria",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
        }


        //editar
        public void BD_Editar_Categoria(int idcateg, string nomCate)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_modificar_categoria", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcat", idcateg);
                cmd.Parameters.AddWithValue("@nombre", nomCate);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La categoria se ha editado Exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //mostrar
        public DataTable Bd_Mostar_Todas_Categorias() 
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_listar_todas_Categorias",cn);
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
                    MessageBox.Show("Error al Consultar: " + ex.Message, "Capa Dato Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return null;
            }

        }

    }
}
