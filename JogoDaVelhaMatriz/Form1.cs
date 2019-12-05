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
            bool verificarCampoVazio = VerificarCampoVazio(campos);

            if (houveVencedorNaHorizontal == true)
                MessageBox.Show("Vitória!");
            else if (houveVencedorNaVertical == true)
                MessageBox.Show("Vitória!");
            else if (houveVencedorNaDiagonal == true)
                MessageBox.Show("Vitória!");
            else if (verificarCampoVazio == true)
                MessageBox.Show("Campos estão vazios, ou não foram preenchidos com 'o' ou 'x'.", "Atenção! Digite novamente!");
            else
                MessageBox.Show("Empate!");

        }

        static bool ProcurarHorizontal(string[,] vetor)
        {
            string resultadoX = "";
            string resultadoO = "";
            int contador = 0;
            foreach (string campos in vetor)
            {
                contador++;
                if (campos == "x")
                {
                    resultadoX = campos + resultadoX;
                    if (resultadoX == "xxx")
                        return true;
                }
                else if (campos == "o")
                {
                    resultadoO = campos + resultadoO;
                    if (resultadoO == "ooo")
                        return true;
                }
                if (contador == 3)
                {
                    resultadoX = "";
                    resultadoO = "";
                    contador = 0;
                }
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
                    if (linhaVertical == "x")
                    {
                        resultadoX = linhaVertical + resultadoX;
                        if (resultadoX == "xxx")
                            return true;
                    }
                    else if (linhaVertical == "o")
                    {
                        resultadoO = linhaVertical + resultadoO;
                        if (resultadoO == "ooo")
                            return true;
                    }
                    else if (linhaVertical == "")
                        return false;
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
                if(vetor[0, 0] == vetor[1, 1] && vetor[1, 1] == vetor[2, 2])
                    haVencedorDiagonal = true;
                else if (vetor[0, 2] == vetor[1, 1] && vetor[1, 1] == vetor[2, 0])
                    haVencedorDiagonal = true;
                else
                    return false;
            }
            return haVencedorDiagonal;
        }

        static bool VerificarCampoVazio(string[,] vetor)
        {
            for (int linha = 0; linha < 3; linha++)
            {
                for (int outraLinha = 0; outraLinha < 3; outraLinha++)
                {
                    var linhas = vetor[outraLinha, linha];
                    if (linhas == string.Empty)
                        return true;
                }

            }
            return false;
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
