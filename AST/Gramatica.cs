﻿using System;
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
            IdentifierTerminal id = new IdentifierTerminal(terminales.id);
            NumberLiteral numero = new NumberLiteral(terminales.numero,NumberOptions.AllowSign);
            var program = ToTerm(terminales.program);
            var var = ToTerm(terminales.var);
            var rconst = ToTerm(terminales.rconst);
            var function = ToTerm(terminales.function);
            var begin = ToTerm(terminales.begin);
            var end = ToTerm(terminales.end);
            var not = ToTerm(terminales.not);
            var div = ToTerm(terminales.div);
            var mod = ToTerm(terminales.mod);
            var and = ToTerm(terminales.and);
            var or = ToTerm(terminales.or);
            var rin = ToTerm(terminales.rin);
            var rtrue = ToTerm(terminales.rtrue);
            var rfalse = ToTerm(terminales.rfalse);
            var cadena = new StringLiteral(terminales.cadena, "\'");
            var comentarioUL = new CommentTerminal(terminales.comentarioUL, "//", new[] { "\n" });
            var comentarioMLTipo1 = new CommentTerminal(terminales.comentarioMLTipo1, "(*", new[] { "*)" });
            var comentarioMLTipo2 = new CommentTerminal(terminales.comentarioMLTipo2, "{", new[] { "}" });
            
            /*TIPOS*/
            var rstring = ToTerm(terminales.rstring);
            var rinteger = ToTerm(terminales.rinteger);
            var rreal = ToTerm(terminales.rreal);
            var rchar = ToTerm(terminales.rchar);
            var rboolean = ToTerm(terminales.rboolean);
            var rvoid = ToTerm(terminales.rvoid);

            /*SIMBOLOS*/
            var punto_coma = ToTerm(terminales.punto_coma);
            var punto = ToTerm(terminales.punto);
            var uses = ToTerm(terminales.uses);
            var coma = ToTerm(terminales.coma);
            var abrir_parentesis = ToTerm(terminales.abrir_parentesis);
            var cerrar_parentesis = ToTerm(terminales.cerrar_parentesis);
            var dos_puntos_igual = ToTerm(terminales.dos_puntos_igual);
            var dos_puntos = ToTerm(terminales.dos_puntos);
            var igual = ToTerm(terminales.igual);

            var menos = ToTerm(terminales.menos);
            var uminus = ToTerm(terminales.uminus);
            var mas = ToTerm(terminales.mas);
            var por = ToTerm(terminales.por);
            var barra_div = ToTerm(terminales.barra_div);
            var distinto = ToTerm(terminales.distinto);
            var menor = ToTerm(terminales.menor);
            var menor_igual = ToTerm(terminales.menor_igual);
            var mayor = ToTerm(terminales.mayor);
            var mayor_igual = ToTerm(terminales.mayor_igual);


            #region Otros
            NonGrammarTerminals.Add(comentarioUL);
            NonGrammarTerminals.Add(comentarioMLTipo1);
            NonGrammarTerminals.Add(comentarioMLTipo2);
            #endregion


            #endregion

            #region No terminales
            NonTerminal INI = new NonTerminal(noterminales.INI);
            NonTerminal COSAS = new NonTerminal(noterminales.COSAS);
            NonTerminal USES = new NonTerminal(noterminales.USES);
            NonTerminal OTRO_USES = new NonTerminal(noterminales.OTRO_USES);

            NonTerminal CUERPO_PROGRAMA = new NonTerminal(noterminales.CUERPO_PROGRAMA);

            NonTerminal INSTRUCCIONES = new NonTerminal(noterminales.INSTRUCCIONES);
            NonTerminal INSTRUCCION = new NonTerminal(noterminales.INSTRUCCION);

            NonTerminal VARIABLE = new NonTerminal(noterminales.VARIABLE);
            NonTerminal OTRA_DECL_VARIABLE = new NonTerminal(noterminales.OTRA_DECL_VARIABLE);
            NonTerminal ASIGNAR_VALOR = new NonTerminal(noterminales.ASIGNAR_VALOR);

            NonTerminal CONSTANTE = new NonTerminal(noterminales.CONSTANTE);
            NonTerminal OTRA_CONSTANTE = new NonTerminal(noterminales.OTRA_CONSTANTE);

            NonTerminal TIPO = new NonTerminal(noterminales.TIPO);
            NonTerminal TRETORNO = new NonTerminal(noterminales.TRETORNO);

            NonTerminal FUNCION_O_PROCEDIMIENTO = new NonTerminal(noterminales.FUNCION_O_PROCEDIMIENTO);
            NonTerminal FUNCION = new NonTerminal(noterminales.FUNCION);
            NonTerminal OTRA_FUNCION = new NonTerminal(noterminales.OTRA_FUNCION);

            NonTerminal SENTENCIAS = new NonTerminal(noterminales.SENTENCIAS);
            NonTerminal SENTENCIA = new NonTerminal(noterminales.SENTENCIA);
            NonTerminal EXPRESION = new NonTerminal(noterminales.EXPRESION);

            // NonTerminal PARAMETROS = new NonTerminal(noterminales.PARAMETROS);

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

            FUNCION.Rule = function + id + abrir_parentesis + cerrar_parentesis + dos_puntos + TIPO + punto_coma + OTRA_FUNCION + begin + SENTENCIAS + end + punto_coma
                //| function + id + abrir_parentesis +PARAMETROS+ cerrar_parentesis + dos_puntos + TIPO + punto_coma + OTRA_FUNCION + begin + SENTENCIAS + end + punto_coma
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

            ASIGNAR_VALOR.Rule = id + dos_puntos_igual + EXPRESION + punto_coma
                ;

            EXPRESION.Rule = uminus + EXPRESION
                | not + EXPRESION                
                | EXPRESION + por + EXPRESION
                | EXPRESION + div + EXPRESION
                | EXPRESION + barra_div + EXPRESION
                | EXPRESION + mod + EXPRESION
                | EXPRESION + and + EXPRESION
                | EXPRESION + mas + EXPRESION
                | EXPRESION + menos + EXPRESION
                | EXPRESION + or + EXPRESION
                //Maybe falta el igual
                | EXPRESION + distinto + EXPRESION
                | EXPRESION + menor + EXPRESION
                | EXPRESION + menor_igual + EXPRESION
                | EXPRESION + mayor +EXPRESION
                | EXPRESION + mayor_igual + EXPRESION
                | EXPRESION + rin + EXPRESION
                
                | numero
                | cadena
                | id
                | rtrue
                | rfalse
                | abrir_parentesis + EXPRESION + cerrar_parentesis
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

            CUERPO_PROGRAMA.Rule = begin +SENTENCIAS+ end + punto
                ;
            #endregion

            this.Root = INI;

            this.RegisterOperators(5, Associativity.Left, terminales.uminus);
            this.RegisterOperators(4, Associativity.Left, terminales.not);
            this.RegisterOperators(3, Associativity.Left,terminales.por, terminales.barra_div, terminales.div, terminales.mod, terminales.and);
            this.RegisterOperators(2, Associativity.Left,terminales.mas, terminales.menos, terminales.or);
            this.RegisterOperators(1, Associativity.Left,terminales.distinto, terminales.menor, terminales.menor_igual, terminales.mayor, terminales.mayor_igual, terminales.rin);

        }
    }
}
