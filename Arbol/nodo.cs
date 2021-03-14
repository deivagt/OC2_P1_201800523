using System;
using System.Collections.Generic;
using System.Text;
using Irony.Ast;
using Irony.Parsing;

namespace OC2_P1_201800523.Arbol
{
    abstract class nodo
    {
        public string type;                //Tipo del Nodo
        public string value;            //Valor del Nodo
        public ParseTreeNode node;      //Nodo original del arbol de irony

        public nodo(string type, string value, ParseTreeNode node) //Para terminales
        {
            this.type = type;
            this.value = value;
            this.node = node;
        }

        public nodo(string type, ParseTreeNode node) //Para no terminales
        {
            this.type = type;
            this.value = "";
            this.node = node;
        }

        public abstract resultado Ejecutar();
    }
}
