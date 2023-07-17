using System;
using System.Threading;

public class Autenticacao
{
    private const string Usuario = "admin";
    private const string Senha = "1234";

    public static void EfetuarLogin()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();

        Console.Write("\nDigite o nome de usuário: ");
        string nomeUsuario = Console.ReadLine()!;

        Console.Write("Digite a senha: ");
        string senhaDigitada = Console.ReadLine()!;

        while (nomeUsuario != Usuario || senhaDigitada != Senha)
        {
            Console.WriteLine("\nCredenciais inválidas. Pressione qualquer tecla para tentar novamente.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Aguarde...");
            Thread.Sleep(2000);
            EfetuarLogin();
        }

        if (nomeUsuario == Usuario && senhaDigitada == Senha)
        {
            Console.WriteLine("\nLogin bem-sucedido! Pressione qualquer tecla para entrar no menu principal.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Aguarde...");
            Thread.Sleep(2000);
            var meuMenu = new Menu();
            meuMenu.ExibirOpcoesDoMenu();
        }
    }
}
