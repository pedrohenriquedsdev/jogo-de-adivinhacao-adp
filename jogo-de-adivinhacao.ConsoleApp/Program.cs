using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string? dificuldadeEscolhida = ExibirMenuDoJogo();

            int[] configuracoes = ExibirJogoConformeDificuldade(dificuldadeEscolhida);
            int numeroAleatorio = configuracoes[0];
            int totalDeTentativas = configuracoes[1];
            int numeroMaximo = configuracoes[2];

            if (numeroMaximo == 0) continue;

            int tentativaAtual = 0;
            int[] listaDeNumerosDigitados = new int[numeroMaximo - 1];

            while (tentativaAtual < totalDeTentativas)
            {
                string? dadoDeEntrada = EntradaDoJogador(numeroMaximo);
                int dadoDeEntradaConvertido = ConverterEntradaDoJogador(dadoDeEntrada);

                if (dadoDeEntradaConvertido == 0) continue;

                bool dadoExistenteNaLista = false;
                for (int i = 0; i < listaDeNumerosDigitados.Length; i++)
                {
                    if (listaDeNumerosDigitados[i] == dadoDeEntradaConvertido)
                    {
                        ExibirMensagem($"⚠  O número {dadoDeEntradaConvertido} já foi tentado!", ConsoleColor.Yellow);
                        dadoExistenteNaLista = true;
                        break;
                    }
                }
                if (dadoExistenteNaLista) continue;

                listaDeNumerosDigitados[dadoDeEntradaConvertido - 1] = dadoDeEntradaConvertido;
                tentativaAtual++;

                bool jogadorAcertou = ValidarTentativaDoJogador(
                    dadoDeEntradaConvertido, numeroAleatorio, tentativaAtual, totalDeTentativas);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"  Tentativa {tentativaAtual} de {totalDeTentativas}");
                Console.ResetColor();

                if (jogadorAcertou)
                {
                    int pontosDoJogador = PontuarJogador(tentativaAtual, totalDeTentativas);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("  ★ ═══════════════════════════════ ★");
                    Console.WriteLine($"         PONTUAÇÃO FINAL: {pontosDoJogador} pts");
                    Console.WriteLine("  ★ ═══════════════════════════════ ★");
                    Console.ResetColor();
                    Console.WriteLine();
                    break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n  Deseja jogar novamente? (s/N): ");
            Console.ResetColor();
            string? opcaoContinuar = Console.ReadLine();

            if (opcaoContinuar?.ToUpper() != "S")
            {
                Console.WriteLine();
                ExibirMensagem("  Obrigado por jogar! Até a próxima. 👋", ConsoleColor.Cyan);
                Console.WriteLine();
                break;
            }
        }
    }

    static void ExibirMensagem(string mensagem, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;
        Console.WriteLine(mensagem);
        Console.ResetColor();
    }

    static string? ExibirMenuDoJogo()
    {
        Console.Clear();
        string tituloDoJogo = "  JOGO DA ADIVINHAÇÃO";
        string linha = "  " + new string('═', tituloDoJogo.Length - 2);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(linha);
        Console.WriteLine(tituloDoJogo);
        Console.WriteLine(linha);
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("  Escolha um nível de dificuldade:");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  [1] Fácil   → 1 a 20  | 10 tentativas");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  [2] Médio   → 1 a 50  |  5 tentativas");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("  [3] Difícil → 1 a 70  |  3 tentativas");
        Console.ResetColor();
        Console.WriteLine();

        Console.Write("  Digite sua escolha: ");
        return Console.ReadLine();
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
                break;
            case "2":
                totalDeTentativas = 5;
                numeroMaximo = 51;
                break;
            case "3":
                totalDeTentativas = 3;
                numeroMaximo = 71;
                break;
            default:
                ExibirMensagem("  ✗ Dificuldade inválida. Tente novamente.", ConsoleColor.Red);
                Console.ReadLine();
                return new int[3];
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"  Adivinhe o número entre 1 e {numeroMaximo - 1}. Você tem {totalDeTentativas} tentativas!");
        Console.ResetColor();
        Console.WriteLine();

        numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo);
        configuracoes[0] = numeroAleatorio;
        configuracoes[1] = totalDeTentativas;
        configuracoes[2] = numeroMaximo;
        return configuracoes;
    }

    static string? EntradaDoJogador(int numeroMaximo)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"  › Digite um número (1 a {numeroMaximo - 1}): ");
        Console.ResetColor();
        return Console.ReadLine();
    }

    static int ConverterEntradaDoJogador(string? dadoDeEntrada)
    {
        if (string.IsNullOrWhiteSpace(dadoDeEntrada))
            ExibirMensagem("  ✗ Entrada vazia não é permitida.", ConsoleColor.Red);
        else if (dadoDeEntrada == "0")
            ExibirMensagem("  ✗ O número 0 não é aceito.", ConsoleColor.Red);
        else if (int.TryParse(dadoDeEntrada, out int dadoDeEntradaConvertido))
            return dadoDeEntradaConvertido;
        else
            ExibirMensagem("  ✗ Digite apenas números!", ConsoleColor.Red);

        return 0;
    }

    static bool ValidarTentativaDoJogador(int dadoDeEntradaConvertido, int numeroAleatorio, int tentativaAtual, int totalDeTentativas)
    {
        if (dadoDeEntradaConvertido == numeroAleatorio)
        {
            ExibirMensagem("  ✔ PARABÉNS! Você acertou!", ConsoleColor.Green);
            return true;
        }
        else if (dadoDeEntradaConvertido > numeroAleatorio)
            ExibirMensagem("  ↓ Muito alto! O número secreto é menor.", ConsoleColor.Yellow);
        else
            ExibirMensagem("  ↑ Muito baixo! O número secreto é maior.", ConsoleColor.Yellow);

        if (tentativaAtual == totalDeTentativas)
        {
            Console.WriteLine();
            ExibirMensagem($"  ✗ Suas tentativas acabaram! O número era {numeroAleatorio}.", ConsoleColor.Red);
        }

        return false;
    }

    static int PontuarJogador(int tentativaAtual, int totalDeTentativas)
    {
        int pontuacao = 1000;
        pontuacao -= (tentativaAtual - 1) * (1000 / totalDeTentativas);
        return Math.Max(pontuacao, 0);
    }
}