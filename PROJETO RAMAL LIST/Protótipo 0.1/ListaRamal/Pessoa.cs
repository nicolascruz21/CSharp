using System.Security.Cryptography.X509Certificates;

class Pessoa
{
    //Instanciando a classe Menu
    Menu meuMenu = new Menu();
    public string Nome { get; set; }
    public string Departamento { get; set; }
    public string Ramal { get; set; }
    private int Id { get; set; }

    public void MenuAdicionarRamal()
    {
        Console.Clear();
        //Invocando Metodo da classe Utilitarios(ExibirLogo)
        Utilitarios.ExibirLogo();

        Console.Write("\nDigite um ramal para registrar:");
        string ramalDigitado = Console.ReadLine()!;

        Console.Write("\nDigite o nome da pessoa:");
        string nomeDigitado = Console.ReadLine()!;

        Console.WriteLine("\nDigite o departamento da pessoa:");
        string departamentoDigitado = Console.ReadLine()!;

        Console.WriteLine($"\nVocê Deseja Registrar o Ramal {ramalDigitado} para o(a) {nomeDigitado}?");
        Console.WriteLine("\nDigite 0 para sim, Digite 1 para não, Digite 2 Para voltar Ao Menu Principal:");
        string resposta = Console.ReadLine()!;
        int respostaNumerica = int.Parse(resposta);

        switch (respostaNumerica)
        {
            case 0:
                AdicionarPessoa();
                Console.WriteLine("Voce Registrou uma pessoa!");
                Console.WriteLine("Pressione qualquer tecla para voltar para o menu principal!");
                Console.ReadKey();
                Console.Clear();
                meuMenu.ExibirOpcoesDoMenu();
                break;
            case 1:
                Console.Clear();
                Console.WriteLine("Aguarde...");
                Thread.Sleep(2000);
                MenuAdicionarRamal();
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Aguarde...");
                Thread.Sleep(2000);

                meuMenu.ExibirOpcoesDoMenu();
                break;
            default:
                Console.WriteLine("Opção Inválida");
                Thread.Sleep(2000);
                MenuAdicionarRamal();
                break;
        }
        void AdicionarPessoa()
        {
            StreamWriter texto = File.AppendText("arquivo.txt");
            texto.WriteLine(nomeDigitado + ", " + ramalDigitado + ", " + departamentoDigitado);
            texto.Close();
        }



    }
    public void RemoverRamal()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();
        Console.WriteLine("Remover Ramal");

        // Solicitar o nome da pessoa a ser removida
        Console.Write("Digite o nome da pessoa que deseja remover o ramal: ");
        string nomeBusca = Console.ReadLine();

        // Ler o conteúdo do arquivo
        string[] linhas = File.ReadAllLines("arquivo.txt");

        bool pessoaEncontrada = false;
        List<string> novasLinhas = new List<string>();

        // Percorrer as linhas e buscar a pessoa pelo nome
        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');
            string nome = campos[0].Trim();

            if (!nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase))
            {
                // Adicionar a linha à lista de novas linhas
                novasLinhas.Add(linha);
            }
            else
            {
                pessoaEncontrada = true;
            }
        }

        if (pessoaEncontrada)
        {
            // Exibir mensagem de confirmação
            Console.WriteLine("Tem certeza que deseja remover a pessoa " + nomeBusca + "? (S/N)");
            string confirmacao = Console.ReadLine();

            if (confirmacao.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                // Sobrescrever o conteúdo do arquivo com as novas linhas
                File.WriteAllLines("arquivo.txt", novasLinhas);
                Console.WriteLine("Ramal removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Operação de remoção cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Pessoa não encontrada.");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal!");
        Console.ReadKey();
        Console.Clear();
        meuMenu.ExibirOpcoesDoMenu();
    }

    public void ExibirTodasPessoas()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();
        Console.WriteLine("Registros de Ramal:");

        // Ler o conteúdo do arquivo
        string[] linhas = File.ReadAllLines("arquivo.txt");

        // Ordenar as linhas em ordem alfabética pelo nome
        Array.Sort(linhas);

        // Exibir cada linha (registro) formatado
        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');
            string nome = campos[0].Trim();
            string ramal = campos[1].Trim();
            string departamento = campos[2].Trim();

            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Ramal: " + ramal);
            Console.WriteLine("Departamento: " + departamento);
            Console.WriteLine("*****************************************");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu Principal!");
        Console.ReadKey();
        Console.Clear();
        meuMenu.ExibirOpcoesDoMenu();
    }

    public void EditarRamal()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();
        Console.WriteLine("Editar Ramal");

        // Solicitar o nome da pessoa a ser editada
        Console.Write("Digite o nome da pessoa que deseja editar o ramal: ");
        string nomeBusca = Console.ReadLine();

        // Ler o conteúdo do arquivo
        string[] linhas = File.ReadAllLines("arquivo.txt");

        bool pessoaEncontrada = false;

        // Percorrer as linhas e buscar a pessoa pelo nome
        for (int i = 0; i < linhas.Length; i++)
        {
            string linha = linhas[i];
            string[] campos = linha.Split(',');
            string nome = campos[0].Trim();

            if (nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase))
            {
                // Pessoa encontrada, solicitar o novo ramal
                Console.Write("Digite o novo ramal: ");
                string novoRamal = Console.ReadLine();

                // Atualizar o ramal no array de campos
                campos[1] = novoRamal;

                // Atualizar a linha no array de linhas
                linhas[i] = string.Join(", ", campos);

                pessoaEncontrada = true;
                break;
            }
        }

        if (pessoaEncontrada)
        {
            // Sobrescrever o conteúdo do arquivo com as linhas atualizadas
            File.WriteAllLines("arquivo.txt", linhas);

            Console.WriteLine("Ramal atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Pessoa não encontrada.");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal!");
        Console.ReadKey();
        Console.Clear();
        meuMenu.ExibirOpcoesDoMenu();
    }

    public void PesquisarRamal()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();
        Console.WriteLine("Pesquisar Ramal");

        // Solicitar o critério de pesquisa (nome ou departamento)
        Console.WriteLine("Digite o critério de pesquisa:");
        Console.WriteLine("1 - Nome");
        Console.WriteLine("2 - Departamento");
        Console.Write("Opção: ");
        int opcao = int.Parse(Console.ReadLine());

        // Definir as variáveis de pesquisa
        string criterio = "";
        bool pesquisarPorDepartamento = false;

        if (opcao == 1)
        {
            Console.Write("\nDigite o nome ou o primeiro nome da pessoa: ");
            criterio = Console.ReadLine();
        }
        else if (opcao == 2)
        {
            Console.Write("\nDigite o departamento: ");
            criterio = Console.ReadLine();
            pesquisarPorDepartamento = true;
        }
        else
        {
            Console.WriteLine("\nOpção inválida!");
            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal!");
            Console.ReadKey();
            Console.Clear();
            meuMenu.ExibirOpcoesDoMenu();
            return;
        }

        // Ler o conteúdo do arquivo
        string[] linhas = File.ReadAllLines("arquivo.txt");

        bool resultadoEncontrado = false;

        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');
            string nome = campos[0].Trim();
            string ramal = campos[1].Trim();
            string departamento = campos[2].Trim();

            if (pesquisarPorDepartamento)
            {
                if (departamento.Equals(criterio, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nome: " + nome);
                    Console.WriteLine("Ramal: " + ramal);
                    Console.WriteLine("Departamento: " + departamento);
                    Console.WriteLine("*****************************************");
                    resultadoEncontrado = true;
                }
            }
            else
            {
                if (nome.StartsWith(criterio, StringComparison.OrdinalIgnoreCase) ||
                    nome.StartsWith(criterio.ToLower(), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nome: " + nome);
                    Console.WriteLine("Ramal: " + ramal);
                    Console.WriteLine("Departamento: " + departamento);
                    Console.WriteLine("*****************************************");
                    resultadoEncontrado = true;
                }
            }
        }

        if (!resultadoEncontrado)
        {
            Console.WriteLine("Nenhum resultado encontrado.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu Principal!");
        Console.ReadKey();
        Console.Clear();
        meuMenu.ExibirOpcoesDoMenu();
    }





}


