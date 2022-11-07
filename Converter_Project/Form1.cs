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
        Double PA, KMP, PS, PPA;
        /*
        PA = Panjang Awal
        KMP = Koefisien Muai Panjang
        PS = Perubahan Suhu
        PPA = PanjangPAfterBox
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
        private void button8_Click(object sender, EventArgs e)
        {
            PA = Convert.ToDouble(PAAfterBox.Text);
            PP = Convert.ToDouble(PanjangPBox.Text);

            PPA = (PA + PP);

            PanjangPAfterBox.Text = Convert.ToString(PPA);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            PanjangPAfterBox.Text = "";
            PanjangPBox.Text = "";
            PAAfterBox.Text = "";
        }

        //PEMUAIAN LUAS
        Double LA, KML, PLA;
        /*
        LA = Luas Awal 
        KML = Koefisien muai luas
        PLA = Pemuaian luas after
        */
        Double PL; //Pemuaian luas
        private void LuasJawabPemuaian_Click(object sender, EventArgs e)
        {
            LA = Convert.ToDouble(LABox.Text);
            KML = Convert.ToDouble(KMLBox.Text);
            PS = Convert.ToDouble(PSBox2.Text);

            PL = (LA * KML * PS);

            LPBox.Text = Convert.ToString(PL);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            LABox.Text = "";
            KMLBox.Text = "";
            PSBox2.Text = "";
            LPBox.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            LA = Convert.ToDouble(LAAfterBox.Text);
            PL = Convert.ToDouble(LuasPBox.Text);

            PLA = (LA + PL);

            LuasPAfterBox.Text = Convert.ToString(PLA);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LAAfterBox.Text = "";
            LuasPBox.Text = "";
            LuasPAfterBox.Text = "";
        }

        //PEMUAIAN VOLUME
        Double VA, KMV, PVA;
        /*
        LA = Luas Awal 
        KMV = Koefisien muai volume
        PVA = Pemuaian Volume after
         */
        Double PV; //Pemuaian volume
        private void button12_Click(object sender, EventArgs e)
        {
            VA = Convert.ToDouble(VABox.Text);
            KMV = Convert.ToDouble(KMVBox.Text);
            PS = Convert.ToDouble(PSBox3.Text);

            PV = (VA * KMV * PS);

            VPBox.Text = Convert.ToString(PV);
        }
        private void VolumeResetPemuaian_Click(object sender, EventArgs e)
        {
            VABox.Text = "";
            KMVBox.Text = "";
            PSBox3.Text = "";
            VPBox.Text = "";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            VA = Convert.ToDouble(VAAfterBox.Text);
            PV = Convert.ToDouble(VolumePBox.Text);

            PVA = (LA + PL);

            volumePAfterBox.Text = Convert.ToString(PVA);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            VAAfterBox.Text = "";
            VolumePBox.Text = "";
            volumePAfterBox.Text = "";
        }


    }
}