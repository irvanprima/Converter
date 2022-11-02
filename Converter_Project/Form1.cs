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
    }
}