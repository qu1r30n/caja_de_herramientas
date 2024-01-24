using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using caja_de_herramientas.clases;

namespace caja_de_herramientas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            poner_al_inicio_del_programa comienso = new poner_al_inicio_del_programa();
            comienso.inicio();
            mult m = new mult();
            //m.entrada_dinero_simple_metodo_sin_lista_de_patrocinadores("config\\sismul2\\negocio.txt", "3", "100");
            //m.entrada_dinero_simple_y_complejo("config\\sismul2\\negocio.txt", "5", "100",porsentage_comision_por_venta:"10");
            m.entrada_dinero_simple_y_complejo("config\\sismul2\\negocio.txt", "5", "100", "config\\sismul2\\patrocinadores_complejos.txt", porsentage_comision_por_venta: "10");
        }
    }
}
