using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoPAV1.Entities;
using ProyectoPAV1.BusinessLayer;

namespace ProyectoPAV1.GUILayer.Marcas
{
    public partial class frmABMMarcas : Form
    {

        private FormMode formMode = FormMode.insert;
        private readonly MarcaService oMarcaService;
        private Marca oMarcaSelected;



        public frmABMMarcas()
        {

            InitializeComponent();
            oMarcaService = new MarcaService();
        }

        public enum FormMode
        {
            insert,
            update,
            delete
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ExisteMarca() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oMarca = new Marca();
                                oMarca.NombreMarca = txtNombre.Text;
                                

                                if (oMarcaService.CrearMarca(oMarca))
                                {
                                    MessageBox.Show("Marca insertada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Nombre de marca encontrada!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oMarcaSelected.NombreMarca = txtNombre.Text;
                           

                            if (oMarcaService.ActualizarMarca(oMarcaSelected))
                            {
                                MessageBox.Show("Marca actualizada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar Marca!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar la marca seleccionada?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oMarcaService.ModificarEstadoMarca(oMarcaSelected))
                            {
                                MessageBox.Show("Marca Habilitada/Deshabilitada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar el usuario!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

            }
        }

        private bool ExisteMarca()
        {
            return oMarcaService.ObtenerMarca(txtNombre.Text) != null;
        }

        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtNombre.Text == string.Empty)
            {
                txtNombre.BackColor = Color.Red;
                txtNombre.Focus();
                return false;
            }
            else
                txtNombre.BackColor = Color.White;

            return true;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmABMMarcas_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nueva Marca";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Marca";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        //txtNombre.Enabled = true;
                        //txtEmail.Enabled = true;
                        //txtEmail.Enabled = true;
                        //txtPassword.Enabled = true;
                        //txtConfirmarPass.Enabled = true;
                        //cboPerfil.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Marca";
                        txtNombre.Enabled = false;
                        //txtEmail.Enabled = false;
                        //txtEmail.Enabled = false;
                        //txtPassword.Enabled = false;
                        //cboPerfil.Enabled = false;
                        //txtConfirmarPass.Enabled = false;
                        break;
                    }
            }
        }

        public void SeleccionarMarca(FormMode op, Marca marcaSelected)
        {
          formMode = op;
          oMarcaSelected = marcaSelected;
        }
 


        private void MostrarDatos()
        {
            if (oMarcaSelected != null)
            {
                txtNombre.Text = oMarcaSelected.NombreMarca;
               
            }
        }

    }
}
        