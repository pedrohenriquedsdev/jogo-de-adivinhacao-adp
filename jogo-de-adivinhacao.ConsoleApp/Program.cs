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

    int numeroAleatorio = RandomNumberGenerator.GetInt32(1, 21); //Gerando números aleatórios com entre intervalos.

    Console.Write("Digite um número entre 1 e 20: ");
    int? chute = Convert.ToInt32(Console.ReadLine()); //Pode ou não vir vazia

    if (chute == numeroAleatorio)
    {
        Console.WriteLine("===================");
        Console.WriteLine("Parabéns Você Acertou!");
        Console.WriteLine("===================");
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

    Console.WriteLine("Deseja Continuar? (S/N): ");
    string? opcaoContinuar = Console.ReadLine();

    if (opcaoContinuar?.ToUpper() != "S") //
    {
        break;
    }

    Console.ReadLine();


}
