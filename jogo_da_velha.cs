using System;

class JogoDaVelha
{
    static void Main()
    {
        char[] posicoesPossiveis = new char[9]{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};
        bool vitoria = false;
        
        int contaJogadas = 0;
        while((vitoria == false) && (contaJogadas < 9))
        {
            
            MostraJogo(posicoesPossiveis);
            
            jogadaJogador(ref posicoesPossiveis, 'X');
            MostraJogo(posicoesPossiveis);
            vitoria = verificaVitoria(posicoesPossiveis, 'X');
            contaJogadas++;
            
            
            if(vitoria || contaJogadas == 9)
            {
                break;
            }
            
            jogadaJogador(ref posicoesPossiveis, 'O');
            MostraJogo(posicoesPossiveis);
            vitoria = verificaVitoria(posicoesPossiveis, 'O');
            contaJogadas++;
        }
        
        if(contaJogadas == 9)
        {
            Console.WriteLine("empate");
        }
    }
    
    static bool verificaVitoria(char[] jogoAtual, char marca)
    {
        // verifica uma vitória na horizontal
        if ((jogoAtual[0] == marca && jogoAtual[1] == marca && jogoAtual[2] == marca) || 
            (jogoAtual[3] == marca && jogoAtual[4] == marca && jogoAtual[5] == marca) ||
            (jogoAtual[6] == marca && jogoAtual[7] == marca && jogoAtual[8] == marca))
        {
            Console.WriteLine($"jogador {marca} venceu");
            return true;
        }
            
        // verifica vitória na vertical
        if ((jogoAtual[0] == marca && jogoAtual[3] == marca && jogoAtual[6] == marca) || 
            (jogoAtual[1] == marca && jogoAtual[4] == marca && jogoAtual[7] == marca) ||
            (jogoAtual[2] == marca && jogoAtual[5] == marca && jogoAtual[8] == marca))
        {
            Console.WriteLine($"jogador {marca} venceu");
            return true;
        }
        
        // verifica vitória nas diagonais
        if ((jogoAtual[0] == marca && jogoAtual[4] == marca && jogoAtual[8] == marca) || 
            (jogoAtual[2] == marca && jogoAtual[4] == marca && jogoAtual[6] == marca))
        {
            Console.WriteLine($"Jogador {marca} venceu");
            return true;
        }
        
        // por padrão vai retornar falso
        return false;
    }
    

    static void jogadaJogador(ref char[] posicoes, char marca)
    {
        // while para o jogador escolher o lugar em que vai jogar
        while(true) 
        {
            Console.Write("marque onde você quer jogar: ");
            string lugar = Console.ReadLine();
            
            // tratando a entrada do usuário para que seja um int
            if (int.TryParse(lugar, out int jogada))
            {
                // verifica se ele jogou algo entre 1 e 9 e se não repetiu posições
                if ((jogada < 1) || (jogada > 9) || (posicoes[jogada - 1] != ' '))
                {
                    Console.WriteLine("jogada inválida...");
                } 
                else 
                {
                    posicoes[jogada - 1] = marca;
                    break;
                }
                
            } 
            else 
            {
                Console.WriteLine("escreva um número inteiro");
            }
        }
    }
   
   
    static void MostraJogo(char[] jogo)
    {
        Console.WriteLine();
        Console.WriteLine($"  1 | 2 | 3     {jogo[0]} | {jogo[1]} | {jogo[2]} ");
        Console.WriteLine(" ------------   ---------");
        Console.WriteLine($"  4 | 5 | 6     {jogo[3]} | {jogo[4]} | {jogo[5]} ");
        Console.WriteLine(" ------------   ---------");
        Console.WriteLine($"  7 | 8 | 9     {jogo[6]} | {jogo[7]} | {jogo[8]} ");
        Console.WriteLine();
    }
}
