using System;
using tabuleiro;
using xadrez;


namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Torre(tab, Cor.Preto), new Possicao(0, 0));
            tab.ColocarPeca(new Torre(tab, Cor.Preto), new Possicao(1, 3));
            tab.ColocarPeca(new Rei(tab, Cor.Preto), new Possicao(2, 4));

            Tela.ImprimirTabuleiro(tab);

            Console.WriteLine(tab);
        }
    }
}
