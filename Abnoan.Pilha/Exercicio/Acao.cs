using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abnoan.Pilha.Exercicio
{
    public class Acao
    {
        public string Descricao { get; set; }

        public Acao(string descricao)
        {
            Descricao = descricao;
        }

        public void Executar()
        {
            Console.WriteLine($"Executando: {Descricao}");
        }

        public void Desfazer()
        {
            Console.WriteLine($"Desfazendo: {Descricao}");
        }
    }
}