using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using caja_de_herramientas.clases.herramientas;

namespace caja_de_herramientas.clases
{
    class mult
    {
        Tex_base bas = new Tex_base();
        operaciones_arreglos op_arreglos = new operaciones_arreglos();
        operaciones_textos op_textos = new operaciones_textos();

        

        public void registro_simple(string direccion, string id_encargado_simple, string tabla_simple, string[] datos, double dinero_registro = 0, object caracter_separacion_objeto = null, bool regis=true)
        {

            string[] caracter_separacion = null;
            if (caracter_separacion_objeto == null)
            {
                caracter_separacion = bas.G_caracter_separacion;
            }
            else
            {
                if (caracter_separacion_objeto is char)
                {
                    caracter_separacion = new string[] { caracter_separacion_objeto + "" };
                }
                if (caracter_separacion_objeto is string)
                {
                    caracter_separacion = caracter_separacion_objeto.ToString().Split(bas.G_separador_para_funciones_espesificas[0]);
                }
                if (caracter_separacion_objeto is string[])
                {
                    caracter_separacion = (string[])caracter_separacion_objeto;
                }
            }



            string datos_usuario = "";
            for (int i = 0; i < datos.Length; i++)
            {
                if (i > datos.Length - 1)
                {
                    datos_usuario = datos_usuario + datos[i] + caracter_separacion[1];
                }
                else
                {
                    datos_usuario = datos_usuario + datos[i];
                }
            }

            int indice_de_la_base = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direccion));
            int cantidad_de_registros = Tex_base.GG_base_arreglo_de_arreglos[indice_de_la_base].Length;
            //                      0_id_usuario                  |       1_id_patrocinador_complejo|                 2_tabla_patrocinador_complejo           |               3_id_encargado_simple           |       4_tabla_encargado_simple    |                       5_diner                 |                 6_pago_directo    |            7_pago_indirecto     |                      8_datos                  |        9_encargados     |
            string info_a_agregar = cantidad_de_registros + caracter_separacion[0] + "0" + caracter_separacion[0] + "patrocinadores_complejos" + caracter_separacion [0] + id_encargado_simple + caracter_separacion [0] + tabla_simple + caracter_separacion [0] + dinero_registro + caracter_separacion [0] + "0" + caracter_separacion [0] + "0" + caracter_separacion [0] + datos_usuario + caracter_separacion [0] + "" + caracter_separacion [0];
            bas.Agregar(direccion, info_a_agregar);

            if (regis == true)
            {
                char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split

                string[] direccion_espliteada = direccion.Split(parametro2);//spliteamos la direccion

                string carpetas = op_textos.joineada_paraesida(direccion_espliteada, "\\", 1);

                DateTime fecha_hora = DateTime.Now;
                string año_mes_dia = fecha_hora.ToString("yyyyMMdd");
                string dir = carpetas + año_mes_dia + "registro_simple_mov.txt";
                bas.Crear_archivo_y_directorio(dir, "registro_simple|dir_tabla|id_usuario|datos_usuario|dinero_registro|id_encargado_simple|");
                string info_movimiento = "registro_simple" + caracter_separacion [0] + direccion + caracter_separacion [0] + cantidad_de_registros + caracter_separacion [0] + datos_usuario + caracter_separacion [0] + dinero_registro + caracter_separacion [0] + id_encargado_simple + caracter_separacion [0];
                bas.Agregar_a_archivo_sin_arreglo(dir, info_movimiento);
            }
        }

        public void registro_complejo(string direccion, string id_encargado_simple, string tabla_simple,string id_encargado_complejo, string tabla_complejo, string[] datos, double dinero_registro = 0, object caracter_separacion_objeto = null, bool regis=true)
        {
            string[] caracter_separacion = null;
            if (caracter_separacion_objeto == null)
            {
                caracter_separacion = bas.G_caracter_separacion;
            }
            else
            {
                if (caracter_separacion_objeto is char)
                {
                    caracter_separacion = new string[] { caracter_separacion_objeto + "" };
                }
                if (caracter_separacion_objeto is string)
                {
                    caracter_separacion = caracter_separacion_objeto.ToString().Split(bas.G_separador_para_funciones_espesificas[0]);
                }
                if (caracter_separacion_objeto is string[])
                {
                    caracter_separacion = (string[])caracter_separacion_objeto;
                }
            }




            string datos_usuario = "";
            for (int i = 0; i < datos.Length; i++)
            {
                if (i > datos.Length - 1)
                {
                    datos_usuario = datos_usuario + datos[i] + caracter_separacion [1];
                }
                else
                {
                    datos_usuario = datos_usuario + datos[i];
                }
            }

            int indice_de_la_base = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direccion));
            int cantidad_de_registros = Tex_base.GG_base_arreglo_de_arreglos[indice_de_la_base].Length;
            //                      0_id_usuario                  |       1_id_patrocinador_complejo|                 2_tabla_patrocinador_complejo           |               3_id_encargado_simple           |       4_tabla_encargado_simple    |                       5_diner                 |                 6_pago_directo    |            7_pago_indirecto     |                      8_datos                  |        9_encargados     |
            string info_a_agregar = cantidad_de_registros + caracter_separacion [0] + id_encargado_complejo + caracter_separacion [0] + tabla_complejo + caracter_separacion [0] + id_encargado_simple + caracter_separacion [0] + tabla_simple + caracter_separacion [0] + dinero_registro + caracter_separacion [0] + "0" + caracter_separacion [0] + "0" + caracter_separacion [0] + datos_usuario + caracter_separacion [0] + "" + caracter_separacion [0];
            
            bas.Agregar(direccion, info_a_agregar);

            if (regis == true)
            {
                char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split

                string[] direccion_espliteada = direccion.Split(parametro2);//spliteamos la direccion

                string carpetas = op_textos.joineada_paraesida(direccion_espliteada, "\\", 1);

                DateTime fecha_hora = DateTime.Now;
                string año_mes_dia = fecha_hora.ToString("yyyyMMdd");
                string dir = carpetas + año_mes_dia + "registro_simple_mov.txt";
                bas.Crear_archivo_y_directorio(dir, "registro_simple|dir_tabla|id_usuario|datos_usuario|dinero_registro|id_encargado_simple|");
                string info_movimiento = "registro_complejo" + caracter_separacion [0] + direccion + caracter_separacion [0] + cantidad_de_registros + caracter_separacion [0] + datos_usuario + caracter_separacion [0] + dinero_registro + caracter_separacion [0] + id_encargado_simple + caracter_separacion [0] + id_encargado_complejo + caracter_separacion [0];
                bas.Agregar_a_archivo_sin_arreglo(dir, info_movimiento);
            }
        }


        public void entrada_dinero_simple_metodo_sin_lista_de_patrocinadores(string direccion, string id_usuario, string cantidad_dinero_string,string porsentage_comision_por_venta=null, string porsentajes_de_comision_encargados_simp = null, object caracter_separacion_objeto = null, bool regis = true)
        {

            string[] caracter_separacion = null;
            if (caracter_separacion_objeto == null)
            {
                caracter_separacion = bas.G_caracter_separacion;
            }
            else
            {
                if (caracter_separacion_objeto is char)
                {
                    caracter_separacion = new string[] { caracter_separacion_objeto + "" };
                }
                if (caracter_separacion_objeto is string)
                {
                    caracter_separacion = caracter_separacion_objeto.ToString().Split(bas.G_separador_para_funciones_espesificas[0]);
                }
                if (caracter_separacion_objeto is string[])
                {
                    caracter_separacion = (string[])caracter_separacion_objeto;
                }
            }
            int indice=Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion("inf\\sismul2\\porcentajes\\porcentajes.txt"));
            if (porsentajes_de_comision_encargados_simp == null)
            {
                
            }
            double dinero_double = Convert.ToDouble(cantidad_dinero_string);
            int indice_de_base = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direccion));
            string[] porcentage_de_encargados_simp_esptli = porsentajes_de_comision_encargados_simp.Split(caracter_separacion [0][0]);

            string pagos_a_hacer = "";
            string columnas_usuarios_para_comparar = "";
            string columnas_para_editar = "";
            string codigo_1_para_incrementar_0_para_editar = "";
            //aqui se saldra el dinero que se les tiene que dar
            for (int i = 0; i < porcentage_de_encargados_simp_esptli.Length; i++)
            {
                pagos_a_hacer = (dinero_double * Convert.ToDouble(porcentage_de_encargados_simp_esptli[i])/100) + bas.G_separador_para_funciones_espesificas;
                columnas_usuarios_para_comparar = columnas_usuarios_para_comparar + "0" + bas.G_separador_para_funciones_espesificas;
                columnas_para_editar = columnas_para_editar + "7" + bas.G_separador_para_funciones_espesificas;
                codigo_1_para_incrementar_0_para_editar = codigo_1_para_incrementar_0_para_editar + "1" + bas.G_separador_para_funciones_espesificas;
            }
            //aqui agrega el pago del usuario
            pagos_a_hacer = (dinero_double * (Convert.ToDouble(porsentage_comision_por_venta) / 100)) + bas.G_separador_para_funciones_espesificas + pagos_a_hacer;
            string patroccinadores = extraer_patrosinadores_funcion_recursiva(direccion, 0, id_usuario, 3, porcentage_de_encargados_simp_esptli.Length, bas.G_separador_para_funciones_espesificas);
            patroccinadores = id_usuario + bas.G_separador_para_funciones_espesificas + patroccinadores;

            columnas_usuarios_para_comparar = op_textos.Trimend_paresido(columnas_usuarios_para_comparar, bas.G_separador_para_funciones_espesificas);
            columnas_para_editar = op_textos.Trimend_paresido(columnas_para_editar, bas.G_separador_para_funciones_espesificas);
            patroccinadores = op_textos.Trimend_paresido(patroccinadores, bas.G_separador_para_funciones_espesificas);
            pagos_a_hacer = op_textos.Trimend_paresido(pagos_a_hacer, bas.G_separador_para_funciones_espesificas);
            codigo_1_para_incrementar_0_para_editar = op_textos.Trimend_paresido(codigo_1_para_incrementar_0_para_editar, bas.G_separador_para_funciones_espesificas);

            op_arreglos.busqueda_multiple_edicion_multiple_arreglo_profunda(Tex_base.GG_base_arreglo_de_arreglos[indice_de_base],columnas_usuarios_para_comparar, patroccinadores, columnas_para_editar, pagos_a_hacer, codigo_1_para_incrementar_0_para_editar);
            //bas.Editar_o_incr_espesifico(direccion,0, id_usuario)
            
            //op_arreglos.arreg
            //registro de movimientos
            if (regis == true)
            {
                char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split

                string[] direccion_espliteada = direccion.Split(parametro2);//spliteamos la direccion

                string carpetas = op_textos.joineada_paraesida(direccion_espliteada, "\\", 1);

                DateTime fecha_hora = DateTime.Now;
                string año_mes_dia = fecha_hora.ToString("yyyyMMdd");
                string dir = carpetas + año_mes_dia + "ent_din_simp_mov.txt";
                bas.Crear_archivo_y_directorio(dir);
                string info_movimiento = "ent_din_simp" + caracter_separacion [0] + direccion + caracter_separacion [0] + id_usuario + caracter_separacion [0] + cantidad_dinero_string + caracter_separacion [0] + porsentajes_de_comision_encargados_simp + caracter_separacion [0];
                bas.Agregar_a_archivo_sin_arreglo(dir, info_movimiento);
            }

        }

        public void entrada_dinero_complejo_metodo_sin_lista_de_patrocinadores(string direccion_enc_simple, string direccion_enc_complejo, string id_usuario_simple, string cantidad_dinero_string, string porsentage_comision_por_venta = null, string porsentajes_de_comision_encargados_simp = null, string porsentajes_de_comision_encargados_complejo = null, object caracter_separacion_objeto = null, bool regis = true)
        {

            string[] caracter_separacion = null;
            if (caracter_separacion_objeto == null)
            {
                caracter_separacion = bas.G_caracter_separacion;
            }
            else
            {
                if (caracter_separacion_objeto is char)
                {
                    caracter_separacion = new string[] { caracter_separacion_objeto + "" };
                }
                if (caracter_separacion_objeto is string)
                {
                    caracter_separacion = caracter_separacion_objeto.ToString().Split(bas.G_separador_para_funciones_espesificas[0]);
                }
                if (caracter_separacion_objeto is string[])
                {
                    caracter_separacion = (string[])caracter_separacion_objeto;
                }
            }


            string[] fila_espliteada=bas.seleccionar(direccion_enc_simple, 0, id_usuario_simple).Split(caracter_separacion[0][0]);
            //entrada_dinero_simple_metodo_sin_lista_de_patrocinadores(direccion_enc_simple,id_usuario_simple,cantidad_dinero_string,);
            //entrada_dinero_simple_metodo_sin_lista_de_patrocinadores(direccion_enc_complejo,);

        }

        public string extraer_patrosinadores_funcion_recursiva(string direccion, int columna_a_comparar_usuario, string id_comparar_usuario, int columna_patrocinadores, int cantidad_patrocinadores_a_extraer, string car_sep_para_retornar = null, object caracter_separacion_objeto = null)
        {
            string[] caracter_separacion = null;
            if (caracter_separacion_objeto == null)
            {
                caracter_separacion = bas.G_caracter_separacion;
            }
            else
            {
                if (caracter_separacion_objeto is char)
                {
                    caracter_separacion = new string[] { caracter_separacion_objeto + "" };
                }
                if (caracter_separacion_objeto is string)
                {
                    caracter_separacion = caracter_separacion_objeto.ToString().Split(bas.G_separador_para_funciones_espesificas[0]);
                }
                if (caracter_separacion_objeto is string[])
                {
                    caracter_separacion = (string[])caracter_separacion_objeto;
                }
            }


            int indice_de_base =Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direccion));

            string ids_pat_a_retornar = null;
            for (int j = 0; j < cantidad_patrocinadores_a_extraer; j++)
            {
                for (int i = 0; i < Tex_base.GG_base_arreglo_de_arreglos[indice_de_base].Length; i++)
                {
                    string[] fila_espliteada = Tex_base.GG_base_arreglo_de_arreglos[indice_de_base][i].Split(caracter_separacion [0][0]);
                    if (fila_espliteada[columna_a_comparar_usuario] == id_comparar_usuario)
                    {
                        if (cantidad_patrocinadores_a_extraer>0)
                        {
                            //que caracter se usara para separar los patrocinadores
                            if (car_sep_para_retornar==null)
                            {
                                ids_pat_a_retornar = ids_pat_a_retornar + extraer_patrosinadores_funcion_recursiva(direccion, columna_a_comparar_usuario, fila_espliteada[columna_patrocinadores], columna_patrocinadores, cantidad_patrocinadores_a_extraer - 1) + caracter_separacion [0];
                            }
                            else
                            {
                                ids_pat_a_retornar = ids_pat_a_retornar + extraer_patrosinadores_funcion_recursiva(direccion, columna_a_comparar_usuario, fila_espliteada[columna_patrocinadores], columna_patrocinadores, cantidad_patrocinadores_a_extraer - 1) + car_sep_para_retornar;
                            }
                            break;
                        }
                        
                    }
                }
            }
            return ids_pat_a_retornar;
        }

        

    }
}
