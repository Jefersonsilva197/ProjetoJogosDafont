using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoJogosDafont.Properties;
using System.Media;

namespace ProjetoJogosDafont
{
    public partial class Form1 : Form
    {
        bool aberta;
        bool trancada;
        bool visivel;
        String nomeJogador = "nada";
        String jogador = "Sem Opção";
        String computador = "Opção";
        int melhor = 0;
        int placarpc = 0;
        int placarjg;

        


        public Form1()
        {
            InitializeComponent();
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            //Codinção para iniciar o jogo
            if (rdb7.Checked == false && rdb3.Checked == false && rdb5.Checked == false && rdbPapel.Checked == false && rdbPedra.Checked == false && rdbTesoura.Checked == false)
            {
                MessageBox.Show("Por favor selecione a quantidade de rounds da partida !", "DAFONT GAMES", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Por favor selecione uma opção !", "DAFONT GAMES", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else if (rdb7.Checked == false && rdb3.Checked == false && rdb5.Checked == false)
            {
                MessageBox.Show("Por favor selecione a quantidade de rounds da partida !", "DAFONT GAMES", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rdbPapel.Checked == false && rdbPedra.Checked == false && rdbTesoura.Checked == false)
            {
                MessageBox.Show("Por favor selecione uma opção !", "DAFONT GAMES", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Random rdm = new Random();
                int sorteio = rdm.Next(1, 4);

                // Condição para Jogada do COMPUTADOR
                if (sorteio == 1)
                {
                    ptbcomputador.Image = Resources.pap;
                    computador = "Papel";
                }
                else if (sorteio == 2)
                {
                    ptbcomputador.Image = Resources.ped;
                    computador = "Pedra";
                }
                else if (sorteio == 3)
                {
                    ptbcomputador.Image = Resources.tes;
                    computador = "Tesoura";
                }
                // FIM DA Condição para Jogada do COMPUTADOR



                // CONDIÇOES PARA COMPARAÇÃO DOS ELEMENTOS
                if (jogador == computador)
                {
                    SoundPlayer sp = new
                    SoundPlayer(Application.StartupPath + "\\empatou.wav");
                    sp.Play();
                    ptbstatus.Image = Resources.empateB;
                }
                else if (jogador == "Papel" && computador == "Pedra")
                {
                    SoundPlayer sp = new
                    SoundPlayer(Application.StartupPath + "\\acertou.wav");
                    sp.Play();
                    ptbstatus.Image = Resources.ganhouB;
                    placarjg++;
                    lblpontosJ.Text = placarjg.ToString();
                }
                else if (jogador == "Papel" && computador == "Tesoura")
                {
                    SoundPlayer sp = new
                    SoundPlayer(Application.StartupPath + "\\errou.wav");
                    sp.Play();
                    ptbstatus.Image = Resources.perdeuB;
                    placarpc++;
                    lblpontosP.Text = placarpc.ToString();
                }
                else if (jogador == "Pedra" && computador == "Tesoura")
                {
                    SoundPlayer sp = new
                    SoundPlayer(Application.StartupPath + "\\acertou.wav");
                    sp.Play();
                    ptbstatus.Image = Resources.ganhouB;
                    placarjg++;
                    lblpontosJ.Text = placarjg.ToString();
                }
                else if (jogador == "Pedra" && computador == "Papel")
                {
                    SoundPlayer sp = new
                    SoundPlayer(Application.StartupPath + "\\errou.wav");
                    sp.Play();
                    ptbstatus.Image = Resources.perdeuB;
                    placarpc++;
                    lblpontosP.Text = placarpc.ToString();
                }
                else if (jogador == "Tesoura" && computador == "Papel")
                {
                    SoundPlayer sp = new
                    SoundPlayer(Application.StartupPath + "\\acertou.wav");
                    sp.Play();
                    ptbstatus.Image = Resources.ganhouB;
                    placarjg++;
                    lblpontosJ.Text = placarjg.ToString();
                }
                else if (jogador == "Tesoura" && computador == "Pedra")
                {
                    SoundPlayer sp = new
                     SoundPlayer(Application.StartupPath + "\\errou.wav");
                    sp.Play();
                    ptbstatus.Image = Resources.perdeuB;
                    placarpc++;
                    lblpontosP.Text = placarpc.ToString();
                }
                // FINAL DAS CONDIÇOES PARA COMPARAÇÃO DOS ELEMENTOS 




                //CONDIÇOES PARA SABER O GANHADOR 
                if (placarpc == melhor)
                {
                    SoundPlayer sp = new
                    SoundPlayer(Application.StartupPath + "\\perdeu.wav");
                    sp.Play();
                    MessageBox.Show("Você Perdeu ! Pressione OK ! Para novo jogo", "DAFONT GAMES", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    placarpc = 0;
                    placarjg = 0;
                    lblpontosP.Text = placarpc.ToString();
                    lblpontosJ.Text = placarjg.ToString();

                }
                else if (placarjg == melhor)
                {
                    SoundPlayer sp = new
                    SoundPlayer(Application.StartupPath + "\\venceu.wav");
                    sp.Play();
                    MessageBox.Show("Você Ganhou ! Pressione OK ! Para novo jogo", "DAFONT GAMES", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    placarpc = 0;
                    placarjg = 0;
                    lblpontosP.Text = placarpc.ToString();
                    lblpontosJ.Text = placarjg.ToString();
                }
                //FINAL DAS CONDIÇOES PARA SABER O GANHADOR 



            }

        }  

        private void rdbPedra_CheckedChanged(object sender, EventArgs e)
        {
            // BOTAO RADIOBUTTON PEDRA
            SoundPlayer sp = new
            SoundPlayer(Application.StartupPath + "\\selecionaOP.wav");
            sp.Play();
            ptbjogador.Image = Resources.ped; 
            jogador = "Pedra";
        }

        private void rdbPapel_CheckedChanged(object sender, EventArgs e)
        {
            // BOTAO RADIOBUTTON PAPEL 
            SoundPlayer sp = new
            SoundPlayer(Application.StartupPath + "\\selecionaOP.wav");
            sp.Play();
            ptbjogador.Image = Resources.pap;
            jogador = "Papel";
        }

        private void rdbTesoura_CheckedChanged(object sender, EventArgs e)
        {
            // BOTAO RADIOBUTTON TESOURA 
            SoundPlayer sp = new
            SoundPlayer(Application.StartupPath + "\\selecionaOP.wav");
            sp.Play();
            ptbjogador.Image = Resources.tes;
            jogador = "Tesoura";
        }

        private void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            SoundPlayer sp = new
            SoundPlayer(Application.StartupPath + "\\selecionaRD.wav");
            sp.Play();
            melhor = 3; // BOTAO RADIOBUTTON 3 
        }

        private void rdb5_CheckedChanged(object sender, EventArgs e)
        {
            SoundPlayer sp = new
            SoundPlayer(Application.StartupPath + "\\selecionaRD.wav");
            sp.Play();
            melhor = 5; // BOTAO RADIOBUTTON 5 
        }

        private void rdb7_CheckedChanged(object sender, EventArgs e)
        {
            SoundPlayer sp = new
            SoundPlayer(Application.StartupPath + "\\selecionaRD.wav");
            sp.Play();
            melhor = 7; // BOTAO RADIOBUTTON 7 
        }

        private void button1_Click(object sender, EventArgs e)
        {
             // BOTAO PARA ZERAR O JOGO
            SoundPlayer sp = new
            SoundPlayer(Application.StartupPath + "\\zerarplacar.wav");
            sp.Play();
            placarpc = 0;
            placarjg = 0;
            lblpontosP.Text = placarpc.ToString();
            lblpontosJ.Text = placarjg.ToString();
            // FINAL DA CONDIÇÃO BOTAO PARA ZERAR O JOGO
        }

        private void btnPortoes_Click(object sender, EventArgs e)
        {
            ptbportao.Visible = false;
            nomeJogador = txtNomeJogador.Text;
            lblnomeJogadorPortoes.Text = nomeJogador;
            lblNomeJogadorjokenpo.Text = nomeJogador;

            if (nomeJogador == "")
            {
                MessageBox.Show("Por Favor Digite seu nome!", "DAFONT GAMES", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SoundPlayer sp = new
                SoundPlayer(Application.StartupPath + "\\selecionaRD.wav");
                sp.Play();
                tabControl1.SelectedTab = tabPage3; // MENU PARA SELECIONAR JOGO DOS PORTOES
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            nomeJogador = txtNomeJogador.Text;
            lblNomeJogadorjokenpo.Text = nomeJogador;
            lblJogador.Text = nomeJogador;
            lblnomeJogadorPortoes.Text = nomeJogador;

            if (nomeJogador == "")
            {
                MessageBox.Show("Por Favor Digite seu nome!", "DAFONT GAMES", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SoundPlayer sp = new
                SoundPlayer(Application.StartupPath + "\\selecionaRD.wav");
                sp.Play();
                tabControl1.SelectedTab = tabPage2; // MENU PARA SELECIONAR JOKENPO
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); // BOTAO PARA SAIR DO JOGO.
        }

        private void btnabrir_Click(object sender, EventArgs e)
        {
            // BOTAO ABRIR PORTAO
            if (aberta == false && trancada == false)
            {

                SoundPlayer sp = new
                SoundPlayer(Application.StartupPath + "\\abrir.wav");
                sp.Play();
                ptbportao.Image = Resources.opened;
                aberta = true;
                //CONDIÇAO PICTURE BOX PORTA DOS MONSTROS SA
                Random rdm = new Random();
                int porta = rdm.Next(5, 11);

                if (porta == 5)
                {
                    ptbPortaMonstro.Image = Resources.M1;
                    lblRecebeMonstro.Text = "BOO";
                    lblMonstro.Text = "CRIANÇA:";
                    
                }
                else if (porta == 6)
                {
                    ptbPortaMonstro.Image = Resources.M2;
                    lblRecebeMonstro.Text = "CELIA";
                    lblMonstro.Text = "MONSTRO:";
                }
                else if (porta == 7)
                {
                    ptbPortaMonstro.Image = Resources.M4;
                    lblRecebeMonstro.Text = "GEORGE S.";
                    lblMonstro.Text = "MONSTRO:";
                    
                }
                else if (porta == 8)
                {
                    ptbPortaMonstro.Image = Resources.M3;
                    lblRecebeMonstro.Text = "MIKE WAZOWSKI";
                    lblMonstro.Text = "MONSTRO:";

                }
                else if (porta == 9)
                {
                    ptbPortaMonstro.Image = Resources.M5;
                    lblRecebeMonstro.Text = "RANDALL";
                    lblMonstro.Text = "MONSTRO:";

                }
                else if (porta == 10)
                {
                    ptbPortaMonstro.Image = Resources.M6;
                    lblRecebeMonstro.Text = "WATERNOOSE";
                    lblMonstro.Text = "MONSTRO:";

                }
                // FIM DA Condição para Jogada do COMPUTADOR

            }

        }

        private void btnfechar_Click(object sender, EventArgs e)
        {
            // BOTAO FECHAR PORTAO
            if (aberta == true && trancada == false)
            {
                SoundPlayer sp = new
                SoundPlayer(Application.StartupPath + "\\fechar.wav");
                sp.Play();
                ptbportao.Image = Resources.closed;
                aberta = false;
                ptbPortaMonstro.Image = Resources.FUNDOPIC;
                lblRecebeMonstro.Text = "-";
            }
        }

        private void btntrancar_Click(object sender, EventArgs e)
        {
            // BOTAO TRANCAR PORTAO
            if (aberta == false && trancada == false)
            {
                SoundPlayer sp = new
                SoundPlayer(Application.StartupPath + "\\trancar.wav");
                sp.Play();
                ptbportao.Image = Resources.locked;
                aberta = false;
                trancada = true;
                ptbPortaMonstro.Image = Resources.FUNDOPICTRANCADA;

            }
        }

        private void btndestrancar_Click(object sender, EventArgs e)
        {
            // BOTAO DESTRANCAR PORTAO
            if (aberta == false && trancada == true)
            {
                SoundPlayer sp = new
                SoundPlayer(Application.StartupPath + "\\destranca.wav");
                sp.Play();
                ptbportao.Image = Resources.closed;
                aberta = false;
                trancada = false;
                ptbPortaMonstro.Image = Resources.FUNDOPIC;
            }
        }

        private void txtNomeJogador_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (visivel == true) // IMAGEM VISIVEL
            {
                ptbPortaMonstro.Visible = true;
                ptbportao.Visible = false; // ESCONDE IMAGEM
                btnmostrar.Text = "MOSTRAR";
                visivel = false; // visivel PARA FALSO (INVISIVEL)
                lblMonstro.Visible = true; // Esconder label monstros
                lblRecebeMonstro.Visible = true; // Esconder label recebe Monstros
            }

            else if (visivel == false) // IMAGEM INVISIVEL
            {
                ptbPortaMonstro.Visible = false;
                ptbportao.Visible = true; // MOSTRANDO IMAGEM
                btnmostrar.Text = "ESCONDER";
                visivel = true; // mundando visivel para verdadeiro
                lblMonstro.Visible = false; // Esconder label monstros
                lblRecebeMonstro.Visible = false; // Esconder label recebe Monstros
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        
           
            

        
    }
}
