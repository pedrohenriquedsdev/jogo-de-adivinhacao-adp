//Objetivos / Passo a passo
//1. Nosso jogo deve aceitar o input do jogador e exibir o valor digitado.
//2. Nosso jogo deve gerar um número secreto aleatório.
//3. Nosso jogo deve validar a tentativa do jogador e exibir uma mensagem.

using System.Security.Cryptography; //Quero usar a biblioteca padrão do sistema relacionada a criptografia.

while (true)
{
    Console.Clear();

    Console.WriteLine("===================");
    Console.WriteLine("Jogo de Adivinhação");
    Console.WriteLine("===================");
    Console.WriteLine("Escolha o nível de dificuldade: ");
    Console.WriteLine("===================");
    Console.WriteLine("1 - Fácil (10 tentativas)");
    Console.WriteLine("2 - Médio (5 tentativas)");
    Console.WriteLine("3 - Difícil (3 tentativas)");
    Console.WriteLine("===================");

    Console.Write("Digite uma opção: ");
    string dificuldade = Console.ReadLine();

    int numeroMaximo;
    int tentativasMaximas;

    switch (dificuldade)
    {
        case "1":
            numeroMaximo = 20;
            tentativasMaximas = 10;
            break;

        case "2":
            numeroMaximo = 50;
            tentativasMaximas = 5;
            break;

        case "3":
            numeroMaximo = 100;
            tentativasMaximas = 3;
            break;

        default:
            Console.WriteLine("===================");
            Console.WriteLine("Tente novamnte!");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            continue;
    }


    //hard coded
    int numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo + 1); //Gerando números aleatórios com entre intervalos.

    for (int tentativa = 1; tentativa <= tentativasMaximas; tentativa++)
    {
        Console.Clear();
        Console.WriteLine("===================");
        Console.WriteLine($"Tentativa {tentativa} de {tentativasMaximas}");
        Console.WriteLine("===================");

        Console.ReadLine();

        Console.Write($"Digite um número entre 1 e {numeroMaximo}: ");
        int? chute = Convert.ToInt32(Console.ReadLine()); //Pode ou não vir vazia

        if (chute == numeroAleatorio)
        {
            Console.WriteLine("===================");
            Console.WriteLine("Parabéns Você Acertou!");
            Console.WriteLine("===================");
            break;
        }

        else if (chute > numeroAleatorio)
        {
            Console.WriteLine("===================");
            Console.WriteLine("O Número Digitado Foi Maior que o Número Secreto! Tente chutar valores menores...");
            Console.WriteLine("===================");
        }
        else
        {
            Console.WriteLine("===================");
            Console.WriteLine("O Número Digitado Foi Menor que o Número Secreto! Tente chutar valores maiores...");
            Console.WriteLine("===================");

        }

        if (tentativa == tentativasMaximas)
        {
            Console.WriteLine($"Você atingiu o limite de tentativas! O número secreto era {numeroAleatorio}");
            Console.WriteLine("===================");
            break;
        }



        Console.WriteLine("Deseja Continuar? (S/N): ");
        string? opcaoContinuar = Console.ReadLine();

        if (opcaoContinuar?.ToUpper() != "S") //
        {
            break;
        }

        Console.ReadLine();
    }
}
