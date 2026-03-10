// Objetivos / Passo-a-passo

// v1
// 1. Nosso jogo deve aceitar o input do jogador e exibir o valor digitado
// 2. Nosso jogo deve gerar um número aleatório
// 3. Nosso jogo deve validar a tentativa do jogador e exibir uma mensagem
// 4. Nosso jogo deve permitir múltiplas tentativas

// v2
// 1. Nosso jogo deve implementar a funcionalidade de Dificuldade e Tentativas limitadas
// 2. Nosso jogo deve umplementar uma funcionalidade de Validação de Números Repetidos

using System; // biblioteca padrão do sistema com classes genéricas
using System.Security.Cryptography; // biblioteca padrão do sistema relacionada a criptografia

while (true == true)
{
    int[] numerosDigitados = new int[100];
    int contadorNumerosDigitados = 0;

    Console.Clear();

    Console.WriteLine("------------------------------------");
    Console.WriteLine("Jogo de Adivinhação");
    Console.WriteLine("------------------------------------");
    Console.WriteLine("Escolha o nível de dificuldade:");
    Console.WriteLine("------------------------------------");
    Console.WriteLine("1 - Fácil (10 tentativas)");
    Console.WriteLine("2 - Médio (5 tentativas)");
    Console.WriteLine("3 - Difícil (3 tentativas)");
    Console.WriteLine("------------------------------------");

    Console.Write("Digite sua escolha: ");
    string? dificuldade = Console.ReadLine();

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
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Por favor, selecione uma dificuldade válida.");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            continue;
    }

    int numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo + 1);

    for (int tentativa = 1; tentativa <= tentativasMaximas; tentativa++)
    {
        Console.Clear();
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Tentativa {tentativa} de {tentativasMaximas}.");
        Console.WriteLine("------------------------------------");

        Console.Write($"Digite um número entre 1 e {numeroMaximo}: ");
        string? chute = Console.ReadLine();

        int numeroDigitado = Convert.ToInt32(chute);

        bool numeroEstaRepetido = false;

        for (int contadorNumeros = 0; contadorNumeros < numerosDigitados.Length; contadorNumeros++)
        {
            if (numerosDigitados[contadorNumeros] == numeroDigitado)
            {
                numeroEstaRepetido = true;
                break;
            }
        }

        if (numeroEstaRepetido == true)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Você já digitou esse número, tente novamente.");
            Console.WriteLine("------------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();

            tentativa--;

            continue;
        }

        if (contadorNumerosDigitados < numerosDigitados.Length)
        {
            numerosDigitados[contadorNumerosDigitados] = numeroDigitado;

            contadorNumerosDigitados++;
        }

        if (numeroDigitado == numeroAleatorio)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Parabéns, você acertou!");
            Console.WriteLine("------------------------------------");

            break;
        }
        else if (numeroDigitado > numeroAleatorio)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("O número digitado foi maior que o número secreto!");
            Console.WriteLine("------------------------------------");
        }
        else
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("O número digitado foi menor que o número secreto!");
            Console.WriteLine("------------------------------------");
        }

        if (tentativa == tentativasMaximas)
        {
            Console.WriteLine($"Você usou todas as suas tentativas! O número era {numeroAleatorio}.");
            Console.WriteLine("------------------------------------");
            break;
        }

        Console.ReadLine();
    }

    Console.Write("Deseja continuar? (s/N): ");
    string? opcaoContinuar = Console.ReadLine();

    if (opcaoContinuar?.ToUpper() != "S")
    {
        break;
    }
}