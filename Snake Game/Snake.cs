using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Snake
    {
        public int Length { get; private set; } //comprimento atual da cobra

        public Point[] Location { get; private set; } //localização em array pois a cobra pode ocupar mais de 1 quadrado

        public Snake() { //construtor para armazenar a posição máxima que a cobra poderá ocupar

            Location = new Point[28 * 28];
            Reset();
        }

        public void Reset() { //determinar a posição inicial sempre que iniciar um novo jogo
            Length = 5; //comprimento inicial de 5 quadrados (pode ser alterado)
            for (int i = 0; i < Length; i++) { //loop para setar a posição inicial
                Location[i].X = 12;
                Location[i].Y = 12;
            }
        }
        public void Follow() {//método follow para o corpo da cobra seguir a cabeça e não separar
            for (int i = Length - 1; i > 0; i--)
            {
                Location[i] = Location[i - 1];
            
            }

        }
        //COMANDOS PARA IR CIMA/BAIXO/ESQ/DIR
        public void Up() {
            Follow(); //sempre será usado para corpo & cabeça acompanharem um ao outro
            Location[0].Y--; //location 0 é a cabeça do corpo inicial (4 seria o rabo)
            if (Location[0].Y < 0)
            {
                Location[0].Y += 28;    //determina se estiver atingindo o topo, surgirá abaixo
            }
        
        }
        public void Down() {
            Follow(); 
            Location[0].Y++; 
            if (Location[0].Y > 27)
            {
                Location[0].Y -= 28;
            }
        }
        public void Left() {
            Follow();
            Location[0].X--;
            if (Location[0].X < 0)
            {
                Location[0].X += 28;
            }
        }
        public void Right() {
            Follow();
            Location[0].X++;
            if (Location[0].X > 27)
            {
                Location[0].X -= 28;
            }
        }

        public void Eat () //método para verificação se a cobra comeu
        {
            Length++;
        }
    }
}