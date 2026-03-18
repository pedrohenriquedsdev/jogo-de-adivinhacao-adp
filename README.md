Aqui vai um README direto, profissional e pronto pra usar 👇

---

# 🎯 Jogo da Adivinhação (C# Console)

Um jogo simples de adivinhação desenvolvido em **C#**, com foco em lógica, validações e estrutura de código.

## 🚀 Funcionalidades

### 🔹 Versão 1

* Input do jogador
* Geração de número aleatório
* Validação da tentativa (maior/menor/acerto)
* Múltiplas tentativas

### 🔹 Versão 2

* Níveis de dificuldade
* Tentativas limitadas
* Validação de números repetidos
* Sistema de pontuação

---

## 🎮 Como funciona

1. O jogador escolhe a dificuldade:

   * Fácil → 10 tentativas (1 a 20)
   * Médio → 5 tentativas (1 a 50)
   * Difícil → 3 tentativas (1 a 70)

2. O sistema gera um número aleatório.

3. O jogador tenta adivinhar:

   * Recebe dica se o número é maior ou menor
   * Não pode repetir números
   * Entradas inválidas não contam tentativa

4. O jogo termina quando:

   * O jogador acerta ✅
   * As tentativas acabam ❌

---

## 🧠 Sistema de Pontuação

Pontuação baseada na proximidade do número correto:

* 🎯 Acerto exato → **1000 pontos**
* 🔥 Diferença < 5 → -20 pontos
* ⚠️ Diferença entre 5 e 10 → -50 pontos
* ❌ Diferença > 10 → -100 pontos

---

## 🛠️ Tecnologias utilizadas

* C#
* .NET
* Console Application
* `RandomNumberGenerator` (número aleatório seguro)

---

## 📌 Conceitos aplicados

* Estruturas de repetição (`while`)
* Condicionais (`if/else`, `switch`)
* Métodos e organização de código
* Validação de entrada
* Arrays
* Lógica de jogo

---

## ▶️ Como executar

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/jogo-adivinhacao.git

# Acesse a pasta
cd jogo-adivinhacao

# Execute o projeto
dotnet run
```

---

## 📈 Possíveis melhorias

* Sistema de ranking
* Histórico de partidas
* Interface gráfica (WinForms / WPF)
* Sons e feedback visual
* Dificuldade customizada

---

## 👨‍💻 Autor

Pedro Henrique dos Santos - 
Focado em evolução como **Dev Backend C# .NET**

---

Se quiser, posso transformar isso em um README mais “nível GitHub top” com badges, gif do jogo rodando e layout mais chamativo.
