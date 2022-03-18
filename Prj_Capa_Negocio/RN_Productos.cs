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




    }
}
