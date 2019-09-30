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
        public frmProductos()
        {
            InitializeComponent();
            marcaService = new MarcaService();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string strSql = "SELECT TOP 20 * FROM Productos WHERE 1=1 ";
            if (!string.IsNullOrEmpty(cboMarcaProducto.Text))
            {
                var Marca = cboMarcaProducto.SelectedValue.ToString();
                strSql += "AND (MarcaProducto=" + Marca + ") ";
                DBHelper D1 = new DBHelper();
                DataTable Tabla1 =D1.ConsultaSQL(strSql);
                cargarGrilla(grdProductos, Tabla1);

            }



        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboMarcaProducto, marcaService.ObtenerTodos(), "NombreMarca", "IdMarca");
        }





        private void cargarGrilla(DataGridView grilla, DataTable tabla)
        {
            grilla.Rows.Clear();
            //debo hacer un ciclo
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                grilla.Rows.Add(tabla.Rows[i]["id_producto"],
                    tabla.Rows[i]["nombre"],
                    tabla.Rows[i]["descripcion"],
                    tabla.Rows[i]["stock"],
                    tabla.Rows[i]["precioVenta"]);
            }

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
            frmABMProducto formulario = new frmABMProducto();
            var producto = (Producto)grdProductos.CurrentRow.Cells[0].Value;
            formulario.SeleccionarProducto(frmABMProducto.FormMode.update, producto);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMProducto formulario = new frmABMProducto();
            var producto = (Producto)grdProductos.CurrentRow.Cells[0].Value;
            formulario.SeleccionarProducto(frmABMProducto.FormMode.delete, producto);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }
    }
}
