//Objetivos / Passo a passo
//1. Nosso jogo deve aceitar o input do jogador e exibir o valor digitado.
//2. Nosso jogo deve gerar um número secreto aleatório.
//3. Nosso jogo deve validar a tentativa do jogador e exibir uma mensagem.

using System.Security.Cryptography; //Quero usar a biblioteca padrão do sistema relacionada a criptografia.

Console.WriteLine("===================");
Console.WriteLine("Jogo de Adivinhação");
Console.WriteLine("===================");

int numeroAleatorio = RandomNumberGenerator.GetInt32(1, 21); //Gerando números aleatórios com entre intervalos.

Console.Write("Digite um número entre 1 e 20: ");
string? chute = Console.ReadLine(); //Pode ou não vir vazia

Console.WriteLine($"O valor digitado foi: {chute}");
Console.WriteLine($"O valor aleatório era: {numeroAleatorio}");


Console.ReadLine();

