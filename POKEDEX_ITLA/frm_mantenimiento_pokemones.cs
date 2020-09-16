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

        }
        private void btn_foto_Click(object sender, EventArgs e)
        {
            agregar_foto();
        }
        #endregion

        #region methods
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
        private void guardar_foto()
        {

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

        #endregion

        
    }
}
