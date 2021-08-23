namespace tabuleiro
{
    class Peca
    {
        public Possicao Possicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Possicao possicao, Cor cor, Tabuleiro tab)
        {
            Possicao = possicao;
            Cor = cor;
            Tab = tab;
            QtdMovimentos = 0;
        }
    }
}
