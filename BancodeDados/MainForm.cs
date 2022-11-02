using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace BancodeDados
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        void Limpar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            label1.Text = richTextBox1.Lines.Length.ToString();
        }
        
        void Button1Click(object sender, EventArgs e) //add
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") 
            {
                MessageBox.Show("Insira as informações em todos os campos.");
                return;
            }
            else {
                string linhaNova = textBox1.Text + "\t" + textBox2.Text + "\t" + textBox3.Text;
                if (int.Parse(label1.Text) == richTextBox1.Lines.Length) {
                    richTextBox1.Text = richTextBox1.Text + "\n" + linhaNova;
                }
                else 
                {
                    string linhaAntes = richTextBox1.Lines[int.Parse(label1.Text)];
                    richTextBox1.Text = richTextBox1.Text.Replace(linhaAntes, linhaNova);
                }
            }
            richTextBox1.SaveFile("funcionarios.txt", RichTextBoxStreamType.PlainText);
            Limpar();
            label1.Text = richTextBox1.Lines.Length.ToString();
        }
        void Button2Click(object sender, EventArgs e) //buscar
        {
            if (textBox4.Text == "") 
            {
                MessageBox.Show("Insira um número");
                return;
            }
            try {
        
                int numLinha = int.Parse(textBox4.Text);
                string linha = richTextBox1.Lines[numLinha];
           
                string[] dados = linha.Split('\t');
                textBox1.Text = dados[0]; //nome
                textBox2.Text = dados[1]; //endereço
                textBox3.Text = dados[2]; //salário
            }
            
            catch {
                MessageBox.Show("Número inválido, tente novamente.");
            }    
            
            label1.Text = textBox4.Text;
            textBox4.Clear(); 
        }
        void MainFormLoad(object sender, EventArgs e)
        {    
            try { 
                richTextBox1.LoadFile("funcionarios.txt", RichTextBoxStreamType.PlainText);
            }
            
            catch (IOException exc) 
            { 
                richTextBox1.SaveFile("funcionarios.txt", RichTextBoxStreamType.PlainText);
                MessageBox.Show("Primeira vez aqui ?\nArquivo inicial não encontrado.\nCriando arquivo: funcionarios");
            }
            label1.Text = richTextBox1.Lines.Length.ToString();
        }
        void Button3Click(object sender, EventArgs e) //botão limpar
        {
            Limpar();
        }
        void Button4Click(object sender, EventArgs e) //botão novo
        {
            Limpar();
            richTextBox1.Clear();
            label1.Text = richTextBox1.Lines.Length.ToString();
        }
    }
}
