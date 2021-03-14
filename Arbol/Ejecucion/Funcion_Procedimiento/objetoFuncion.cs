using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Irony.Ast;
using Irony.Parsing;
using OC2_P1_201800523.tablaSimbolos;
using OC2_P1_201800523.Arbol.Ejecucion.Expresion;
using OC2_P1_201800523.AST;
using OC2_P1_201800523.Arbol.Ejecucion.sentencias;

namespace OC2_P1_201800523.Arbol.Ejecucion.Funcion_Procedimiento
{
    class objetoFuncion
    {
        public string id;
        //public LinkedList<>
        public string retorno;
        public ParseTreeNode lstSent;

        public objetoFuncion(string id)//Constructor procedimieto
        {
            this.id = id;
            this.retorno = "";
            this.lstSent = null;
        }
        public objetoFuncion(string id,string retorno)//Constructor procedimieto
        {
            this.id = id;
            this.retorno = retorno;
            this.lstSent = null;
        }


        void hacerEjecucion()
        {
            if(lstSent != null)
            {
                if (lstSent.ChildNodes.Count != 0)
                {
                    LinkedList<sentencia> listaSentencias = new LinkedList<sentencia>();
                    sentencias.sentencias sentencias = new sentencias.sentencias(noterminales.SENTENCIAS, lstSent);
                    sentencias.nuevaEjecucion(listaSentencias);

                    foreach (var sentencia in listaSentencias)
                    {
                        sentencia.Ejecutar();
                    }

                }
            }
        }
    }
}
