using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Irony.Ast;
using Irony.Parsing;
using OC2_P1_201800523.tablaSimbolos;
using OC2_P1_201800523.Arbol.Ejecucion.Expresion;
using OC2_P1_201800523.AST;

namespace OC2_P1_201800523.Arbol.Ejecucion.constantes
{
    class constante : nodo
    {
        public constante(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public constante(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {

            ParseTreeNode id = node.ChildNodes.ElementAt(0);
            ParseTreeNode tipo = node.ChildNodes.ElementAt(2);
            ParseTreeNode expresion = node.ChildNodes.ElementAt(4);
            ParseTreeNode otraConstante = node.ChildNodes.ElementAt(6);

            int fila = id.Token.Location.Line;
            int columna = id.Token.Location.Column;

            expresion expr = new expresion(noterminales.EXPRESION, expresion);
            resultado res = expr.Ejecutar();
            string eltipo = tipo.ChildNodes.ElementAt(0).Token.Text;
            simbolo nuevoSimbolo = new simbolo(manejadorArbol.ambitoActual, id.Token.Text, res.getValor(),eltipo, fila + 1, columna + 1,false,true);
            manejadorArbol.tabladeSimbolos.agregarSimbolo(nuevoSimbolo);

            if (otraConstante.ChildNodes.Count != 0)
            {
                constante otraVar = new constante(noterminales.CONSTANTE, otraConstante);
                otraVar.Ejecutar();
            }

            return new resultado();
        }
    }
}
