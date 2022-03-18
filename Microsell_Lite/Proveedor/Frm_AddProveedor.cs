﻿using System;
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

namespace Microsell_Lite.Proveedor
{
    public partial class Frm_AddProveedor : Form
    {

        string xFotoruta;
        public Frm_AddProveedor()
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

            if (txt_idprov.Text.Trim().Length < 2) {fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el identificador para el proveedor"; ver.ShowDialog(); fil.Hide(); return false;}
            if (txt_nom_prov.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el nombre del proveedor"; ver.ShowDialog(); fil.Hide();txt_nom_prov.Focus(); return false; }
            if (txt_rubro.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el rubro para el proveedor"; ver.ShowDialog(); fil.Hide(); txt_rubro.Focus(); return false; }
            if (txt_ruc.Text.Trim().Length < 8) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa un RUC correcto para el proveedor"; ver.ShowDialog(); fil.Hide(); txt_ruc.Focus(); return false; }
            if (txt_corr.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa un correo para el proveedor"; ver.ShowDialog(); fil.Hide(); txt_corr.Focus(); return false; }
            if (txt_telf.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa un nro de telefono para el proveedor"; ver.ShowDialog(); fil.Hide(); txt_telf.Focus(); return false; }
            if (txt_nuec.Text.Trim().Length < 2) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa un contacto para el proveedor"; ver.ShowDialog(); fil.Hide(); txt_nuec.Focus(); return false; }

            return true;

        }

        private void Registrar_Proveedor() 
        {
            RN_Proveedor pr = new RN_Proveedor();
            EN_Proveedor en = new EN_Proveedor();

            try
            {
                en.Idproveedor = txt_idprov.Text;
                en.Rubro = txt_rubro.Text;
                en.Ruc = txt_ruc.Text;
                en.Telefono = txt_telf.Text;
                en.Correo = txt_corr.Text;
                en.Direccion = txt_dir_prov.Text;
                en.Nombreproveedor = txt_nom_prov.Text;
                en.Contacto = txt_nuec.Text;
                en.Fotologo = xFotoruta;
                pr.RN_Registrar_Proveedor(en);
                limpiarForm();
                this.Tag = "A";
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Guardar: " +ex.Message,"Form Add Proveedor",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        
        
        }

        private void limpiarForm() 
        {
            txt_corr.Text = "";
            txt_dir_prov.Text = "";
            txt_idprov.Text = "";
            txt_nom_prov.Text = "";
            txt_nuec.Text = "";
            txt_rubro.Text = "";
            txt_ruc.Text = "";
            txt_telf.Text = "";
        
        
        }







        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if(Validar_Textobox() == true)
            {
                Registrar_Proveedor();

            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
