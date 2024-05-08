using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abnoan.Pilha.Exercicio
{
    public class Editor
    {
        public List<SessaoDeEdicao> sessoesAbertas = new List<SessaoDeEdicao>();
        public Dictionary<string, SessaoDeEdicao> sessoesPorId = new Dictionary<string, SessaoDeEdicao>();

        public void AbrirSessao(SessaoDeEdicao sessao)
        {
            sessoesAbertas.Add(sessao);
            sessoesPorId[sessao.Id] = sessao;
        }

        public void FecharSessao(string id)
        {
            var sessao = sessoesPorId[id];
            sessoesAbertas.Remove(sessao);
            sessoesPorId.Remove(id);
        }

        public SessaoDeEdicao ObterSessaoPorId(string id)
        {
            return sessoesPorId[id];
        }

        public void ListarSessoesAbertas()
        {
            foreach (var sessao in sessoesAbertas)
            {
                Console.WriteLine($"Documento: {sessao.NomeDocumento}, ID: {sessao.Id}");
            }
        }
    }
}