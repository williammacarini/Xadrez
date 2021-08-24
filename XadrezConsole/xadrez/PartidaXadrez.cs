using System;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Termina { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Termina = false;
            ColocarPecas();
        }
        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudaJogador();

        }
        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if(tab.Pecass(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if(JogadorAtual != tab.Pecass(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.Pecass(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.Pecass(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        private void MudaJogador()
        {
            if(JogadorAtual == Cor.Branco)
            {
                JogadorAtual = Cor.Preto;
            }
            else
            {
                JogadorAtual = Cor.Branco;
            }
        }
        private void ColocarPecas()
        {
            tab.ColocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('c', 1).ToPossicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('c', 2).ToPossicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('d', 2).ToPossicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('e', 2).ToPossicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branco), new PosicaoXadrez('e', 1).ToPossicao());
            tab.ColocarPeca(new Rei(tab, Cor.Branco), new PosicaoXadrez('d', 1).ToPossicao());

            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('c', 7).ToPossicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('c', 8).ToPossicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('d', 7).ToPossicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('e', 7).ToPossicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('e', 8).ToPossicao());
            tab.ColocarPeca(new Rei(tab, Cor.Preto), new PosicaoXadrez('d', 8).ToPossicao());
        }
    }
}
