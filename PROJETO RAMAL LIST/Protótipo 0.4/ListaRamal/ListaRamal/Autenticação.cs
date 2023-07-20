using System;
using System.IO;
using System.Threading;

namespace RamalList.Modelos;

public class Autenticacao
{
    public static string UsuarioLogado { get; private set; } // Armazena o nome do usuário logado

    public static void CriarArquivoUsuarios()
    {
        // Verificar se o arquivo "User.txt" já existe
        if (File.Exists("User.txt"))
        {
            return;
        }

        // Criar um array de usuários
        Usuario[] usuarios = new Usuario[]
        {
        new Usuario { Login = Admin.Login, Senha = Admin.Senha },
        new Usuario { Login = "x000000", Senha = "123456" },
        new Usuario { Login = "d000000", Senha = "123456" }
        };

        // Criar o arquivo "User.txt" e escrever os dados dos usuários
        using (StreamWriter writer = new StreamWriter("User.txt"))
        {
            foreach (var usuario in usuarios)
            {
                writer.WriteLine($"{usuario.Login},{usuario.Senha}");
            }
        }
    }


    public static void EfetuarLogin()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();

        Console.Write("\nDigite o nome de usuário: ");
        string nomeUsuario = Console.ReadLine();

        Console.Write("Digite a senha: ");
        string senhaDigitada = Console.ReadLine();

        if (nomeUsuario == Admin.Login && senhaDigitada == Admin.Senha)
        {
            // Efetuar o login do usuário admin
            UsuarioLogado = nomeUsuario;
            Utilitarios.VoltarMenu();
        }
        else
        {
            // Ler os dados dos usuários do arquivo "User.txt"
            string[] linhas = File.ReadAllLines("User.txt");

            bool usuarioEncontrado = false;

            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');

                string nome = campos[0];
                string senha = campos[1];

                if (nomeUsuario == nome && senhaDigitada == senha)
                {
                    usuarioEncontrado = true;
                    UsuarioLogado = nomeUsuario;

                    Console.WriteLine("\nLogin bem-sucedido!");
                    Utilitarios.VoltarMenu();
                    break;
                }
            }

            if (!usuarioEncontrado)
            {
                Console.WriteLine("\nCredenciais inválidas. Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Aguarde...");
                Thread.Sleep(2000);
                EfetuarLogin();
            }
        }
    }


}

