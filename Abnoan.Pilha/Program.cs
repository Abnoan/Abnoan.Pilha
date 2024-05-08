using Abnoan.Pilha.Exercicio;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Criação e Inicialização

        Stack<int> pilhaDeNumeros = new Stack<int>();
        Stack<string> pilhaDeMensagens = new Stack<string>();

        pilhaDeMensagens = new Stack<string>(new List<string>() { "Olá", "Mundo", "C#" });
        pilhaDeNumeros = new Stack<int>(new List<int>() { 1, 2, 5, 6, 78, 96, 128, 256 });

        #endregion

        #region Operações

        // Adiciona o número 1028 ao topo da pilha
        pilhaDeNumeros.Push(1028);

        // Remove e retorna o elemento no topo
        var topo = pilhaDeNumeros.Pop();

        // Retorna o elemento no topo sem removê-lo
        var elementoTopo = pilhaDeNumeros.Peek();

        if (pilhaDeNumeros.Count > 0)
        {
            topo = pilhaDeNumeros.Pop();
            Console.WriteLine("Elemento no topo removido: " + topo);
        }
        else
            Console.WriteLine("A pilha está vazia!");



        int quantidadeElementos = pilhaDeMensagens.Count;

        if (pilhaDeNumeros.Count < 50)
            pilhaDeNumeros.Push(2056);
        else
            Console.WriteLine("Capacidade máxima alcançada. Não é possível adicionar mais elementos.");


        foreach (var item in pilhaDeNumeros)
        {
            Console.WriteLine(item);
        }

        #endregion

        #region Vamos Praticar?
        //Criar uma simulação de sistema de navegação de páginas, 
        //onde as ações de avançar e voltar são controladas por pilhas.
        Stack<string> historicoNavegacao = new Stack<string>();
        historicoNavegacao.Push("HomePage");
        historicoNavegacao.Push("AboutPage");
        Console.WriteLine("Voltando para: " + historicoNavegacao.Pop());


        //Sistema de Recomendação de Livros
        Stack<string> pilhaLivrosLidos = new Stack<string>();
        Dictionary<string, List<string>> livrosPorGenero = new Dictionary<string, List<string>>();

        pilhaLivrosLidos.Push("Ficção Científica: Duna");
        pilhaLivrosLidos.Push("Fantasia: Senhor dos Anéis");

        var generoComum = "Ficção Científica";
        var proximoLivro = livrosPorGenero[generoComum].FirstOrDefault();
        Console.WriteLine($"Próximo livro recomendado do gênero {generoComum}: {proximoLivro}");

        //Gerenciador de Eventos
        Stack<Evento> pilhaEventos = new Stack<Evento>();
        Dictionary<string, Queue<Evento>> eventosPorTipo = new Dictionary<string, Queue<Evento>>();

        // Adicionando eventos
        var evento1 = new Evento { Tipo = "Conferência", Descricao = "Conferência de Tecnologia" };
        pilhaEventos.Push(evento1);
        if (!eventosPorTipo.ContainsKey(evento1.Tipo))
            eventosPorTipo[evento1.Tipo] = new Queue<Evento>();
        eventosPorTipo[evento1.Tipo].Enqueue(evento1);

        // Processando eventos
        while (pilhaEventos.Count > 0)
        {
            var evento = pilhaEventos.Pop();
            var fila = eventosPorTipo[evento.Tipo];
            var eventoParaProcessar = fila.Dequeue();
            Console.WriteLine($"Processando evento: {eventoParaProcessar.Descricao}");
        }
        #endregion

        #region Exercicio
        
        // Cria uma instância do editor
        Editor editor = new Editor();

        // Cria e abre sessões de edição para diferentes documentos
        SessaoDeEdicao sessao1 = new SessaoDeEdicao("1", "Documento1.txt");
        SessaoDeEdicao sessao2 = new SessaoDeEdicao("2", "Documento2.txt");
        editor.AbrirSessao(sessao1);
        editor.AbrirSessao(sessao2);

        // Adiciona múltiplas ações à primeira sessão
        sessao1.ExecutarAcao(new Acao("Escrever 'Olá mundo!'"));
        sessao1.ExecutarAcao(new Acao("Adicionar nova linha"));
        sessao1.ExecutarAcao(new Acao("Inserir assinatura"));

        // Adiciona ações à segunda sessão
        sessao2.ExecutarAcao(new Acao("Escrever 'Bem-vindo ao C#.'"));
        sessao2.ExecutarAcao(new Acao("Escrever 'Aprendendo pilhas'"));

        // Desfazer a última ação em ambas as sessões
        Console.WriteLine("\nDesfazendo na sessão 1...");
        sessao1.Desfazer();
        Console.WriteLine("Desfazendo na sessão 2...");
        sessao2.Desfazer();

        // Refazer a ação na primeira sessão
        Console.WriteLine("Refazendo na sessão 1...");
        sessao1.Refazer();

        // Desfazer duas ações seguidas na primeira sessão
        Console.WriteLine("Desfazendo duas ações na sessão 1...");
        sessao1.Desfazer();
        sessao1.Desfazer();

        // Tentativa de refazer mais vezes do que desfeito
        try
        {
            Console.WriteLine("Tentando refazer mais vezes do que o possível na sessão 1...");
            sessao1.Refazer();
            sessao1.Refazer();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }

        // Listar as sessões abertas
        Console.WriteLine("\nSessões abertas no editor:");
        editor.ListarSessoesAbertas();

        // Fechar uma sessão e listar as restantes
        Console.WriteLine("\nFechando a sessão 1...");
        editor.FecharSessao("1");
        Console.WriteLine("Sessões abertas após fechar a sessão 1:");
        editor.ListarSessoesAbertas();

        #endregion
    }
}