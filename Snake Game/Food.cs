using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    internal class Food{

        public Point Location { get; private set; } //possibilita utilizar coordenadas X e Y

        public void CreateFood() //cria a comida
        {
            Random rnd = new Random(); //gerar as comidas em números aleatórios
            Location = new Point(rnd.Next(0,27), rnd.Next(0, 27)) ; //determina as dimensões da área
        }
        
    }
}
