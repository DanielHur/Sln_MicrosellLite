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
    public class BD_Proveedor : BDConexion
    {

        public void BD_Registrar_Proveedor(EN_Proveedor en)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_Proveedor", cn);
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
                SqlCommand cmd = new SqlCommand("sp_Modificar_Proveedor", cn);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Error al Eliminar: " + ex.Message, "Capa Dato Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }



    }
}
