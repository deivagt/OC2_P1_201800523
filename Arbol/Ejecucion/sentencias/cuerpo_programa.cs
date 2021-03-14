using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Irony.Ast;
using Irony.Parsing;
using OC2_P1_201800523.tablaSimbolos;
using OC2_P1_201800523.Arbol.Ejecucion.Expresion;
using OC2_P1_201800523.AST;


namespace OC2_P1_201800523.Arbol.Ejecucion.sentencias
{
    class cuerpo_programa : nodo
    {
        public cuerpo_programa(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public cuerpo_programa(string tipo, ParseTreeNode node) : base(tipo, node) { }

        public override resultado Ejecutar()
        {
            ParseTreeNode lstSent = node.ChildNodes.ElementAt(1);
            if (lstSent.ChildNodes.Count != 0)
            {
                LinkedList<sentencia> listaSentencias = new LinkedList<sentencia>();
                sentencias sentencias = new sentencias(noterminales.SENTENCIAS, lstSent);
                sentencias.nuevaEjecucion(listaSentencias);

                foreach (var sentencia in listaSentencias)
                {
                    sentencia.Ejecutar();
                }

            }

            return new resultado();
        }
    }
}
