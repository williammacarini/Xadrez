using tabuleiro;

namespace xadrez
{

    class Peao : Peca
    {

        private PartidaXadrez Partida;

        public Peao(Tabuleiro tab, Cor Cor, PartidaXadrez partida) : base(tab, Cor)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = Tab.Pecass(pos);
            return p != null && p.Cor != Cor;
        }

        private bool livre(Posicao pos)
        {
            return Tab.Pecass(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branco)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p1 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(p1) && livre(p1) && Tab.PosicaoValida(pos) && livre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                // #jogadaespecial en passant
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && existeInimigo(esquerda) && Tab.Pecass(esquerda) == Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && existeInimigo(direita) && Tab.Pecass(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
                else
                {
                    pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                    if (Tab.PosicaoValida(pos) && livre(pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                    pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                    Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                    if (Tab.PosicaoValida(p2) && livre(p2) && Tab.PosicaoValida(pos) && livre(pos) && QtdMovimentos == 0)
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                    pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(pos) && existeInimigo(pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                    pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(pos) && existeInimigo(pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }

                    // #jogadaespecial en passant
                    if (Posicao.Linha == 4)
                    {
                        Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                        if (Tab.PosicaoValida(esquerda) && existeInimigo(esquerda) && Tab.Pecass(esquerda) == Partida.VulneravelEnPassant)
                        {
                            mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                        }
                        Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                        if (Tab.PosicaoValida(direita) && existeInimigo(direita) && Tab.Pecass(direita) == Partida.VulneravelEnPassant)
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
