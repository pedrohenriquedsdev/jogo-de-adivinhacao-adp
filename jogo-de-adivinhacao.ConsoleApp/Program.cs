// Objetivos / Passo-a-passo

// v1
// 1. Nosso jogo deve aceitar o input do jogador e exibir o valor digitado [x]  
// 2. Nosso jogo deve gerar um número aleatório [x]  
// 3. Nosso jogo deve validar a tentativa do jogador e exibir uma mensagem [x]  
// 4. Nosso jogo deve permitir múltiplas tentativas [x] 

// v2
// 1. Nosso jogo deve implementar a funcionalidade de Dificuldade e Tentativas limitadas [X] 
// 2. Nosso jogo deve implementar a funcionalidade de Validação de Números Repetidos [X] 
// 3. Nosso jogo deve implementar a funcionalidade de Pontuação [X] 

using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            //Exibir Menu
            string? dificuldadeEscolhida = ExibirMenuDoJogo();

            //Configurar o jogo
            int[] configuracoes = ExibirJogoConformeDificuldade(dificuldadeEscolhida);
            int numeroAleatorio = configuracoes[0];
            int totalDeTentativas = configuracoes[1];
            int numeroMaximo = configuracoes[2];

            //Validações / In game
            int tentativaAtual = 0;
            int[] listaDeNumerosDigitados = new int[numeroMaximo - 1];

            while (tentativaAtual < totalDeTentativas)
            {
                string? dadoDeEntrada = EntradaDoJogador(numeroMaximo);
                int dadoDeEntradaConvertido = ConverterEntradaDoJogador(dadoDeEntrada);

                // 1. Inválido? Não conta
                if (dadoDeEntradaConvertido == 0) continue;

                // 2. Repetido? Não conta
                bool dadoExistenteNaLista = false;
                for (int i = 0; i < listaDeNumerosDigitados.Length; i++)
                {
                    if (listaDeNumerosDigitados[i] == dadoDeEntradaConvertido)
                    {
                        Console.WriteLine($"{dadoDeEntradaConvertido} já está na lista!");
                        dadoExistenteNaLista = true;
                        break;
                    }
                }
                if (dadoExistenteNaLista) continue;

                // 3. Tudo certo — agora salva, incrementa e valida
                listaDeNumerosDigitados[dadoDeEntradaConvertido - 1] = dadoDeEntradaConvertido;
                tentativaAtual++;

                bool jogadorAcertou = ValidarTentativaDoJogador(
                    dadoDeEntradaConvertido, numeroAleatorio, tentativaAtual, totalDeTentativas);

                Console.WriteLine($"{tentativaAtual} de {totalDeTentativas}");
                // 4. Pontuar Jogador Baseado em Acertos e Posicões
                int pontosDoJogador = PontuarJogador(dadoDeEntradaConvertido, numeroAleatorio);

                if (jogadorAcertou)
                {
                    Console.WriteLine($"Pontuação final: {pontosDoJogador}");
                    break;
                }

            }

            Console.Write("Deseja continuar? (s/N): ");
            string? opcaoContinuar = Console.ReadLine();

            if (opcaoContinuar?.ToUpper() != "S")
            {
                break;
            }
        }


    }

    static string? ExibirMenuDoJogo()
    {
        string tituloDoJogo = "JOGO DA ADIVINHAÇÃO";
        string linha = new string('=', tituloDoJogo.Length); //Construtor
        Console.WriteLine(linha);
        Console.WriteLine(tituloDoJogo);
        Console.WriteLine(linha);

        Console.WriteLine("\nEscolha um nível de dificuldade:");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("1 - Fácil (10 tentativas)");
        Console.WriteLine("2 - Médio (5 tentativas)");
        Console.WriteLine("3 - Difícil (3 tentativas)");
        Console.WriteLine("------------------------------------");

        Console.Write("Digite sua escolha: ");
        string? dificuldadeEscolhida = Console.ReadLine();

        return dificuldadeEscolhida;
    }

    static int[] ExibirJogoConformeDificuldade(string? dificuldadeEscolhida)
    {
        int[] configuracoes = new int[3];
        int totalDeTentativas = 0;
        int numeroMaximo = 0;
        int numeroAleatorio = 0;

        switch (dificuldadeEscolhida)
        {
            case "1":
                totalDeTentativas = 10;
                numeroMaximo = 21;
                Console.WriteLine($"Você terá {totalDeTentativas} tentativas para adivinhar um número de 1 a {numeroMaximo - 1}.");
                break;

            case "2":
                totalDeTentativas = 5;
                numeroMaximo = 51;
                Console.WriteLine($"Você terá {totalDeTentativas} tentativas para adivinhar um número de 1 a {numeroMaximo - 1}.");
                break;

            case "3":
                totalDeTentativas = 3;
                numeroMaximo = 71;
                Console.WriteLine($"Você terá {totalDeTentativas} tentativas para adivinhar um número de 1 a {numeroMaximo - 1}.");
                break;

            default:
                Console.WriteLine("Dificuldade inválida.");
                Console.ReadLine();
                return new int[3];
        }

        numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo);
        configuracoes[0] = numeroAleatorio;
        configuracoes[1] = totalDeTentativas;
        configuracoes[2] = numeroMaximo;
        return configuracoes;
    }

    static string? EntradaDoJogador(int numeroMaximo)
    {
        Console.Write($"Digite um número entre 1 e {numeroMaximo - 1}: ");
        string? dadoDeEntrada = Console.ReadLine()!;

        return dadoDeEntrada;
    }

    static int ConverterEntradaDoJogador(string? dadoDeEntrada)
    {

        if (string.IsNullOrWhiteSpace(dadoDeEntrada))
        {
            Console.WriteLine("ERRO! Espaços em branco ou valores nulos não serão permitidos.");
        }

        else if (dadoDeEntrada == "0")
        {
            Console.WriteLine("Valor 0 não é aceito. Digite um valor válido!");
        }

        else if (int.TryParse(dadoDeEntrada, out int dadoDeEntradaConvertido))
        {
            return dadoDeEntradaConvertido;
        }

        else
        {
            Console.WriteLine("Por favor insira apenas números e não letras!");
        }

        return 0;
    }

    static bool ValidarTentativaDoJogador(int dadoDeEntradaConvertido, int numeroAleatorio, int tentativaAtual, int totalDeTentativas)
    {
        if (dadoDeEntradaConvertido == numeroAleatorio)
        {
            Console.WriteLine("PARABÉNS! Você acertou o número aleatório!");
            return true;
        }
        else if (dadoDeEntradaConvertido > numeroAleatorio)
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

        if (tentativaAtual == totalDeTentativas)
        {
            Console.WriteLine($"Você usou todas as tentativas. O número era {numeroAleatorio}.");
            Console.WriteLine("------------------------------------");
        }

        return false;

    }

    static int PontuarJogador(int dadoDeEntradaConvertido, int numeroAleatorio)
    {
        int pontuacao = 1000;
        int diferencaEntreDados = Math.Abs(dadoDeEntradaConvertido - numeroAleatorio);

        if (diferencaEntreDados == 0)       // acerto exato → 1000 pontos
            return pontuacao;

        else if (diferencaEntreDados > 10)
            pontuacao -= 100;

        else if (diferencaEntreDados >= 5)
            pontuacao -= 50;

        else
            pontuacao -= 20;

        return pontuacao;
    }

}