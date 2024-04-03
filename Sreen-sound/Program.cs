
//List<string> ListaBandas = new List<string> { "U2", "The Beatles", "Calypso"};  



Dictionary<string, List<int>> BandasRegistradas = new Dictionary<string, List<int>>();
BandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6});
BandasRegistradas.Add("The Beatles", new List<int> { 10, 8, 2});

void ExibirLogo()
{
    string mensagemBoasVindas = "Bem vindo a o Screen Sound!";

    Console.WriteLine(@"

    ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
    ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
    ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
    ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
    ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
    ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
        ");
    Console.WriteLine(mensagemBoasVindas);
}

void ExibirOpcoesMenu()
{
    ExibirLogo();

    Console.WriteLine("\nDigite 1 para inserir uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para mostrar a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite sua opção:");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: Mostrarbandas();
            break;
        case 3: AvaliarBandas();
            break;
        case 4: ExibirMedia();
            break;
        case -1:EncerrarPrograma();
            break;
        default: Console.WriteLine("Opção invalida");
            break ; 
    }
}


void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloOpcoes("Registros de bandas");
    Console.Write("Digite o nome da banda que deseja Registrar: ");
    string nomeBanda = Console.ReadLine()!;
    BandasRegistradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"\nA banda {nomeBanda} foi registrada!");
    Thread.Sleep(2000);
    Console.Clear() ;   
    ExibirOpcoesMenu();
}

void Mostrarbandas()
{
    Console.Clear();
    ExibirTituloOpcoes("Bandas Registradas");

    /*for (int i = 0; i < ListaBandas.Count; i++)
    {
        Console.WriteLine($"Banda: {ListaBandas[i]}");
    }*/

    foreach (string banda in BandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");  
    }
    Console.WriteLine("\n Digite qualquer tecla para retornar a o menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesMenu();

}

void AvaliarBandas()
{
    Console.Clear();
    ExibirTituloOpcoes("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeBandas = Console.ReadLine()!;    

    if (BandasRegistradas.ContainsKey(nomeBandas)) 
    {
        Console.WriteLine($"Qual nota a banda {nomeBandas} merece:");
        int nota = int.Parse(Console.ReadLine()!);
        BandasRegistradas[nomeBandas].Add(nota);
        Console.WriteLine($"\n A nota {nota} foi registrada com sucesso para a banda {nomeBandas}.");
        Console.WriteLine("Digite uma tecla para voltar a o menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();

    }  else {
        Console.WriteLine($"\nA banda {nomeBandas} Não foi encontrada.");
        Console.WriteLine("Digite uma tecla para voltar a o menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }
}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloOpcoes("Media das Bandas");
    Console.Write("\n Digite o nome da banda para saber sua média de notas:");
    string mediaBandas = Console.ReadLine()!;

    if (BandasRegistradas.ContainsKey (mediaBandas))
    {
        double media = BandasRegistradas[mediaBandas].Average();
        media = Convert.ToDouble(media.ToString("n1"));
        Console.WriteLine($"\nA media da banda {mediaBandas} é igual a " + media );
        Console.WriteLine("Digite uma tecla para voltar a o menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    } else {
        Console.WriteLine($"\nA banda {mediaBandas} Não foi encontrada.");
        Console.WriteLine("Digite uma tecla para voltar a o menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }

}

void EncerrarPrograma()
{
    Console.Clear();
    Console.WriteLine("Tchau Tchau :)");
   
}

void ExibirTituloOpcoes( string titulo)
{
    int quantidadeLetras = titulo.Length;
    string asteriscos = "".PadLeft(quantidadeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

ExibirOpcoesMenu();

