using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database.combobox;
using database;
using System.IO;

namespace POKEDEX_ITLA
{
    public partial class frm_mantenimiento_pokemones : Form
    {
        database.database servicios;
        private string filename;
        private int id_pokemon;
        private string location;
        /*La diferencia entre el location y entre el filename es que
         el filename lo voy a utilizar cuando estemos agregando una foto nueva y el location
         lo vamos a utilizar cuando vamos a dejar la misma foto*/

        public frm_mantenimiento_pokemones()
        {
            id_pokemon = 0;
            filename = "";
            servicios = new database.database();
            InitializeComponent();
        }


        #region events
        private void frm_mantenimiento_pokemones_Load(object sender, EventArgs e)
        {
            Load_grid();
            Load_regiones();
            Load_tipos();
            deshabilitar_botones();
            dgv_pokemones.ClearSelection();
            
        }
        private void btn_foto_Click(object sender, EventArgs e)
        {
            agregar_foto();
        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {/*Esta condicion que tenenos aqui quiere decir que si el texto esta vacio o tiene espacion
            en blanco*/
            if (!string.IsNullOrWhiteSpace(tb_nombre.Text))
            {
                agregar();
                /*En esta condicion decimos que si el filename esta vacio es porque no estamos agregando
                 ninguna foto, asi que el metodo no se ejecuta, de lo contrario se va a ejecutar*/
                if (!string.IsNullOrEmpty(filename))
                {
                    guardar_foto();
                }
                limpiar_todo();
                Load_grid();
            }
            else
            {
                MessageBox.Show("El pokemon debe tener un nombre");
            }


            filename = "";


        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            editar();
            if (!string.IsNullOrEmpty(filename))
            {
                guardar_foto();
            }
            Load_grid();
            MessageBox.Show("Pokemon editado");
            deshabilitar_botones();
            limpiar_todo();
            filename = "";
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            var opcion = MessageBox.Show("Seguro que desea eliminar a este pokemon","",MessageBoxButtons.YesNo);
            if (opcion == DialogResult.Yes)
            {
                eliminar();
                MessageBox.Show("POKEMON ELIMINADO");
                deshabilitar_botones();
                limpiar_todo();
                Load_grid();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar_todo();
            deshabilitar_botones();
        }
        private void dgv_pokemones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            
            tb_nombre.Text = dgv_pokemones.Rows[index].Cells[0].Value.ToString();

            id_pokemon = servicios.Getid_pokemon(tb_nombre.Text);
            cb_tipo1.Text = dgv_pokemones.Rows[index].Cells[1].Value.ToString();
            cb_tipo2.Text = dgv_pokemones.Rows[index].Cells[2].Value.ToString();
            cb_region.Text = dgv_pokemones.Rows[index].Cells[3].Value.ToString();
            location = servicios.Get_foto(id_pokemon);
            pictureBox1.ImageLocation = location;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            habilitar_botones();
        }
        #endregion

        #region methods
        private void editar()
        {
            repositorio_pokemon pokemon = new repositorio_pokemon();
            comboboxitem tipo1 = cb_tipo1.SelectedItem as comboboxitem;
            comboboxitem tipo2 = cb_tipo2.SelectedItem as comboboxitem;
            comboboxitem region = cb_region.SelectedItem as comboboxitem;
            pokemon.id = id_pokemon;
            pokemon.nombre = tb_nombre.Text;
            pokemon.tipo1 = Convert.ToInt32(tipo1.value);
            pokemon.tipo2 = Convert.ToInt32(tipo2.value);
            pokemon.region = Convert.ToInt32(region.value);
            pokemon.foto = location;
            servicios.editar_pokemon(id_pokemon,pokemon);

        }
        private void eliminar()
        {
            servicios.eliminar_pokemon(id_pokemon);
            File.Delete(location);/*esto lo utilizamos para eliminar el archivo que contiene la foto*/
        }
        private void Load_grid()
        {
            dgv_pokemones.DataSource = servicios.Getpokemones();
        }
        private void agregar_foto()
        {
            DialogResult resultado = foto_pokemon.ShowDialog();/*Aqui lo primero que hacemos en almacenar
            el resultado del dialogo y suponemos que si el usuario le dio a OK es porque se anadio
            una imagen*/
            if (resultado == DialogResult.OK)
            {
                string file = foto_pokemon.FileName;//Aque sacamos el nombre del archivo
                filename = file;
                pictureBox1.ImageLocation = filename;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;/*Aqui se utiliza esta propiedad para
                que la imagen de adapte al tamaño del picture box*/
            }
        }
        private void agregar()
        {
            repositorio_pokemon pokemon = new repositorio_pokemon();
            comboboxitem tipo_selected = cb_tipo1.SelectedItem as comboboxitem;
            comboboxitem tipo_selected2 = cb_tipo2.SelectedItem as comboboxitem;
            comboboxitem region = cb_region.SelectedItem as comboboxitem;
            pokemon.nombre = tb_nombre.Text;
            pokemon.tipo1 = Convert.ToInt32(tipo_selected.value);
            pokemon.tipo2 = Convert.ToInt32(tipo_selected2.value);
            pokemon.region = Convert.ToInt32(region.value);
            
            switch (tipo_selected.value)
            {
                case null:
                    pokemon.tipo1 = 1;
                    break;

            }
            /*Con estos dos bucles switch me aseguro de que si el tipo pokemon no fue seleccionado
             entonces por defecto le ponga como valor 0 para que entonces tome como un N/A*/
            switch (tipo_selected2.value)
            {
                case null:
                    pokemon.tipo2 = 1;
                    break;

            }
            switch (region.value)
            {
                case null:
                    pokemon.region = 1;
                    break;

            }
            servicios.agregar_pokemon(pokemon);
        }
        private void guardar_foto()
        {/*Este es para guardar las fotos en una carpeta, pero no en la base de datos*/


            int id = id_pokemon == 0 ? servicios.Getlastid() : id_pokemon;
            /*en esta validacion decimos si id_pokemon == 0 entonces se ejecuta el servicio.getlastid
             de lo contratio tomaremos el valor que tenga el id_pokemon*/
            string directory = @"imagenes\pokemon\" + id + "\\";/*Aqui vamos a hacer un folder dentro
            de la varmeta pokemon, por cada pokemon que agreguemos*/

            string[] filenamesplit = filename.Split('\\');/*utilizamos este array para separar la ruta del
            archivo por espacios asi podremos conseguir solo el nombre del archivo*/
            string filename1 = filenamesplit[(filenamesplit.Length-1)];/*Aqui lo que hacemos es que 
            tomamos la ultima posicion del array que es donde se supone que se almacena el nombre del archivo*/
            crear_directorio(directory);
            string destination = directory + filename1; //Aqui le agregamos al directorio el nombre
            //de la imagen para entonces completar una ubicacion de donde se va a guardar

            File.Copy(filename,destination,true);/*finalmente aqui tomo la ubicacion de la imagen
            original para copiarla en el nuevo destino que yo cree y le pongo true para que en caso
            de que ya exista una imagen ahi con ese nombre, simplemente la sobreescriba*/

            servicios.guardar_foto(id,destination);
        }
        
        private void crear_directorio(string directorio)
        {
            /*Aqui verificamos si el directorio existe, si no existe entonces se va a crear
             */
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        }
        private void Load_tipos()
        {
            /*Aqui lo que hacemos es que llenamos los combobox que tienen los tipos de pokemos
             aparte de esto para poder utilizar la carpeta que tiene la clase del combobox item
             tenemos que declarar la clase alla arriba con el using <nombre de la carpeta>*/
            List<repositorio_tipos_pokemon> tipos_pokes = servicios.GetTipos_Pokemons();
            comboboxitem opcion_defecto = new comboboxitem
            {
                value = null,
                text = "Seleccione una opcion"
            };
            cb_tipo1.Items.Add(opcion_defecto);
            cb_tipo1.SelectedItem = opcion_defecto;
            cb_tipo2.Items.Add(opcion_defecto);
            cb_tipo2.SelectedItem = opcion_defecto;
            foreach (var item in tipos_pokes)
            {
                comboboxitem tipos = new comboboxitem
                {
                    value = item.id,
                    text = item.tipo
                };
                cb_tipo1.Items.Add(tipos);
                cb_tipo2.Items.Add(tipos);
            }


        }
        private void Load_regiones()
        {
            List<repositorio_regiones> regiones = servicios.Getregiones();
            comboboxitem opcion_defecto = new comboboxitem
            {
                value = null,
                text = "Seleccione una opcion"
            };
            cb_region.Items.Add(opcion_defecto);
            cb_region.SelectedItem = opcion_defecto;
            foreach (var item in regiones)
            {
                comboboxitem combobox = new comboboxitem
                {
                    value = item.id,
                    text = item.region
                };
                cb_region.Items.Add(combobox);
            }
        }
        private void deshabilitar_botones()
        {
            /*Este metodo es para deshabilitar los botones de editar, eliminar o cancelar
             despues de que se realizar cualquiera de estas acciones*/
            btn_cancelar.Enabled = false;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_agregar.Enabled = true;
            tb_nombre.Clear();
            

        }
        private void habilitar_botones()
        {
            btn_agregar.Enabled = false;
            btn_cancelar.Enabled = true;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;
        }

        private void limpiar_todo()
        {
            pictureBox1.ImageLocation = "";
            tb_nombre.Clear();
            cb_region.Text = "Seleccione una opcion";
            cb_tipo1.Text = "Seleccione una opcion";
            cb_tipo2.Text = "Seleccione una opcion";


        }




        #endregion

        
    }
}
