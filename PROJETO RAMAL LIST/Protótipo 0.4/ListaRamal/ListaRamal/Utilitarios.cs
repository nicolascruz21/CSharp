namespace RamalList.Modelos;

public static class Utilitarios
{
    public static void ExibirLogo()
    {
        Console.WriteLine(@"
        
█▀█ ▄▀█ █▀▄▀█ ▄▀█ █░░ █░░ █ █▀ ▀█▀
█▀▄ █▀█ █░▀░█ █▀█ █▄▄ █▄▄ █ ▄█ ░█                   @ｂｙ：Ｎｉｃｏｌａｓ Ｆａｒｉａｓ
        ");
    }
    public static void VoltarMenu()
    { 
        if (Autenticacao.UsuarioLogado == "ADMIN")
        {
            Console.WriteLine("Pressione qualquer tecla e vá para o menu principal.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Aguarde...");
            Thread.Sleep(2000);

            var meuMenu = new Menu();
            meuMenu.ExibirOpcoesDoMenuAdmin();
        }
        else
        {
            Console.WriteLine("Pressione qualquer tecla e vá para o menu principal.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Aguarde...");
            Thread.Sleep(2000);

            var meuMenu = new Menu();
            meuMenu.ExibirOpcoesDoMenu();
        }  
    }
}