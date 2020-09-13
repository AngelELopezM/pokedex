using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POKEDEX_ITLA
{
    public partial class frm_mantenimiento_regiones : Form
    {
        database.database servicios;
        int id_region;
        public frm_mantenimiento_regiones()
        {
            servicios = new database.database();
            InitializeComponent();
        }

        #region eventos
        private void frm_mantenimiento_regiones_Load(object sender, EventArgs e)
        {
            deshabilitar_botones();
            Load_grid();
        }
        private void dgv_regiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                id_region = Convert.ToInt32(dgv_regiones.Rows[index].Cells[0].Value);
                tb_nombre_region.Text = dgv_regiones.Rows[index].Cells[1].Value.ToString();
                habilitar_botones();
            }
            catch (Exception)
            {

                
            }
            
        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (tb_nombre_region.Text == "")
            {
                MessageBox.Show("Debe introducir una region");
            }
            else
            {
                MessageBox.Show("Nueva region agregada");
                agregar();
                Load_grid();
            }
        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (tb_nombre_region.Text=="")
            {
                MessageBox.Show("El nombre no puede quedar vacio");
            }
            else
            {
                editar();
                deshabilitar_botones();
                MessageBox.Show("La region editada");
                Load_grid();
            }
            
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            string region = tb_nombre_region.Text;
            var opcion =  MessageBox.Show("Seguro que desea eliminar la region "+ region,"", MessageBoxButtons.YesNo);
            if (opcion == DialogResult.Yes)
            {
                eliminar();
                MessageBox.Show("Region eliminada");
                deshabilitar_botones();
                Load_grid();
            }
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            deshabilitar_botones();
        }
        private void btn_volver_Click(object sender, EventArgs e)
        {
            frm_principal principal = new frm_principal();
            principal.Show();
            this.Hide();
        }
        #endregion
        #region methods
        private void Load_grid()
        {
            dgv_regiones.DataSource = servicios.Get_reion();
        }
        private void agregar()
        {
            servicios.agregar_region(tb_nombre_region.Text);
        }
        private void editar()
        {
            string region = tb_nombre_region.Text;
            servicios.editar_region(id_region,region);
        }
        private void eliminar()
        {
            servicios.eliminar_region(id_region);
        }

        private void deshabilitar_botones()
        {
            /*Este metodo es para deshabilitar los botones de editar, eliminar o cancelar
             despues de que se realizar cualquiera de estas acciones*/
            btn_cancelar.Enabled = false;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_agregar.Enabled = true;
            tb_nombre_region.Clear();

        }
        private void habilitar_botones()
        {
            btn_agregar.Enabled = false;
            btn_cancelar.Enabled =  true;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;
        }





        #endregion

        
    }
}
