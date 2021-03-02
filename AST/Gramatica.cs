using System;
using System.Collections.Generic;
using System.Text;
using Irony.Parsing;
using Irony.Ast;

namespace OC2_P1_201800523.AST
{
    class Gramatica : Grammar
    {
        public Gramatica() : base(caseSensitive: false)
        {

            /*
             NOTAS:
                Pendiente entender Object
             
             
             */

            
            #region Declaracion de Terminales
            IdentifierTerminal id = new IdentifierTerminal("id");
            NumberLiteral numero = new NumberLiteral("numero");
            //var id = ToTerm("id");
            var program = ToTerm("program");
            var punto_coma = ToTerm(";");
            var punto = ToTerm(".");
            var uses = ToTerm("uses");
            var coma = ToTerm(",");
            var var = ToTerm("var");
            var rconst = ToTerm("const");

            var function = ToTerm("function");
            var abrir_parentesis = ToTerm("(");
            var cerrar_parentesis = ToTerm(")");
            var dos_puntos_igual = ToTerm(":=");
            var dos_puntos = ToTerm(":");
            var igual = ToTerm("=");


            /***************/

            var rstring = ToTerm("string");
            var rinteger = ToTerm("integer");
            var rreal = ToTerm("real");
            var rchar = ToTerm("char");
            var rboolean = ToTerm("boolean");
            var rvoid = ToTerm("void");
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
            NonTerminal VARIABLE = new NonTerminal("VARIABLE");
            NonTerminal ASIGNAR_VALOR = new NonTerminal("ASIGNAR_VALOR");
            NonTerminal CONSTANTE = new NonTerminal("CONSTANTE");
            NonTerminal OTRA_CONSTANTE = new NonTerminal("OTRA_CONSTANTE");
            NonTerminal TIPO = new NonTerminal("TIPO");
            NonTerminal TRETORNO = new NonTerminal("TRETORNO");
            NonTerminal OTRA_DECL_VARIABLE = new NonTerminal("OTRA_DECL_VARIABLE");
            NonTerminal FUNCION_O_PROCEDIMIENTO = new NonTerminal("FUNCION_O_PROCEDIMIENTO");
            NonTerminal FUNCION = new NonTerminal("FUNCION");
            NonTerminal OTRA_FUNCION = new NonTerminal("OTRA_FUNCION");

            NonTerminal SENTENCIAS = new NonTerminal("SENTENCIAS");
            NonTerminal SENTENCIA = new NonTerminal("SENTENCIA");

            NonTerminal EXPRESION = new NonTerminal("EXPRESION");

            #endregion

            #region DEFINICION OWO
            INI.Rule = COSAS;
            COSAS.Rule = program + id + punto_coma + USES + INSTRUCCIONES + CUERPO_PROGRAMA;

            USES.Rule = uses + id + punto_coma
                | uses + id + coma + OTRO_USES
                ;

            OTRO_USES.Rule = id + coma + OTRO_USES
                | id + punto_coma
                ;

            INSTRUCCIONES.Rule = INSTRUCCIONES + INSTRUCCION
                | INSTRUCCION
                
                ;

            INSTRUCCION.Rule = FUNCION_O_PROCEDIMIENTO
                | var + VARIABLE
                | rconst + CONSTANTE
                ;

            VARIABLE.Rule = id + dos_puntos + TIPO + punto_coma + OTRA_DECL_VARIABLE
                | id + coma + VARIABLE
                ;

            OTRA_DECL_VARIABLE.Rule = VARIABLE
                | Empty
                ;

            CONSTANTE.Rule = id + igual + EXPRESION + punto_coma + OTRA_CONSTANTE
                | id + dos_puntos + TIPO + igual + EXPRESION + punto_coma + OTRA_CONSTANTE
                ;
            OTRA_CONSTANTE.Rule = CONSTANTE
                | Empty
                ;

            FUNCION_O_PROCEDIMIENTO.Rule = FUNCION
                ;

            FUNCION.Rule = function + id + abrir_parentesis + cerrar_parentesis + dos_puntos + TIPO + punto_coma + OTRA_FUNCION + begin +SENTENCIAS+ end + punto_coma
                ;

            OTRA_FUNCION.Rule = FUNCION
                | Empty
                ;

            SENTENCIAS.Rule = SENTENCIAS + SENTENCIA
                | SENTENCIA
                | Empty
                
                ;

            SENTENCIA.Rule = ASIGNAR_VALOR
                ;

            ASIGNAR_VALOR.Rule = id +dos_puntos_igual + EXPRESION + punto_coma
                ;

            EXPRESION.Rule = numero
                ;

            TIPO.Rule = rstring
                | rinteger
                | rreal
                | rchar
                | rboolean
                | id
                ;

            TRETORNO.Rule = rstring
                | rinteger
                | rreal
                | rchar
                | rboolean
                | rvoid
                | id
                ;

            CUERPO_PROGRAMA.Rule = begin + end + punto
                ;
            #endregion

            this.Root = INI;


        }
    }
}
