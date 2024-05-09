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

        // Limpa todos os elementos da pilha
        pilhaDeNumeros.Clear();


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
        Stack<string> historico = new();
        Dictionary<string, List<string>> biblioteca = [];

        biblioteca.Add("Ficção", new List<string>() { "Duna", "Harry Potter 1", "Narnia" });
        biblioteca.Add("Ação", new List<string>() { "MIB", "Duro de Matar", "O poderoso chefao" });
        biblioteca.Add("Historia", new List<string>() { "A Mumia", "Crespulo", "Alexandre, o grande" });
        biblioteca.Add("Terror", new List<string>() { "Colheita Maldita" });

        AdicionarLivroLido(ref historico, ref biblioteca, "Terror", "Sexta Feira 13");
        AdicionarLivroLido(ref historico, ref biblioteca, "Terror", "Panico");
        AdicionarLivroLido(ref historico, ref biblioteca, "Ficção", "Interstellar");
        AdicionarLivroLido(ref historico, ref biblioteca, "Ação", "Velozes e Furiosos");
        AdicionarLivroLido(ref historico, ref biblioteca, "Historia", "Cleopatra");

        var livroPraLer = RecomendarProximoLivro(historico, biblioteca);
        Console.WriteLine(livroPraLer);
        Console.WriteLine();

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
        Console.WriteLine("Desfazendo na sessão 1...");
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
        Console.WriteLine("Sessões abertas no editor:");
        editor.ListarSessoesAbertas();

        // Fechar uma sessão e listar as restantes
        Console.WriteLine("Fechando a sessão 1...");
        editor.FecharSessao("1");
        Console.WriteLine("Sessões abertas após fechar a sessão 1:");
        editor.ListarSessoesAbertas();

        #endregion
    }

    static void AdicionarLivroLido(ref Stack<string> historico,
    ref Dictionary<string, List<string>> livros, string genero, string livro)
    {
        historico.Push(livro);

        if (!livros.ContainsKey(genero))
        {
            livros[genero] = new List<string>();
        }

        livros[genero].Add(livro);
    }

    static string RecomendarProximoLivro(Stack<string> historico,
    Dictionary<string, List<string>> livros)
    {
        //var contador = 0;
        Dictionary<string, int> contador = new();
        foreach (var livroLido in historico)
        {
            string genero = livros.FirstOrDefault(s => s.Value.Contains(livroLido)).Key;
            if (contador.ContainsKey(genero))
            {
                contador[genero]++;
            }
            else
            {
                contador[genero] = 1;
            }
        }
        var generoMaisFrequente = contador.OrderByDescending(cont => cont.Value).First().Key;

        var livrosNLidos = livros[generoMaisFrequente].Except(historico).ToList();
        return livrosNLidos.First();
    }
}