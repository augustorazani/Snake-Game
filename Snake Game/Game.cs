using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    internal class Game
    {
        public Keys Direction { get; set; } //enumerador para armazenar qual tecla foi clicada
        public Keys Arrow { get; set; } //enumerador teclado

        //referenciar componentes de formulários no código abaixo

        private Timer Frame { get; set; }
        private Label LbPontuacao { get; set; }
        private Panel PnTela { get; set; }

        private int pontos = 0; //varíável para incrementar pontuação

        public Game(ref Timer timer, ref Label label, ref Panel panel)
        {//contrutor para referenciar e refletir no formulário
            PnTela = panel; // recebendo os valores
            Frame = timer; // recebendo os valores
            LbPontuacao = label;// recebendo os valores
            Snake = new Snake(); // iniciando classes
            Food = new Food(); // iniciando classes
            Direction = Keys.Left; // setando direção inicial para andar
            Arrow = Direction; // setando direção inicial para andar
            offScreenBitmap = new Bitmap(428, 428); // criando as medidas da tela
        } //construtor com parâmetros referência

        #region Classes
        private Food Food; //classe para trabalhar com a classe da comida
        private Snake Snake; //classe para trabalhar com a classe da cobra

        private Bitmap offScreenBitmap;//permite trabalhar com os pixels da tela

        private Graphics bitmapGraph; //desenhar os componentes
        private Graphics screenGraph; //gerar a tela em branco
        #endregion

        #region Métodos
        public void StartGame()
        {
            Snake.Reset();
            Food.CreateFood();
            Direction = Keys.Left;
            bitmapGraph = Graphics.FromImage(offScreenBitmap);
            screenGraph = PnTela.CreateGraphics();
            Frame.Enabled = true;
        }//inicializa os componentes no início do jogo

        public void Tick()
        {
            if //lógica para validar a direção que a cobra irá
                (((Arrow == Keys.Left) && (Direction != Keys.Right)) ||
                ((Arrow == Keys.Right) && (Direction != Keys.Left)) ||
                ((Arrow == Keys.Up) && (Direction != Keys.Down)) ||
                ((Arrow == Keys.Down) && (Direction != Keys.Up)))
            {
                Direction = Arrow;
            }

            switch (Direction)
            {
                case Keys.Left:
                    Snake.Left();
                    break;

                case Keys.Right:
                    Snake.Right();
                    break;

                case Keys.Up:
                    Snake.Up();
                    break;

                case Keys.Down:
                    Snake.Down();
                    break;
            }

            bitmapGraph.Clear(Color.White); //limpa os componentes criados

            bitmapGraph.DrawImage(Properties.Resources.food, (Food.Location.X * 15), (Food.Location.Y * 15), 15, 15); //acessa a imagem enviada como RECURSO

            bool gameOver = false;

            for (int i = 0; i < Snake.Length; i++)
            {
                if (i == 0)
                {
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#006400")), (Snake.Location[i].X * 15), (Snake.Location[i].Y * 15), 15, 15); //acessa a imagem enviada como RECURSO
                }
                else
                {
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#00FF00")), (Snake.Location[i].X * 15), (Snake.Location[i].Y * 15), 15, 15);
                }

                if ((Snake.Location[i] == Snake.Location[0]) && (i > 0)) //se a localização da cabeça da cobra ocupar a mesma posição do corpo, irá encerrar o jogo
                {
                    gameOver = true;
                }   
            }

            screenGraph.DrawImage(offScreenBitmap, 0, 0);

            CheckCollision();

            if (gameOver)
            {
                GameOver();
            }
        } //update que irá rodar a cada 100ms

        public void CheckCollision()
        {
            if (Snake.Location[0] == Food.Location)
            {
                Snake.Eat();
                Food.CreateFood();
                pontos += 10;
                LbPontuacao.Text = "PONTOS: " + pontos;
            }
        } //verifica colisão da cabeça com o corpo

        public void GameOver()
        {
            Frame.Enabled = false;
            bitmapGraph.Dispose();
            screenGraph.Dispose();
            LbPontuacao.Text = "PONTOS: 0";
            MessageBox.Show("Game Over");

        }
        #endregion

    }
}