using System;
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
    public partial class Frm_Distrito : Form
    {
        public bool editar = false;
        public Frm_Distrito()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Distr();

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
            var lis = lsv_dis;
            lsv_dis.Items.Clear();
            lsv_dis.Columns.Clear();
            lsv_dis.View = View.Details;
            lsv_dis.GridLines = false;
            lsv_dis.FullRowSelect = true;
            lsv_dis.Scrollable = true;
            lsv_dis.HideSelection = false;
            //configurar la columnas
            lsv_dis.Columns.Add("ID", 40, HorizontalAlignment.Left);//0
            lsv_dis.Columns.Add("Distrito", 200, HorizontalAlignment.Left);//1
        }

        private void Llenar_ListView(DataTable data) 
        {
            lsv_dis.Items.Clear();
            for (int i = 0; i<data.Rows.Count;i++) {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Dis"].ToString());
                list.SubItems.Add(dr["Distrito"].ToString());
                lsv_dis.Items.Add(list);
            }
        
        }
        
        private void Cargar_Todos_Distr()
        {
            RN_Distrito obj = new RN_Distrito();
            DataTable dato = new DataTable();

            dato = obj.Bd_Mostar_Todas_Distrito();
            if (dato != null)
            {
                if (dato.Rows.Count > 0)
                {
                    Llenar_ListView(dato);
                }
                else
                {
                    lsv_dis.Items.Clear();
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
            RN_Distrito obj = new RN_Distrito();
            if (txt_nom.Text.Trim().Length == 0) { MessageBox.Show("Ingresa el nombre del distrito", "Registrar Distrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (editar == false)
            {
                //Nuevo
                obj.BD_Registrar_Distrito(txt_nom.Text);
                pnl_add.Visible = false;
                Cargar_Todos_Distr();
                txt_nom.Text = "";
            }
            else
            {
                //Editar
                obj.BD_Editar_Distrito(Convert.ToInt32(txt_id.Text), txt_nom.Text);
                pnl_add.Visible = false;
                Cargar_Todos_Distr();
                txt_nom.Text = "";
                editar = false;

            }
            
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            if (lsv_dis.SelectedItems.Count == 0) 
            {
                MessageBox.Show("Seleccione el Item para editar","Advertencia de Seguridad",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);      
                return; 
            }
            else 
            { 
                var lsv = lsv_dis.SelectedItems[0];
                txt_id.Text = lsv.SubItems[0].Text;
                txt_nom.Text = lsv.SubItems[1].Text;
                pnl_add.Visible = true;
                txt_nom.Focus();
                editar = true;
            
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (lsv_dis.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccione el item para eliminar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                var lsv = lsv_dis.SelectedItems[0];
                txt_id.Text = lsv.SubItems[0].Text;

                Frm_Sino sino = new Frm_Sino();

                sino.Lbl_msm1.Text = "Estas Seguro de eliminar esta marca";
                sino.ShowDialog();
                if (sino.Tag.ToString() == "Si")
                {
                    RN_Distrito rm = new RN_Distrito();
                    rm.BD_Eliminar_Distrito(Convert.ToInt32(txt_id.Text));
                    Cargar_Todos_Distr();
                }


            }

        }
    }
}
