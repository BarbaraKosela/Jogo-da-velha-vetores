using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelhaMatriz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            string[,] campos;
            campos = new string[3, 3];

            campos[0, 0] = textBox1.Text;
            campos[0, 1] = textBox2.Text;
            campos[0, 2] = textBox3.Text;

            campos[1, 0] = textBox4.Text;
            campos[1, 1] = textBox5.Text;
            campos[1, 2] = textBox6.Text;

            campos[2, 0] = textBox7.Text;
            campos[2, 1] = textBox8.Text;
            campos[2, 2] = textBox9.Text;

            bool houveVencedorNaHorizontal = ProcurarHorizontal(campos);
            bool houveVencedorNaVertical = ProcurarVertical(campos);
            bool houveVencedorNaDiagonal = ProcurarDiagonal(campos);

            if (houveVencedorNaHorizontal == true)
                MessageBox.Show("Vitória!");
            else if (houveVencedorNaVertical == true)
                MessageBox.Show("Vitória!");
            else if (houveVencedorNaDiagonal == true)
                MessageBox.Show("Vitória!"); 
            else
                MessageBox.Show("Não houve vencedor");

        }

        static bool ProcurarHorizontal(string[,] vetor)
        {
            string resultadoX = "";
            string resultadoO = "";
            for (int horiz = 0; horiz < 3; horiz++)
            {
                for (int outroHoriz = 0; outroHoriz < 3; outroHoriz++)
                {
                    var linhaHorizontal = vetor[horiz, outroHoriz];
                    if (linhaHorizontal == "X")
                    {
                        resultadoX = linhaHorizontal + resultadoX;
                        if (resultadoX == "XXX")
                            return true;
                    }
                    else if (linhaHorizontal == "O")
                    {
                        resultadoO = linhaHorizontal + resultadoO;
                        if (resultadoO == "OOO")
                            return true;
                    }
                }
                resultadoX = "";
                resultadoO = "";
            }
            return false;
        }
        static bool ProcurarVertical(string[,] vetor)
        {
            string resultadoX = "";
            string resultadoO = "";
            for (int vert = 0; vert < 3; vert++)
            {
                for (int outroVert = 0; outroVert < 3; outroVert++)
                {
                    var linhaVertical = vetor[outroVert, vert];
                    if (linhaVertical == "X")
                    {
                        resultadoX = linhaVertical + resultadoX;
                        if (resultadoX == "XXX")
                            return true;
                    }
                    else if (linhaVertical == "O")
                    {
                        resultadoO = linhaVertical + resultadoO;
                        if (resultadoO == "OOO")
                            return true;
                    }
                }
                resultadoX = "";
                resultadoO = "";
            }
            return false;
        }
        static bool ProcurarDiagonal(string[,] vetor)
        {
            bool haVencedorDiagonal = false;
            while (!haVencedorDiagonal)
            {
                if (vetor[0, 0] == "X" && vetor[1, 1] == "X" && vetor[2, 2] == "X" ||
                    vetor[0, 0] == "O" && vetor[1, 1] == "O" && vetor[2, 2] == "O")
                    haVencedorDiagonal = true;
                else if (vetor[0, 2] == "X" && vetor[1, 1] == "X" && vetor[2, 0] == "X" ||
                    vetor[0, 2] == "O" && vetor[1, 1] == "O" && vetor[2, 0] == "O")
                    haVencedorDiagonal = true;
                else
                    return false;
            }
            return haVencedorDiagonal;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }
    }
}
