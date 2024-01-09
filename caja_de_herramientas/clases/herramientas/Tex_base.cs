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
        static public string[][] GG_base_arreglo_de_arreglos;

        

        char[] G_parametros = { '|', '°', '¬', '^' };



        /*Aquí poner las funciones de las otras clases Si te vas a llevar esta clase solamente --------------------------------
        Ver poniendo también los nombres de las funciones que estás usando para no pasar toda la clase -----------------------
        Próstata también el nombre de la clase para saber de qué clase se está sacando las funciones -------------------------
        */
        operaciones_arreglos op_arreglos = new operaciones_arreglos();

        //fin Aquí poner las funciones de las otras clases Si te vas a llevar esta clase solamente --------------------------------
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

                        string columnas_unidas = string.Join("" + G_parametros[0], columnas);
                        Agregar(direccion_archivo, columnas_unidas);//agrega las columnas

                    }

                    //si crea ele archivo lee el archivo

                }
            }



        }

        public void Agregar(string direccion_archivos, string agregando)
        {
            StreamWriter sw = new StreamWriter(direccion_archivos, true);
            sw.WriteLine(agregando);
            sw.Close();

        }

        public string Editar_espesifico(string direccion_archivo, int num_column_comp, string comparar, string numero_columnas_editar, string editar_columna, char caracter_separacion = '|')
        {

            StreamReader sr = new StreamReader(direccion_archivo);
            string dir_tem = direccion_archivo.Replace(".txt", "_tem.txt");
            StreamWriter sw = new StreamWriter(dir_tem, true);
            string exito_o_fallo;

            try
            {
                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    string linea = sr.ReadLine();//leemos linea y lo guardamos en palabra
                    if (linea != null)
                    {
                        string[] palabra = linea.Split(caracter_separacion);

                        if (palabra[num_column_comp] == comparar)
                        {
                            string linea_editada = "";
                            string[] columnas_editar = numero_columnas_editar.Split(caracter_separacion);
                            string[] remplaso_dato = editar_columna.Split(caracter_separacion);
                            for (int i = 0; i < columnas_editar.Length; i++)
                            {
                                palabra[Convert.ToInt32(columnas_editar[i])] = remplaso_dato[i];
                            }
                            for (int i = 0; i < palabra.Length; i++)
                            {
                                linea_editada = linea_editada + palabra[i] + caracter_separacion;
                            }
                            linea_editada = Trimend_paresido(linea_editada, caracter_separacion);

                            sw.WriteLine(linea_editada);

                        }
                        else
                        {
                            sw.WriteLine(linea);
                        }
                    }
                }
                exito_o_fallo = "1)exito";
                sr.Close();
                sw.Close();
                File.Delete(direccion_archivo);//borramos el archivo original
                File.Move(dir_tem, direccion_archivo);//renombramos el archivo temporal por el que tenia el original

            }
            catch (Exception error)
            {
                sr.Close();
                sw.Close();
                exito_o_fallo = "2)error:" + error;
                File.Delete(dir_tem);//borramos el archivo original
            }
            return exito_o_fallo;
        }


        // Método para leer un archivo de texto y devolver un array de strings
        /*
        public string[] Leer(string direccion_archivo, string pos_string = null, char caracter_separacion = '|')
        {
            
            // Crear un StreamReader para leer el archivo
            StreamReader sr = new StreamReader(direccion_archivo);


            while (sr.ReadLine() != null)
            {
                string linea;
                if (pos_string != null)
                {
                    linea = sr.ReadLine();
                }
                else
                {

                }
            }

            // Cerrar el StreamReader
            sr.Close();

        }
        */





    }
}
