using System;
using System.Collections.Generic;
using System.Text;
using Irony.Parsing;
using Irony.Ast;

namespace OC2_P1_201800523.AST
{
    class AnalizadorSintactico :Grammar
    {

        public ParseTreeNode raiz;
        public void analisis(string entrada)
        {
            
            Gramatica gram = new Gramatica();
            LanguageData leng = new LanguageData(gram);
            Parser parser = new Parser(leng);
            ParseTree arbol = parser.Parse(entrada);
            try
            {
                if(arbol.Root != null)
                {
                    raiz = arbol.Root;
                    recorrer(raiz);
                    manejadorArbol.iniciar(raiz);
                    manejadorArbol.ejecutar();
                    manejadorArbol.imprimirTabla();
                }
                else
                {
                    foreach(var a in arbol.ParserMessages)
                    {
                        System.Diagnostics.Debug.WriteLine(a.Message + " " + a.Location.Line+1 + " " + a.Location.Column+1);
                    }
                }
               
                
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


        public string graficar(ParseTreeNode padre)
        {
            string salida = "dot {";

            salida += "nodo" + manejadorArbol.contadorNodos + "[label=\"" + padre.Term.Name + "\"];\n";
            manejadorArbol.contadorNodos++;
            foreach (var hijo in padre.ChildNodes)
            {

                string nuevoNodo = "nodo"+ manejadorArbol.contadorNodos+ "[label=\"" +hijo.Term.Name + "\"];\n";
                string puntero = "nodo" + manejadorArbol.contadorNodos + "->" + "nodo" + (manejadorArbol.contadorNodos - 1);
                manejadorArbol.contadorNodos++;
                salida += nuevoNodo + puntero + "\n" ;
                AnalizadorSintactico n = new AnalizadorSintactico();
                salida += n.gr(hijo, salida);

            }

            return salida += "}";

        }
        string gr(ParseTreeNode padre, string cadenaActual)
        {
            cadenaActual += "nodo" + manejadorArbol.contadorNodos + "[label=\"" + padre.Term.Name + "\"];\n";
            manejadorArbol.contadorNodos++;
            foreach (var hijo in padre.ChildNodes)
            {

                string nuevoNodo = "nodo" + manejadorArbol.contadorNodos + "[label=\"" + hijo.Term.Name + "\"];\n";
                string puntero = "nodo" + manejadorArbol.contadorNodos + "->" + "nodo" + (manejadorArbol.contadorNodos - 1);
                manejadorArbol.contadorNodos++;
                cadenaActual += nuevoNodo + puntero;
                AnalizadorSintactico n = new AnalizadorSintactico();
                cadenaActual += n.gr(hijo, cadenaActual);

            }

            return cadenaActual;
        }

    }
}
