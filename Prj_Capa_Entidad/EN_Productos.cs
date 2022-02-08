using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Productos
    {
        //@idpro char (20),
        private string _idpro;

        //@idprove char (6),
        private string _idprove;

        //@descripcion varchar(150),
        private string _descripcion;

        //@frank real,
        private double frank;

        //@Pre_compraSol real,
        private double _pre_compraSol;

        //@pre_CompraDolar real,
        private double _pre_compraDolar;

        //@StockActual real,
        private double _stockActual;

        //@idCat int,
        private int _idCat;

        //@idMar int,
        private int _idMar;

        //@Foto varchar(180),
        private string _foto;


        //@Pre_Venta_Menor real,
        private double _pre_venta_menor;

        //@Pre_Venta_Mayor real,
        private double _pre_venta_mayor;

        //@Pre_Venta_Dolar real,
        private double _pre_venta_dolar;

        //@UndMdida char (6),
        private string _undMedida;

        //@PesoUnit real,
        private double _pesoUnit;

        //@Utilidad real,
        private double _utilidad;

        //@TipoProd varchar(12),
        private string _tipoProd;

        //@ValorporProd real
        private double _valorPorProd;

    }
}
