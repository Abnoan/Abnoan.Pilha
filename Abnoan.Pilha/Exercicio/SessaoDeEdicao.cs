using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abnoan.Pilha.Exercicio
{
    public class SessaoDeEdicao
    {
        public Stack<Acao> acoesFeitas = new Stack<Acao>();
        public Stack<Acao> acoesDesfeitas = new Stack<Acao>();
        public string Id { get; set; }
        public string NomeDocumento { get; set; }

        public SessaoDeEdicao(string id, string nomeDocumento)
        {
            Id = id;
            NomeDocumento = nomeDocumento;
        }

        public void ExecutarAcao(Acao acao)
        {
            acao.Executar();
            acoesFeitas.Push(acao);
            acoesDesfeitas.Clear();
        }

        public void Desfazer()
        {
            if (acoesFeitas.Count > 0)
            {
                Acao acao = acoesFeitas.Pop();
                acao.Desfazer();
                acoesDesfeitas.Push(acao);
            }
            else
            {
                Console.WriteLine("Nada para desfazer.");
            }
        }

        public void Refazer()
        {
            if (acoesDesfeitas.Count > 0)
            {
                Acao acao = acoesDesfeitas.Pop();
                acao.Executar();
                acoesFeitas.Push(acao);
            }
            else
            {
                Console.WriteLine("Nada para refazer.");
            }
        }
    }
}