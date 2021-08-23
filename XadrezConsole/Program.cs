using System;
using tabuleiro;
using xadrez;


namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /* try
             {
                 Tabuleiro tab = new Tabuleiro(8, 8);

                 tab.ColocarPeca(new Torre(tab, Cor.Preto), new Possicao(0, 0));
                 tab.ColocarPeca(new Torre(tab, Cor.Preto), new Possicao(1, 3));
                 tab.ColocarPeca(new Rei(tab, Cor.Preto), new Possicao(0, 2));

                 Tela.ImprimirTabuleiro(tab);

                 Console.WriteLine(tab);
             }
             catch(TabuleiroException e)
             {
                 Console.WriteLine(e.Message);
             }*/
            PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            Console.WriteLine(pos);
            Console.WriteLine(pos.ToPossicao());
        }
    }
}
