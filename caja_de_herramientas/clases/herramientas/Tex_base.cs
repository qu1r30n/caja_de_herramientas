using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using caja_de_herramientas.clases.herramientas;
using System.IO;

namespace caja_de_herramientas.clases.herramientas
{
    class Tex_base
    {

        static public string[][] GG_base_arreglo_de_arreglos = null;
        //direcciones_de_las_bases
        public string[,] G_dir_bd_y_valor_inicial_bidimencional;

        //[0]=indice desde donde comensara desde el 0 nombre de las columnas y es mejor empesar desde el 1
        string[] G_configuracion = { "1" };

        //caracteres de separacion//el primero lo usaremos diferente NO USAR EL MISMO QUE string G_separador_para_funciones_espesificas;
        public string[] G_caracteres_separacion = { "|", "°", "¬", "^" };
        string G_separador_para_funciones_espesificas = "~";

        /*Aquí poner las funciones de las otras clases Si te vas a llevar esta clase solamente --------------------------------
       Ver poniendo también los nombres de las funciones que estás usando para no pasar toda la clase -----------------------
       Próstata también el nombre de la clase para saber de qué clase se está sacando las funciones -------------------------
       */
        operaciones_arreglos op_arreglos = new operaciones_arreglos();

        //fin Aquí poner las funciones de las otras clases Si te vas a llevar esta clase solamente --------------------------------


        public void inicio(string[] caracteres_separacion = null)
        {
            if (caracteres_separacion==null)
            {
                caracteres_separacion = G_caracteres_separacion;
            }

            string direccion_archivo_de_direcciones_de_bd = "config_tb\\inicio.txt";
            string fila_inicial = "direccion_de_las_bases_de_datos"+ G_separador_para_funciones_espesificas + "fila_inicial";

            Crear_archivo_y_directorio(direccion_archivo_de_direcciones_de_bd, fila_inicial);
            string[] direcciones_bases_datos_y_fila_inicial = Leer_inicial(direccion_archivo_de_direcciones_de_bd);
            
            for (int i = 1; i < direcciones_bases_datos_y_fila_inicial.Length; i++)
            {
                string[] espliteados_direcciones_bases_datos_y_fila_inicial = direcciones_bases_datos_y_fila_inicial[i].Split(caracteres_separacion[0][0]);
                
                Crear_archivo_y_directorio(espliteados_direcciones_bases_datos_y_fila_inicial[0], espliteados_direcciones_bases_datos_y_fila_inicial[1]);
                GG_base_arreglo_de_arreglos = op_arreglos.agregar_arreglo_a_arreglo_de_arreglos(GG_base_arreglo_de_arreglos, Leer_inicial(espliteados_direcciones_bases_datos_y_fila_inicial[0]));
                G_dir_bd_y_valor_inicial_bidimencional = op_arreglos.agregar_registro_del_array_bidimensional(G_dir_bd_y_valor_inicial_bidimencional, direcciones_bases_datos_y_fila_inicial[i], new string[] { G_separador_para_funciones_espesificas });

            }
            

        }



        //no muy importantes---------------------------------------------------------------------------------------------------

        public string Trimend_paresido(string texto, char caracter_separacion = '|')
        {
            string texto_editado = "";
            string[] texto_spliteado = texto.Split(caracter_separacion);

            if (texto_spliteado[texto_spliteado.Length - 1] == "")
            {
                for (int i = 0; i < texto_spliteado.Length; i++)
                {
                    if (i < texto_spliteado.Length - 2)
                    {
                        texto_editado = texto_editado + texto_spliteado[i] + caracter_separacion;
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
                        texto_editado = texto_editado + texto_spliteado[i] + caracter_separacion;
                    }

                    else
                    {
                        texto_editado = texto_editado + texto_spliteado[i];
                    }
                }
            }


            return texto_editado;
        }

        //fin no muy importantes-------------------------------------------------------------------------------------------------

        

        public void Crear_archivo_y_directorio(string direccion_archivo, string valor_inicial = null, string[] columnas = null)//columnas: es para crearlas y se separan la columnas por un '|' valor_inicial: no se utilisa en este programa era para poner un tipo eslogan o un titulo  pero en este programa no lo nesesite
        {
            char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split
            string acumulador_directorios_y_archvo = "";
            string[] direccion_espliteada = direccion_archivo.Split(parametro2);//spliteamos la direccion

            for (int i = 0; i < direccion_espliteada.Length; i++)//pasamos por todas las los directorios y archivo
            {
                if (i < direccion_espliteada.Length - 1)//el path muestra 6 palabras que fueron espliteadas se le resta uno por que los arreglos empiesan desde 0 y solo se le pone el menor que por que la ultima palabra es el archivo
                {
                    acumulador_directorios_y_archvo = acumulador_directorios_y_archvo + direccion_espliteada[i] + "\\"; // va acumulando los directorios a los que va a entrar ejemplo: ventas\\   ventas\\2016    ventas\\2016\\        ventas\\2016\\11      ventas\\2016\\11\\dias\\  y no muestra el ultimo por que es el archivo y en el if  le dijimos que lo dejara en el penultimo
                    if (!Directory.Exists(acumulador_directorios_y_archvo))//si el directorio no existe entrara y lo creara
                    {

                        Directory.CreateDirectory(acumulador_directorios_y_archvo);//crea el directorio

                    }
                }
            }

            if (direccion_espliteada[direccion_espliteada.Length - 1] != "")//checa si escribio tambien el archivo o solo carpetas
            {
                if (!File.Exists(direccion_archivo))//si el archivo no existe entra y lo crea
                {
                    FileStream fs0 = new FileStream(direccion_archivo, FileMode.CreateNew);//crea una variable tipo filestream "fs0"  y crea el archivo
                    fs0.Close();//cierra fs0 para que se pueda usar despues



                    if (valor_inicial != null)// si al llamar a la funcion  le pusiste valor_inicial las escribe //se utilisa para que sea como un titulo o un eslogan pero lo utilisaremos en este prog
                    {
                        Agregar(direccion_archivo, valor_inicial);//escribe aqui el valor inicial si es que lo pusiste
                    }

                    if (columnas != null)//si al llamar a la funcion le pusistes columnas a agregar//recuerda que se separan por comas
                    {

                        string columnas_unidas = string.Join("" + G_caracteres_separacion[0], columnas);
                        Agregar(direccion_archivo, columnas_unidas);//agrega las columnas

                    }

                    //si crea ele archivo lee el archivo

                }
            }



        }

        // Método para leer un archivo de texto y devolver un array de strings

        public string[] Leer_inicial(string direccionArchivo, string posString = null, string[] caracteres_separacion = null, int iniciar_desde_que_fila = 0)
        {
            if (caracteres_separacion == null)
            {
                caracteres_separacion = G_caracteres_separacion;
            }

            // Declaración de variables
            string[] linea = null;      // Almacenará todas las líneas cuando posString sea null
            string[] resultado = null;  // Almacenará el resultado final cuando posString no sea null
            string[] posSplit;
            int[] posiciones;

            string palabra = null;

            // Crear un objeto StreamReader para leer el archivo
            StreamReader sr = new StreamReader(direccionArchivo);

            // Si posString es null, se lee el archivo línea por línea y se agrega cada línea a "linea"
            if (posString == null)
            {
                while ((palabra = sr.ReadLine()) != null)
                {
                    if (palabra != "")
                    {
                        linea = op_arreglos.agregar_registro_del_array(linea, palabra);
                    }
                }
            }
            // Si posString no es null, se extraen las columnas especificadas y se agregan a "resultado"
            else
            {
                posSplit = posString.Split(caracteres_separacion[0][0]);
                posiciones = new int[posSplit.Length];

                // Convertir las posiciones de las columnas de string a int
                for (int i = 0; i < posiciones.Length; i++)
                {
                    posiciones[i] = Convert.ToInt32(posSplit[i]);
                }

                // Leer el archivo línea por línea y procesar según las posiciones especificadas
                for (int i = 0; (palabra = sr.ReadLine()) != null; i++)
                {
                    string[] splLinea = palabra.Split(caracteres_separacion[0][0]);

                    palabra = "";
                    for (int j = 0; j < posiciones.Length; j++)
                    {
                        if (j < posiciones.Length - 1)
                        {
                            palabra = palabra + splLinea[posiciones[j]] + caracteres_separacion[0];
                        }
                        else
                        {
                            palabra = palabra + splLinea[posiciones[j]];
                        }
                    }

                    // Agregar la palabra procesada al arreglo "resultado"
                    resultado = op_arreglos.agregar_registro_del_array(resultado, palabra);
                }

                // Cerrar el StreamReader ya que se ha completado el procesamiento
                sr.Close();

                // Copiar el resultado a un nuevo arreglo para evitar referencias no deseadas
                string[] arreglo_a_retornar = new string[resultado.Length];
                for (int fila = iniciar_desde_que_fila; fila < resultado.Length; fila++)
                {
                    arreglo_a_retornar[fila] = "" + resultado[fila];
                }

                // Devolver el resultado
                return arreglo_a_retornar;
            }

            // Cerrar el StreamReader ya que se ha completado el procesamiento
            sr.Close();

            // Copiar el contenido de "linea" a un nuevo arreglo para evitar referencias no deseadas
            string[] t2 = new string[linea.Length];
            for (int mnm = 0; mnm < linea.Length; mnm++)
            {
                t2[mnm] = "" + linea[mnm];
            }

            // Devolver el resultado
            return t2;
        }


        public string[] Agregar(string direccion_archivos, string agregando)
        {
            StreamWriter sw = new StreamWriter(direccion_archivos, true);
            sw.WriteLine(agregando);
            sw.Close();

            string num_indice_de_direccion = sacar_indice_del_arreglo_de_direccion(direccion_archivos);
            
            if (num_indice_de_direccion != null)
            {
                int num_indice_de_direccion_int = Convert.ToInt32(num_indice_de_direccion);
                GG_base_arreglo_de_arreglos[num_indice_de_direccion_int] = op_arreglos.agregar_registro_del_array(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int], agregando);
                
                return GG_base_arreglo_de_arreglos[num_indice_de_direccion_int];
            }

            return null;
        }

        public string[] Editar_o_incr_espesifico(string direccion_archivo, int num_column_comp, string comparar, string numero_columnas_editar, string editar_columna, string edit_0_o_increm_1 = null, string[] caracteres_separacion = null)
        {
            if (caracteres_separacion == null)
            {
                caracteres_separacion = G_caracteres_separacion;
            }

            string num_indice_de_direccion = sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            int num_indice_de_direccion_int = Convert.ToInt32(num_indice_de_direccion);

            

            for (int i = 0; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
            {
                string[] columnas = GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i].Split(caracteres_separacion[0][0]);
                
                if (columnas[num_column_comp] == comparar)
                {
                    
                    GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i] = op_arreglos.editar_incr_string_funcion_recursiva(GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i], numero_columnas_editar, editar_columna, edit_0_o_increm_1);
                    
                    cambiar_archivo_con_arreglo(direccion_archivo, GG_base_arreglo_de_arreglos[num_indice_de_direccion_int]);
                    break;
                }
            }
            return GG_base_arreglo_de_arreglos[num_indice_de_direccion_int];          
        }

        
        public string sacar_indice_del_arreglo_de_direccion(string direccion_archivo)
        {
            string num_indice_de_direccion = null;
            for (int i = 0; i < G_dir_bd_y_valor_inicial_bidimencional.GetLength(0); i++)
            {
                if (G_dir_bd_y_valor_inicial_bidimencional[i, 0] == direccion_archivo)
                {
                    num_indice_de_direccion = ""+i;
                }
            }
            return num_indice_de_direccion;
        }


        public string cambiar_archivo_con_arreglo(string direccion_archivo, string[] arreglo, string[] caracteres_separacion = null)
        {
            if (caracteres_separacion == null)
            {
                caracteres_separacion = G_caracteres_separacion;
            }

            string exito_o_fallo = "";
            string dir_tem = "tem.txt";
            StreamWriter sw = new StreamWriter(dir_tem, true);
            try
            {

                for (int i = 0; i < arreglo.Length; i++)
                {
                    sw.WriteLine(arreglo[i]);
                }
                exito_o_fallo = "1" + caracteres_separacion[0] + "exito";
            }
            catch (Exception e)
            {

                exito_o_fallo = "2" + caracteres_separacion[0] + "fallo" + caracteres_separacion[0] + e;

            }


            sw.Close();
            File.Delete(direccion_archivo);//borramos el archivo original
            File.Move(dir_tem, direccion_archivo);//renombramos el archivo temporal por el que tenia el original

            return exito_o_fallo;
        }

        public string[] eliminar_fila(string direccion_archivo, int num_column_comp, string comparar, string[] caracteres_separacion = null)
        {
            if (caracteres_separacion == null)
            {
                caracteres_separacion = G_caracteres_separacion;
            }
            string num_indice_de_direccion = sacar_indice_del_arreglo_de_direccion(direccion_archivo);
            int num_indice_de_direccion_int = Convert.ToInt32(num_indice_de_direccion);

            string temp = "";

            for (int i = 0; i < GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length; i++)
            {
                string[] columnas = GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i].Split(caracteres_separacion[0][0]);

                if (columnas[num_column_comp] == comparar)
                {
                    break;
                }

                if (i> GG_base_arreglo_de_arreglos[num_indice_de_direccion_int].Length-1)
                {
                    temp = temp + GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i] + G_separador_para_funciones_espesificas;
                }
                else
                {
                    temp = temp + GG_base_arreglo_de_arreglos[num_indice_de_direccion_int][i];
                }
                
            }
            string[] arreglo_a_retornar = temp.Split(G_separador_para_funciones_espesificas[0]);
            return arreglo_a_retornar;
        }


    }
}
