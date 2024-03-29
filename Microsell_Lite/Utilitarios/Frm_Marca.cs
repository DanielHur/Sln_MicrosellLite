﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Negocio;
using Prj_Capa_Datos;
namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Marca : Form
    {
        public bool editar = false;
        public Frm_Marca()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Marca();

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

        private void Configurar_listView() 
        {
            var lis = lsv_mar;
            lsv_mar.Items.Clear();
            lsv_mar.Columns.Clear();
            lsv_mar.View = View.Details;
            lsv_mar.GridLines = false;
            lsv_mar.FullRowSelect = true;
            lsv_mar.Scrollable = true;
            lsv_mar.HideSelection = false;
            //configurar la columnas
            lsv_mar.Columns.Add("ID", 40, HorizontalAlignment.Left);//0
            lsv_mar.Columns.Add("Marca", 200, HorizontalAlignment.Left);//1
        }

        private void Llenar_ListView(DataTable data) 
        {
            lsv_mar.Items.Clear();
            for (int i = 0; i<data.Rows.Count;i++) {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Marca"].ToString());
                list.SubItems.Add(dr["Marca"].ToString());
                lsv_mar.Items.Add(list);
            }
        
        }
        
        private void Cargar_Todos_Marca()
        {
            RN_Marca obj = new RN_Marca();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostar_Todas_Marcas();
            if (dato != null)
            {
                if (dato.Rows.Count > 0)
                {
                    Llenar_ListView(dato);
                }
                else
                {
                    lsv_mar.Items.Clear();
                }
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            txt_nom.Focus();
            editar = false;
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            RN_Marca obj = new RN_Marca();
            if (txt_nom.Text.Trim().Length == 0) { MessageBox.Show("Ingresa el nombre de la marca", "Registrar Marca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (editar == false)
            {
                //Nuevo
                obj.RN_Registrar_Marcas(txt_nom.Text);
                pnl_add.Visible = false;
                Cargar_Todos_Marca();
                txt_nom.Text = "";
            }
            else
            {
                //Editar
                obj.RN_Editar_Marca(Convert.ToInt32(txt_id.Text), txt_nom.Text);
                pnl_add.Visible = false;
                Cargar_Todos_Marca();
                txt_nom.Text = "";
                editar = false;

            }
            
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            if (lsv_mar.SelectedItems.Count == 0) 
            {
                MessageBox.Show("Seleccione el Item para editar","Advertencia de Seguridad",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);      
                return; 
            }
            else 
            { 
                var lsv = lsv_mar.SelectedItems[0];
                txt_id.Text = lsv.SubItems[0].Text;
                txt_nom.Text = lsv.SubItems[1].Text;
                pnl_add.Visible = true;
                txt_nom.Focus();
                editar = true;
            
            }
        }

        private void pnl_add_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (lsv_mar.SelectedIndices.Count == 0) 
            {
                MessageBox.Show("Seleccione el item para eliminar","Advertencia de Seguridad",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return; 
            }
            else 
            {
                var lsv = lsv_mar.SelectedItems[0];
                txt_id.Text = lsv.SubItems[0].Text;

                Frm_Sino sino = new Frm_Sino();

                sino.Lbl_msm1.Text = "Estas Seguro de eliminar esta marca";
                sino.ShowDialog();
                if (sino.Tag.ToString() == "Si") 
                {
                    RN_Marca rm = new RN_Marca();
                    rm.RN_Eliminar_Marca(Convert.ToInt32(txt_id.Text));
                    Cargar_Todos_Marca();
                }
            
            
            }
            
            
        }
    }
}
