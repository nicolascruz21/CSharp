namespace RamalList.Modelos;

class Menu
{
    private Pessoa pessoa;  // Declaração da instância de Pessoa

    public void ExibirOpcoesDoMenuAdmin()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();

        pessoa = new Pessoa();  // Criar instância da classe Pessoa

        Console.WriteLine("\nDigite 1 Para Gerenciar Ramal");
        Console.WriteLine("\nDigite 2 Para Exibir lista de Ramal");
        Console.WriteLine("\nDigite 3 Para Pesquisar um Ramal");
        Console.WriteLine("\nDigite 4 Para Exibir Grupos de Captura");
        Console.WriteLine("\nDigite 5 Para Verificar Permissões");
        Console.WriteLine("\nDigite 6 Para Gerenciar Usuários");
        Console.WriteLine("\nDigite -1 Para Sair");
        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

        switch (opcaoEscolhidaNumerica)
        {
            case 1:
                pessoa.GerenciarRamal();  // Chamar o método da classe Pessoa
                break;
            case 2:
                pessoa.ExibirTodasPessoas(); // Chamar o método da classe Pessoa
                break;
            case 3:
                pessoa.PesquisarRamal(); // Chamar o método da classe Pessoa
                break;
            case 4:
                pessoa.ExibirGruposCaptura(); // Chamar o método da classe Pessoa
                break;
            case 5:
                pessoa.VerificarPermissao();  //Chamar o método da classe Pessoa
                break;
            case 6: 
                Admin.GerenciarUsuario(); //Chamar o método da classe Pessoa
                break;
            case -1:
                Console.WriteLine("\nVocê Saiu :)");
                break;
        }
    }

    public void ExibirOpcoesDoMenu()
    {
        pessoa = new Pessoa();  // Criar instância da classe Pessoa
        Console.Clear();
        Utilitarios.ExibirLogo();
        Console.WriteLine("\nDigite 1 Para Exibir lista de Ramal");
        Console.WriteLine("\nDigite 2 Para Pesquisar um Ramal");
        Console.WriteLine("\nDigite -1 Para Sair");
        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

        switch (opcaoEscolhidaNumerica)
        {
            case 1:
                pessoa.ExibirTodasPessoas();  // Chamar o método da classe Pessoa
                break;
            case 2:
                pessoa.PesquisarRamal(); //Chamar o método da classe Pessoa
                break;           
            case -1:
                Console.WriteLine("\nVocê Saiu :)");
                break;
        }

    }
}   
