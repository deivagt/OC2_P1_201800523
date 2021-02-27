using System;
using System.Collections.Generic;
using System.Text;
using Irony.Parsing;
using Irony.Ast;

namespace OC2_P1_201800523.AST
{
    class AnalizadorSintactico :Grammar
    {
        public void analisis(string entrada)
        {
            Gramatica gram = new Gramatica();
            LanguageData leng = new LanguageData(gram);
            Parser parser = new Parser(leng);
            ParseTree arbol = parser.Parse(entrada);
            ParseTreeNode raiz = arbol.Root;
            recorrer(raiz);

        }

        public void recorrer(ParseTreeNode nodo)
        {
            foreach(var hijo in nodo.ChildNodes)
            {
                System.Diagnostics.Debug.WriteLine(hijo.Term);
                recorrer(hijo);
            }
        }
    }
}
