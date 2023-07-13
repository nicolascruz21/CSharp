using System.Security.Cryptography.X509Certificates;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Pessoa
{
    private static int proximoId = 1; // Próximo ID disponível
    //Instanciando a classe Menu
    Menu meuMenu = new Menu();
    public string Nome { get; set; }
    public string Departamento { get; set; }
    public string Ramal { get; set; }
    public int Permissao { get; set; }
    public int GrupoCaptura { get; set; }
    public int Id { get; set; } // Propriedade somente leitura para o ID

    // Construtor da classe Pessoa
    public Pessoa()
    {
        Id = proximoId;
        proximoId++; // Incrementa o próximo ID disponível
    }
    public void MenuAdicionarRamal()
    {
        Console.Clear();
        // Invocando Método da classe Utilitarios (ExibirLogo)
        Utilitarios.ExibirLogo();

        Console.Write("\nDigite um ramal para registrar: ");
        string ramalDigitado = Console.ReadLine();

        // Verificar se o ramal já está em uso
        if (VerificarRamalExistente(ramalDigitado))
        {
            Console.WriteLine("\nRamal em uso. Por favor, escolha outro ramal.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal!");
            Console.ReadKey();
            Console.Clear();
            meuMenu.ExibirOpcoesDoMenu();
            return;
        }

        Console.Write("\nDigite o nome da pessoa: ");
        string nomeDigitado = Console.ReadLine();

        Console.Write("\nDigite o departamento da pessoa: ");
        string departamentoDigitado = Console.ReadLine();

        Console.Write("\nDigite o grupo de captura da pessoa: ");
        string grupoCapturaDigitado = Console.ReadLine();

        int grupoCaptura = 0; // Valor padrão para grupo de captura

        if (!string.IsNullOrWhiteSpace(grupoCapturaDigitado))
        {
            int.TryParse(grupoCapturaDigitado, out grupoCaptura);

            // Verificar se o valor do grupoCaptura está dentro do intervalo permitido (1 a 9)
            if (grupoCaptura < 1 || grupoCaptura > 9)
            {
                Console.WriteLine("Valor inválido para o grupo de captura. O valor deve estar entre 1 e 9.");
                Console.WriteLine("Pressione qualquer tecla para voltar para o menu principal!");
                Console.ReadKey();
                Console.Clear();
                meuMenu.ExibirOpcoesDoMenu();
                return;
            }
        }

        Console.Write("\nDigite a permissão da pessoa: ");
        string permissaoDigitada = Console.ReadLine();

        int permissao = 0; // Valor padrão para permissão

        if (!string.IsNullOrWhiteSpace(permissaoDigitada))
        {
            int.TryParse(permissaoDigitada, out permissao);

            // Verificar se o valor da permissao está dentro do intervalo permitido (1 a 7)
            if (permissao < 1 || permissao > 7)
            {
                Console.WriteLine("Valor inválido para a permissão. O valor deve estar entre 1 e 7.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal!");
                Console.ReadKey();
                Console.Clear();
                meuMenu.ExibirOpcoesDoMenu();
                return;
            }
        }

        Console.WriteLine($"\nDeseja registrar o Ramal {ramalDigitado} para {nomeDigitado}?");
        Console.WriteLine("Digite 0 para sim, 1 para não, 2 para voltar ao Menu Principal: ");
        string resposta = Console.ReadLine();
        int respostaNumerica = int.Parse(resposta);

        switch (respostaNumerica)
        {
            case 0:
                AdicionarPessoa(nomeDigitado, ramalDigitado, departamentoDigitado, grupoCaptura, permissao);
                Console.WriteLine("Você registrou uma pessoa!");
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
    }

    private bool VerificarRamalExistente(string ramal)
    {
        // Ler o conteúdo do arquivo
        string[] linhas = File.ReadAllLines("arquivo.txt");

        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');

            string ramalExistente = campos[2].Trim();

            if (ramalExistente.Equals(ramal, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }


    void AdicionarPessoa(string nome, string ramal, string departamento, int grupoCaptura, int permissao)
    {
        
        StreamWriter texto = File.AppendText("arquivo.txt");
        texto.WriteLine($"{Id}, {nome}, {ramal}, {departamento}, {grupoCaptura}, {permissao}");
        texto.Close();
    }
    public void RemoverRamal()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();
        Console.WriteLine("Remover Ramal");

        Console.WriteLine("Digite o critério de pesquisa:");
        Console.WriteLine("1 - Nome");
        Console.WriteLine("2 - ID");
        Console.WriteLine("3 - Remover Todos os Ramais");
        Console.Write("Opção: ");
        int opcao = int.Parse(Console.ReadLine());
       
        if (opcao == 3)
        {
            Console.WriteLine("Tem certeza que deseja remover todos os ramais? (S/N)");
            string confirmacao = Console.ReadLine();

            if (confirmacao.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                File.WriteAllText("arquivo.txt", string.Empty);
                Console.WriteLine("Todos os ramais foram removidos com sucesso!");
            }
            else
            {
                Console.WriteLine("Operação de remoção cancelada.");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu Principal!");
            Console.ReadKey();
            Console.Clear();
            meuMenu.ExibirOpcoesDoMenu();
            return;
        }

        string criterio = "";
        bool pesquisarPorDepartamento = false;
        bool pesquisarPorId = false;

        if (opcao == 1)
        {
            Console.Write("\nDigite o nome da pessoa: ");
            criterio = Console.ReadLine();
        }
        else if (opcao == 2)
        {
            Console.Write("\nDigite o ID da pessoa: ");
            criterio = Console.ReadLine();
            pesquisarPorId = true;
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

        string[] linhas = File.ReadAllLines("arquivo.txt");

        bool pessoaEncontrada = false;
        List<string> novasLinhas = new List<string>();

        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');

            int id = int.Parse(campos[0].Trim());
            string nome = campos[1].Trim();

            if ((pesquisarPorDepartamento && campos[3].Trim().Equals(criterio, StringComparison.OrdinalIgnoreCase)) ||
                (pesquisarPorId && id.ToString().Equals(criterio, StringComparison.OrdinalIgnoreCase)) ||
                (nome.Equals(criterio, StringComparison.OrdinalIgnoreCase)))
            {
                pessoaEncontrada = true;
            }
            else
            {
                novasLinhas.Add(linha);
            }
        }

        if (pessoaEncontrada)
        {
            Console.WriteLine($"Tem certeza que deseja remover a pessoa {criterio}? (S/N)");
            string confirmacao = Console.ReadLine();

            if (confirmacao.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
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

        Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu Principal!");
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

        // Criar uma lista de pessoas
        List<Pessoa> pessoas = new List<Pessoa>();

        // Percorrer as linhas e criar objetos Pessoa
        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');

            int id = int.Parse(campos[0].Trim());
            string nome = campos[1].Trim();
            string ramal = campos[2].Trim();
            string departamento = campos[3].Trim();
            int grupoCaptura = int.Parse(campos[4].Trim());
            int permissao = int.Parse(campos[5].Trim());

            Pessoa pessoa = new Pessoa()
            {
                Id = id,
                Nome = nome,
                Ramal = ramal,
                Departamento = departamento,
                GrupoCaptura = grupoCaptura,
                Permissao = permissao
            };

            pessoas.Add(pessoa);
        }

        // Ordenar a lista de pessoas por nome
        pessoas.Sort((p1, p2) => string.Compare(p1.Nome, p2.Nome, StringComparison.OrdinalIgnoreCase));

        // Exibir cada pessoa da lista
        foreach (Pessoa pessoa in pessoas)
        {
            Console.WriteLine("ID: " + pessoa.Id);
            Console.WriteLine("Nome: " + pessoa.Nome);
            Console.WriteLine("Ramal: " + pessoa.Ramal);
            Console.WriteLine("Departamento: " + pessoa.Departamento);
            Console.WriteLine("Grupo de Captura: " + pessoa.GrupoCaptura);
            Console.WriteLine("Permissão: " + pessoa.Permissao);
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

        Console.WriteLine("Digite o critério de pesquisa:");
        Console.WriteLine("1 - Nome");
        Console.WriteLine("2 - ID");
        Console.Write("Opção: ");
        int opcao = int.Parse(Console.ReadLine()!);

        string criterio = "";
        bool pesquisarPorDepartamento = false;
        bool pesquisarPorId = false;

        switch (opcao) 
        {
            case 1:
                Console.Write("\nDigite o nome ou o primeiro nome da pessoa: ");
                criterio = Console.ReadLine();
            break;
            case 2:
                Console.Write("\nDigite o ID da pessoa: ");
                criterio = Console.ReadLine();
                pesquisarPorId = true;
                break;
            default:
                Console.WriteLine("\nOpção inválida!");
                Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal!");
                Console.ReadKey();
                Console.Clear();
                meuMenu.ExibirOpcoesDoMenu();
                break;
        }

        string[] linhas = File.ReadAllLines("arquivo.txt");

        bool pessoaEncontrada = false;

        for (int i = 0; i < linhas.Length; i++)
        {
            string linha = linhas[i];
            string[] campos = linha.Split(',');

            int id = int.Parse(campos[0].Trim());
            string nome = campos[1].Trim();

            if ((pesquisarPorDepartamento && campos[3].Trim().Equals(criterio, StringComparison.OrdinalIgnoreCase)) ||
                (pesquisarPorId && id.ToString().Equals(criterio, StringComparison.OrdinalIgnoreCase)) ||
                (nome.StartsWith(criterio, StringComparison.OrdinalIgnoreCase) ||
                nome.StartsWith(criterio.ToLower(), StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("ID: " + id);
                Console.WriteLine("Nome: " + nome);
                Console.WriteLine("Ramal: " + campos[2].Trim());
                Console.WriteLine("Departamento: " + campos[3].Trim());
                Console.WriteLine("Grupo de Captura: " + campos[4].Trim());
                Console.WriteLine("Permissão: " + campos[5].Trim());
                Console.WriteLine("*****************************************");

                // Menu de edição
                bool continuarEdicao = true;

                while (continuarEdicao)
                {
                    Console.WriteLine("Digite o número do campo que deseja editar:");
                    Console.WriteLine("1 - Nome");
                    Console.WriteLine("2 - Ramal");
                    Console.WriteLine("3 - Departamento");
                    Console.WriteLine("4 - Grupo de Captura");
                    Console.WriteLine("5 - Permissão");
                    Console.WriteLine("0 - Voltar ao Menu Principal");
                    Console.Write("Opção: ");
                    int opcaoEdicao = int.Parse(Console.ReadLine()!);

                    switch (opcaoEdicao)
                    {
                        case 0:
                            continuarEdicao = false;
                            break;
                        case 1:
                            Console.Write("Digite o novo nome: ");
                            string novoNome = Console.ReadLine();
                            campos[1] = novoNome;
                            Console.WriteLine("Nome atualizado com sucesso!");
                            break;
                        case 2:
                            Console.Write("Digite o novo ramal: ");
                            string novoRamal = Console.ReadLine();
                            campos[2] = novoRamal;
                            Console.WriteLine("Ramal atualizado com sucesso!");
                            break;
                        case 3:
                            Console.Write("Digite o novo departamento: ");
                            string novoDepartamento = Console.ReadLine();
                            campos[3] = novoDepartamento;
                            Console.WriteLine("Departamento atualizado com sucesso!");
                            break;
                        case 4:
                            Console.Write("Digite o novo grupo de captura: ");
                            string novoGrupoCaptura = Console.ReadLine();
                            campos[4] = novoGrupoCaptura;
                            Console.WriteLine("Grupo de Captura atualizado com sucesso!");
                            break;
                        case 5:
                            Console.Write("Digite a nova permissão: ");
                            string novaPermissao = Console.ReadLine();
                            campos[5] = novaPermissao;
                            Console.WriteLine("Permissão atualizada com sucesso!");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }

                    Console.WriteLine("Pressione qualquer tecla para continuar a edição ou 0 para voltar ao Menu Principal:");
                    string continuar = Console.ReadLine();
                    if (continuar == "0")
                    {
                        continuarEdicao = false;
                    }
                }

                linhas[i] = string.Join(", ", campos);
                pessoaEncontrada = true;
                break;
            }
        }

        if (pessoaEncontrada)
        {
            File.WriteAllLines("arquivo.txt", linhas);
            Console.WriteLine("Dados atualizados com sucesso!");
        }
        else
        {
            Console.WriteLine("Pessoa não encontrada.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu Principal!");
        Console.ReadKey();
        Console.Clear();
        meuMenu.ExibirOpcoesDoMenu();
    }
    public void PesquisarRamal()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();
        Console.WriteLine("Pesquisar Ramal");

        // Solicitar o critério de pesquisa (nome, departamento ou ID)
        Console.WriteLine("Digite o critério de pesquisa:");
        Console.WriteLine("1 - Nome");
        Console.WriteLine("2 - Departamento");
        Console.WriteLine("3 - ID");
        Console.Write("Opção: ");
        int opcao = int.Parse(Console.ReadLine());

        // Definir as variáveis de pesquisa
        string criterio = "";
        bool pesquisarPorDepartamento = false;
        bool pesquisarPorId = false;

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
        else if (opcao == 3)
        {
            Console.Write("\nDigite o ID da pessoa: ");
            criterio = Console.ReadLine();
            pesquisarPorId = true;
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

            int id = int.Parse(campos[0].Trim());
            string nome = campos[1].Trim();
            string ramal = campos[2].Trim();
            string departamento = campos[3].Trim();
            int grupoCaptura = int.Parse(campos[4].Trim());
            int permissao = int.Parse(campos[5].Trim());

            if (pesquisarPorDepartamento)
            {
                if (departamento.Equals(criterio, StringComparison.OrdinalIgnoreCase))
                {
                    ExibirInformacoesPessoa(id, nome, ramal, departamento, grupoCaptura, permissao);
                    resultadoEncontrado = true;
                }
            }
            else if (pesquisarPorId)
            {
                if (id.ToString().Equals(criterio, StringComparison.OrdinalIgnoreCase))
                {
                    ExibirInformacoesPessoa(id, nome, ramal, departamento, grupoCaptura, permissao);
                    resultadoEncontrado = true;
                }
            }
            else
            {
                if (nome.StartsWith(criterio, StringComparison.OrdinalIgnoreCase) ||
                    nome.StartsWith(criterio.ToLower(), StringComparison.OrdinalIgnoreCase))
                {
                    ExibirInformacoesPessoa(id, nome, ramal, departamento, grupoCaptura, permissao);
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
    public void ExibirGruposCaptura()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();
        Console.WriteLine("Grupos de Captura e Ramais:");

        // Ler o conteúdo do arquivo
        string[] linhas = File.ReadAllLines("arquivo.txt");

        // Dicionário para armazenar os grupos de captura e os ramais correspondentes
        Dictionary<int, List<string>> gruposCaptura = new Dictionary<int, List<string>>();

        // Dicionário para armazenar os ramais e seus grupos de captura
        Dictionary<string, int> ramaisGrupoCaptura = new Dictionary<string, int>();

        // Percorrer as linhas e adicionar os ramais aos grupos de captura
        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');

            int grupoCaptura = int.Parse(campos[4].Trim());
            string ramal = campos[2].Trim();

            if (gruposCaptura.ContainsKey(grupoCaptura))
            {
                gruposCaptura[grupoCaptura].Add(ramal);
            }
            else
            {
                gruposCaptura[grupoCaptura] = new List<string> { ramal };
            }

            ramaisGrupoCaptura[ramal] = grupoCaptura;
        }

        // Exibir os grupos de captura disponíveis
        Console.WriteLine("Grupos de Captura Disponíveis:");
        for (int i = 1; i <= 9; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("\nDigite o número do grupo que deseja visualizar ou");
        Console.WriteLine("Digite 'verificador' para usar o Verificador de Captura ou");
        Console.WriteLine("Digite 0 para voltar ao Menu Principal:");

        string opcao = Console.ReadLine();

        if (opcao == "0")
        {
            Console.Clear();
            meuMenu.ExibirOpcoesDoMenu();
            return;
        }

        if (opcao == "verificador")
        {
            Console.WriteLine("\nDigite o ramal que deseja verificar:");
            string ramalVerificar = Console.ReadLine();

            if (ramaisGrupoCaptura.ContainsKey(ramalVerificar))
            {
                int grupoCaptura = ramaisGrupoCaptura[ramalVerificar];

                Console.WriteLine("\nRamais capturados pelo ramal " + ramalVerificar + ":");
                foreach (string ramal in gruposCaptura[grupoCaptura])
                {
                    Console.WriteLine(ramal);
                }
            }
            else
            {
                Console.WriteLine("\nRamal não encontrado.");
            }
        }
        else
        {
            int opcaoGrupo = int.Parse(opcao);

            // Verificar se o grupo selecionado existe
            if (opcaoGrupo >= 1 && opcaoGrupo <= 9)
            {
                Console.WriteLine("\nGrupo de Captura: " + opcaoGrupo);
                Console.WriteLine("Ramais: " + string.Join(", ", gruposCaptura[opcaoGrupo]));
                Console.WriteLine("*****************************************");

                Console.WriteLine("\nRamais que podem ser capturados por ramais do Grupo " + opcaoGrupo + ":");
                foreach (var grupoCaptura in gruposCaptura)
                {
                    if (grupoCaptura.Key == opcaoGrupo)
                    {
                        continue; // Ignorar o próprio grupo
                    }

                    Console.WriteLine("Grupo " + grupoCaptura.Key + ": " + string.Join(", ", grupoCaptura.Value));
                }
            }
            else
            {
                Console.WriteLine("\nGrupo de Captura não encontrado.");
            }
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu Principal!");
        Console.ReadKey();
        Console.Clear();
        meuMenu.ExibirOpcoesDoMenu();
    }
    public void VerificarPermissao()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();
        Console.WriteLine("Verificador de Permissão");

        // Ler o conteúdo do arquivo
        string[] linhas = File.ReadAllLines("arquivo.txt");

        // Dicionário para armazenar as permissões de acesso e suas descrições
        Dictionary<int, string> descricaoPermissoes = new Dictionary<int, string>()
    {
        { 1, "Ramal" },
        { 2, "Ramal/Local" },
        { 3, "Ramal/Local/Celular" },
        { 4, "Ramal/Local/Celular/DDD (proibido 0300)" },
        { 5, "Ramal/Local/Celular/DDD" },
        { 6, "Ramal/Local/Celular/DDD" },
        { 7, "Ramal/Local/Celular/DDD/DDI" }
    };

        // Dicionário para armazenar as permissões de acesso
        Dictionary<string, int> permissoesAcesso = new Dictionary<string, int>();

        // Percorrer as linhas e adicionar as permissões
        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');

            int permissao = int.Parse(campos[5].Trim());
            string ramal = campos[2].Trim();

            if (!permissoesAcesso.ContainsKey(ramal))
            {
                permissoesAcesso[ramal] = permissao;
            }
        }

        Console.WriteLine("\nDigite o ramal que deseja verificar a permissão:");
        string ramalVerificar = Console.ReadLine();

        if (permissoesAcesso.ContainsKey(ramalVerificar))
        {
            int permissao = permissoesAcesso[ramalVerificar];
            Console.WriteLine("\nPermissão do ramal " + ramalVerificar + ": " + descricaoPermissoes[permissao]);
        }
        else
        {
            Console.WriteLine("\nRamal não encontrado.");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu Principal!");
        Console.ReadKey();
        Console.Clear();
        meuMenu.ExibirOpcoesDoMenu();
    }
    private void ExibirInformacoesPessoa(int id, string nome, string ramal, string departamento, int grupoCaptura, int permissao)
    {
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Nome: " + nome);
        Console.WriteLine("Ramal: " + ramal);
        Console.WriteLine("Departamento: " + departamento);
        Console.WriteLine("Grupo de Captura: " + grupoCaptura);
        Console.WriteLine("Permissão: " + permissao);
        Console.WriteLine("*****************************************");
    }
}