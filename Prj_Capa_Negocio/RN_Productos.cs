using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;

namespace Prj_Capa_Negocio
{
    public class RN_Productos
    {
        public void RN_Registrar_Producto(EN_Productos pro)
        {

            BD_Productos obj = new BD_Productos();
            obj.BD_Registrar_Producto(pro);

        }
        public void RN_Editar_Producto(EN_Productos pro)
        {

            BD_Productos obj = new BD_Productos();
            obj.BD_Editar_Producto(pro);


        }
        public DataTable RN_Mostar_Todas_Producto()
        {

            BD_Productos obj = new BD_Productos();
            return obj.Bd_Mostar_Todas_Producto();
        }

        public DataTable RN_Buscar_Productos(string valor) 
        {
            BD_Productos obj = new BD_Productos();
            return obj.BD_Buscar_Productos(valor);
        }
        public void RN_DarBaja_Producto(string idprod)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_DarBaja_Producto(idprod);

        }

        public void RN_Eliminar_Producto(string idprod)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Eliminar_Producto(idprod);

        }
        public void RN_Sumar_Stock_Producto(string idprod, double stock)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Sumar_Stock_Producto(idprod,stock);

        }
        public void RN_Restar_Stock_Producto(string idprod, double stock)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Restar_Stock_Producto(idprod, stock);

        }

        public void RN_Actualizar_PrecioCompra_Producto(string idprod, double preCompS, double preVenMen, double utilidad, double valorAlmacen)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Actualizar_PrecioCompra_Producto(idprod, preCompS, preVenMen, utilidad, valorAlmacen);

        }

    }
}
