using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;
using System.Net;

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
            if (double.TryParse(CelciusBox.Text, out c))
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
            else
            {
                MessageBox.Show("Masukkan angka/ tekan RESET", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KonversiSuhu.Enabled = false;
        }
        private void CelciusBox_TextChanged(object sender, EventArgs e)
        {
            KonversiSuhu.Enabled = true;
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            CelciusBox.Text = "";
            FahrenheitBox.Text = "";
            ReamurBox.Text = "";
            KelvinBox.Text = "";
            KonversiSuhu.Enabled = false;
        }

        //cuaca
        string APIKey = "9125fe4caf9b4adb07b6357fc12dd3cc";
        private void btnTampilkan_Click_1(object sender, EventArgs e)
        {
            tampilCuaca();
        }        
        void tampilCuaca()
        {
            using (WebClient web = new WebClient())
            {
                try
                {
                    string namaKota = TBKota.Text.ToString();

                    string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q=" + namaKota + "&appid=" + APIKey);
                    var json = web.DownloadString(url);
                    InfoCuaca.root Info = JsonConvert.DeserializeObject<InfoCuaca.root>(json);

                    picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                    lblCuaca.Text = Info.weather[0].main;
                    lblDetailCuaca.Text = Info.weather[0].description;
                    lblTerbenam.Text = convertDateTime(Info.sys.sunset).ToString();
                    lblTerbit.Text = convertDateTime(Info.sys.sunrise).ToString();

                    lblKecepatanAngin.Text = Info.wind.speed + " Knot".ToString();
                    lblTekananUdara.Text = Info.main.pressure + " PSi".ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Masukkan nama kota\n" + $"'{ex.Message}'", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        DateTime convertDateTime(long second)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(second).ToLocalTime();

            return day;
        }
        private void btnResetCuaca_Click(object sender, EventArgs e)
        {
            TBKota.Text = " ";
            lblCuaca.Text = "N/A";
            lblDetailCuaca.Text = "N/A";
            lblTerbenam.Text = "N/A";
            lblTerbit.Text = "N/A";
            lblKecepatanAngin.Text = "N/A";
            lblTekananUdara.Text = "N/A";
            picIcon.Image = null;
        }
        

        //Waktu
        Double detik, menit, jam, hari;
        private void KonversiWaktu_Click_1(object sender, EventArgs e)
        {
            if (double.TryParse(MenitBox.Text, out menit))
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
            else
            {
                MessageBox.Show("Masukkan angka/ tekan RESET ", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KonversiWaktu.Enabled = false;
        }
        
        private void MenitBox_TextChanged(object sender, EventArgs e)
        {
            KonversiWaktu.Enabled = true;
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
        private void PanjangJawabPemuaian_Click(object sender, EventArgs e)
        {
            try
            {
                PA = Convert.ToDouble(PABox.Text);
                KMP = Convert.ToDouble(KMPBox.Text);
                PS = Convert.ToDouble(PSBox.Text);

                PP = (PA * KMP * PS);

                PPBox.Text = Convert.ToString(PP);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Masukkan angka/ tekan RESET \n" + $"'{ex.Message}'", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PanjangResetPemuaian_Click(object sender, EventArgs e)
        {
            PABox.Text = "";
            KMPBox.Text = "";
            PSBox.Text = "";
            PPBox.Text = "";
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                PA = Convert.ToDouble(PAAfterBox.Text);
                PP = Convert.ToDouble(PanjangPBox.Text);

                PPA = (PA + PP);

                PanjangPAfterBox.Text = Convert.ToString(PPA);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Masukkan angka/ tekan RESET \n" + $"'{ex.Message}'", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void LuasJawabPemuaian_Click_1(object sender, EventArgs e)
        {
            try
            {
                LA = Convert.ToDouble(LABox.Text);
                KML = Convert.ToDouble(KMLBox.Text);
                PS = Convert.ToDouble(PSBox2.Text);

                PL = (LA * KML * PS);

                LPBox.Text = Convert.ToString(PL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Masukkan angka/ tekan RESET \n" + $"'{ex.Message}'", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LuasResetPemuaian_Click(object sender, EventArgs e)
        {
            LABox.Text = "";
            KMLBox.Text = "";
            PSBox2.Text = "";
            LPBox.Text = "";
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                LA = Convert.ToDouble(LAAfterBox.Text);
                PL = Convert.ToDouble(LuasPBox.Text);

                PLA = (LA + PL);

                LuasPAfterBox.Text = Convert.ToString(PLA);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Masukkan angka/ tekan RESET \n" + $"'{ex.Message}'", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void VolumeJawabPemuaian_Click(object sender, EventArgs e)
        {
            try
            {
                VA = Convert.ToDouble(VABox.Text);
                KMV = Convert.ToDouble(KMVBox.Text);
                PS = Convert.ToDouble(PSBox3.Text);

                PV = (VA * KMV * PS);

                VPBox.Text = Convert.ToString(PV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Masukkan angka/ tekan RESET \n" + $"'{ex.Message}'", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                VA = Convert.ToDouble(VAAfterBox.Text);
                PV = Convert.ToDouble(VolumePBox.Text);

                PVA = (VA + PV);

                volumePAfterBox.Text = Convert.ToString(PVA);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Masukkan angka/ tekan RESET \n" + $"'{ex.Message}'", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            VAAfterBox.Text = "";
            VolumePBox.Text = "";
            volumePAfterBox.Text = "";
        }



    }
}