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


        }
    }
}
