using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    public class RN_Categoria
    {
        public void RN_Registrar_Categoria(string nomCate)
        {
            BD_Categoria obj = new BD_Categoria();
            obj.BD_Registrar_Categoria(nomCate);

        }

        public void RN_Editar_Categoria(int idcateg, string nomCate)
        {
            BD_Categoria obj = new BD_Categoria();
            obj.BD_Editar_Categoria(idcateg, nomCate);


        }

        public DataTable RN_Mostar_Todas_Categorias()
        {
            BD_Categoria obj = new BD_Categoria();
            return obj.Bd_Mostar_Todas_Categorias();

        }

    }
}
