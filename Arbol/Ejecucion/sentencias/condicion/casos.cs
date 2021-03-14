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
    class casos
    {
        public ParseTreeNode expr;
        public ParseTreeNode sentencia;
        public casos(ParseTreeNode expr, ParseTreeNode sentencia)
        {
            this.expr = expr;
            this.sentencia = sentencia;
        }

    }
}
