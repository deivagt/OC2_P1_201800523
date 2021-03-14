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
    class Case : nodo
    {
        public Case(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public Case(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {
            return new resultado();
        }

    public void nuevaEjecucion(LinkedList<casos> lista)
        {

            if (node.ChildNodes.Count == 2)
            {
                ParseTreeNode elcaso = node.ChildNodes.ElementAt(1).ChildNodes.ElementAt(0);
                ParseTreeNode lasreglas = node.ChildNodes.ElementAt(1).ChildNodes.ElementAt(3);
                casos caso = new casos(elcaso, lasreglas);
                lista.AddLast(caso);

                Case sigCaso = new Case(noterminales.CASOS, node.ChildNodes.ElementAt(0));
                sigCaso.nuevaEjecucion(lista);
                
            }
            else if (node.ChildNodes.Count == 1)
            {
                ParseTreeNode elcaso = node.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0);
                ParseTreeNode lasreglas = node.ChildNodes.ElementAt(0).ChildNodes.ElementAt(3);
                casos caso = new casos(elcaso, lasreglas);
                lista.AddLast(caso);
            }
            else
            {
                //XD
            }
        }
    }
}

