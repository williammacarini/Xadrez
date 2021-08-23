using System;
using tabuleiro;
using xadrez;


namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaXadrez partida = new PartidaXadrez();

                while (!partida.Termina)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicao().ToPossicao();

                    bool[,] posicaoPossiveis = partida.tab.Pecass(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab, posicaoPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicao().ToPossicao();

                    partida.ExecutarMovimento(origem, destino);
                }
                

                Console.WriteLine(partida.tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            /*PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            Console.WriteLine(pos);
            Console.WriteLine(pos.ToPossicao());*/
        }
    }
}
