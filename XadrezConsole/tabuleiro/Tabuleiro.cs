namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }
        public Peca Pecass(int linhas, int colunas)
        {
            return Pecas[linhas, colunas];
        }
        public Peca Pecass(Possicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }
        public bool ExistePeca(Possicao pos)
        {
            ValidarPosicao(pos);
            return Pecass(pos) != null;
        }
        public void ColocarPeca(Peca p, Possicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Possicao = pos;
        }
        public bool PosicaoValida(Possicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }
        public void ValidarPosicao(Possicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
    }
}
