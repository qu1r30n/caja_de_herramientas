using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caja_de_herramientas.clases.herramientas
{
    class var_fun_GG
    {
        

        static public int GG_indice_donde_comensar = 1;

        static public string[] GG_caracter_separacion = { "|", "°", "¬", "^" };
        static public string GG_separador_para_funciones_espesificas = "~";
        static public string GG_separador_para_funciones_espesificas2 = "§";

        //funciones---------------------------------------------------------------------------------------------------------
        
        public string[] GG_funcion_caracter_separacion(object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = null;
            if (caracter_separacion_objeto == null)
            {
                caracter_separacion = GG_caracter_separacion;
            }
            else
            {
                if (caracter_separacion_objeto is char)
                {
                    caracter_separacion = new string[] { caracter_separacion_objeto + "" };
                }
                if (caracter_separacion_objeto is string)
                {
                    if (caracter_separacion_objeto.ToString() != GG_separador_para_funciones_espesificas)
                    {
                        caracter_separacion = caracter_separacion_objeto.ToString().Split(GG_separador_para_funciones_espesificas[0]);
                    }
                    else
                    {
                        caracter_separacion = caracter_separacion_objeto.ToString().Split(GG_separador_para_funciones_espesificas2[0]);
                    }

                }
                if (caracter_separacion_objeto is string[])
                {
                    caracter_separacion = (string[])caracter_separacion_objeto;
                }
            }

            return caracter_separacion;

        }

        //movimientos a repetir esto es mas para la aplicacion del celular para pasarlo al de la computadora y mejorar
        //tienes que poner en datos la informacion de_las_variables si es un arreglo usa el join paresido y agregale un GG_separador_para_funciones_espesificas
        public string GG_movimientos_a_repetir(string direccion, string datos,bool guardar_movimiento=false)
        {
            if (guardar_movimiento == true)
            {


                Tex_base bas = new Tex_base();
                operaciones_textos op_textos = new operaciones_textos();
                string carpetas = op_textos.joineada_paraesida_y_quitador_de_extremos_del_string(direccion, "\\", 2);

                bas.Agregar_a_archivo_sin_arreglo(direccion, datos);

                return datos;
            }
            return null;
        }

        //registro para control de ventas compras y todo
        public string GG_registros(string direccion,object datos)
        {
            Tex_base bas = new Tex_base();
            operaciones_textos op_textos = new operaciones_textos();
            string carpetas = op_textos.joineada_paraesida_y_quitador_de_extremos_del_string(direccion, "\\", 2);

            string info_a_retornar = "";
            if (datos is string)
            {
                
                bas.Agregar_a_archivo_sin_arreglo(direccion, (string)datos);
                info_a_retornar = (string)datos;
                return info_a_retornar;
            }
            else if (datos is string[])
            {
                string[] temp = (string[])datos;
                bas.Crear_archivo_y_directorio(carpetas + "\\", "datos", leer_y_agrega_al_arreglo: false);
                for (int i = 0; i < temp.Length; i++)
                {
                    bas.Agregar_a_archivo_sin_arreglo(direccion, temp[i]);
                    info_a_retornar = info_a_retornar + temp[i] + "\n";
                }
                return info_a_retornar;
            }
            return null;
        }
    }
}
