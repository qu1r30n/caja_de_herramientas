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

            enlase_a_herramienta enlase_herram = new enlase_a_herramienta();

            enlase_herram.enl_a_editar();
        }
    }
}
