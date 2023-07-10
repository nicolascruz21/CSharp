using System.Security.Cryptography.X509Certificates;

class Pessoa
{
    //Instanciando a classe Menu
    Menu meuMenu = new Menu();
    public string Nome { get; set; }
    public string Departamento { get; set; }
    public string Ramal { get; set; }
    private int Id { get; set; }

    private List<Pessoa> pessoaList;

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
                Pessoa pessoa = new Pessoa { Ramal = ramalDigitado, Nome = nomeDigitado, Departamento = departamentoDigitado }; 
                AdicionarPessoa(pessoa);
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

        void AdicionarPessoa(Pessoa pessoa)
        {
            pessoaList.Add(pessoa);
        }
         void ExibirTodasPessoas()
        {
            Console.Clear();
            Utilitarios.ExibirLogo();
            Console.WriteLine("Registros de Ramal:");

            Console.WriteLine($"\nNome: {Nome}");
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Ramal: {Ramal}");
            Console.WriteLine("------------");

            Console.WriteLine("Pressione Qualquer tecla para voltar ao Menu Principal!");
            Console.ReadKey();
            Console.Clear();
            meuMenu.ExibirOpcoesDoMenu();

        }


    }



