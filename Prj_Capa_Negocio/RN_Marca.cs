using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;
using System.Data;


namespace Prj_Capa_Negocio
{
    public class RN_Marca
    {
        public void RN_Registrar_Marcas(string nomMarca)
        {
            BD_Marcas obj = new BD_Marcas();
            obj.BD_Registrar_Marcas(nomMarca);

        }

        public void RN_Editar_Marca(int idMarca, string nomMarca)
        {
            BD_Marcas obj = new BD_Marcas();
            obj.BD_Editar_Marca(idMarca, nomMarca);


        }

        public DataTable RN_Mostar_Todas_Marcas()
        {
            BD_Marcas obj = new BD_Marcas();
            return obj.Bd_Mostar_Todas_Marcas();

        }

        public void RN_Eliminar_Marca(int idMarca) 
        {
            BD_Marcas obj = new BD_Marcas();
            obj.BD_Eliminar_Marca(idMarca);

        }

    }
}
