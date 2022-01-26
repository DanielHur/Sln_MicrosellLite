using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;
using System.Data;

namespace Prj_Capa_Negocio
{
    public class RN_Distrito
    {
        public void BD_Registrar_Distrito(string nomDist) 
        {
            BD_Distrito obj = new BD_Distrito();
            obj.BD_Registrar_Distrito(nomDist);

        }

        public void BD_Editar_Distrito(int idDist, string nomDist) 
        {
            BD_Distrito obj = new BD_Distrito();
            obj.BD_Editar_Distrito(idDist, nomDist);

        }
        public void BD_Eliminar_Distrito(int idDistr) 
        {
            BD_Distrito obj = new BD_Distrito();
            obj.BD_Eliminar_Distrito(idDistr);

        }
        public DataTable Bd_Mostar_Todas_Distrito() 
        {

            BD_Distrito obj = new BD_Distrito();
            return obj.Bd_Mostar_Todas_Distrito();

        }


    }
}
