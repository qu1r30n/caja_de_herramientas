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
        public string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        public string[] G_separador_para_funciones_espesificas_ = var_fun_GG.GG_caracter_separacion_funciones_espesificas;

        public void inicio()
        {

            string direccion_archivo_de_direcciones_de_bd = "archivos_iniciales\\inicio.txt";
            string fila_inicial = "direccion_de_las_bases_de_datos" + bas.G_separador_para_funciones_espesificas_[0] + "fila_inicial" + bas.G_separador_para_funciones_espesificas_[0] + "arreglo_de_filas_separado_por_§//posdata_solo_ir_agregando_archivos_asta_abajo_por_que_las_filas_ya_son_ocupadas_por_el_programa_y_no_borrar";
            string[] agregar_filas =
            {
                "config\\tienda\\inventario\\inventario.txt~producto|contenido|tipo_medida|precio_venta|cod_barras|cantidad|costo_comp|provedor|grupo|no poner nada|cant_produc_x_paquet|tipo_de_producto|ligar_produc_sab|impuestos|parte_de_que_producto~",
                "config\\sismul2\\negocio.txt~0_id_usuario|1_id_patrocinador_comp|2_tabla_patrocinador_comp|3_id_encargado_simple|4_tabla_encargado_simple|5_diner|6_pago_directo|7_pago_inderecto|8_datos|~1|1|patrocinadores_complejos|1|negocio|0|0|0|nombre°ap_p°ap_m°0°banco°curp°7487660000°direccion°colonia°municipio°estado°correo|§2|1|patrocinadores_complejos|1|negocio|0|0|0|nombre°ap_p°ap_m°0°banco°curp°7487660000°direccion°colonia°municipio°estado°correo|§3|1|patrocinadores_complejos|2|negocio|0|0|0|nombre°ap_p°ap_m°0°banco°curp°7487660000°direccion°colonia°municipio°estado°correo|§4|2|patrocinadores_complejos|3|negocio|0|0|0|nombre°ap_p°ap_m°0°banco°curp°7487660000°direccion°colonia°municipio°estado°correo|§5|3|patrocinadores_complejos|4|negocio|0|0|0|nombre°ap_p°ap_m°0°banco°curp°7487660000°direccion°colonia°municipio°estado°correo|",
                "config\\sismul2\\patrocinadores_complejos.txt~0_id_usuario|1_id_patrocinador_comp|2_tabla_patrocinador_comp|3_id_encargado_simple|4_tabla_encargado_simple|5_diner|6_pago_directo|7_pago_inderecto|8_datos|~1|1|patrocinadores_complejos|1|patrocinadores_complejos|0|0|0|nombre°ap_p°ap_m°0°banco°curp°7487660000°direccion°colonia°municipio°estado°correo|§2|1|patrocinadores_complejos|1|patrocinadores_complejos|0|0|0|nombre°ap_p°ap_m°0°banco°curp°7487660000°direccion°colonia°municipio°estado°correo|§3|1|patrocinadores_complejos|2|patrocinadores_complejos|0|0|0|nombre°ap_p°ap_m°0°banco°curp°7487660000°direccion°colonia°municipio°estado°correo|§4|1|patrocinadores_complejos|3|patrocinadores_complejos|0|0|0|nombre°ap_p°ap_m°0°banco°curp°7487660000°direccion°colonia°municipio°estado°correo|§5|1|patrocinadores_complejos|4|patrocinadores_complejos|0|0|0|nombre°ap_p°ap_m°0°banco°curp°7487660000°direccion°colonia°municipio°estado°correo|",
                "config\\sismul2\\porcentajes\\porcentajes.txt~fila1:_porsentage_venta_directa_fila2:porcentajes_simple_fila3:_porcentajes_complejo_fila4:_porcentaje_venta_directa_complejo~15§10|5§10|10|10§15"
            };

            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(direccion_archivo_de_direcciones_de_bd, fila_inicial, agregar_filas, caracter_separacion_fun_esp_objeto: G_separador_para_funciones_espesificas_[2]);
            

            //Tex_base.GG_dir_bd_y_valor_inicial_bidimencional = op_arreglos.agregar_registro_del_array_bidimensional(Tex_base.GG_dir_bd_y_valor_inicial_bidimencional, direccion_archivo_de_direcciones_de_bd, new string[] { bas.G_separador_para_funciones_espesificas });

            for (int i = G_configuracion; i < Tex_base.GG_base_arreglo_de_arreglos[0].Length; i++)
            {
                string[] espliteados_direcciones_bases_datos_y_fila_inicial = Tex_base.GG_base_arreglo_de_arreglos[0][i].Split(bas.G_separador_para_funciones_espesificas_[0][0]);
                string[] filas_iniciales = espliteados_direcciones_bases_datos_y_fila_inicial[2].Split(G_separador_para_funciones_espesificas_[1][0]);
                if (i>0)
                {
                    bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(espliteados_direcciones_bases_datos_y_fila_inicial[0], espliteados_direcciones_bases_datos_y_fila_inicial[1], filas_iniciales);   
                }
            }
        }
    }
}
