﻿using System;
using System.Collections.Generic;
using System.Text;
using Irony.Parsing;
using Irony.Ast;

namespace OC2_P1_201800523.AST
{
    class AnalizadorSintactico : Grammar
    {

        public ParseTreeNode raiz;
        public void analisis(string entrada)
        {
            Program.form.richTextBox2.Text = "";
            Program.form.richTextBox3.Text = "";
            Program.form.richTextBox4.Text = "";
            Program.form.richTextBox5.Text = "";

            Gramatica gram = new Gramatica();
            LanguageData leng = new LanguageData(gram);
            Parser parser = new Parser(leng);
            ParseTree arbol = parser.Parse(entrada);
            try
            {
                if (arbol.Root != null)
                {
                    raiz = arbol.Root;
                    recorrer(raiz);
                    manejadorArbol.iniciar(raiz);
                    manejadorArbol.ejecutar();
                    graficar(raiz);
                    //manejadorArbol.imprimirTabla();

                    foreach (var a in arbol.ParserMessages)
                    {
                        Program.form.richTextBox5.AppendText("Error: " + a.Message + " in line " + (a.Location.Line + 1) + " and column " + (a.Location.Column + 1) + "\n");


                    }
                }
                else
                {
                    
                    foreach (var a in arbol.ParserMessages)
                    {
                        Program.form.richTextBox5.AppendText("Error: "+a.Message + " in line " + (a.Location.Line + 1) + " and column " + (a.Location.Column + 1) + "\n");


                    }
                }


            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

        }

        public void recorrer(ParseTreeNode nodo)
        {
            foreach (var hijo in nodo.ChildNodes)
            {
                System.Diagnostics.Debug.WriteLine(hijo.Term);
                recorrer(hijo);
            }
        }


        public string graficar(ParseTreeNode padre)
        {
            return manejadorArbol.graficar(padre);
        }
        

    }
}
