using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Irony.Parsing;

using OC2_P1_201800523.AST;
using OC2_P1_201800523.tablaSimbolos;

namespace OC2_P1_201800523.Arbol.Ejecucion.Expresion
{
    class expresion : nodo
    {
        public expresion(string tipo, string valor, ParseTreeNode node ) : base(tipo, valor, node) { }
        public expresion(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {            
            if (node.ChildNodes.Count == 1)
            {               
                ParseTreeNode salida = node.ChildNodes.ElementAt(0);
                if(salida.Term.ToString() == "numero")
                {
                   
                    if(int.TryParse(salida.Token.Text, out int i) == true)
                    {
                        return new resultado(salida.Term.ToString(), int.Parse(salida.Token.Text));
                    }else {
                        return new resultado(salida.Term.ToString(), double.Parse(salida.Token.Text));
                    }
                    
                }
                else if (salida.Term.ToString() == "cadena")
                {
                    string retorno = salida.Token.Text.Replace("'", "");
                    if(retorno.Length == 1)
                    {
                        return new resultado(terminales.rchar, retorno);
                    }
                    else
                    {
                        return new resultado(terminales.rstring, retorno);
                    }
                    
                }                
                else // id
                {
                    if(salida.Token.Text == "true"|| salida.Token.Text == "false")
                    {
                        return new resultado(terminales.rboolean, salida.Token.Text);
                    }
                    else
                    {
                        simbolo a = manejadorArbol.tabladeSimbolos.buscarSimbolo(salida.Token.Text);
                        if (a != null)
                        {
                            if (a.tipo == "integer" || a.tipo == "real")
                            {
                                return new resultado(terminales.numero, a.valor);
                            }
                            else
                            {
                                return new resultado(a.tipo, a.valor);
                            }

                        }
                    }

                    
                    return new resultado();
                }

            }
            else if(node.ChildNodes.Count == 2)
            {
                if (node.ChildNodes.ElementAt(0).Term.ToString() != "-")//UMINUS
                {

                    expresion derecha = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(1));
                    resultado resDer = derecha.Ejecutar();
                    resultado res = new resultado(terminales.numero, -resDer.getNumero());
                    return res;
                }else//NOT
                {
                    expresion derecha = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(1));
                    resultado resDer = derecha.Ejecutar();
                    resultado res = new resultado(terminales.numero, (!resDer.getBooleano()).ToString());
                    return res;
                }
            }
            else if (node.ChildNodes.Count == 3)
            {
               
                if (node.ChildNodes.ElementAt(0).Term.ToString() != "EXPRESION") /*CASO DEL PARENTESIS*/
                {
                    expresion centro = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(1));
                    resultado res = centro.Ejecutar();
                    return res;
                }
                else
                {
                    expresion izquierda = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(0));
                    expresion derecha = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(2));

                    resultado resIzq = izquierda.Ejecutar();
                    resultado resDer = derecha.Ejecutar();

                    ParseTreeNode salida = node.ChildNodes.ElementAt(1);

                    switch (salida.Token.Text)
                    {
                        case "+": return new resultado(terminales.numero, resIzq.getNumero() + resDer.getNumero());
                        case "-": return new resultado(terminales.numero, resIzq.getNumero() - resDer.getNumero());
                        case "*": return new resultado(terminales.numero, resIzq.getNumero() * resDer.getNumero());
                        case "div": return new resultado(terminales.numero, resIzq.getNumero() / resDer.getNumero());
                        case "/": return new resultado(terminales.numero, (double)resIzq.getNumero() / resDer.getNumero());
                        case "mod": return new resultado(terminales.numero, resIzq.getNumero() % resDer.getNumero());
                        case "and":
                            if (resIzq.getBooleano() == true && resDer.getBooleano() == true)
                            {
                                return new resultado(terminales.rtrue, "true");
                            }
                            else
                            {
                                return new resultado(terminales.rfalse, "false");
                            }
                        case "or":
                            if (resIzq.getBooleano() == false && resDer.getBooleano() == false)
                            {
                                return new resultado(terminales.rfalse, "false");
                            }
                            else
                            {
                                return new resultado(terminales.rtrue, "true");
                            }
                        case "AND":
                            if (resIzq.getBooleano() == true && resDer.getBooleano() == true)
                            {
                                return new resultado(terminales.rtrue, "true");
                            }
                            else
                            {
                                return new resultado(terminales.rfalse, "false");
                            }
                        case "OR":
                            if (resIzq.getBooleano() == false && resDer.getBooleano() == false)
                            {
                                return new resultado(terminales.rfalse, "false");
                            }
                            else
                            {
                                return new resultado(terminales.rtrue, "true");
                            }
                        case "=":
                            if (resIzq.getValor() == resDer.getValor())
                            {
                                return new resultado(terminales.rtrue, "true");
                            }
                            else
                            {
                                return new resultado(terminales.rfalse, "false");
                            }
                        case "<>":
                            if (resIzq.getValor() != resDer.getValor())
                            {
                                return new resultado(terminales.rtrue, "true");
                            }
                            else
                            {
                                return new resultado(terminales.rfalse, "false");
                            }
                        case "<":

                            if (resIzq.getNumero() < resDer.getNumero())
                            {
                                return new resultado(terminales.rtrue, "true");
                            }
                            else
                            {
                                return new resultado(terminales.rfalse, "false");
                            }
                        case ">":

                            if (resIzq.getNumero() > resDer.getNumero())
                            {
                                return new resultado(terminales.rtrue, "true");
                            }
                            else
                            {
                                return new resultado(terminales.rfalse, "false");
                            }
                        case "<=":

                            if (resIzq.getNumero() <= resDer.getNumero())
                            {
                                return new resultado(terminales.rtrue, "true");
                            }
                            else
                            {
                                return new resultado(terminales.rfalse, "false");
                            }
                        case ">=":

                            if (resIzq.getNumero() >= resDer.getNumero())
                            {
                                return new resultado(terminales.rtrue, "true");
                            }
                            else
                            {
                                return new resultado(terminales.rfalse, "false");
                            }

                    }
                }
            }
            else
            {
                //FALTA LA LLAMADA A FUNCIONES
            }

                return new resultado();
        }
    }
}
