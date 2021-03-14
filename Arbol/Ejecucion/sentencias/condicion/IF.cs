using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Irony.Ast;
using Irony.Parsing;
using OC2_P1_201800523.tablaSimbolos;
using OC2_P1_201800523.Arbol.Ejecucion.Expresion;
using OC2_P1_201800523.AST;


namespace OC2_P1_201800523.Arbol.Ejecucion.sentencias.condicion
{
    class IF : nodo
    {
        public IF(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public IF(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {
            if (node.ChildNodes.Count == 4) // else normalito
            {
                hacerEjecucion(node.ChildNodes.ElementAt(2));
            }
            else //else if
            {

                /*Condicion del if*/
                ParseTreeNode expresion = node.ChildNodes.ElementAt(2);
                expresion expr = new expresion(noterminales.EXPRESION, expresion);
                resultado res = expr.Ejecutar();
                if (res.getValor() == "true")
                {
                    hacerEjecucion(node.ChildNodes.ElementAt(5));
                }
                else if (res.getValor() == "false")
                {
                    if(node.ChildNodes.ElementAt(7).ChildNodes.Count != 0)
                    {
                        IF siguienteifelse = new IF(noterminales.ELSEIF, node.ChildNodes.ElementAt(7));
                        siguienteifelse.Ejecutar();
                    }
                    
                }
                else
                {
                    //Error
                }


                return new resultado();
            }

            return new resultado();
        }

        void hacerEjecucion(ParseTreeNode lstSent)
        {
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
        }
    }
}
