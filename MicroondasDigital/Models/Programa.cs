using MicroondasDigital.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroondasDigital.Models
{
    public class Programa
    {
        [Required (ErrorMessage = "Informe o alimento")]
        public string nome { get; set; }
        [Required (ErrorMessage = "Informe a instrução do programa")]
        public string instrucao { get; set; }
        [TempoValido]
        public int tempo { get; set; }
        [PotenciaValido]
        public int potencia { get; set; }
        [Required (ErrorMessage = "Informe o caracter")]
        public char caracter { get; set; }


        public Programa()
        {
 
        }

        public Programa(string nome, string instrucao, int tempo, int potencia, char caracter)
        {
            this.nome = nome;
            this.instrucao = instrucao;
            this.tempo = tempo;
            this.potencia = potencia;
            this.caracter = caracter;
        }

    }

}