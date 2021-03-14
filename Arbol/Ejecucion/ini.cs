using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Irony.Parsing;
using OC2_P1_201800523.Arbol.Ejecucion;
using OC2_P1_201800523.AST;

namespace OC2_P1_201800523.Arbol.Ejecucion
{
    class ini : nodo
    {
        public ini(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public ini(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        { 
            etc.cosas a = new etc.cosas(noterminales.COSAS, node.ChildNodes.ElementAt(0));            
            resultado res = a.Ejecutar();
            //Program.form.richTextBox2.AppendText(res.getValor() + "\n");
            return res;
        }
    }
}
