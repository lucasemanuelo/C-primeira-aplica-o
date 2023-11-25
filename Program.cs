// Screen Sound
string saudacao = "  Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> { "Yunk Vino", "DomLaike"};
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Japa", new List<int> { 8, 5, 10});
bandasRegistradas.Add("Duzz", new List<int> ());
void ExibirLogo()
{
    Console.WriteLine(@"
    
█████████████████████████████████████████████████████████████████████████
█─▄▄▄▄█─▄▄▄─█▄─▄▄▀█▄─▄▄─█▄─▄▄─█▄─▀█▄─▄███─▄▄▄▄█─▄▄─█▄─██─▄█▄─▀█▄─▄█▄─▄▄▀█
█▄▄▄▄─█─███▀██─▄─▄██─▄█▀██─▄█▀██─█▄▀─████▄▄▄▄─█─██─██─██─███─█▄▀─███─██─█
▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▀▀▄▄▀▀▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀

    ");
    Console.WriteLine(saudacao);
}


void ExibirOpcoesMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite uma opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: ExibirMedia();
            break;
        case 0: Console.WriteLine("Volte sempre");
            break;
        default: Console.WriteLine("Opção invalida");
            break;
    }
}
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das Bandas");
    Console.Write("Nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo Bandas Registradas"); 
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarBanda()
{
    //Digite qual banda deseja avaliar
    //se a banda existir no dicionario atribuir nota
    //senão exibir msg e voltar ao menu

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Qual banda deseja avaliar? ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a sua nota para a banda {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} para banda {nomeDaBanda} foi registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesMenu();
    }else
    {
        Console.WriteLine($"A banda: {nomeDaBanda} não foi encontrada!\n");
        Console.WriteLine("Digite uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }
}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir Media");
    Console.Write("Qual banda deseja ver a media? ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é de {notasDaBanda.Average()}.");
        Console.WriteLine("Digite uma tecla para voltar");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }else
    {
        Console.WriteLine($"\nA banda: {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }
}


ExibirOpcoesMenu();