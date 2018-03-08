using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Gra
{
    public partial class Puzle : Form
    {


        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private PictureBox flaga;
        private Label tekst;
        private Label tekst2;
        private Button memorki;

        PictureBox Klikniety1 = null;
        PictureBox Klikniety2 = null;

        /// <summary>
        /// lista punktów z lokalizacją PictureBoxów
        /// </summary>
        public List<Point> listapunktow = new List<Point>();
        Point punkt1 = new Point(100, 1);
        Point punkt2 = new Point(250, 1);
        Point punkt3 = new Point(400, 1);
        Point punkt4 = new Point(550, 1);
        Point punkt5 = new Point(100, 150);
        Point punkt6 = new Point(250, 150);
        Point punkt7 = new Point(400, 150);
        Point punkt8 = new Point(550, 150);
        Point punkt9 = new Point(100, 300);
        Point punkt10 = new Point(250, 300);
        Point punkt11 = new Point(400, 300);
        Point punkt12 = new Point(550, 300);
        /// <summary>
        /// zmienna odpowiadająca za zliczanie pętli trzeciego etapu
        /// </summary>
        int liczniktrzeciejtury = -1;
        /// <summary>
        /// licznik pictureboxów
        /// </summary>
        private int liczbaplytek = 0; // licznik pictureboxów
       /// <summary>
      /// licznik tury
        /// </summary>
        private int tura = 0; // licznik tury
        /// <summary>
        /// licznik bledów
        /// </summary>
        private int lbled; // licznik bledów

        /// <summary>
        /// Lista PictureBoxów uzywanych w grze ( bez PB flaga)
        /// </summary>
        public List<PictureBox> listaplytek = new List<PictureBox>();

        /// <summary>
        /// kopia listy punktow do wykonywania operacji
        /// </summary>
        public List<Point> kopia = new List<Point>();
        private PictureBox plytka1;
        private PictureBox plytka1_duplikat;
        private PictureBox plytka2;
        private PictureBox plytka2_duplikat;
        private PictureBox plytka3;
        private PictureBox plytka3_duplikat;
        private PictureBox plytka4;
        private PictureBox plytka4_duplikat;
        private PictureBox plytka5;
        private PictureBox plytka5_duplikat;
        private PictureBox plytka6;
        private PictureBox plytka6_duplikat;


        /// <summary>
        /// Główna funkcja
        /// </summary>

        public Puzle()
        {
            InitializeComponent();
            listapunktow.Add(punkt1);
            listapunktow.Add(punkt2);
            listapunktow.Add(punkt3);
            listapunktow.Add(punkt4);
            listapunktow.Add(punkt5);
            listapunktow.Add(punkt6);
            listapunktow.Add(punkt7);
            listapunktow.Add(punkt8);
            listapunktow.Add(punkt9);
            listapunktow.Add(punkt10);
            listapunktow.Add(punkt11);
            listapunktow.Add(punkt12);
            kopia = listapunktow.ToList();
            myTimer.Tick += MyTimer_Tick;
            myTimer.Interval = 2200; 


            this.BackgroundImage = Properties.Resources.tlo;

            #region plytki

            memorki = new Button();
            memorki.Location = new System.Drawing.Point(1, 500);
            this.Controls.Add(memorki);
            memorki.Click += Memorki_Click;
            memorki.Text = "Poziom 1";

            tekst = new Label();
            tekst.Width = 150;
            tekst.Height = 20;
            tekst.Location = new System.Drawing.Point(580, 450);
            this.Controls.Add(tekst);
            tekst.Text = "Nazwa Kraju";
             lbled=0;
            tekst2 = new Label();
            tekst2.Width = 150;
            tekst2.Height = 20;
            tekst2.Location = new System.Drawing.Point(100, 500);
            this.Controls.Add(tekst2);
            tekst2.Text = Convert.ToString(lbled);
;

            flaga = new PictureBox();
            RysujFlage(this, 580, 470, flaga);
            flaga.Image = Properties.Resources.znak;
            this.Controls.Add(flaga);

            plytka1 = new PictureBox();
            plytka1.Tag = "Polska";
            RysujFlage(this, 100, 1, plytka1);
            plytka1.Image = Properties.Resources.pl;
            // listaplytek.Add(plytka1);
            this.Controls.Add(plytka1);
            plytka1.Click += Flaga_Click;

            plytka1_duplikat = new PictureBox();
            plytka1_duplikat.Tag = "Polska";
            RysujFlage(this, 250, 1, plytka1_duplikat);
            plytka1_duplikat.Image = Properties.Resources.pl;
            listaplytek.Add(plytka1_duplikat);
            this.Controls.Add(plytka1_duplikat);
            plytka1_duplikat.Click += Plytka1_duplikat_Click;

            plytka2 = new PictureBox();
            plytka2.Tag = "Stany Zjednoczone";
            RysujFlage(this, 400, 1, plytka2);
            plytka2.Image = Properties.Resources.us;
            //   listaplytek.Add(plytka2);
            this.Controls.Add(plytka2);
            plytka2.Click += Plytka2_Click;

            plytka2_duplikat = new PictureBox();
            plytka2_duplikat.Tag = "Stany Zjednoczone";
            RysujFlage(this, 550, 1, plytka2_duplikat);
            plytka2_duplikat.Image = Properties.Resources.us;
            listaplytek.Add(plytka2_duplikat);
            this.Controls.Add(plytka2_duplikat);
            plytka2_duplikat.Click += Plytka2_duplikat_Click;

            plytka4 = new PictureBox();
            plytka4.Tag = "Rosja";
            RysujFlage(this, 400, 1, plytka4);
            plytka4.Image = Properties.Resources.ru;
            listaplytek.Add(plytka4);
            this.Controls.Add(plytka4);
            plytka4.Click += Plytka4_Click;

            plytka4_duplikat = new PictureBox();
            plytka4_duplikat.Tag = "Rosja";
            RysujFlage(this, 550, 1, plytka4_duplikat);
            plytka4_duplikat.Image = Properties.Resources.ru;
            listaplytek.Add(plytka2);
            listaplytek.Add(plytka1);
            listaplytek.Add(plytka4_duplikat);
            this.Controls.Add(plytka4_duplikat);
            plytka4_duplikat.Click += Plytka4_duplikat_Click;
            #endregion // 
            LosowanieMiejsc(); 
            myTimer.Start();

        }


        private void MyTimer_Tick(object sender, EventArgs e)
        {

            ukrywanieplytek();
            myTimer.Stop();
        }
        #region klikniecie

  
        /// <summary>
        /// Rozpoczyne gre od nowa
        /// </summary>
        private void Memorki_Click(object sender, EventArgs e) 
        {
            this.Hide();
            Puzle form1 = new Puzle();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

         /// <summary>
        /// ustawia flage dla danej plytki
        /// </summary>
        private void Plytka6_duplikat_Click(object sender, EventArgs e) 
        {

            if ((string)plytka6_duplikat.Tag == "Czechy")
                plytka6_duplikat.Image = Properties.Resources.cz;
            Sprawdzanie(plytka6_duplikat, plytka6);
        }

         /// <summary>
        /// ustawia flage dla danej plytki
        /// </summary>
        private void Plytka6_Click(object sender, EventArgs e) 
        {

            plytka6.Image = Properties.Resources.cz;
            Sprawdzanie(plytka6, plytka6_duplikat);
        }


        /// <summary>
        /// ustawia flage dla danej plytki
        /// </summary>
        private void Plytka5_duplikat_Click(object sender, EventArgs e) 
        {
            if ((string)plytka5_duplikat.Tag == "Singapur")
                plytka5_duplikat.Image = Properties.Resources.sg;
            Sprawdzanie(plytka5_duplikat, plytka5);
        }

         /// <summary>
        /// ustawia flage dla danej plytki
        /// </summary>
        private void Plytka5_Click(object sender, EventArgs e) 
        {
            plytka5.Image = Properties.Resources.sg;
            Sprawdzanie(plytka5, plytka5_duplikat);
        }

         /// <summary>
        /// ustawia flage dla danej plytki
        /// </summary>
        private void Plytka4_duplikat_Click(object sender, EventArgs e) 
        {
            if ((string)plytka4_duplikat.Tag == "Rosja")
                plytka4_duplikat.Image = Properties.Resources.ru;
            Sprawdzanie(plytka4_duplikat, plytka4);

        }

         /// <summary>
        /// ustawia flage dla danej plytki
        /// </summary>
        private void Plytka4_Click(object sender, EventArgs e) 
        {
            //if ((string)plytka4.Tag == "Rosja")
            plytka4.Image = Properties.Resources.ru;
            Sprawdzanie(plytka4, plytka4_duplikat);
        }

         /// <summary>
        /// ustawia flage dla danej plytki
        /// </summary>
        private void Plytka3_duplikat_Click(object sender, EventArgs e) 
        {

            if ((string)plytka3_duplikat.Tag == "Norwegia")
                plytka3_duplikat.Image = Properties.Resources.no;
            else if ((string)plytka3_duplikat.Tag == "Stany Zjednoczone")
                plytka3_duplikat.Image = Properties.Resources.us;

            Sprawdzanie(plytka3_duplikat, plytka3);
        }

         /// <summary>
        /// ustawia flage dla danej plytki
        /// </summary>
        private void Plytka3_Click(object sender, EventArgs e) 
        {
            if ((string)plytka3.Tag == "Norwegia")
                plytka3.Image = Properties.Resources.no;
            else if ((string)plytka3.Tag == "Stany Zjednoczone")
                plytka3.Image = Properties.Resources.us;

            Sprawdzanie(plytka3, plytka3_duplikat);
        }

         /// <summary>
        /// ustawia flage dla danej plytki
        /// </summary>
        private void Plytka2_duplikat_Click(object sender, EventArgs e) 
        {
            if ((string)plytka2_duplikat.Tag == "Polska")
                plytka2_duplikat.Image = Properties.Resources.pl;
            else if ((string)plytka2_duplikat.Tag == "Stany Zjednoczone")
                plytka2_duplikat.Image = Properties.Resources.us;

            Sprawdzanie(plytka2_duplikat, plytka2);
        }

         /// <summary>
        /// ustawia flage dla danej plytki
        /// </summary>
        private void Plytka1_duplikat_Click(object sender, EventArgs e) 
        {
            if ((string)plytka1_duplikat.Tag == "Polska")
                plytka1_duplikat.Image = Properties.Resources.pl;
            else if ((string)plytka1_duplikat.Tag == "Stany Zjednoczone")
                plytka1_duplikat.Image = Properties.Resources.us;

            Sprawdzanie(plytka1_duplikat, plytka1);
        }

         /// <summary>
        /// ustawia flage dla danej plytki
        /// </summary>
        private void Plytka2_Click(object sender, EventArgs e) 
        {
            if ((string)plytka2.Tag == "Polska")
                plytka2.Image = Properties.Resources.pl;
            else if ((string)plytka2.Tag == "Stany Zjednoczone")
                plytka2.Image = Properties.Resources.us;

            Sprawdzanie(plytka2, plytka2_duplikat);

        }

        /// <summary>
        ///ustawia flage dla danej plytki
        /// </summary>
        private void Flaga_Click(object sender, EventArgs e) 
        {

            if ((string)plytka1.Tag == "Polska")
                plytka1.Image = Properties.Resources.pl;
            else if ((string)plytka1.Tag == "Stany Zjednoczone")
                plytka1.Image = Properties.Resources.us;
            Sprawdzanie(plytka1, plytka1_duplikat);

        }
        #endregion

         /// <summary>
        /// rysowanie flagi
        /// </summary>
        public void RysujFlage(Form form, int x, int y, PictureBox a) 
        {

            a.Width = 100;
            a.Height = 50;
            a.Location = new System.Drawing.Point(x, y);
            a.Visible = true;

        }

         /// <summary>
        /// Usuwa PictureBoxy po prawidlowym zaznaczeniu
        /// </summary>
        private void Sprawdzanie(PictureBox a, PictureBox b) 
        {
            if (Klikniety1 == null)
                Klikniety1 = a;

            else if (Klikniety1 != null && Klikniety2 == null)
            {
                Klikniety2 = a;
            }
            if (Klikniety1 != null && Klikniety2 != null)
            {
                if (Klikniety1.Tag == Klikniety2.Tag && Klikniety1.Location != Klikniety2.Location)
                {
                    DodawanieFlagi(Klikniety1);
                    Klikniety1 = null;
                    Klikniety2 = null;
                    Task.Delay(1000).Wait();
                    a.Visible = false;
                    b.Visible = false;
                    tura++;
                    tura2();
                    if (tura >= 7)
                        liczniktrzeciejtury++;
                    tura3();
                    if (liczniktrzeciejtury == 6)
                    {
                        liczniktrzeciejtury = 0;
                        LosowanieMiejsc();
                        ukrywanieplytek();
                        
                    }
                  

                }
                else
                {
                    Task.Delay(500).Wait();
                    foreach (PictureBox plytka in listaplytek)
                    {

                        plytka.Image = Properties.Resources.znak;

                        Klikniety1 = null;
                        Klikniety2 = null;

                    }
                    lbled++;
                    tekst2.Text = "Liczba błędów" + " " + Convert.ToString(lbled);
                }
            }
        }

         /// <summary>
        /// rozmieszcza pseudo-losowo Pictureboxy po planszy
        /// </summary>
        void LosowanieMiejsc() 
        {
            liczbaplytek = 0;
            foreach (PictureBox plytka in listaplytek)
            {// if(plytka.Visible == true)
                liczbaplytek++;
            }
            foreach (PictureBox plytka in listaplytek)
            {
                Random losowa = new Random();
                int r = losowa.Next(liczbaplytek);
                plytka.Location = kopia[r];
                kopia.RemoveAt(r);
                liczbaplytek--;
                plytka.Visible = true;
                Task.Delay(10).Wait();
            }
            kopia = listapunktow.ToList();

        }

         /// <summary>
        /// wywoluje ture2
        /// </summary>
        void tura2() 
        {

            if (tura == 3)
            {
                plytka3 = new PictureBox();
                plytka3.Tag = "Norwegia";
                RysujFlage(this, 100, 150, plytka3);
                plytka3.Image = Properties.Resources.no;
                listaplytek.Add(plytka3);
                plytka3.Visible = true;
                this.Controls.Add(plytka3);
                plytka3.Click += Plytka3_Click; ;

                plytka3_duplikat = new PictureBox();
                plytka3_duplikat.Tag = "Norwegia";
                RysujFlage(this, 250, 150, plytka3_duplikat);
                plytka3_duplikat.Image = Properties.Resources.no;
                plytka3_duplikat.Visible = true;
                listaplytek.Add(plytka3_duplikat);
                this.Controls.Add(plytka3_duplikat);
                plytka3_duplikat.Click += Plytka3_duplikat_Click; ;

                LosowanieMiejsc();
                myTimer.Start();

            }
        }

        /// <summary>
        /// wywołuje ture 3
        /// </summary>
        void tura3() 
        {
            if (tura == 7)
            {

                plytka5 = new PictureBox();
                plytka5.Tag = "Singapur";
                RysujFlage(this, 100, 150, plytka5);
                plytka5.Image = Properties.Resources.sg;
                plytka5.Visible = false;
                this.Controls.Add(plytka5);
                plytka5.Click += Plytka5_Click;

                plytka5_duplikat = new PictureBox();
                plytka5_duplikat.Tag = "Singapur";
                RysujFlage(this, 250, 150, plytka5_duplikat);
                plytka5_duplikat.Image = Properties.Resources.sg;
                plytka5_duplikat.Visible = false;
                listaplytek.Add(plytka5_duplikat);
                this.Controls.Add(plytka5_duplikat);
                plytka5_duplikat.Click += Plytka5_duplikat_Click;


                plytka6 = new PictureBox();
                plytka6.Tag = "Czechy";
                RysujFlage(this, 100, 150, plytka6);
                plytka6.Image = Properties.Resources.cz;
                listaplytek.Add(plytka6);
                plytka6.Visible = false;
                this.Controls.Add(plytka6);
                plytka6.Click += Plytka6_Click;

                plytka6_duplikat = new PictureBox();
                plytka6_duplikat.Tag = "Czechy";
                RysujFlage(this, 250, 150, plytka6_duplikat);
                plytka6_duplikat.Image = Properties.Resources.cz;
                plytka6_duplikat.Visible = false;
                listaplytek.Add(plytka6_duplikat);
                listaplytek.Add(plytka5);
                this.Controls.Add(plytka6_duplikat);
                plytka6_duplikat.Click += Plytka6_duplikat_Click;


                LosowanieMiejsc();
                myTimer.Start();


            }




        }


         /// <summary>
        /// ustawia obraz znak jako picturebox
        /// </summary>
        void ukrywanieplytek() 
        {

            foreach (PictureBox plytka in listaplytek)

            {
                plytka.Image = Properties.Resources.znak;


            }

        }

        /// <summary>
        /// kopiuje ostatnią wybraną flage
        /// </summary>
        void DodawanieFlagi(PictureBox a) 
        {
            flaga.Image = a.Image;
            tekst.Text = (string)a.Tag;



        }





    }
}


