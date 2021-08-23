namespace tabuleiro
{
    class Possicao
    {
        public int Linha{ get; set; }
        public int Coluna { get; set; }

        public Possicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        public override string ToString()
        {
            return Linha
                + ", "
                + Coluna;
        }
    }
}
