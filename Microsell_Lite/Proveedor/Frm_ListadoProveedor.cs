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
    public partial class Frm_ListadoProveedor : Form
    {

        string xFotoruta;
        public Frm_ListadoProveedor()
        {
            InitializeComponent();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Proveedores();
        }

        private void Configurar_listView()
        {
            var lis = lv_proveedor;

            lv_proveedor.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 0, HorizontalAlignment.Left); //0
            lis.Columns.Add("Nombre de Proveedor", 450, HorizontalAlignment.Left);  //1

        }

        private void Llenar_ListView(DataTable data) 
        {
            lv_proveedor.Items.Clear();
            
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["IDPROVEE"].ToString());
                list.SubItems.Add(dr["NOMBRE"].ToString());
                lv_proveedor.Items.Add(list);

            }
        
        }
        private void Cargar_Todos_Proveedores() 
        { 
            RN_Proveedor obj = new RN_Proveedor();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostar_Todas_Proveedor();
            if (dato.Rows.Count > 0) 
            {
                Llenar_ListView(dato);
            }
            else 
            {
                lv_proveedor.Items.Clear();
            }
        
        }


        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void lbl_abrir_Click(object sender, EventArgs e)
        {


        }

        private bool Validar_Textobox() 
        {


            return true;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void lsv_prove_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lv_proveedor.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Selecciona un Proveedor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                lb_Id.Text = lv_proveedor.SelectedItems[0].SubItems[0].Text;
                lb_Nombre.Text = lv_proveedor.SelectedItems[0].SubItems[1].Text;

                this.Tag = "A";
                this.Close();
            }
        }

        private void lsv_prove_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lv_proveedor.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("Selecciona un Proveedor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    lb_Id.Text = lv_proveedor.SelectedItems[0].SubItems[0].Text;
                    lb_Nombre.Text = lv_proveedor.SelectedItems[0].SubItems[1].Text;

                    this.Tag = "A";
                    this.Close();

                }
            }
        }

        private void lv_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
