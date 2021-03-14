using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Irony.Ast;
using Irony.Parsing;
using OC2_P1_201800523.tablaSimbolos;
using OC2_P1_201800523.Arbol.Ejecucion.Expresion;
using OC2_P1_201800523.AST;

namespace OC2_P1_201800523.Arbol.Ejecucion.Funcion_Procedimiento
{
    class declararenfuncion :nodo
    {

        public declararenfuncion(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public declararenfuncion(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {
            throw new NotImplementedException();
        }

        public void nuevaEjecucion(LinkedList<ParseTreeNode> lista)
        {
            if (node.ChildNodes.Count != 2)
            {
                declararenfuncion siguiente = new declararenfuncion(noterminales.OTRA_DECL_VARIABLE, node.ChildNodes.ElementAt(0));
                siguiente.nuevaEjecucion(lista);
                lista.AddLast(node.ChildNodes.ElementAt(2));
            }
            else
            {
                lista.AddLast(node.ChildNodes.ElementAt(1));
            }
        }
    }
}
