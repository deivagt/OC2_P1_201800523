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
                recorrer(raiz);
                manejadorArbol.iniciar(raiz);
                manejadorArbol.ejecutar();
                imprimirTabla();
                
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

        void imprimirTabla()
        {
            foreach(var simbolo in manejadorArbol.tabladeSimbolos.getTabla())
            {
                System.Diagnostics.Debug.WriteLine(simbolo.categoria + " " +simbolo.ambito + " " + simbolo.id + " " + simbolo.tipo + " " + simbolo.valor + " " + simbolo.fila + " " + simbolo.columna);
            }
        }
    }
}
