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
            IdentifierTerminal id = new IdentifierTerminal(terminales.id);
            NumberLiteral numero = new NumberLiteral(terminales.numero);            
            var program = ToTerm(terminales.program);           
            var var = ToTerm(terminales.var);
            var rconst = ToTerm(terminales.rconst);
            var function = ToTerm(terminales.function);
            var begin = ToTerm(terminales.begin);
            var end = ToTerm(terminales.end);

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
            NonTerminal ASIGNAR_VALOR = new NonTerminal(noterminales.ASIGNAR_VALOR);
            NonTerminal CONSTANTE = new NonTerminal(noterminales.CONSTANTE);
            NonTerminal OTRA_CONSTANTE = new NonTerminal(noterminales.OTRA_CONSTANTE);
            NonTerminal TIPO = new NonTerminal(noterminales.TIPO);
            NonTerminal TRETORNO = new NonTerminal(noterminales.TRETORNO);
            NonTerminal OTRA_DECL_VARIABLE = new NonTerminal(noterminales.OTRA_DECL_VARIABLE);
            NonTerminal FUNCION_O_PROCEDIMIENTO = new NonTerminal(noterminales.FUNCION_O_PROCEDIMIENTO);
            NonTerminal FUNCION = new NonTerminal(noterminales.FUNCION);
            NonTerminal OTRA_FUNCION = new NonTerminal(noterminales.OTRA_FUNCION);

            NonTerminal SENTENCIAS = new NonTerminal(noterminales.SENTENCIAS);
            NonTerminal SENTENCIA = new NonTerminal(noterminales.SENTENCIA);

            NonTerminal EXPRESION = new NonTerminal(noterminales.EXPRESION);

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
