using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Entidad;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    public class RN_Proveedor
    {
        public void RN_Registrar_Proveedor(EN_Proveedor en) 
        {
            BD_Proveedor obj = new BD_Proveedor();
            obj.BD_Registrar_Proveedor(en);
        }

        public void RN_Editar_Proveedor(EN_Proveedor en) 
        {
            BD_Proveedor obj = new BD_Proveedor();
            obj.BD_Editar_Proveedor(en);

        }

        public DataTable RN_Mostar_Todas_Proveedor()
        {
            BD_Proveedor obj = new BD_Proveedor();
            return obj.Bd_Mostar_Todas_Proveedor();

        }

    }
}
