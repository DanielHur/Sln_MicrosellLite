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
namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Categoria : Form
    {
        public Frm_Categoria()
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

        }

    }
}
