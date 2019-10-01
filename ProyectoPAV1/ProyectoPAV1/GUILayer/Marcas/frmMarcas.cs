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
    public partial class frmMarcas : Form
    {

        private MarcaService oMarcaService;

        public frmMarcas()
        {
            InitializeComponent();
            InitializeDataGridView();
            oMarcaService = new MarcaService();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String condiciones = "";
            var filters = new Dictionary<string, object>();

            if (!chkTodas.Checked)//si el checkbox no esta marcado...
            {
  
                if (txtNombre.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("marca", txtNombre.Text);
                    //condiciones += "AND u.usuario=" + "'" + txtNombre.Text + "'";

                    condiciones += " AND (nombre LIKE '%" + txtNombre.Text + "%') ";

                    // strSql += " AND (u.usuario LIKE '%' + @usuario + '%') ";
                }

                if (filters.Count > 0)
                    //SIN PARAMETROS
                    dgvMarcas.DataSource = oMarcaService.ConsultarConFiltros(condiciones);


                else
                    MessageBox.Show("Debe ingresar una Marca", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                
                dgvMarcas.DataSource = oMarcaService.ObtenerTodos();
        }



        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvMarcas.ColumnCount = 2;
            dgvMarcas.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvMarcas.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvMarcas.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvMarcas.Columns[0].Name = "Id Marca";
            dgvMarcas.Columns[0].DataPropertyName = "IdMarca";
            // Definimos el ancho de la columna.

            dgvMarcas.Columns[1].Name = "Nombre Marca";
            dgvMarcas.Columns[1].DataPropertyName = "NombreMarca";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvMarcas.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvMarcas.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void btnNueva_Click(object sender, EventArgs e) //nueva marca
        {
            frmABMMarcas formulario = new frmABMMarcas();
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e) //editar marca
        {
            frmABMMarcas fr = new frmABMMarcas();
            var marca = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
            fr.SeleccionarMarca(frmABMMarcas.FormMode.update, marca);
            fr.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e) //eliminar marca
        {
            frmABMMarcas frm = new frmABMMarcas();
            var marca = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
            frm.SeleccionarMarca(frmABMMarcas.FormMode.delete,marca);
            frm.ShowDialog();
            btnConsultar_Click(sender, e);

        }

        private void chkTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodas.Checked)
            {
                txtNombre.Enabled = false;
                
            }
            else
            {
                txtNombre.Enabled = true;
                
            }
        }

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
