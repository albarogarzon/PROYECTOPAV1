using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoPAV1.DataAccessLayer;
using ProyectoPAV1.BusinessLayer;
using ProyectoPAV1.Entities;
using ProyectoPAV1.GUILayer.Productos;


namespace ProyectoPAV1.GUILayer
{
    public partial class frmProductos : Form
    {
        private readonly MarcaService marcaService;
        private ProductoService oProductoService;
        public frmProductos()
        {
            InitializeComponent();
            marcaService = new MarcaService();
            oProductoService = new ProductoService();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            String condiciones = " ";

            if (!string.IsNullOrEmpty(cboMarcaProducto.Text))
            {
                var Marca = cboMarcaProducto.SelectedValue.ToString();
                condiciones += "AND (m.idMarca=" + Marca + ") ";
                //SIN PARAMETROS
                 grdProductos.DataSource = oProductoService.ConsultarConFiltros(condiciones);
                
            }



        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboMarcaProducto, marcaService.ObtenerTodos(), "NombreMarca", "IdMarca");
        }

        

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            // Datasource: establece el origen de datos de este objeto.
            cbo.DataSource = source;
            // DisplayMember: establece la propiedad que se va a mostrar para este ListControl.
            cbo.DisplayMember = display;
            // ValueMember: establece la ruta de acceso de la propiedad que se utilizará como valor real para los elementos de ListControl.
            cbo.ValueMember = value;
            //SelectedIndex: establece el índice que especifica el elemento seleccionado actualmente.
            cbo.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMProducto formulario = new frmABMProducto();
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }
       

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMProducto fr = new frmABMProducto();
            var producto = (Producto)grdProductos.CurrentRow.DataBoundItem;
            fr.SeleccionarProducto(frmABMProducto.FormMode.update, producto);
            fr.ShowDialog();
            btnConsultar_Click(sender, e);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMProducto fr = new frmABMProducto();
            var producto = (Producto)grdProductos.CurrentRow.DataBoundItem;
            fr.SeleccionarProducto(frmABMProducto.FormMode.delete, producto);
            fr.ShowDialog();
            btnConsultar_Click(sender, e);
        }
        private void grdProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
