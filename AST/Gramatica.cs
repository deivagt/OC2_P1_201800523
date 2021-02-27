using System;
using System.Collections.Generic;
using System.Text;
using Irony.Parsing;
using Irony.Ast;

namespace OC2_P1_201800523.AST
{
    class Gramatica : Grammar
    {
        public Gramatica() : base (caseSensitive : false)
        {
            #region Declaracion de Terminales

            IdentifierTerminal id = new IdentifierTerminal("id");
            //var id = ToTerm("id");
            var program = ToTerm("program");
            var punto_coma = ToTerm(";");
            var punto = ToTerm(".");
            var uses = ToTerm("uses");
            var coma = ToTerm(",");

            var function = ToTerm("function");
            var abrir_parentesis = ToTerm("(");
            var cerrar_parentesis = ToTerm(")");

            var dos_puntos = ToTerm(":");

            /***************/
            var tipo = ToTerm("tipo");
            /***************/

            var begin = ToTerm("begin");
            var end = ToTerm("end");

            #endregion

            #region No terminales
            NonTerminal INI = new NonTerminal("INI");
            NonTerminal COSAS = new NonTerminal("COSAS");
            NonTerminal USES = new NonTerminal("USES");
            NonTerminal CUERPO_PROGRAMA = new NonTerminal("CUERPO_PROGRAMA");
            NonTerminal INSTRUCCIONES = new NonTerminal("INSTRUCCIONES");
            NonTerminal OTRO_USES = new NonTerminal("OTRO_USES");
            NonTerminal INSTRUCCION = new NonTerminal("INSTRUCCION");
            NonTerminal FUNCION_O_PROCEDIMIENTO = new NonTerminal("FUNCION_O_PROCEDIMIENTO");
            NonTerminal FUNCION = new NonTerminal("FUNCION");
            NonTerminal OTRA_FUNCION = new NonTerminal("OTRA_FUNCION");

            #endregion

            #region DEFINICION OWO
            INI.Rule = COSAS;
            COSAS.Rule = program + id + punto_coma + USES + INSTRUCCIONES + CUERPO_PROGRAMA ;

            USES.Rule = uses + id + punto_coma
                | uses + id + coma + OTRO_USES
                ;

            OTRO_USES.Rule = id + coma + OTRO_USES
                | id + punto_coma
                ;

            INSTRUCCIONES.Rule = INSTRUCCION + INSTRUCCIONES
                | INSTRUCCION
                ;

            INSTRUCCION.Rule = FUNCION_O_PROCEDIMIENTO;

            FUNCION_O_PROCEDIMIENTO.Rule = FUNCION;

            FUNCION.Rule = function + id + abrir_parentesis + cerrar_parentesis + dos_puntos + tipo + punto_coma + OTRA_FUNCION + begin + end + punto_coma;

            OTRA_FUNCION.Rule = FUNCION
                | Empty
                ;
            CUERPO_PROGRAMA.Rule = begin + end + punto;
            #endregion

            this.Root = INI;


        }
    }
}
