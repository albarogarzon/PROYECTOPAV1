using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoPAV1.GUILayer;
using ProyectoPAV1.GUILayer.Productos;
using ProyectoPAV1.GUILayer.Usuarios;
using ProyectoPAV1.GUILayer.Marcas;

namespace ProyectoPAV1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmProductos());
        }
    }
}
