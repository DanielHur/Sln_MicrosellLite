using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Entidad;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
    public class BD_Productos : BDConexion
    {
        public static bool seGuardo;
        public static bool seEdito;

        public void BD_Registrar_Producto(EN_Productos en)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", en.Idpro);
                cmd.Parameters.AddWithValue("@idprove", en.Idprove);
                cmd.Parameters.AddWithValue("@descripcion", en.Descripcion);
                cmd.Parameters.AddWithValue("@frank", en.Frank);
                cmd.Parameters.AddWithValue("@Pre_compraSol", en.Pre_compraSol);
                cmd.Parameters.AddWithValue("@pre_CompraDolar", en.Pre_compraDolar);
                cmd.Parameters.AddWithValue("@StockActual", en.StockActual);
                cmd.Parameters.AddWithValue("@idCat", en.IdCat);
                cmd.Parameters.AddWithValue("@idMar", en.IdMar);
                cmd.Parameters.AddWithValue("@Foto", en.Foto);
                cmd.Parameters.AddWithValue("@Pre_Venta_Menor", en.Pre_venta_menor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Mayor ", en.Pre_venta_mayor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Dolar", en.Pre_venta_dolar);
                cmd.Parameters.AddWithValue("@UndMdida", en.UndMedida);
                cmd.Parameters.AddWithValue("@PesoUnit", en.PesoUnit);
                cmd.Parameters.AddWithValue("@Utilidad", en.Utilidad);
                cmd.Parameters.AddWithValue("@TipoProd", en.TipoProd);
                cmd.Parameters.AddWithValue("@ValorporProd", en.ValorPorProd);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El Producto se ha registrado Exitosamente");
                seGuardo = true;
            }
            catch (Exception ex)
            {
                seGuardo = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            }
        }


        public void BD_Editar_Producto(EN_Productos en)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", en.Idpro);
                cmd.Parameters.AddWithValue("@idprove", en.Idprove);
                cmd.Parameters.AddWithValue("@descripcion", en.Descripcion);
                cmd.Parameters.AddWithValue("@frank", en.Frank);
                cmd.Parameters.AddWithValue("@Pre_compraSol", en.Pre_compraSol);
                cmd.Parameters.AddWithValue("@pre_CompraDolar", en.Pre_compraDolar);
                cmd.Parameters.AddWithValue("@idCat", en.IdCat);
                cmd.Parameters.AddWithValue("@idMar", en.IdMar);
                cmd.Parameters.AddWithValue("@Foto", en.Foto);
                cmd.Parameters.AddWithValue("@Pre_Venta_Menor", en.Pre_venta_menor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Mayor ", en.Pre_venta_mayor);
                cmd.Parameters.AddWithValue("@Pre_Venta_Dolar", en.Pre_venta_dolar);
                cmd.Parameters.AddWithValue("@UndMdida", en.UndMedida);
                cmd.Parameters.AddWithValue("@PesoUnit", en.PesoUnit);
                cmd.Parameters.AddWithValue("@Utilidad", en.Utilidad);
                cmd.Parameters.AddWithValue("@TipoProd", en.TipoProd);
                
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seEdito = true;
                MessageBox.Show("El Producto se ha modificado Exitosamente");
            }
            catch (Exception ex)
            {
                seEdito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al Editar: " + ex.Message, "Capa Dato Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //mostrar
        public DataTable Bd_Mostar_Todas_Producto()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_cargar_Todos_Productos", cn);
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
                MessageBox.Show("Error al Buscar Todos: " + ex.Message, "Capa Dato Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }

        public DataTable Bd_Buscar_Productos(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_buscador_Productos", cn);
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
                MessageBox.Show("Error al Buscar: " + ex.Message, "Capa Dato Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }

        public void BD_DarBaja_Producto(string idprod)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Darbaja_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seEdito = true;
                MessageBox.Show("El Producto se ha dado de baja Exitosamente");
            }
            catch (Exception ex)
            {
                seEdito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al Dar de Baja: " + ex.Message, "Capa Dato Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Eliminar_Producto(string idprod)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Eliminar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seEdito = true;
                MessageBox.Show("El Producto se ha Eliminado Exitosamente");
            }
            catch (Exception ex)
            {
                seEdito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al Eliminar: " + ex.Message, "Capa Dato Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Sumar_Stock_Producto(string idprod, double stock)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_SumarStock", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);
                cmd.Parameters.AddWithValue("@stock", stock);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {
              
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al sumar stock: " + ex.Message, "Capa Dato Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Restar_Stock_Producto(string idprod, double stock)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Restar_Stock", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);
                cmd.Parameters.AddWithValue("@stock", stock);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al restar stock: " + ex.Message, "Capa Dato Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Actualizar_PrecioCompra_Producto(string idprod,double preCompS,double preVenMen,double utilidad, double valorAlmacen)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actulizar_Precios_CompraVenta_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Pro", idprod);
                cmd.Parameters.AddWithValue("@Pre_CompraS", preCompS);
                cmd.Parameters.AddWithValue("@Pre_vntaxMenor", preVenMen);
                cmd.Parameters.AddWithValue("@Utilidad", utilidad);
                cmd.Parameters.AddWithValue("@ValorAlmacen", valorAlmacen);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    //MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Dato Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MessageBox.Show("Error al actualizar Precion Compra: " + ex.Message, "Capa Dato Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
