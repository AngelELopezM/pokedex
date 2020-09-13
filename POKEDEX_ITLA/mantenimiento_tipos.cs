using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database;

namespace POKEDEX_ITLA
{
    public partial class frm_mantenimiento_tipos : Form
    {
        database.database servicios;
        public int id;
        public frm_mantenimiento_tipos()
        {
            servicios = new database.database();
            InitializeComponent();
        }


        #region events
        private void button2_Click(object sender, EventArgs e)
        {
            if (tb_nombre_tipo.Text == "")
            {
                MessageBox.Show("Debes digitar un tipo de pokemon", "POKEDEX");
            }
            else
            {
                editar();
                deshabilitar_botones();
                Load_grid();
                dgv_tipos.ClearSelection();
            }
            
           
        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (tb_nombre_tipo.Text == "")
            {
                MessageBox.Show("Debes digitar un tipo de pokemon","POKEDEX");
            }
            else
            {
                agregar();
                Load_grid();
                dgv_tipos.ClearSelection();
            }
            
        }

        private void frm_mantenimiento_tipos_Load(object sender, EventArgs e)
        {
            Load_grid();

            
        }
        
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            eliminar();
            Load_grid();
            dgv_tipos.ClearSelection();
        }
        private void dgv_tipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;


                id = Convert.ToInt32(dgv_tipos.Rows[index].Cells[0].Value);
                tb_nombre_tipo.Text = dgv_tipos.Rows[index].Cells[1].Value.ToString();
                habilitar_botones();
            }
            catch (Exception)
            {

                
            }
            
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            deshabilitar_botones();
            tb_nombre_tipo.Clear();
            dgv_tipos.ClearSelection();
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
            dgv_tipos.DataSource = servicios.Get_tipos();
        }
        private void agregar()
        {
            servicios.agregar_tipo(tb_nombre_tipo.Text);
            tb_nombre_tipo.Clear();
            dgv_tipos.ClearSelection();
        }
        private void editar()
        {
            string tipo_poke = tb_nombre_tipo.Text;
            servicios.editar_tipo(id, tipo_poke);
            tb_nombre_tipo.Clear();
            dgv_tipos.ClearSelection();
        }
        private void eliminar()
        {
            servicios.eliminar(id);
            tb_nombre_tipo.Clear();
            dgv_tipos.ClearSelection();
        }

        private void habilitar_botones()
        {
            /*Con este metodo habilitamos los botones de cancelar, editar y eliminar
             y desabilitamos el boton de agregar*/
            btn_cancelar.Enabled = true;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;
            btn_agregar.Enabled = false;
        }
        private void deshabilitar_botones()
        {
            
            btn_cancelar.Enabled = false;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_agregar.Enabled = true;
        }






        #endregion

        
    }
}
