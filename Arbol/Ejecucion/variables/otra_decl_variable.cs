using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Irony.Ast;
using Irony.Parsing;
using OC2_P1_201800523.tablaSimbolos;
using OC2_P1_201800523.Arbol.Ejecucion.Expresion;
using OC2_P1_201800523.AST;

namespace OC2_P1_201800523.Arbol.Ejecucion.variables
{
    class otra_decl_variable : nodo
    {
        public otra_decl_variable(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public otra_decl_variable(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {
            return new resultado();
        }

        public void nuevaEjecucion(LinkedList<ParseTreeNode> lista)
        {
            if (node.ChildNodes.Count != 1)
            {
                otra_decl_variable siguiente = new otra_decl_variable(noterminales.OTRA_DECL_VARIABLE, node.ChildNodes.ElementAt(0));
                siguiente.nuevaEjecucion(lista);
                lista.AddLast(node.ChildNodes.ElementAt(2));
            }
            else
            {
                lista.AddLast(node.ChildNodes.ElementAt(0));
            }
        }
    }
}
