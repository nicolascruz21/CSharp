namespace RamalList.Modelos;

public class Admin
{
    public  static string Login => "ADMIN";
    public static string Senha => "Admin321";

    public static void GerenciarUsuario()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();
        Console.WriteLine("Gerenciar Ramal");

        Console.WriteLine("Digite a opção desejada:");
        Console.WriteLine("1 - Adicionar Usuário");
        Console.WriteLine("2 - Remover Usuário");
        Console.WriteLine("3 - Editar Usuário");
        Console.WriteLine("0 - Voltar ao Menu");
        Console.Write("Opção: ");
        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                AdicionarUsuario();
                break;
            case 2:
                RemoverUsuario();
                break;
            case 3:
                EditarUsuario();
                break;
            case 0:
                Utilitarios.VoltarMenu();
                break;
            default:
                Console.WriteLine("\nOpção Inválida");
                Utilitarios.VoltarMenu();
                break;
        }
    }
    public static void AdicionarUsuario()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();

        Console.Write("Digite o nome de usuário: ");
        string nomeUsuario = Console.ReadLine();

        // Verificar se o nome de usuário já está em uso
        string[] linhas = File.ReadAllLines("User.txt");
        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');
            string nome = campos[0];

            if (nomeUsuario == nome)
            {
                Console.WriteLine("Nome de usuário já está em uso.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
                Console.ReadKey();
                Console.Clear();
                Utilitarios.VoltarMenu();
                return;
            }
        }

        Console.Write("Digite a senha: ");
        string senha = Console.ReadLine();

        // Adicionar o novo usuário ao arquivo "User.txt"
        using (StreamWriter writer = new StreamWriter("User.txt", true))
        {
            writer.WriteLine($"{nomeUsuario},{senha}");
        }

        Console.WriteLine("Usuário adicionado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        Utilitarios.VoltarMenu();
    }
    public static void RemoverUsuario()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();

        Console.Write("Digite o nome de usuário que deseja remover: ");
        string nomeUsuario = Console.ReadLine();

        // Ler os dados dos usuários do arquivo "User.txt"
        string[] linhas = File.ReadAllLines("User.txt");

        // Criar uma lista para armazenar os usuários atualizados
        List<string> usuariosAtualizados = new List<string>();

        bool usuarioEncontrado = false;

        // Percorrer as linhas do arquivo e verificar se o usuário existe
        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');
            string nome = campos[0];

            if (nomeUsuario == nome)
            {
                usuarioEncontrado = true;
            }
            else
            {
                // Adicionar usuários diferentes do usuário que será removido na lista atualizada
                usuariosAtualizados.Add(linha);
            }
        }

        if (!usuarioEncontrado)
        {
            Console.WriteLine("Usuário não encontrado.");
        }
        else
        {
            // Sobrescrever o arquivo "User.txt" com a lista atualizada de usuários
            File.WriteAllLines("User.txt", usuariosAtualizados);

            Console.WriteLine("Usuário removido com sucesso!");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        Utilitarios.VoltarMenu();
    }
    public static void EditarUsuario()
    {
        Console.Clear();
        Utilitarios.ExibirLogo();

        Console.Write("Digite o nome de usuário que deseja editar: ");
        string nomeUsuario = Console.ReadLine();

        // Ler os dados dos usuários do arquivo "User.txt"
        string[] linhas = File.ReadAllLines("User.txt");

        // Criar uma lista para armazenar os usuários atualizados
        List<string> usuariosAtualizados = new List<string>();

        bool usuarioEncontrado = false;

        // Percorrer as linhas do arquivo e verificar se o usuário existe
        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');
            string nome = campos[0];
            string senha = campos[1];

            if (nomeUsuario == nome)
            {
                Console.Write("Digite a nova senha: ");
                string novaSenha = Console.ReadLine();

                // Adicionar o usuário com a senha atualizada na lista de usuários atualizados
                usuariosAtualizados.Add($"{nome},{novaSenha}");
                usuarioEncontrado = true;
            }
            else
            {
                // Adicionar usuários diferentes do usuário que será editado na lista atualizada
                usuariosAtualizados.Add(linha);
            }
        }

        if (!usuarioEncontrado)
        {
            Console.WriteLine("Usuário não encontrado.");
        }
        else
        {
            // Sobrescrever o arquivo "User.txt" com a lista atualizada de usuários
            File.WriteAllLines("User.txt", usuariosAtualizados);

            Console.WriteLine("Usuário editado com sucesso!");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        Utilitarios.VoltarMenu();
    }
    public void DesabilitarAtributo()
    {
        Console.WriteLine("Qual atributo desabilitar?");
        Console.WriteLine("1-ID");
        Console.WriteLine("2-Nome");
        Console.WriteLine("3-Ramal");
        Console.WriteLine("4-Departamento");
        Console.WriteLine("5-Grupo de Captura");
        Console.WriteLine("6-Permissão");
        Console.WriteLine("0-Todos");
        string opcao = Console.ReadLine()!;
        int opcaoNumerica = int.Parse(opcao);

        switch (opcaoNumerica)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Desabilitar para quem?");
                break;

            case 2:
                Console.Clear();
                break;

            case 3:
                Console.Clear();
                break;

            case 4:
                Console.Clear();
                break;

            case 5:
                Console.Clear();
                break;

            case 6:
                Console.Clear();
                break;

            case 0:
                Utilitarios.VoltarMenu();
                break;
        }
    }
}
