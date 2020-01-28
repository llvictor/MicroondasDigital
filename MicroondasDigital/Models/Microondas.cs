using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroondasDigital.Models
{
    public class Microondas
    {
        public IList<Programa> programas { get; set; }

        // Singleton

        private static Microondas instance;

        public static Microondas Instance()
        {
            if (instance == null)
            {
                instance = new Microondas();
            }
 
            return instance;
        }

        private Microondas()
        {
            programas = new List<Programa>();
            programas.Add(new Programa("Frango", "Assar o frango", 120, 5, '!'));
            programas.Add(new Programa("Cuzcuz", "Cozinhar cuzcuz", 90, 10, '@'));
            programas.Add(new Programa("Peixe", "Cozinhar peixe", 35, 4, '#'));
            programas.Add(new Programa("Macarrão", "Esquentar macarrão", 60, 8, '$'));
            programas.Add(new Programa("Feijão", "Descongelar feijão", 115, 7, '%'));
        }

        public void Adicionar(Programa programa)
        {
            programas.Add(programa);
        }

        public bool Executar(string programa, string alimento)
        {
            if(!programa.ToLower().Equals("default"))
                return programa.ToLower().Contains(alimento.ToLower());

            //Programa não definido ou aquecimento rápido
            return true;    
        }

    }
}