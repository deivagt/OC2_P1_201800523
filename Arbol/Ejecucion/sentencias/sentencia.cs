using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Irony.Ast;
using Irony.Parsing;
using OC2_P1_201800523.tablaSimbolos;
using OC2_P1_201800523.Arbol.Ejecucion.Expresion;
using OC2_P1_201800523.AST;
using OC2_P1_201800523.Arbol.Ejecucion.sentencias.condicion;

namespace OC2_P1_201800523.Arbol.Ejecucion.sentencias
{
    class sentencia : nodo
    {
        public sentencia(string tipo, string valor, ParseTreeNode node) : base(tipo, valor, node) { }
        public sentencia(string tipo, ParseTreeNode node) : base(tipo, node) { }
        public override resultado Ejecutar()
        {
            resultado res = null;
            ParseTreeNode palabraClave = node.ChildNodes.ElementAt(0);
            if (manejadorArbol.controlBreak == false && manejadorArbol.controlContinue == false)
            {
                switch (palabraClave.Token.Text)
                {

                    case "if":
                        if (node.ChildNodes.Count == 7) // if normalito
                        {
                            /*Condicion del if*/
                            ParseTreeNode expresion = node.ChildNodes.ElementAt(1);
                            expresion expr = new expresion(noterminales.EXPRESION, expresion);
                            res = expr.Ejecutar();
                            if (res.getValor() == "true")
                            {
                                hacerEjecucion(node.ChildNodes.ElementAt(4));
                            }
                            else

                            {
                                if (res.getValor() != "false")
                                {

                                }
                                else
                                {
                                    //ERROR
                                }
                            }
                        }
                        else //if else
                        {
                            ParseTreeNode expresion = node.ChildNodes.ElementAt(1);
                            expresion expr = new expresion(noterminales.EXPRESION, expresion);
                            res = expr.Ejecutar();
                            if (res.getValor() == "true")
                            {
                                hacerEjecucion(node.ChildNodes.ElementAt(4));
                            }
                            else if (res.getValor() == "false")
                            {
                                ParseTreeNode elseif = node.ChildNodes.ElementAt(6);
                                condicion.IF siguienteelseif = new condicion.IF(noterminales.ELSEIF, elseif);
                                siguienteelseif.Ejecutar();
                            }
                            else
                            {
                                //Error
                            }
                        }

                        return new resultado();

                    case "case":
                        expresion ex = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(1));
                        res = ex.Ejecutar();

                        LinkedList <casos> listaCasos = new LinkedList<casos>();
                        Case cas = new Case(noterminales.CASOS, node.ChildNodes.ElementAt(3));
                        cas.nuevaEjecucion(listaCasos);
                        foreach(var caso in listaCasos)
                        {
                            expresion cond = new expresion(noterminales.EXPRESION, caso.expr);
                            resultado comparacionActual = cond.Ejecutar();
                            if(res.tipo == comparacionActual.tipo)
                            {
                                if(res.valor == comparacionActual.valor)
                                {
                                    hacerEjecucion(caso.sentencia);
                                    return new resultado();
                                }
                            }
                        }                        

                        if(node.ChildNodes.Count != 6)//con else
                        {
                            hacerEjecucion(node.ChildNodes.ElementAt(6));
                        }
                        return new resultado();
                    case "while":

                        expresion condicion = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(1));
                        ParseTreeNode sentencias = node.ChildNodes.ElementAt(4);

                        res = condicion.Ejecutar();
                        if (res.valor == "true" || res.valor == "false")
                        {
                            while (res.valor == "true")
                            {

                                hacerEjecucion(sentencias);
                                res = condicion.Ejecutar();
                                if (res.valor == "true" || res.valor == "false")
                                {
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("ERROR");
                                    break;
                                }
                                //Manejo de break
                                if(manejadorArbol.controlBreak == true)
                                {                                    
                                    manejadorArbol.controlBreak = false;
                                    break;
                                }
                                if (manejadorArbol.controlContinue == true)
                                {
                                    manejadorArbol.controlContinue = false;
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("ERROR");
                        }

                        return new resultado();


                    case "repeat":
                        if(node.ChildNodes.Count == 5)
                        {
                            ParseTreeNode sen = node.ChildNodes.ElementAt(1);
                            expresion cond = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(3));
                            

                            res = cond.Ejecutar();
                            if (res.valor == "true" || res.valor == "false")
                            {
                                do
                                {
                                    hacerEjecucion(sen);
                                    res = cond.Ejecutar();
                                    if (res.valor == "true" || res.valor == "false")
                                    {
                                    }
                                    else
                                    {
                                        System.Diagnostics.Debug.WriteLine("ERROR");
                                        break;
                                    }
                                    //Manejo de break
                                    if (manejadorArbol.controlBreak == true)
                                    {
                                        manejadorArbol.controlBreak = false;
                                        break;
                                    }
                                    if (manejadorArbol.controlContinue == true)
                                    {
                                        manejadorArbol.controlContinue = false;
                                        continue;
                                    }
                                } while (res.valor == "false");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("ERROR");
                            }
                        }
                        else
                        {
                            ParseTreeNode sen = node.ChildNodes.ElementAt(2);
                            expresion cond = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(5));
                            

                            res = cond.Ejecutar();
                            if (res.valor == "true" || res.valor == "false")
                            {
                                do
                                {
                                    hacerEjecucion(sen);
                                    res = cond.Ejecutar();
                                    if (res.valor == "true" || res.valor == "false")
                                    {
                                    }
                                    else
                                    {
                                        System.Diagnostics.Debug.WriteLine("ERROR");
                                        break;
                                    }
                                    //Manejo de break
                                    if (manejadorArbol.controlBreak == true)
                                    {
                                        manejadorArbol.controlBreak = false;
                                        break;
                                    }
                                    if (manejadorArbol.controlContinue == true)
                                    {
                                        manejadorArbol.controlContinue = false;
                                        continue;
                                    }
                                } while (res.valor == "false");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("ERROR");
                            }
                        }                     
                        return new resultado();
                    case "break":
                        manejadorArbol.controlBreak = true;
                        return new resultado();

                    case "Exit":
                        manejadorArbol.controlExit = true;

                        simbolo fn1 = manejadorArbol.tabladeSimbolos.buscarFuncion(manejadorArbol.ambitoActual);
                        if (fn1 != null)
                        {
                            expresion exprs = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(2));
                            resultado rt = exprs.Ejecutar();
                            fn1.valor = rt.valor;
                            
                        }
                        return new resultado();
                    case "for":
                        #region Asignar variable
                        tablaSimbolos.simbolo variable1 = manejadorArbol.tabladeSimbolos.buscarSimbolo(node.ChildNodes.ElementAt(1).Token.Text);
                        if (variable1 != null)
                        {
                            expresion exp = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(3));
                            res = exp.Ejecutar();

                            determinarTipo(res, variable1);

                            if (variable1.tipo == res.tipo)
                            {
                                variable1.valor = res.getValor();
                            }
                            else
                            {
                                if (variable1.tipo == "string" && res.tipo == "char" || variable1.tipo == "real" && res.tipo == "integer")
                                {
                                    variable1.valor = res.getValor();
                                }
                            }
                        }
                        else
                        {
                            //ERROR
                        }
                        #endregion

                        #region Preparar for
                        expresion iterador = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(5));
                        resultado it = iterador.Ejecutar();
                        ParseTreeNode senten = node.ChildNodes.ElementAt(8);


                        if (double.TryParse(variable1.valor, out double s) && double.TryParse(it.valor, out double se))
                        {
                            double temp1 = double.Parse(variable1.valor);
                            double temp2 = double.Parse(it.valor);
                            if (temp1 < temp2)
                            {
                                for (variable1.valor = temp1.ToString();  temp1 <= temp2; temp1++)
                                {

                                    variable1.valor = temp1.ToString();
                                    hacerEjecucion(senten);
                                    if (manejadorArbol.controlBreak == true)
                                    {
                                        manejadorArbol.controlBreak = false;
                                        break;
                                    }
                                    if (manejadorArbol.controlContinue == true)
                                    {
                                        manejadorArbol.controlContinue = false;
                                        continue;
                                    }
                                    
                                } 
                            }
                            else if (temp1 > temp2)
                            {
                                for (; temp1 >= temp2; temp1--)
                                {
                                    variable1.valor = temp1.ToString();
                                    hacerEjecucion(senten);
                                    if (manejadorArbol.controlBreak == true)
                                    {
                                        manejadorArbol.controlBreak = false;
                                        break;
                                    }
                                    if (manejadorArbol.controlContinue == true)
                                    {
                                        manejadorArbol.controlContinue = false;
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                hacerEjecucion(senten);
                                variable1.valor = temp1.ToString();
                            }
                        }
                        else
                        {
                            //ERROR
                        }
                        

                        
                        #endregion
                        return new resultado();

                    case "continue":
                        manejadorArbol.controlContinue = true;
                        return new resultado();

                    case "writeln":
                        ParseTreeNode aux = node.ChildNodes.ElementAt(2);
                        funcionBasica.writeln escribir = new funcionBasica.writeln(noterminales.PARAMETROSWRITELN, aux);
                        escribir.Ejecutar();

                        return new resultado();

                    case "write": //MODIFICAR
                        ParseTreeNode aux1 = node.ChildNodes.ElementAt(2);
                        funcionBasica.write escribir1 = new funcionBasica.write(noterminales.PARAMETROSWRITELN, aux1);
                        escribir1.Ejecutar();

                        return new resultado();


                    default:
                        if (palabraClave.Term.ToString() == "id")
                        {
                            if (node.ChildNodes.ElementAt(1).Token.Text == ":=")//Asignacion
                            {
                                tablaSimbolos.simbolo variable = manejadorArbol.tabladeSimbolos.buscarSimbolo(palabraClave.Token.Text);
                                if (variable != null)
                                {
                                    expresion exp = new expresion(noterminales.EXPRESION, node.ChildNodes.ElementAt(2));
                                    res = exp.Ejecutar();

                                    determinarTipo(res, variable);

                                    if (variable.tipo == res.tipo)
                                    {
                                        //TIPOS CONCUERDAN
                                        variable.valor = res.getValor();
                                        //manejadorArbol.imprimirTabla();
                                    }
                                    else
                                    {
                                        if (variable.tipo == "string" && res.tipo == "char" || variable.tipo == "real" && res.tipo == "integer")
                                        {
                                            variable.valor = res.getValor();
                                           // manejadorArbol.imprimirTabla();
                                        }
                                    }

                                }
                                else
                                {
                                    //ERROR
                                }
                            }else //LLAMADAFUNCION
                            {
                                string id = node.ChildNodes.ElementAt(0).Token.Text;
                                string ambitoanterior = manejadorArbol.ambitoActual.Clone().ToString();
                                manejadorArbol.ambitoActual = id;
                                simbolo fn = manejadorArbol.tabladeSimbolos.buscarFuncion(id);
                                if(fn != null)
                                {
                                    Funcion_Procedimiento.objetoFuncion of = fn.fn;
                                    hacerEjecucion(of.lstSent);
                                }
                                
                                manejadorArbol.ambitoActual = "global";
                            }

                        }
                        return new resultado();
                }
            }
            else
            {
                return new resultado();
            }

        }

        void hacerEjecucion(ParseTreeNode lstSent)
        {
            if (lstSent.ChildNodes.Count != 0)
            {
                LinkedList<sentencia> listaSentencias = new LinkedList<sentencia>();
                sentencias sentencias = new sentencias(noterminales.SENTENCIAS, lstSent);
                sentencias.nuevaEjecucion(listaSentencias);
                
                foreach (var sentencia in listaSentencias)
                {
                    sentencia.Ejecutar();
                }

            }
        }

        void determinarTipo(resultado res, simbolo variable)
        {
            if (res.tipo == "numero")
            {
                if (int.TryParse(res.valor, out int i) == true)
                {
                    res.tipo = "integer";
                }
                else
                {
                    res.tipo = "real";
                }
            }
        }

        


    }
}
