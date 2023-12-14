using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        PnTela = panel; // recebendo os valores
            Frame = timer; // recebendo os valores
            LbPontuacao = Label;// recebendo os valores

            offScreenBitmap = new Bitmap(428,428); //criando as medidas da tela
        Snake = new Snake();//iniciando classes
        Food = new Food();//iniciando classes
        Direction = Keys.Left; //setando direção inicial para andar
            Arrow = Direction; //setando direção inicial para andar

            
    }


    }
}
 