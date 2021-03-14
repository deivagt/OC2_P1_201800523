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
    class decltipos : nodo
    {
        public decltipos(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public decltipos(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {
           if(node.ChildNodes.Count == 5)//Tipo normalito uwu
            {
                ParseTreeNode otraDelcTipo = node.ChildNodes.ElementAt(4);

                if (node.ChildNodes.ElementAt(0).Term.ToString() == terminales.id)
                {
                    ParseTreeNode id = node.ChildNodes.ElementAt(0);
                    ParseTreeNode tipo = node.ChildNodes.ElementAt(2);

                    int fila = id.Token.Location.Line;
                    int columna = id.Token.Location.Column;
                    string eltipo = tipo.ChildNodes.ElementAt(0).Token.Text;
                    simbolo nuevoSimbolo = new simbolo(manejadorArbol.ambitoActual, id.Token.Text, eltipo, fila + 1, columna + 1, true);
                    manejadorArbol.tabladeSimbolos.agregarSimbolo(nuevoSimbolo);
                }
                else
                {
                    LinkedList<ParseTreeNode> listaVar = new LinkedList<ParseTreeNode>();
                    ParseTreeNode ids = node.ChildNodes.ElementAt(0);
                    ParseTreeNode tipo = node.ChildNodes.ElementAt(2);
                    

                    delvariost variasVariables = new delvariost(noterminales.OTRA_DECL_VARIABLE, ids);

                    variasVariables.nuevaEjecucion(listaVar);

                    foreach (var a in listaVar)
                    {
                        int fila = a.Token.Location.Line;
                        int columna = a.Token.Location.Column;
                        string eltipo = tipo.ChildNodes.ElementAt(0).Token.Text;
                        simbolo nuevoSimbolo = new simbolo(manejadorArbol.ambitoActual, a.Token.Text, eltipo, fila + 1, columna + 1, true);
                        manejadorArbol.tabladeSimbolos.agregarSimbolo(nuevoSimbolo);
                    }
                }
                   
                if (otraDelcTipo.ChildNodes.Count != 0)
                {
                    decltipos otroTipo = new decltipos(noterminales.DECLTIPOS, otraDelcTipo);
                    otroTipo.Ejecutar();
                }
            }
            else if (node.ChildNodes.Count == 7) // OBJETO
            {
                
                ParseTreeNode id = node.ChildNodes.ElementAt(0);

                declaracionatributos atributos = new declaracionatributos(noterminales.DECLARACIONATRIBUTOS, node.ChildNodes.ElementAt(4));
                LinkedList<simbolo> listaAtributos = new LinkedList<simbolo>();
                atributos.obtenerAtributos(listaAtributos, id.Token.Text);
                

                int fila = id.Token.Location.Line;
                int columna = id.Token.Location.Column;
                simbolo nuevoSimbolo = new simbolo( manejadorArbol.ambitoActual, id.Token.Text, fila + 1, columna + 1, listaAtributos);
                manejadorArbol.tabladeSimbolos.agregarSimbolo(nuevoSimbolo);

            }
           else //ARRAY
            {

            }

            return new resultado();

        }
    }
}
