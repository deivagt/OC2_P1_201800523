using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Irony.Parsing;
using Irony.Ast;
using OC2_P1_201800523.Arbol.Ejecucion;
using OC2_P1_201800523.AST;
using OC2_P1_201800523.Arbol;
using OC2_P1_201800523.tablaSimbolos;
namespace OC2_P1_201800523
{
   
        class manejadorArbol
        {
        public static bool controlBreak = false;
        public static bool controlContinue = false;
        //public static bool controlExit = false;
        public static string ambitoActual;
        static ParseTreeNode raiz;
        public static tabla tabladeSimbolos;
            public static void iniciar(ParseTreeNode nuevaRaiz)
            {
                
                manejadorArbol.raiz = nuevaRaiz;
                tabladeSimbolos = new tabla();
                ambitoActual = "global";          
           
            }

            public static void ejecutar()
            {
                ini a = new ini(noterminales.INI, manejadorArbol.raiz);
                resultado salida = a.Ejecutar();
            }

        public static void imprimirTabla()
        {
            foreach (var simbolo in manejadorArbol.tabladeSimbolos.getTabla())
            {
                System.Diagnostics.Debug.WriteLine(simbolo.categoria + " " + simbolo.ambito + " " + simbolo.id + " " + simbolo.tipo + " " + simbolo.valor + " " + simbolo.fila + " " + simbolo.columna);
            }
        }

    }
    
}
