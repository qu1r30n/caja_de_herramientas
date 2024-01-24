using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using caja_de_herramientas.clases.herramientas;

namespace caja_de_herramientas.clases
{
    class poner_al_inicio_del_programa
    {
        Tex_base bas = new Tex_base();
        operaciones_arreglos op_arreglos = new operaciones_arreglos();

        int G_configuracion = var_fun_GG.GG_indice_donde_comensar;

        public void inicio()
        {

            string direccion_archivo_de_direcciones_de_bd = "archivos_iniciales\\inicio.txt";
            string fila_inicial = "direccion_de_las_bases_de_datos" + bas.G_separador_para_funciones_espesificas + "fila_inicial" + bas.G_separador_para_funciones_espesificas + "arreglo_de_filas_separado_por_§//posdata_solo_ir_agregando_archivos_asta_abajo_por_que_las_filas_ya_son_ocupadas_por_el_programa_y_no_borrar";

            bas.Crear_archivo_y_directorio(direccion_archivo_de_direcciones_de_bd, fila_inicial,leer_y_agrega_al_arreglo:false);
            string[] direcciones_bases_datos_y_fila_inicial = bas.Leer_inicial(direccion_archivo_de_direcciones_de_bd,iniciar_desde_que_fila:1);


            for (int i = G_configuracion; i < direcciones_bases_datos_y_fila_inicial.Length; i++)
            {
                string[] espliteados_direcciones_bases_datos_y_fila_inicial = direcciones_bases_datos_y_fila_inicial[i].Split(bas.G_separador_para_funciones_espesificas[0]);
                string[] filas_iniciales = espliteados_direcciones_bases_datos_y_fila_inicial[2].Split(bas.G_separador_para_funciones_espesificas2[0]);
                if (i>0)
                {
                    bas.Crear_archivo_y_directorio(espliteados_direcciones_bases_datos_y_fila_inicial[0], espliteados_direcciones_bases_datos_y_fila_inicial[1], filas_iniciales, false);
                    Tex_base.GG_base_arreglo_de_arreglos = op_arreglos.agregar_arreglo_a_arreglo_de_arreglos(Tex_base.GG_base_arreglo_de_arreglos, bas.Leer_inicial(espliteados_direcciones_bases_datos_y_fila_inicial[0]));
                }
                
                Tex_base.GG_dir_bd_y_valor_inicial_bidimencional = op_arreglos.agregar_registro_del_array_bidimensional(Tex_base.GG_dir_bd_y_valor_inicial_bidimencional, direcciones_bases_datos_y_fila_inicial[i], new string[] { bas.G_separador_para_funciones_espesificas });
            }
        }
    }
}
