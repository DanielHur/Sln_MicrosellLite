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

        public static bool seguardo = false;
        public static bool seedito = false;


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
                cmd.Parameters.AddWithValue("@frank", en.Frank);
                cmd.Parameters.AddWithValue("@Pre_compraSol", en.Pre_compraSol);
                cmd.Parameters.AddWithValue("@pre_CompraDolar", en.Pre_CompraDolar);
                cmd.Parameters.AddWithValue("@StockActual", en.StockActual);
                cmd.Parameters.AddWithValue("@idCat", en.IdCat);
                cmd.Parameters.AddWithValue("@idMar", en.IdMar);
                cmd.Parameters.AddWithValue("@Foto", en.Foto);
                cmd.Parameters.AddWithValue("@Pre_Venta_Menor", en.Pre_venta_menor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Mayor", en.Pre_venta_mayor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Dolar", en.Pre_venta_Dolar);
                cmd.Parameters.AddWithValue("@UndMdida", en.UndMedida);
                cmd.Parameters.AddWithValue("@PesoUnit", en.PesoUnit);
                cmd.Parameters.AddWithValue("@Utilidad", en.Utilidad);
                cmd.Parameters.AddWithValue("@TipoProd", en.TipoProd);
                cmd.Parameters.AddWithValue("@ValorporProd", en.ValorProd);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                seguardo = true;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Editar_Producto(EN_Producto en)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", en.Idpro);
                cmd.Parameters.AddWithValue("@idprove", en.Idprovee);
                cmd.Parameters.AddWithValue("@descripcion", en.Descripcion);
                cmd.Parameters.AddWithValue("@frank", en.Frank);
                cmd.Parameters.AddWithValue("@Pre_compraSol", en.Pre_compraSol);
                cmd.Parameters.AddWithValue("@pre_CompraDolar", en.Pre_CompraDolar);
                cmd.Parameters.AddWithValue("@idCat", en.IdCat);
                cmd.Parameters.AddWithValue("@idMar", en.IdMar);
                cmd.Parameters.AddWithValue("@Foto", en.Foto);
                cmd.Parameters.AddWithValue("@Pre_Venta_Menor", en.Pre_venta_menor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Mayor", en.Pre_venta_mayor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Dolar", en.Pre_venta_Dolar);
                cmd.Parameters.AddWithValue("@UndMdida", en.UndMedida);
                cmd.Parameters.AddWithValue("@PesoUnit", en.PesoUnit);
                cmd.Parameters.AddWithValue("@Utilidad", en.Utilidad);
                cmd.Parameters.AddWithValue("@TipoProd", en.TipoProd);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                seedito = true;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    seedito = false;
                    cn.Close();
                    //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al Editar: " + ex.Message, "Capa Dato Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
