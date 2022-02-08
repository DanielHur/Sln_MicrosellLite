using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Prj_Capa_Entidad;

namespace Prj_Capa_Datos
{
    public class BD_Producto : BDConexion
    {

        public void BD_Registrar_Producto(EN_Producto en)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", en.Idpro);
                cmd.Parameters.AddWithValue("@idprove", en.Idprovee);
                cmd.Parameters.AddWithValue("@descripcion", en.Descripcion);
                cmd.Parameters.AddWithValue("@frank", en.Telefono);
                cmd.Parameters.AddWithValue("@Pre_compraSol", en.Rubro);
                cmd.Parameters.AddWithValue("@pre_CompraDolar", en.Ruc);
                cmd.Parameters.AddWithValue("@StockActual", en.Correo);
                cmd.Parameters.AddWithValue("@idCat", en.Contacto);
                cmd.Parameters.AddWithValue("@idMar", en.Fotologo);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El Proveedor se ha registrado Exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Editar_Proveedor(EN_Proveedor en)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproveedor", en.Idproveedor);
                cmd.Parameters.AddWithValue("@nombre", en.Nombreproveedor);
                cmd.Parameters.AddWithValue("@direccion", en.Direccion);
                cmd.Parameters.AddWithValue("@telefono", en.Telefono);
                cmd.Parameters.AddWithValue("@rubro", en.Rubro);
                cmd.Parameters.AddWithValue("@ruc", en.Ruc);
                cmd.Parameters.AddWithValue("@correo", en.Correo);
                cmd.Parameters.AddWithValue("@contacto", en.Contacto);
                cmd.Parameters.AddWithValue("@fotologo", en.Fotologo);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El Proveedor se ha modificado Exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al Editar: " + ex.Message, "Capa Dato Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //mostrar
        public DataTable Bd_Mostar_Todas_Proveedor()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Proveedores", cn);
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
                MessageBox.Show("Error al Buscar Todos: " + ex.Message, "Capa Dato Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }

        public DataTable Bd_Buscar_Proveedor(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_buscar_proveedor_porvalor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valor", valor);
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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Capa Dato Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }

    }
}
