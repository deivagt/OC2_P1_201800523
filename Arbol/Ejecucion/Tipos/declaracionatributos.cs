using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Irony.Ast;
using Irony.Parsing;
using OC2_P1_201800523.tablaSimbolos;
using OC2_P1_201800523.Arbol.Ejecucion.Expresion;
using OC2_P1_201800523.AST;

namespace OC2_P1_201800523.Arbol.Ejecucion.Tipos
{
    class declaracionatributos : nodo
    {
        public declaracionatributos(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public declaracionatributos(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {

            throw new NotImplementedException();
        }

        public void  obtenerAtributos(LinkedList<simbolo> lista, string variablePadre)
        {
            
            ParseTreeNode otroAtributo = node.ChildNodes.ElementAt(4);

            if (node.ChildNodes.ElementAt(0).Term.ToString() == terminales.id)
            {
                ParseTreeNode id = node.ChildNodes.ElementAt(0);
                ParseTreeNode tipo = node.ChildNodes.ElementAt(2);

                int fila = id.Token.Location.Line;
                int columna = id.Token.Location.Column;
                string eltipo = tipo.ChildNodes.ElementAt(0).Token.Text;
                simbolo nuevoSimbolo = new simbolo(true,variablePadre, id.Token.Text, eltipo, fila + 1, columna + 1);
                lista.AddLast(nuevoSimbolo);

            }
            else
            {
                LinkedList<ParseTreeNode> listaVar = new LinkedList<ParseTreeNode>();
                ParseTreeNode ids = node.ChildNodes.ElementAt(0);
                ParseTreeNode tipo = node.ChildNodes.ElementAt(2);


                otroatributo variasVariables = new otroatributo(noterminales.OTRADECLARACIONATRIBUTOS, ids);

                variasVariables.nuevaEjecucion(listaVar);

                foreach (var a in listaVar)
                {
                    int fila = a.Token.Location.Line;
                    int columna = a.Token.Location.Column;
                    string eltipo = tipo.ChildNodes.ElementAt(0).Token.Text;
                    simbolo nuevoSimbolo = new simbolo(true,variablePadre, a.Token.Text, eltipo, fila + 1, columna + 1);
                    lista.AddLast(nuevoSimbolo);
                }
            }

            if (otroAtributo.ChildNodes.Count != 0)
            {
                declaracionatributos otroAtr = new declaracionatributos(noterminales.DECLARACIONATRIBUTOS, otroAtributo);
                otroAtr.obtenerAtributos(lista,variablePadre);
            }

        }
    }
}
