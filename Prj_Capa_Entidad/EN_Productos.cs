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

        public string Idpro { get => _idpro; set => _idpro = value; }
        public string Idprove { get => _idprove; set => _idprove = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public double Frank { get => frank; set => frank = value; }
        public double Pre_compraSol { get => _pre_compraSol; set => _pre_compraSol = value; }
        public double Pre_compraDolar { get => _pre_compraDolar; set => _pre_compraDolar = value; }
        public double StockActual { get => _stockActual; set => _stockActual = value; }
        public int IdCat { get => _idCat; set => _idCat = value; }
        public int IdMar { get => _idMar; set => _idMar = value; }
        public string Foto { get => _foto; set => _foto = value; }
        public double Pre_venta_menor { get => _pre_venta_menor; set => _pre_venta_menor = value; }
        public double Pre_venta_mayor { get => _pre_venta_mayor; set => _pre_venta_mayor = value; }
        public double Pre_venta_dolar { get => _pre_venta_dolar; set => _pre_venta_dolar = value; }
        public string UndMedida { get => _undMedida; set => _undMedida = value; }
        public double PesoUnit { get => _pesoUnit; set => _pesoUnit = value; }
        public double Utilidad { get => _utilidad; set => _utilidad = value; }
        public string TipoProd { get => _tipoProd; set => _tipoProd = value; }
        public double ValorPorProd { get => _valorPorProd; set => _valorPorProd = value; }
    }
}
