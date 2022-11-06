namespace Converter_Project
{
    public partial class Converter : Form
    {
        
        public Converter()
        {
            InitializeComponent();
        }

        //Suhu
        Double c, f, r, k;
        private void Konversi_Click(object sender, EventArgs e)
        {
            c = Convert.ToDouble(CelciusBox.Text);
            f = (c * 9 / 5) + 32;
            r = (c * 4) / 5;
            k = (c + 273.15);

            CelciusBox.Text = Convert.ToString($"{c}°C");
            FahrenheitBox.Text = Convert.ToString($"{f}°F");
            ReamurBox.Text = Convert.ToString($"{r}°R");
            KelvinBox.Text = Convert.ToString($"{k}°K");
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            CelciusBox.Text = "";
            FahrenheitBox.Text = "";
            ReamurBox.Text = "";
            KelvinBox.Text = "";
        }

        //Waktu
        Double detik, menit, jam, hari;

        

        private void KonversiWaktu_Click(object sender, EventArgs e)
        {
            menit = Convert.ToDouble(MenitBox.Text);
            detik = (menit * 3600);
            jam = (menit / 60);
            hari = (menit / 1440);

            MenitBox.Text = Convert.ToString(menit);
            DetikBox.Text = Convert.ToString(detik);
            JamBox.Text = Convert.ToString(jam);
            HariBox.Text = Convert.ToString(hari);
        }
        private void ResetWaktu_Click(object sender, EventArgs e)
        {
            MenitBox.Text = "";
            DetikBox.Text = "";
            JamBox.Text = "";
            HariBox.Text = "";
        }

        //PEMUAIAN PANJANG
        Double PA, KMP, PS;
        /*
        PA = Panjang Awal
        KMP = Koefisien Muai Panjang
        PS = Perubahan Suhu
        */
        Double PP; // Pemuaian panjang
        private void button1_Click(object sender, EventArgs e)
        {
            PA = Convert.ToDouble(PABox.Text);
            KMP = Convert.ToDouble(KMPBox.Text);
            PS = Convert.ToDouble(PSBox.Text);
            
            PP = (PA * KMP * PS);

            PPBox.Text = Convert.ToString(PP);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PABox.Text = "";
            KMPBox.Text = "";
            PSBox.Text = "";
            PPBox.Text = "";
        }

        //PEMUAIAN LUAS
        Double LA, KML;
        /*
        LA = Luas Awal 
        KML = Koefisien muai luas
         */
        Double PL; //Pemuaian luas
        private void LuasJawabPemuaian_Click(object sender, EventArgs e)
        {
            LA = Convert.ToDouble(LABox.Text);
            KML = Convert.ToDouble(KMLBox.Text);
            PS = Convert.ToDouble(PSBox2.Text);

            PL = (LA * KML * PS);

            PLBox.Text = Convert.ToString(PL);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            LABox.Text = "";
            KMLBox.Text = "";
            PSBox2.Text = "";
            PLBox.Text = "";
        }

        //PEMUAIAN VOLUME
        Double VA, KMV;
        /*
        LA = Luas Awal 
        KMV = Koefisien muai volume
         */
        Double PV; //Pemuaian volume
        private void button12_Click(object sender, EventArgs e)
        {
            VA = Convert.ToDouble(VABox.Text);
            KMV = Convert.ToDouble(KMVBox.Text);
            PS = Convert.ToDouble(PSBox3.Text);

            PV = (VA * KMV * PS);

            PVBox.Text = Convert.ToString(PV);
        }
        private void VolumeResetPemuaian_Click(object sender, EventArgs e)
        {
            VABox.Text = "";
            KMVBox.Text = "";
            PSBox3.Text = "";
            PVBox.Text = "";
        }


    }
}