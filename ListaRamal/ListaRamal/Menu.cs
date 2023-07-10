﻿class Menu
{
    private Pessoa pessoa;  // Declaração da instância de Pessoa

    public void ExibirOpcoesDoMenu()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();

        pessoa = new Pessoa();  // Criar instância da classe Pessoa

        Console.WriteLine("\nDigite 1 Para Adicionar um Ramal");
        Console.WriteLine("\nDigite 2 Para Remover um Ramal");
        Console.WriteLine("\nDigite 3 Para Editar um Ramal");
        Console.WriteLine("\nDigite 4 Para Exibir lista de Ramal");
        Console.WriteLine("\nDigite 5 Para Pesquisar um Ramal");
        Console.WriteLine("\nDigite -1 Para Sair");
        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

        switch (opcaoEscolhidaNumerica)
        {
            case 1:
                pessoa.MenuAdicionarRamal();  // Chamar o método da instância de Pessoa
                break;
            case 2:
                RemoverRamal removerRamal = new RemoverRamal();
                removerRamal.PrintTest();
                break;
            case 3:
                EditarRamal editarRamal = new EditarRamal();
                editarRamal.PrintTest();
                break;
            case 4:
                pessoa.ExibirTodasPessoas();  // Chamar o método da instância de Pessoa
                break;
            case 5:
                PesquisarRamal pesquisarRamal = new PesquisarRamal();
                pesquisarRamal.PrintTest();
                break;
            case -1:
                Console.WriteLine("\nVocê Saiu :)");
                break;
        }
    }
}