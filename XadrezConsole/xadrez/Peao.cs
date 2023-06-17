﻿using Tabuleiro;

namespace Xadrez
{
    public class Peao : Peca
    {

        private readonly PartidaXadrez Partida;

        public Peao(Tabuleiro.Tabuleiro tab, Cor Cor, PartidaXadrez partida) : base(tab, Cor)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tab.Peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new(0, 0);

            if (Cor == Cor.Branco)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p1 = new(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(p1) && Livre(p1) && Tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                // #jogadaespecial en passant
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
                else
                {
                    pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                    if (Tab.PosicaoValida(pos) && Livre(pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                    pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                    Posicao p2 = new(Posicao.Linha + 1, Posicao.Coluna);
                    if (Tab.PosicaoValida(p2) && Livre(p2) && Tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                    pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                    pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }

                    // #jogadaespecial en passant
                    if (Posicao.Linha == 4)
                    {
                        Posicao esquerda = new(Posicao.Linha, Posicao.Coluna - 1);
                        if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                        {
                            mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                        }
                        Posicao direita = new(Posicao.Linha, Posicao.Coluna + 1);
                        if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == Partida.VulneravelEnPassant)
                        {
                            mat[direita.Linha + 1, direita.Coluna] = true;
                        }
                    }
                }
            }
            return mat;
        }
    }
}
