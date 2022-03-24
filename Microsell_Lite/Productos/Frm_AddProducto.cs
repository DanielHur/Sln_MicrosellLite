using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Utilitarios;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Microsell_Lite.Proveedor;

namespace Microsell_Lite.Productos
{
    public partial class Frm_AddProducto : Form
    {

        string xFotoruta;
        public Frm_AddProducto()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {

        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_abrir_Click(object sender, EventArgs e)
        {
            var FilePath = string.Empty;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK) 
                {
                    xFotoruta = openFileDialog1.FileName;
                    piclogo.Load(xFotoruta);
                }
            }
            catch (Exception ex)
            {

                piclogo.Load(Application.StartupPath + @"\usuario2.png");
                xFotoruta = Application.StartupPath + @"\usuario2.png";
                MessageBox.Show("Error al guardar imagen de Proveedor", ex.Message);




            }

        }

        private bool Validar_Textobox() 
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (txt_IdProd.Text.Trim().Length < 2) {fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el identificador para el proveedor"; ver.ShowDialog(); fil.Hide(); return false;}
            if (txt_DesProd.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el nombre del proveedor"; ver.ShowDialog(); fil.Hide();txt_DesProd.Focus(); return false; }
            if (txt_Categoria.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el rubro para el proveedor"; ver.ShowDialog(); fil.Hide(); txt_Categoria.Focus(); return false; }
            if (txt_ruc.Text.Trim().Length < 8) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa un RUC correcto para el proveedor"; ver.ShowDialog(); fil.Hide(); txt_ruc.Focus(); return false; }
            if (txt_corr.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa un correo para el proveedor"; ver.ShowDialog(); fil.Hide(); txt_corr.Focus(); return false; }
            if (txt_Marca.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa un nro de telefono para el proveedor"; ver.ShowDialog(); fil.Hide(); txt_Marca.Focus(); return false; }
            if (txt_PrecioUnitario.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa un contacto para el proveedor"; ver.ShowDialog(); fil.Hide(); txt_PrecioUnitario.Focus(); return false; }

            return true;

        }



        private void limpiarForm() 
        {
            txt_corr.Text = "";
            txt_Prov.Text = "";
            txt_IdProd.Text = "";
            txt_DesProd.Text = "";
            txt_PrecioUnitario.Text = "";
            txt_Categoria.Text = "";
            txt_ruc.Text = "";
            txt_Marca.Text = "";
        
        
        }







        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_listo_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {





        }

            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProveedor lis = new Frm_ListadoProveedor();
            


            fil.Show();
            
            lis.ShowDialog();
            fil.Hide();

            if (lis.Tag.ToString() == "A") 
            {
                txt_Prov.Text = lis.lb_Nombre.Text;
                lbl_IdProvee.Text = lis.lb_Id.Text;  


            }

        }
    }
}
