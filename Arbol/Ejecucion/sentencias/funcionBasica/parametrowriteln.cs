using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Irony.Ast;
using Irony.Parsing;
using OC2_P1_201800523.tablaSimbolos;
using OC2_P1_201800523.Arbol.Ejecucion.Expresion;
using OC2_P1_201800523.AST;

namespace OC2_P1_201800523.Arbol.Ejecucion.sentencias.funcionBasica
{
    class parametrowriteln : nodo
    {
        public parametrowriteln(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public parametrowriteln(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {

            throw new NotImplementedException();
        }

        public void nuevoParametro(LinkedList<expresion> lista)
        {
            if (node.ChildNodes.Count == 3)
            {
                parametrowriteln sigExpr = new parametrowriteln(noterminales.PARAMETROSWRITELN, node.ChildNodes.ElementAt(0));
                sigExpr.nuevoParametro(lista);

                expresion exp = new expresion(noterminales.SENTENCIA, node.ChildNodes.ElementAt(2));
                lista.AddLast(exp);
            }
            else if (node.ChildNodes.Count == 1)
            {
                expresion ins = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(0));
                lista.AddLast(ins);
            }
            else
            {
                //XD
            }
        }
    }
}
