using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProyectoPAV1.DataAccessLayer;
using ProyectoPAV1.BusinessLayer;


namespace ProyectoPAV1.GUILayer
{
    public partial class frmLogin : Form
    {
        private readonly UsuarioService usuarioService;

        public string UsuarioLogueado { get; internal set; }
        public frmLogin()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if ((txtUsuario.Text == ""))
            {
                MessageBox.Show("Se debe ingresar un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Validamos que se haya ingresado una password
            if ((txtContraseña.Text == ""))
            {
                MessageBox.Show("Se debe ingresar una contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Controlamos que las creadenciales sean las correctas. 
            var usr = usuarioService.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);
            //Controlamos que las creadenciales sean las correctas. 
            if (usr != null)
            {
                // Login OK
                UsuarioLogueado = usr.NombreUsuario;
                this.Close();
            }
            else
            {
                //Limpiamos el campo password, para que el usuario intente ingresar un usuario distinto.
                txtContraseña.Text = "";
                // Enfocamos el cursor en el campo password para que el usuario complete sus datos.
                txtContraseña.Focus();
                //Mostramos un mensaje indicando que el usuario/password es invalido.
                MessageBox.Show("Debe ingresar usuario y/o contraseña válidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //Mostramos el formulario al centro del formulario padre.
            this.CenterToParent();
        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {

        }
    }

}