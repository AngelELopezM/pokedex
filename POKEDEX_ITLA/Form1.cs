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
    public partial class frm_principal : Form
    {
        public frm_principal()
        {
            InitializeComponent();
        }

        #region events
        private void btn_mant_tipos_Click(object sender, EventArgs e)
        {
            frm_mantenimiento_tipos tipos = new frm_mantenimiento_tipos();
            tipos.Show();
            this.Hide();
        }
        private void btn_mant_regiones_Click(object sender, EventArgs e)
        {
            frm_mantenimiento_regiones regiones = new frm_mantenimiento_regiones();
            regiones.Show();
            this.Hide();
        }
        private void btn_mant_pokemon_Click(object sender, EventArgs e)
        {
            frm_mantenimiento_pokemones pokemones = new frm_mantenimiento_pokemones();
            pokemones.Show();
            this.Hide();

        }
        #endregion


    }
}
