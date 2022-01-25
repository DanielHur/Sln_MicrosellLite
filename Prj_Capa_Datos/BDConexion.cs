using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Datos
{
    public class BDConexion
    {
        public string Conectar()
        {
            return @"data Source=DESKTOP-M9TOKFV\SQLEXPRESS;Initial Catalog=POS_Microsell_Lite;Integrated Security = true";//"data source =DESKTOP-M9TOKFV\SQLEXPRESS;Initial Catalog=POS_Microsell_Lite;Integrated security=true";
            
        }
    }
}
