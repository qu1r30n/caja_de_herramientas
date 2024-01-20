using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using caja_de_herramientas.clases.herramientas;

namespace caja_de_herramientas.clases.herramientas
{
    class operaciones_textos
    {
        public string[] G_caracter_separacion = { "|", "°", "¬", "^" };
        public string G_separador_para_funciones_espesificas = "~";

        public string joineada_paraesida(string[] arreglo, object caracter_separacion_objeto = null, int restar_cuantas_ultimas_celdas = 0)
        {
            string[] caracter_separacion = null;
            if (caracter_separacion_objeto == null)
            {
                caracter_separacion = G_caracter_separacion;
            }
            else
            {
                if (caracter_separacion_objeto is char)
                {
                    caracter_separacion = new string[] { caracter_separacion_objeto + "" };
                }
                if (caracter_separacion_objeto is string)
                {
                    caracter_separacion = caracter_separacion_objeto.ToString().Split(G_separador_para_funciones_espesificas[0]);
                }
                if (caracter_separacion_objeto is string[])
                {
                    caracter_separacion = (string[])caracter_separacion_objeto;
                }
            }

            string a_retornar = "";
            int cantidad_celdas_a_retornar_del_arreglo = arreglo.Length - restar_cuantas_ultimas_celdas;
            for (int i = 0; i < cantidad_celdas_a_retornar_del_arreglo; i++)
            {
                if (i < cantidad_celdas_a_retornar_del_arreglo - 1)
                {
                    a_retornar = a_retornar + arreglo[i] + caracter_separacion[0];
                }
                else
                {
                    a_retornar = a_retornar + arreglo[i];
                }
            }
            return a_retornar;
        }

        public string Trimend_paresido(string texto, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = null;
            if (caracter_separacion_objeto == null)
            {
                caracter_separacion = G_caracter_separacion;
            }
            else
            {
                if (caracter_separacion_objeto is char)
                {
                    caracter_separacion = new string[] { caracter_separacion_objeto + "" };
                }
                if (caracter_separacion_objeto is string)
                {
                    caracter_separacion = caracter_separacion_objeto.ToString().Split(G_separador_para_funciones_espesificas[0]);
                }
                if (caracter_separacion_objeto is string[])
                {
                    caracter_separacion = (string[])caracter_separacion_objeto;
                }
            }

            string texto_editado = "";
            string[] texto_spliteado = texto.Split(caracter_separacion[0][0]);

            if (texto_spliteado[texto_spliteado.Length - 1] == "")
            {
                for (int i = 0; i < texto_spliteado.Length; i++)
                {
                    if (i < texto_spliteado.Length - 2)
                    {
                        texto_editado = texto_editado + texto_spliteado[i] + caracter_separacion[0];
                    }
                    else
                    {
                        texto_editado = texto_editado + texto_spliteado[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < texto_spliteado.Length; i++)
                {
                    if (i < texto_spliteado.Length - 1)
                    {
                        texto_editado = texto_editado + texto_spliteado[i] + caracter_separacion[0];
                    }

                    else
                    {
                        texto_editado = texto_editado + texto_spliteado[i];
                    }
                }
            }


            return texto_editado;
        }

    }
}
