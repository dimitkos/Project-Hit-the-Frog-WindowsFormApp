using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace FrogGame_MPPL17024
{
    public partial class Userform : Form
    {
        //tha to xrhsimopoihsoume gia na paiksei mousikh
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        Random random = new Random();
        int counter = 0;
        //akeraios gia ton arithmo xtyphmatwn sthn eikona
        int hitcounter;
        //akeraios gia ton arithmo xtyphmatwn sthn forma
        int mouseCounter = 0;
        //double poy moy ypologizei thn akriveia twn xtyphmatwn tou paikth
        double accuracy;


        public Userform()
        {
            InitializeComponent();
            //arxika to panel2 kai to textbox tha einai krymmena
            panel2.Hide();
            textBox2.Hide();
            //orizw xrwma sto panel1
            panel1.BackColor = Color.Aquamarine;
            //afhnw to koumpi button1 se default xrwma
            button1.BackColor = DefaultBackColor;
            //to vazoume etsi wste sthn arxh na mhn mporei na klikarei o paikths
            pictureBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //,e to pathma tou play energopoieitai
            pictureBox1.Enabled = true ;
            //otan paththei to koumpi start tha paizie mousikh oso o xrhsths paizei
            //leme loipon poio arxeio wav tha paiksei
            player.SoundLocation = "fgsound.wav";
            //kia sthn synexeia paizie mousikh
            player.Play();
            counter = 31;
            //kryvoume to panel1 wste o xrhsths mhn mporei na pathsei ta koympia dyskolias h allaksei user
            panel1.Hide();

            //edw kathorizetai to epipedo dyskolias
            if (easy.Checked == true)
            {
                //sto eykolo epipedo exoume 
                //thn energopoihsh ths antistrofhs metrhshs
                timer1.Enabled = true;
                //thn taxythta pou kineite o vatraxos
                timer2.Enabled = true;
                //kai megalwnoume thn forma wste na einai pio eykolo ston xrhsth
                this.WindowState = FormWindowState.Maximized;
            }
            //gia to pio dyskolo epipedo
            if (hard.Checked == true)
            {
                //energopoioume pali thn antistrofh metrhsh
                timer1.Enabled = true;
                //kai mesw tou timer3 o vatraxos kineitai pio grhgora
                timer3.Enabled = true;
                //mikrenoume thn forma wste na einai pio dyskolo gia ton xrhsth
                this.WindowState = FormWindowState.Normal;
                //epeidh ayksithike to epipedo dyskolias kanoume resize na mikrynei h eikona
                Size size = new Size(70, 70);
                pictureBox1.Size = size;


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //ton counter ton theloume gia thn antistrofh metrhsh
            counter--;
            //twra sto label3 se morfh string tha emfanizetai o xronos pou apomenei ston xrhsth
            label3.Text = counter.ToString();
            //tha ta xrhsimopoihsoume  gia na mas deixnei hmeromhnia kai wra poy epiakseo xrhsths pou tha einia mesa se txt
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("dddd, dd MMMM yyyy HH:mm");
            //otan teleiwsei o counter dhladh o xronos
            if (counter == 0)
            {
                //tote tha apenergopoihthoun oi treis timer otan liksei o xronos
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                //kai epipleon den tha mporoume na xtyphsoume ton vatraxo kai na paroume pontous
                pictureBox1.Enabled = false;
                //epishs me thn liksh ths antistrofhs metrhshs valame h forma na pernei to fysiologiko ths xrwma
                //ayto ginetai giati an o paikths evaze prwta to hard h forma tha xrwmatizontan
                //kai an phgaine na ksanapaiksei to easy  tha emene to prohgoumeno xrwma
                this.BackColor = DefaultBackColor;


                //me to poy teleivsei o xronos dhmioyrgei ena arxeio txt kai kanei append tous xrhstes pou paizoun

                using (StreamWriter sw1 = File.AppendText("frog.txt"))
                {
                    //kai typwnei sto txt to onoma xrhsth posa xtyphmata eixe kathws kai thn hmeromhnia
                    sw1.WriteLine("User " + textBox1.Text + " hits " + hitcounter + " times the frog in date " + formattedDate);
                }

                //tha dhmiourghsw ena deytero arxeio poy na krata mono ta scores
                using (StreamWriter sw1 = File.AppendText("frogscore.txt"))
                {
                    sw1.WriteLine(hitcounter);
                }
                //kai emfanizei mynhma ston xrhsth oti to paixnidi teleiwse kai posoys pontous exei
                MessageBox.Show("Game Over!Your score is: " + hitcounter.ToString());
                //afou teleiwse to paixnidi twra tha emfanisoume to panel2 poy einai h epilogh twn koympiwn
                panel2.Show();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //kathorizoume pou tha kineitai o vatraxos apo tis diastaseis ths formas afairw to width,height tis photos
            int x = random.Next(this.Width - pictureBox1.Width);
            int y = random.Next(this.Height - pictureBox1.Height);
            pictureBox1.Location = new Point(x, y);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //edw o timer3 einai gia to dyskolo epipedo kai gi ayto exoume xamhlo interval=400
            //pali kathorizoume tis diastaseis pou tha kineitai o vatraxos
            int x = random.Next(this.Width - pictureBox1.Width);
            int y = random.Next(this.Height - pictureBox1.Height);
            pictureBox1.Location = new Point(x, y);
            //edw allazoume to xrwma ths formas me enallages kokkino kai prasino wste na dyskoleyetai o paikths
            var colors = new[] { Color.Red, Color.Green };
            var index = DateTime.Now.Second % colors.Length;
            this.BackColor = colors[index];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //otan xtyphsei o xrhsths thn eikona tha pernei enan ponto kai etsi tha ayksanetai kata ena
            hitcounter++;
            //sthn synexeia sto label5 tha tou emfanizie poses fores exei xtyphsie ton vatraxo
            label5.Text = hitcounter.ToString();
            Accuracy(mouseCounter, hitcounter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int k;
            //ftiaxnw mia lista opoy tha pernei apo to arxeio txt fgscore ta score  tha tha kanei akeraious kai tha ta vazei mesa sthn lista
            List<int> scores = new List<int>();
            //kanw thn diadikasia na ta pernw apo to txt kai na ta vazw akeraious mesa sthn lista
            using (var sr = new StreamReader("frogscore.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    k = int.Parse(sr.ReadLine());
                    scores.Add(k);
                }

            }
            //sthn synexeia typwnw to megisto score ths listas
            MessageBox.Show("The highest score is " + scores.Max());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //arxika kanoume to textbox pou htan krymmeno na emfanistei
            textBox2.Show();
            //sthn synexeia apo to arxeio frog poy krataei ta score kai to usernametheloume na to riksoume sto textbox
            //wste o xrhsths na vlepei tis epidoseis tou
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader("frog.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    sb.AppendLine(sr.ReadLine());
                }
                textBox2.Text = sb.ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //kanw to textbox na einai mono gia read na mhn to peirazei o xrhsths
            textBox2.ReadOnly = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //me to pathma toy koumpiou o paikths pleon mporei na paiksei allo paixnidi 
            //kryvoume to panel2 kai to textbox
            textBox2.Hide();
            panel2.Hide();
            //kai emfanizoume to panel1 opoy ekei mporie na ksanagrapsei username kai na epileksei epipedo dyskolias
            panel1.Show();
            //mhdenizoume ton counter kai to antistoixo label
            hitcounter = 0;
            label5.Text = hitcounter.ToString();
            //sthn synexeia arxikopoiw wste na mhdenizie to accuracy apo thn arxh
            mouseCounter = 0;
            accuracy = 0;
            label6.Text = "Hit Accuracy: " + 0.ToString() + "%";
            //energopoioume 
            pictureBox1.Enabled = true;
            //otan ksekinhsei neo paixnidi tote sto textbox pou vazoume to username katharizei gia dieykolynsei
            textBox1.Clear();
        }

        private void Userform_FormClosing(object sender, FormClosingEventArgs e)
        {
            //an pathsoume x sthn forma panv deksia vgainoume apo thn efarmogh 
             Application.Exit();

        }

        private void Userform_MouseClick(object sender, MouseEventArgs e)
        {
            //an o timer 1 einai energopoihmenos mono tote na metraei ta click sthn forma
            if(timer1.Enabled==true)
            {
                mouseCounter++;
                Accuracy(mouseCounter, hitcounter);
            }
 
        }
        //ftiaksmae mia methodo opoy tha ypologizei thn akriveia xtyphmatwn toy paikth
        //aythn thn methodo thn kalw dyo fores kai sto mouseclick ths formas kais to picturebox esti vste to label6
        //na ananewnetai synexws se kath xtyphma pou dinoume eite sthn forma eite sthn eikona
        private string Accuracy(int mousecounter, int hitcounter)
        {
            //kanwntas casting ypologizoume to pososto,valame ton paragonta 0.000000001 dioti sthn arxh tha yphrxe
            //provlhma me thn diairesh me to mhden 
            accuracy = (double)(((double)hitcounter / (double)(mouseCounter + hitcounter + 0.000000001)) * 100);
            //sthn synexeia epistrefei sto label6 to lektiko mazi me thn akriveia strogkylopoihmenh
            return label6.Text = "Hit Accuracy: " + Math.Round(accuracy, 1).ToString() + "%";
        }
    }
}
