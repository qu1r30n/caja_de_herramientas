using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace caja_de_herramientas.clases.herramientas
{
    class operaciones_arreglos
    {

        string[] G_caracteres_separacion = { "|", "°", "¬", "^", "~" };

        public string[] agregar_registro_del_array(string[] arreglo, string registro)
        {
            string[] temp = new string[arreglo.Length + 1];

            for (int i = 0; i < arreglo.Length; i++)
            {
                temp[i] = arreglo[i];
            }

            temp[arreglo.Length] = registro;

            return temp;
        }
        /*
        public string[][] agregar_arreglo_a_arreglo_de_arreglos(string[][] arreglo_de_arreglos, string[] nuevo_arreglo)
        {
            string[][] temp = new string[arreglo_de_arreglos.Length + 1][];

            for (int i = 0; i < arreglo_de_arreglos.Length; i++)
            {
                temp[i] = arreglo_de_arreglos[i];
            }

            temp[arreglo_de_arreglos.Length] = nuevo_arreglo;

            return temp;
        }
        */
        public string[][] agregar_arreglo_a_arreglo_de_arreglos(string[][] arreglo_de_arreglos, string[] nuevo_arreglo)
        {
            if (arreglo_de_arreglos == null)
            {
                // Si el arreglo de arreglos es null, se crea un nuevo arreglo de arreglos con un solo elemento.
                return new string[][] { nuevo_arreglo };
            }

            string[][] temp = new string[arreglo_de_arreglos.Length + 1][];
            Array.Copy(arreglo_de_arreglos, temp, arreglo_de_arreglos.Length);
            temp[arreglo_de_arreglos.Length] = nuevo_arreglo;
            return temp;
        }


        public string[] quitar_registro_del_array(string[] arreglo)
        {
            if (arreglo.Length <= 1)
            {
                // No hay elementos para quitar, devolver un array vacío o el mismo array
                return null;
            }

            string[] temp = new string[arreglo.Length - 1];

            for (int i = 1; i < arreglo.Length; i++)
            {
                temp[i - 1] = arreglo[i];
            }


            return temp;
        }

        public string busqueda_profunda_arreglo(string[] areglo,string columnas_a_recorrer, string comparar,string columnas_a_retornar=null, string[] caracteres_separacion = null)
        {
            if (caracteres_separacion == null) 
            {
                caracteres_separacion = G_caracteres_separacion;
            }


            string[] arr_col_rec = null;
            //caracteres_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            arr_col_rec = columnas_a_recorrer.Split(caracteres_separacion[0][0]);

            for (int i = 0; i < areglo.Length; i++)
            {

                string tem_linea = areglo[i];
                string[][] niveles_de_profundidad=null;
                int j = 0;
                do
                {

                    //caracteres_separacion[j][0] el primer [j] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                    niveles_de_profundidad = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, tem_linea.Split(caracteres_separacion[j][0]));
                    tem_linea= niveles_de_profundidad[j][Convert.ToInt32(arr_col_rec[j])];
                    
                    j++;
                } while (j < arr_col_rec.Length);

                string tem_linea_2 = "";
                //comparacion--------------------------------------------------------------------------
                if (tem_linea == comparar)
                {
                    if (columnas_a_retornar == null)
                    {
                        return areglo[i];
                    }
                    else
                    {

                        string[] info_a_recorrer = columnas_a_retornar.Split(caracteres_separacion[0][0]);
                        for (int l = 0; l < info_a_recorrer.Length; l++)
                        {
                            tem_linea_2 = info_a_recorrer[l];
                            string[][] niveles_de_profundidad_2 = null;
                            int k = 1;
                            do
                            {

                                //caracteres_separacion[k][0] el primer [k] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                                niveles_de_profundidad_2 = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad_2, tem_linea_2.Split(caracteres_separacion[k][0]));
                                tem_linea_2 = niveles_de_profundidad_2[k][Convert.ToInt32(arr_col_rec[k])];

                                k++;
                            } while (k < arr_col_rec.Length);
                            
                        }

                        return tem_linea_2;
                    }
                    
                }
            
            }
            return null;
        }




        public string editar_incr_string_funcion_recursiva(string texto, object columnas_a_recorrer, string info_a_sustituir, string edit_0_o_increm_1 = null,  string[] caracterSeparacion = null, string caracter_separacion_dif_a_texto = null)
        {
            //string texto="0|1|2¬3°4¬5|6", object columnas_a_recorrer="2°1°1", string info_a_sustituir="10", string edit_0_o_increm_1 = "1",  string[] caracterSeparacion = null, string caracter_separacion_dif_a_texto = "°"

            /*ejemplo puesto
                    string[] indices_espliteado = indices_a_editar.Split(caracteres_separacion[0][0]);
                    string[] info_editar_espliteado = info_editar.Split(caracteres_separacion[0][0]);
                    string[] edit_0_o_increm_1_espliteado = edit_0_o_increm_1.Split(caracteres_separacion[0][0]);
                    for (int k = 0; k < indices_espliteado.Length; k++)
                    {
                        areglo[i] = editar_incr_string_funcion_recursiva(areglo[i], indices_espliteado[k], info_editar_espliteado[k], edit_0_o_increm_1_espliteado[k], caracter_separacion_dif_a_texto:"°");
                    }
            
            */
            if (caracterSeparacion == null)
            {
                caracterSeparacion = G_caracteres_separacion;
            }

            string[] espliteado_columnas_recorrer = { };

            //Sí es un string lo splitea Este normalmente es al inicio de la función 
            if (columnas_a_recorrer is string)
            {
                if (caracter_separacion_dif_a_texto==null)
                {
                    espliteado_columnas_recorrer = columnas_a_recorrer.ToString().Split(caracterSeparacion[0][0]);
                }
                else
                {
                    espliteado_columnas_recorrer = columnas_a_recorrer.ToString().Split(caracter_separacion_dif_a_texto[0]);
                }
                
            }
            else if (columnas_a_recorrer is string[] temp)
            {

                espliteado_columnas_recorrer = temp;
            }
            
            string[] espliteado_texto = texto.Split(caracterSeparacion[0][0]);

            //En esta parte Se inicia desde el segundo elemento y se guardan los caracteres y
            //las columnas para sí hay otro elemento En el arreglo múltiple 
            string texto_a_retornar = "";

            string[] tem_array_caracter_separacion = caracterSeparacion;
            if (espliteado_columnas_recorrer.Length > 0)
            {
                string[] tem_array_col_recorrer = espliteado_columnas_recorrer;
                //espliteado_texto = texto.Split(Convert.ToChar(tem_array_caracter_separacion[0]));
                texto_a_retornar = espliteado_texto[Convert.ToInt32(tem_array_col_recorrer[0])];

                tem_array_col_recorrer = new string[espliteado_columnas_recorrer.Length - 1];
                tem_array_caracter_separacion = new string[caracterSeparacion.Length - 1];
                for (int i = 1; i < espliteado_columnas_recorrer.Length; i++)
                {

                    tem_array_col_recorrer[i - 1] = espliteado_columnas_recorrer[i];

                }
                for (int i = 1; i < caracterSeparacion.Length; i++)
                {
                    tem_array_caracter_separacion[i - 1] = caracterSeparacion[i];
                }


                espliteado_texto[Convert.ToInt32(espliteado_columnas_recorrer[0])] = editar_incr_string_funcion_recursiva(texto_a_retornar, tem_array_col_recorrer, info_a_sustituir, edit_0_o_increm_1, tem_array_caracter_separacion); // Llamada recursiva


            }
            else
            {
                if (edit_0_o_increm_1=="1")
                {
                    espliteado_texto[0] = "" + (Convert.ToDouble(espliteado_texto[0]) + Convert.ToDouble(info_a_sustituir));
                }
                else
                {
                    espliteado_texto[0] = info_a_sustituir;
                }
                
            }

            string retornar = string.Join(caracterSeparacion[0], espliteado_texto);
            return retornar;
        }

        

        public string[] editar_busqueda_profunda_arreglo(string[] areglo, string columnas_a_recorrer, string comparar, object columnas_a_recorrer_editar, string info_a_sustituir, string[] caracteres_separacion = null)
        {
            if (caracteres_separacion == null)
            {
                caracteres_separacion = G_caracteres_separacion;
            }


            string[] arr_col_rec = null;
            //caracteres_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            arr_col_rec = columnas_a_recorrer.Split(caracteres_separacion[0][0]);

            for (int i = 0; i < areglo.Length; i++)
            {

                string tem_linea = areglo[i];
                string[][] niveles_de_profundidad = null;
                int j = 0;
                do
                {

                    //caracteres_separacion[j][0] el primer [j] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                    niveles_de_profundidad = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, tem_linea.Split(caracteres_separacion[j][0]));
                    tem_linea = niveles_de_profundidad[j][Convert.ToInt32(arr_col_rec[j])];

                    j++;
                } while (j < arr_col_rec.Length);

                string tem_linea_2 = "";
                //comparacion--------------------------------------------------------------------------
                if (tem_linea == comparar)
                {
                    areglo[i] = editar_incr_string_funcion_recursiva(areglo[i], columnas_a_recorrer_editar, info_a_sustituir);
                    return areglo;
                }

            }
            return null;
        }


        public string editar_busqueda_multiple_edicion_profunda_arreglo(string[] areglo, string columnas_a_recorrer, string comparar, string indices_a_editar, string info_editar,string edit_0_o_increm_1=null, string[] caracteres_separacion = null)
        {
            //editar_busqueda_multiple_edicion_profunda_arreglo(arreglo, "2|1|1", "5", "2°1°1|1|2°1°0", "10|10|10","1|1|0");
            if (caracteres_separacion == null)
            {
                caracteres_separacion = G_caracteres_separacion;
            }


            string[] arr_col_rec = null;
            //caracteres_separacion[0][0] el primer [0] es la celda y el segundo [0] es el caracter para no usar convert.tochar
            arr_col_rec = columnas_a_recorrer.Split(caracteres_separacion[0][0]);

            for (int i = 0; i < areglo.Length; i++)
            {

                string tem_linea = areglo[i];
                string[][] niveles_de_profundidad = null;
                int j = 0;
                do
                {

                    //caracteres_separacion[j][0] el primer [j] es la celda y el segundo [0] es el caracter para no usar convert.tochar
                    niveles_de_profundidad = agregar_arreglo_a_arreglo_de_arreglos(niveles_de_profundidad, tem_linea.Split(caracteres_separacion[j][0]));
                    tem_linea = niveles_de_profundidad[j][Convert.ToInt32(arr_col_rec[j])];

                    j++;
                } while (j < arr_col_rec.Length);

                string tem_linea_2 = "";
                //comparacion--------------------------------------------------------------------------
                if (tem_linea == comparar)
                {
                    
                        
                    string[] indices_espliteado = indices_a_editar.Split(caracteres_separacion[0][0]);
                    string[] info_editar_espliteado = info_editar.Split(caracteres_separacion[0][0]);
                    string[] edit_0_o_increm_1_espliteado = edit_0_o_increm_1.Split(caracteres_separacion[0][0]);
                    for (int k = 0; k < indices_espliteado.Length; k++)
                    {
                        areglo[i] = editar_incr_string_funcion_recursiva(areglo[i], indices_espliteado[k], info_editar_espliteado[k], edit_0_o_increm_1_espliteado[k], caracter_separacion_dif_a_texto:"°");
                    }

                    return areglo[i];
                }

            }
            return "no_se_encontro";
        }

        public string si_no_existe_agrega_string(string[] areglo, string columnas_a_recorrer, string comparar, string texto_a_agregar, string[] caracteres_separacion = null)
        {
            if (caracteres_separacion == null)
            {
                caracteres_separacion = G_caracteres_separacion;
            }

            string info_encontrada=busqueda_profunda_arreglo(areglo, columnas_a_recorrer, comparar);
            if (info_encontrada!=null)
            {
                return info_encontrada;
            }
            else
            {
                agregar_registro_del_array(areglo, texto_a_agregar);
                return null;
            }

        }
    }
}
