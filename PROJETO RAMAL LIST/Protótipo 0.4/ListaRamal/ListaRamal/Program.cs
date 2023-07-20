namespace RamalList.Modelos;

class Program
{
    static void Main(string[] args)
    {
        // Criar o arquivo de usuários
        Autenticacao.CriarArquivoUsuarios();
        // Criação de uma instância da classe Menu
        Menu meuMenu = new Menu();
        // Efetuar o login
        Autenticacao.EfetuarLogin();           
    }
}
