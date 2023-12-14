using Snake_Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Snake_Game
{
    class Game
    {
        public Keys Direction { get; set; } //enumerador para armazenar qual tecla foi clicada
        public Keys Arrow { get; set; }

        //referenciar componentes de formulários no código abaixo

        private Timer Frame { get; set; }
        private Label LbPontuacao { get; set; }
        private Panel PnTela { get; set; }

        private int pontos = 0; //varíável para incrementar pontuação

        private Food Food; //classe para trabalhar com a classe da comida
        private Snake Snake; //classe para trabalhar com a classe da cobra

        private Bitmap offScreenBitmap;//permite trabalhar com os pixels da tela

        private Graphics bitmapGraph; //desenhar os componentes
        private Graphics screenGraph; //gerar a tela em branco

        public Game(ref Timer timer, ref Label label, ref Panel panel); //contrutor para referenciar e refletir no formulário
        PnTela = Panel; // recebendo os valores
        Frame = timer; // recebendo os valores
        LbPontuacao = Label;// recebendo os valores

        offScreenBitmap = new Bitmap(428,428); //criando as medidas da tela
        Snake = new Snake();//iniciando classes
        Food = new Food();//iniciando classes
        Direction = Keys.Left; //setando direção inicial para andar
        Arrow = Direction; //setando direção inicial para andar
             
        public void StartGame() //construtor para iniciar o jogo
        {
            Snake.Reset();
            Food.CreateFood();
            Direction = Keys.Left;
            bitmapGraph = Graphics.FromImage(offScreenBitmap);
            screenGraph = PnTela.CreateGraphics();
            Frame.Enabled = true

        }
        public void Tick();
            if(((Arrow==Keys.Left)&&(Direction!=Keys.Right)|| //regras de movimentos
            ((Arrow==Keys.Right)&&(Direction!=Keys.Left))||
            ((Arrow==Keys.Up)&&(Direction!=Keys.Down))||
            ((Arrow==Keys.Down)&&(Direction!=Keys.Up)))
    }
    switch (Direction{ //movimentos
	    case Keys.Left:
            Snake.left();
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

    bitmapGraph.Clear(Color.White); //cria o mapa

    bitmapGraph.DrawImage(Properties.Resources.food(Food.Location.X * 15), (Food.Location.X * 15, 15, 15));

    bool gameOver = false; //finaliza jogo caso cabeça colidir com corpo

for (int i = 0; i < Snake.Length; i++)
{
    if (i == 0) //verificação para mudar a cor da cabeça da cobra
    {
        bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#000000")), (Snake.Location.X[i] * 15), (Snake.Location.Y[i] * 15), 15, 15)};
    }
    else
{
    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#4F4F4F")), (Snake.Location.X[i] * 15), (Snake.Location.Y[i] * 15), 15, 15)};
}
if ((Snake.Location[int] == Snake.Location[0])&& (i > 0))
{
    gameOver = true;   
}
    }
if (gameOver) {


}
screenGraph.DrawImage(offScreenBitmap, 0, 0);
public void CheckCollision() //verifica colisao
{
    if (Snake.Location[0] == Food.Location)
    {
        Snake.Eat();
        Food.CreateFood();
        pontos += 9;
        LbPontuacao.Text = "PONTOS: " + pontos; 

    }
}
public void GameOver()
    {
    Frame.Enabled = false;
    bitmapGraph.Dispose();
    screenGraph.Dispose();
    LbPontuacao.Text = "PONTOS: 0";
    MessageBox.Show("Game Over");


    }
}
