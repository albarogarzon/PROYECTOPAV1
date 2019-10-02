using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoPAV1.BusinessLayer;
using ProyectoPAV1.Entities;

namespace ProyectoPAV1.GUILayer.Productos
{

    public partial class frmABMProducto : Form
    {
        private FormMode formMode = FormMode.insert;

    private readonly ProductoService oProductoService;
    private readonly MarcaService oMarcaService;
    private Producto oProductoSelected;

        public frmABMProducto()
        {
            InitializeComponent();
            oMarcaService = new MarcaService();
            oProductoService = new ProductoService();
        }

        public enum FormMode
        {
            insert,
            update,
            delete
        }



        private void frmABMProducto_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboMarca, oMarcaService.ObtenerTodos(), "NombreMarca", "IdMarca");
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Producto";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Producto";
                        MostrarDatos();
                        txtNombre.Enabled = true;
                        txtDescripción.Enabled = true;
                        txtStock.Enabled = true;
                        txtPrecio.Enabled = true;
                        cboMarca.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        this.Text = "Habilitar/Deshabilitar Producto";
                        MostrarDatos();
                        txtNombre.Enabled = false;
                        txtDescripción.Enabled = false;
                        txtStock.Enabled = false;
                        txtPrecio.Enabled = false;
                        cboMarca.Enabled = false;
                        break;
                    }
            }
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ExisteProducto() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oProducto = new Producto();
                                oProducto.NombreProducto = txtNombre.Text;
                                oProducto.DescripciónProducto = txtDescripción.Text;
                                oProducto.StockProducto = txtStock.Text;
                                oProducto.PrecioProducto = txtPrecio.Text;
                                oProducto.MarcaProducto = new Marca();
                                oProducto.MarcaProducto.IdMarca = (int)cboMarca.SelectedValue;

                                if (oProductoService.CrearProducto(oProducto))
                                {
                                    MessageBox.Show("producto insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Nombre de producto encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oProductoSelected.NombreProducto = txtNombre.Text;
                            oProductoSelected.DescripciónProducto = txtDescripción.Text;
                            oProductoSelected.StockProducto = txtStock.Text;
                            oProductoSelected.PrecioProducto = txtPrecio.Text;
                            oProductoSelected.MarcaProducto = new Marca();
                            oProductoSelected.MarcaProducto.IdMarca = (int)cboMarca.SelectedValue;

                            if (oProductoService.ActualizarProducto(oProductoSelected))
                            {
                                MessageBox.Show("Producto actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el producto!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el producto seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (oProductoService.ModificarEstadoProducto(oProductoSelected))
                            {
                                MessageBox.Show("Producto Habilitada/Deshabilitada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar el producto!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }


        }
        public void SeleccionarProducto(FormMode op, Producto productoSelected)
        {
            formMode = op;
            oProductoSelected = productoSelected;
        }
        private void MostrarDatos()
        {
            if (oProductoSelected != null)
            {
                txtNombre.Text = oProductoSelected.NombreProducto;
                txtDescripción.Text = oProductoSelected.DescripciónProducto;
                txtStock.Text = oProductoSelected.StockProducto;
                txtPrecio.Text = oProductoSelected.PrecioProducto;
                cboMarca.Text = oProductoSelected.MarcaProducto.NombreMarca;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
        

        private bool ExisteProducto()
        {
            return oProductoService.ObtenerProducto(txtNombre.Text) != null;
        }

    }
}
