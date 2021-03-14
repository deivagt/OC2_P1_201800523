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
    class write : nodo
    {
        public write(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public write(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {
            string cadenaSalida = "";
            if (node.ChildNodes.Count == 1)
            {
                expresion expr = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(0));
                resultado res = expr.Ejecutar();
                cadenaSalida += res.getValor();
            }
            else
            {
                LinkedList<expresion> listaExpresiones = new LinkedList<expresion>();

                parametrowriteln par = new parametrowriteln(noterminales.PARAMETROSWRITELN, node.ChildNodes.ElementAt(0));
                par.nuevoParametro(listaExpresiones);

                foreach (var a in listaExpresiones)
                {
                    resultado res = a.Ejecutar();
                    cadenaSalida += res.getValor();
                }

                expresion laultima = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(2));
                resultado res1 = laultima.Ejecutar();
                cadenaSalida += res1.getValor();
            }

            Program.form.richTextBox2.AppendText(cadenaSalida);

            return new resultado();
        }
    }
}

