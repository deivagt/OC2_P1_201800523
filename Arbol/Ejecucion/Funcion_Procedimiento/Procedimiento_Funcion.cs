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
using OC2_P1_201800523.Arbol.Ejecucion.variables;

namespace OC2_P1_201800523.Arbol.Ejecucion.Funcion_Procedimiento
{
    class Procedimiento_Funcion : nodo
    {
        public Procedimiento_Funcion(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public Procedimiento_Funcion(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {
            
            string identificador;
            ParseTreeNode parametros;
            ParseTreeNode variables;
            ParseTreeNode acciones;
            ParseTreeNode otrFuncion;
            ParseTreeNode Retorno;
            if (node.ChildNodes.Count == 11)//Sin parametros
            {
                identificador = node.ChildNodes.ElementAt(1).Token.Text;

                objetoFuncion oF = new objetoFuncion(identificador);
                variables = node.ChildNodes.ElementAt(5);
                otrFuncion = node.ChildNodes.ElementAt(6);
                acciones = node.ChildNodes.ElementAt(8);

                //AGREGAR EN LA TABLA DE SIMBOLOS
                int fila = node.ChildNodes.ElementAt(1).Token.Location.Line;
                int columna = node.ChildNodes.ElementAt(1).Token.Location.Column;

                simbolo nuevaFuncion = new simbolo(manejadorArbol.ambitoActual, identificador, fila, columna, oF);
                manejadorArbol.tabladeSimbolos.agregarSimbolo(nuevaFuncion);

                if (variables.ChildNodes.Count != 0)
                {
                    string ambitoanterior = manejadorArbol.ambitoActual.Clone().ToString();
                    manejadorArbol.ambitoActual = identificador;
                    //AGREGAR A LA TABLA DE SIMBOLOS

                    LinkedList<ParseTreeNode> lvar = new LinkedList<ParseTreeNode>();
                    declararenfuncion def = new declararenfuncion("", variables);
                    def.nuevaEjecucion(lvar);
                    foreach (var a in lvar)
                    {
                        variable nuevaval = new variable(noterminales.VARIABLE, a);
                        nuevaval.Ejecutar();
                    }

                    manejadorArbol.ambitoActual = "global";
                }

                if (otrFuncion.ChildNodes.Count != 0)
                {
                    //CREAR NUEVA FUNCION/PROCEDIMIENTO
                }

                if (acciones.ChildNodes.Count != 0)
                {
                    oF.lstSent = acciones;
                }
            }
            else if (node.ChildNodes.Count == 13)
            {
                identificador = node.ChildNodes.ElementAt(1).Token.Text;
                Retorno = node.ChildNodes.ElementAt(5).ChildNodes.ElementAt(0);
                objetoFuncion oF = new objetoFuncion(identificador);
                variables = node.ChildNodes.ElementAt(7);
                otrFuncion = node.ChildNodes.ElementAt(8);
                acciones = node.ChildNodes.ElementAt(10);

                //AGREGAR EN LA TABLA DE SIMBOLOS
                int fila = node.ChildNodes.ElementAt(1).Token.Location.Line;
                int columna = node.ChildNodes.ElementAt(1).Token.Location.Column;
                string tipo = Retorno.Token.Text;
                simbolo nuevaFuncion = new simbolo(manejadorArbol.ambitoActual, identificador, fila, columna,tipo, oF);
                manejadorArbol.tabladeSimbolos.agregarSimbolo(nuevaFuncion);

                oF.retorno = tipo;
                if (variables.ChildNodes.Count != 0)
                {
                    string ambitoanterior = manejadorArbol.ambitoActual.Clone().ToString();
                    manejadorArbol.ambitoActual = identificador;
                    //AGREGAR A LA TABLA DE SIMBOLOS

                    LinkedList<ParseTreeNode> lvar = new LinkedList<ParseTreeNode>();
                    declararenfuncion def = new declararenfuncion("", variables);
                    def.nuevaEjecucion(lvar);
                    foreach (var a in lvar)
                    {
                        variable nuevaval = new variable(noterminales.VARIABLE, a);
                        nuevaval.Ejecutar();
                    }

                    manejadorArbol.ambitoActual = "global";
                }

                if (otrFuncion.ChildNodes.Count != 0)
                {
                    //CREAR NUEVA FUNCION/PROCEDIMIENTO
                }

                if (acciones.ChildNodes.Count != 0)
                {
                    oF.lstSent = acciones;
                }

            }
            else if (node.ChildNodes.Count == 14)
            {
                identificador = node.ChildNodes.ElementAt(1).Token.Text;
                parametros = node.ChildNodes.ElementAt(3);
                Retorno = node.ChildNodes.ElementAt(6).ChildNodes.ElementAt(0);
                objetoFuncion oF = new objetoFuncion(identificador);
                
                variables = node.ChildNodes.ElementAt(8);
                otrFuncion = node.ChildNodes.ElementAt(9);
                acciones = node.ChildNodes.ElementAt(11);

                //AGREGAR EN LA TABLA DE SIMBOLOS
                int fila = node.ChildNodes.ElementAt(1).Token.Location.Line;
                int columna = node.ChildNodes.ElementAt(1).Token.Location.Column;
                string tipo = Retorno.Token.Text;
                simbolo nuevaFuncion = new simbolo(manejadorArbol.ambitoActual, identificador, fila, columna, tipo, oF);
                manejadorArbol.tabladeSimbolos.agregarSimbolo(nuevaFuncion);

                oF.retorno = tipo;
                if (variables.ChildNodes.Count != 0)
                {
                    string ambitoanterior = manejadorArbol.ambitoActual.Clone().ToString();
                    manejadorArbol.ambitoActual = identificador;
                    //AGREGAR A LA TABLA DE SIMBOLOS

                    LinkedList<ParseTreeNode> lvar = new LinkedList<ParseTreeNode>();
                    declararenfuncion def = new declararenfuncion("", variables);
                    def.nuevaEjecucion(lvar);
                    foreach (var a in lvar)
                    {
                        variable nuevaval = new variable(noterminales.VARIABLE, a);
                        nuevaval.Ejecutar();
                    }

                    manejadorArbol.ambitoActual = "global";
                }

                if (otrFuncion.ChildNodes.Count != 0)
                {
                    //CREAR NUEVA FUNCION/PROCEDIMIENTO
                }

               

                if (acciones.ChildNodes.Count != 0)
                {
                    oF.lstSent = acciones;
                }
            }
                return new resultado();
        }
        
    }
}
