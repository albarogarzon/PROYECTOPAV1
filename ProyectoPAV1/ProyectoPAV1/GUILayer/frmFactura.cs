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

namespace ProyectoPAV1.GUILayer
{
    public partial class frmFactura : Form
    {
        private readonly BindingList<FacturaDetalle> listaFacturaDetalle;
        private readonly ProductoService productoService;
        private readonly FacturaService facturaService;

        public frmFactura()
        {
            InitializeComponent();
           
            dgvDetalle.AutoGenerateColumns = false;

            facturaService = new FacturaService();
            productoService = new ProductoService();

            listaFacturaDetalle = new BindingList<FacturaDetalle>();
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            InicializarFormulario();

            LlenarCombo(cboProducto, productoService.ObtenerTodos(), "NombreProducto", "IdProducto");

            dgvDetalle.DataSource = listaFacturaDetalle;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
        }
        private void InicializarFormulario()
        {

            btnAgregar.Enabled = false;
            txtDescuento.Text = (0).ToString("N2");
            txtNroFact.Text = "1";
            //cboTipoFact.SelectedIndex = -1;
            txtNroFact.Text = "";

            //cboCliente.SelectedIndex = -1;
            // txtDireccion.Text = "";
            //txtCUIT.Text = "";

            InicializarDetalle();

            dgvDetalle.DataSource = null;

        }
        private void InicializarDetalle()
        {
            cboProducto.SelectedIndex = -1;
            txtCantidad.Text = "";
            txtPrecio.Text = 0.ToString("N2");
            txtImporte.Text = 0.ToString("N2");
        }
        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.ValueMember = value;
            cbo.DisplayMember = display;
            cbo.DataSource = source;
            cbo.SelectedIndex = -1;
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedItem != null)
            {
                var producto = (Producto)cboProducto.SelectedItem;
                var pp = Convert.ToDouble(producto.PrecioProducto);
                txtPrecio.Text = pp.ToString("C");
                txtCantidad.Enabled = true;
                int cantidad = 0;
                int.TryParse(txtCantidad.Text, out cantidad);
                txtImporte.Text = (Convert.ToDouble(producto.PrecioProducto) * cantidad).ToString("C");
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
                txtCantidad.Enabled = false;
                txtCantidad.Text = "";
                txtPrecio.Text = "";
                txtImporte.Text = "";
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int cantidad = 0;
            int.TryParse(txtCantidad.Text, out cantidad);

            var producto = (Producto)cboProducto.SelectedItem;
            listaFacturaDetalle.Add(new FacturaDetalle()
            {
                NroItem = listaFacturaDetalle.Count + 1,
                Producto = producto,
                Cantidad = cantidad,
                PrecioUnitario = Convert.ToDouble(producto.PrecioProducto)
            });

            CalcularTotales();

            InicializarDetalle();
        }

        private void CalcularTotales()
        {
            var subtotal = listaFacturaDetalle.Sum(p => p.Importe);
            txtSubtotal.Text = subtotal.ToString();

            double descuento = 0;
            double.TryParse(txtDescuento.Text, out descuento);

            var importeTotal = subtotal - subtotal * descuento / 100;
            txtImporteTotal.Text = importeTotal.ToString("C");
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var factura = new Factura
                {
                    Fecha = dtpFecha.Value,
                    NombreCliente = txtNombreCliente.Text,
                    IdUsuario =1,
                    FacturaDetalle = listaFacturaDetalle,
                    SubTotal = double.Parse(txtSubtotal.Text),
                    Descuento = double.Parse(txtDescuento.Text)
                };

                if (facturaService.ValidarDatos(factura))
                {
                    facturaService.Crear(factura);

                    MessageBox.Show(string.Concat("La factura nro: ", factura.IdFactura, " se generó correctamente."), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    InicializarFormulario();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la factura! " + ex.Message + ex.StackTrace, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            InicializarFormulario();
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {

            if (cboProducto.SelectedItem != null)
            {
                int cantidad = 0;
                int.TryParse(txtCantidad.Text, out cantidad);
                var producto = (Producto)cboProducto.SelectedItem;
                txtImporte.Text = (Convert.ToDouble(producto.PrecioProducto) * cantidad).ToString("C");
            }
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            CalcularTotales();
            double descuento = 0;
            if (double.TryParse(txtDescuento.Text, out descuento))
            {
                txtDescuento.Text = descuento.ToString("N2");
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null)
            {
                var detalleSeleccionado = (FacturaDetalle)dgvDetalle.CurrentRow.DataBoundItem;
                listaFacturaDetalle.Remove(detalleSeleccionado);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            InicializarDetalle();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
   if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
     if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
