using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Producto
    {

        //        @idpro char (20),
        private String _idpro;

        //@idprove char (6),
        private String _idprovee;

        //@descripcion varchar(150),
        private String _descripcion;
        
        //@frank real,
        private Double _frank;

        //@Pre_compraSol real,
        private Double _pre_compraSol;

        //@pre_CompraDolar real,
        private Double _pre_CompraDolar;

        //@StockActual real,
        private Double _stockActual;

        //@idCat int,
        private int _idCat;

        //@idMar int,
        private int _idMar;


        //@Foto varchar(180),
        private String _foto;

        //@Pre_Venta_Menor real,
        private Double _pre_venta_menor;

        //@Pre_Venta_Mayor real,
        private Double _pre_venta_mayor;

        //@Pre_Venta_Dolar real,
        private Double _pre_venta_Dolar;

        //@UndMdida char (6),
        private String _UndMedida;

        //@PesoUnit real,
        private Double _pesoUnit;

        //@Utilidad real,
        private Double _utilidad;

        //@TipoProd varchar(12),
        private String _tipoProd;


        //@ValorporProd real
        private Double _valorProd;

        public string Idpro { get => _idpro; set => _idpro = value; }
        public string Idprovee { get => _idprovee; set => _idprovee = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public double Frank { get => _frank; set => _frank = value; }
        public double Pre_compraSol { get => _pre_compraSol; set => _pre_compraSol = value; }
        public double Pre_CompraDolar { get => _pre_CompraDolar; set => _pre_CompraDolar = value; }
        public double StockActual { get => _stockActual; set => _stockActual = value; }
        public int IdCat { get => _idCat; set => _idCat = value; }
        public int IdMar { get => _idMar; set => _idMar = value; }
        public string Foto { get => _foto; set => _foto = value; }
        public double Pre_venta_menor { get => _pre_venta_menor; set => _pre_venta_menor = value; }
        public double Pre_venta_mayor { get => _pre_venta_mayor; set => _pre_venta_mayor = value; }
        public double Pre_venta_Dolar { get => _pre_venta_Dolar; set => _pre_venta_Dolar = value; }
        public string UndMedida { get => _UndMedida; set => _UndMedida = value; }
        public double PesoUnit { get => _pesoUnit; set => _pesoUnit = value; }
        public double Utilidad { get => _utilidad; set => _utilidad = value; }
        public string TipoProd { get => _tipoProd; set => _tipoProd = value; }
        public double ValorProd { get => _valorProd; set => _valorProd = value; }
    }
}
