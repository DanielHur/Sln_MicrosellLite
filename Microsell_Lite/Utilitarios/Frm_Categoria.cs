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
    public partial class Frm_Categoria : Form
    {
        public bool editar = false;
        public Frm_Categoria()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_Categ();

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
            var lis = lsv_cat;
            lsv_cat.Items.Clear();
            lsv_cat.Columns.Clear();
            lsv_cat.View = View.Details;
            lsv_cat.GridLines = false;
            lsv_cat.FullRowSelect = true;
            lsv_cat.Scrollable = true;
            lsv_cat.HideSelection = false;
            //configurar la columnas
            lsv_cat.Columns.Add("ID", 40, HorizontalAlignment.Left);//0
            lsv_cat.Columns.Add("Categoria", 200, HorizontalAlignment.Left);//1
        }

        private void Llenar_ListView(DataTable data) 
        {
            lsv_cat.Items.Clear();
            for (int i = 0; i<data.Rows.Count;i++) {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Cat"].ToString());
                list.SubItems.Add(dr["Categoria"].ToString());
                lsv_cat.Items.Add(list);
            }
        
        }
        
        private void Cargar_Todos_Categ()
        {
            RN_Categoria obj = new RN_Categoria();
            DataTable dato = new DataTable();

            dato = obj.RN_Mostar_Todas_Categorias();
            if (dato != null)
            {
                if (dato.Rows.Count > 0)
                {
                    Llenar_ListView(dato);
                }
                else
                {
                    lsv_cat.Items.Clear();
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
            RN_Categoria obj = new RN_Categoria();
            if (txt_nom.Text.Trim().Length == 0) { MessageBox.Show("Ingresa el nombre de la categoria", "Registrar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (editar == false)
            {
                //Nuevo
                obj.RN_Registrar_Categoria(txt_nom.Text);
                pnl_add.Visible = false;
                Cargar_Todos_Categ();
                txt_nom.Text = "";
            }
            else
            {
                //Editar
                obj.RN_Editar_Categoria(Convert.ToInt32(txt_id.Text), txt_nom.Text);
                pnl_add.Visible = false;
                Cargar_Todos_Categ();
                txt_nom.Text = "";
                editar = false;

            }
            
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            if (lsv_cat.SelectedItems.Count == 0) 
            {
                MessageBox.Show("Seleccione el Item para editar","Advertencia de Seguridad",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);      
                return; 
            }
            else 
            { 
                var lsv = lsv_cat.SelectedItems[0];
                txt_id.Text = lsv.SubItems[0].Text;
                txt_nom.Text = lsv.SubItems[1].Text;
                pnl_add.Visible = true;
                txt_nom.Focus();
                editar = true;
            
            }
        }
    }
}
