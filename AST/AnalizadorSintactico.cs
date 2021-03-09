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
            try
            {
                ParseTreeNode raiz = arbol.Root;
                manejadorArbol.iniciar(raiz);
                manejadorArbol.ejecutar();
                System.Diagnostics.Debug.WriteLine(raiz.Term);
                recorrer(raiz);
            } catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

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
