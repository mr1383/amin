using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Guna.UI2.WinForms;
using BLL;
using BE;
using DAL;



namespace ProejectGamenet
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            btnReset.Enabled = false;
            BtnStop.Enabled = false;
            btnReset2.Enabled = false;
            BtnStop2.Enabled = false;
            btnReset3.Enabled = false;
            BtnStop3.Enabled = false;
            btnReset4.Enabled = false;
            BtnStop4.Enabled = false;
            btnReset5.Enabled = false;
            BtnStop5.Enabled = false;
            btnReset6.Enabled = false;
            BtnStop6.Enabled = false;
            btnReset7.Enabled = false;
            BtnStop7.Enabled = false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.Columns[0].DataPropertyName = "id";
            dataGridView1.Columns[1].DataPropertyName = "name";
            dataGridView1.Columns[2].DataPropertyName = "price";
            dataGridView1.Columns[3].DataPropertyName = "dastebandi";
            dataGridView1.Columns[4].DataPropertyName = "tedad";
            dataGridView1.DataSource = new blhuman().Read();

        }

        int timePrice = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {

            btnStart.Enabled = false;
            btnReset.Enabled = false;
            BtnStop.Enabled = true;
            Mytimer.Enabled = true;
            ActiveControl = null;

        }
        private void BtnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnReset.Enabled = true;
            BtnStop.Enabled = false;
            Mytimer.Enabled = false;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            btnReset.Enabled = false;
            lblfinishpm.Text = "";
            time.Text = "00:00:00";
            lblPrice.Text = "0 تومان";
            timePrice = 0;
            CalcPrice();
            ActiveControl = null;
        }
        private void Mytimer_Tick(object sender, EventArgs e)
        {

            Check_Seconds();
            timePrice += 1;
            CalcPrice();
            double timeInMinutes = timePrice / 60.0;
            int stopTimeInMinutes = 0;
            if (!int.TryParse(txttime.Text, out stopTimeInMinutes))
            {

                stopTimeInMinutes = 0;
            }
            if (stopTimeInMinutes > 0 && timeInMinutes >= stopTimeInMinutes)
            {
                Mytimer.Enabled = false;
                BtnStop.Enabled = false;
                btnStart.Enabled = true;
                btnReset.Enabled = true;
                lblfinishpm.Text = "پایان وقت";
                errorProvider1.SetError(lblfinishpm, "پایان وقت");
            }
            else
            {
                errorProvider1.Clear();
                lblfinishpm.Text = "";
            }


        }
        void Check_Seconds()
        {
            string sec, min;
            sec = time.Text.Substring(6, 2);
            min = time.Text.Substring(3, 2);
            if (Convert.ToInt32(sec) < 59)
                if (Convert.ToInt32(sec) < 9)
                    sec = "0" + Convert.ToString(Convert.ToInt32(sec) + 1);
                else
                    sec = Convert.ToString(Convert.ToInt32(sec) + 1);
            else
            {
                sec = "00";
                Check_Minutes();
            }
            time.Text = time.Text.Substring(0, 6) + sec;

        }

        void Check_Minutes()
        {
            string min, hour;
            min = time.Text.Substring(3, 2);
            hour = time.Text.Substring(0, 2);
            if (Convert.ToInt32(min) < 59)
                if (Convert.ToInt32(min) < 9)
                    min = "0" + Convert.ToString(Convert.ToInt32(min) + 1);
                else
                    min = Convert.ToString(Convert.ToInt32(min) + 1);
            else
            {
                min = "00";
                if (Convert.ToInt32(hour) < 23)
                    if (Convert.ToInt32(hour) < 9)
                        hour = "0" + Convert.ToString(Convert.ToInt32(hour) + 1);
                    else
                        hour = Convert.ToString(Convert.ToInt32(hour) + 1);
                else
                    hour = "00";
            }
            time.Text = hour + ":" + min + time.Text.Substring(5, 3);
        }

        void CalcPrice()
        {
            int PerPrice; Int32.TryParse(txtPerPrice.Text, out PerPrice);
            double AllMinTime = timePrice / 60;
            double CalcedFinalPrice = Math.Round((PerPrice * AllMinTime) / 60);
            lblPrice.Text = CalcedFinalPrice.ToString() + " تومان";
        }

        // دستگاه دوم//////////////////////////////////////////////////////////////////////////
        int timePrice2 = 0;
        private void btnStart2_Click(object sender, EventArgs e)
        {
            btnStart2.Enabled = false;
            btnReset2.Enabled = false;
            BtnStop2.Enabled = true;
            Mytimer2.Enabled = true;
            ActiveControl = null;
        }
        private void BtnStop2_Click(object sender, EventArgs e)
        {
            btnStart2.Enabled = true;
            btnReset2.Enabled = true;
            BtnStop2.Enabled = false;
            Mytimer2.Enabled = false;
        }
        private void btnReset2_Click(object sender, EventArgs e)
        {
            btnReset2.Enabled = false;
            time2.Text = "00:00:00";
            lblPrice2.Text = "0 تومان";
            timePrice2 = 0;
            CalcPrice2();
            ActiveControl = null;
            errorProvider2.Clear();
            lblfinishpm2.Text = "";


        }
        private void Mytimer2_Tick(object sender, EventArgs e)
        {
            Check_Seconds2();
            timePrice2 += 1;
            CalcPrice2();
            double timeInMinutes2 = timePrice2 / 60.0;
            int stopTimeInMinutes2 = 0;
            if (!int.TryParse(txttime2.Text, out stopTimeInMinutes2))
            {

                stopTimeInMinutes2 = 0;
            }
            if (stopTimeInMinutes2 > 0 && timeInMinutes2 >= stopTimeInMinutes2)
            {
                Mytimer2.Enabled = false;
                BtnStop2.Enabled = false;
                btnStart2.Enabled = true;
                btnReset2.Enabled = true;
                lblfinishpm2.Text = "پایان وقت";
                errorProvider2.SetError(lblfinishpm2, "پایان وقت");
            }
            else
            {
                errorProvider2.Clear();
                lblfinishpm2.Text = "";
            }
        }
        void Check_Seconds2()
        {
            string sec2, min2;
            sec2 = time2.Text.Substring(6, 2);
            min2 = time2.Text.Substring(3, 2);
            if (Convert.ToInt32(sec2) < 59)
                if (Convert.ToInt32(sec2) < 9)
                    sec2 = "0" + Convert.ToString(Convert.ToInt32(sec2) + 1);
                else
                    sec2 = Convert.ToString(Convert.ToInt32(sec2) + 1);
            else
            {
                sec2 = "00";
                Check_Minutes2();
            }
            time2.Text = time2.Text.Substring(0, 6) + sec2;
        }

        void Check_Minutes2()
        {
            string min2, hour2;
            min2 = time2.Text.Substring(3, 2);
            hour2 = time2.Text.Substring(0, 2);
            if (Convert.ToInt32(min2) < 59)
                if (Convert.ToInt32(min2) < 9)
                    min2 = "0" + Convert.ToString(Convert.ToInt32(min2) + 1);
                else
                    min2 = Convert.ToString(Convert.ToInt32(min2) + 1);
            else
            {
                min2 = "00";
                if (Convert.ToInt32(hour2) < 23)
                    if (Convert.ToInt32(hour2) < 9)
                        hour2 = "0" + Convert.ToString(Convert.ToInt32(hour2) + 1);
                    else
                        hour2 = Convert.ToString(Convert.ToInt32(hour2) + 1);
                else
                    hour2 = "00";
            }
            time2.Text = hour2 + ":" + min2 + time2.Text.Substring(5, 3);
        }

        void CalcPrice2()
        {
            int PerPrice2; Int32.TryParse(txtPerPrice2.Text, out PerPrice2);
            double AllMinTime = timePrice2 / 60;
            double CalcedFinalPrice = Math.Round((PerPrice2 * AllMinTime) / 60);
            lblPrice2.Text = CalcedFinalPrice.ToString() + " تومان";


        }

        // دستگاه سوم//////////////////////////////////////////////////////////////////////////
        int timePrice3 = 0;
        private void btnStart3_Click(object sender, EventArgs e)
        {
            btnStart3.Enabled = false;
            btnReset3.Enabled = false;
            BtnStop3.Enabled = true;
            Mytimer3.Enabled = true;
            ActiveControl = null;
        }

        private void BtnStop3_Click(object sender, EventArgs e)
        {
            btnStart3.Enabled = true;
            btnReset3.Enabled = true;
            BtnStop3.Enabled = false;
            Mytimer3.Enabled = false;
        }

        private void btnReset3_Click(object sender, EventArgs e)
        {
            btnReset3.Enabled = false;
            time3.Text = "00:00:00";
            lblPrice3.Text = "0 تومان";
            timePrice3 = 0;
            CalcPrice3();
            ActiveControl = null;
            errorProvider3.Clear();
            lblfinishpm3.Text = "";
        }
        private void Mytimer3_Tick(object sender, EventArgs e)
        {
            Check_Seconds3();
            timePrice3 += 1;
            CalcPrice3();
            double timeInMinutes3 = timePrice3 / 60.0;
            int stopTimeInMinutes3 = 0;
            if (!int.TryParse(txttime3.Text, out stopTimeInMinutes3))
            {

                stopTimeInMinutes3 = 0;
            }
            if (stopTimeInMinutes3 > 0 && timeInMinutes3 >= stopTimeInMinutes3)
            {
                Mytimer3.Enabled = false;
                BtnStop3.Enabled = false;
                btnStart3.Enabled = true;
                btnReset3.Enabled = true;
                lblfinishpm3.Text = "پایان وقت";
                errorProvider3.SetError(lblfinishpm3, "پایان وقت");
            }
            else
            {
                errorProvider3.Clear();
                lblfinishpm3.Text = "";
            }
        }
        void Check_Seconds3()
        {
            string sec3, min3;
            sec3 = time3.Text.Substring(6, 2);
            min3 = time3.Text.Substring(3, 2);
            if (Convert.ToInt32(sec3) < 59)
                if (Convert.ToInt32(sec3) < 9)
                    sec3 = "0" + Convert.ToString(Convert.ToInt32(sec3) + 1);
                else
                    sec3 = Convert.ToString(Convert.ToInt32(sec3) + 1);
            else
            {
                sec3 = "00";
                Check_Minutes3();
            }
            time3.Text = time3.Text.Substring(0, 6) + sec3;
        }

        void Check_Minutes3()
        {
            string min3, hour3;
            min3 = time3.Text.Substring(3, 2);
            hour3 = time3.Text.Substring(0, 2);
            if (Convert.ToInt32(min3) < 59)
                if (Convert.ToInt32(min3) < 9)
                    min3 = "0" + Convert.ToString(Convert.ToInt32(min3) + 1);
                else
                    min3 = Convert.ToString(Convert.ToInt32(min3) + 1);
            else
            {
                min3 = "00";
                if (Convert.ToInt32(hour3) < 23)
                    if (Convert.ToInt32(hour3) < 9)
                        hour3 = "0" + Convert.ToString(Convert.ToInt32(hour3) + 1);
                    else
                        hour3 = Convert.ToString(Convert.ToInt32(hour3) + 1);
                else
                    hour3 = "00";
            }
            time3.Text = hour3 + ":" + min3 + time3.Text.Substring(5, 3);
        }

        void CalcPrice3()
        {
            int PerPrice3; Int32.TryParse(txtPerPrice3.Text, out PerPrice3);
            double AllMinTime = timePrice3 / 60;
            double CalcedFinalPrice = Math.Round((PerPrice3 * AllMinTime) / 60);
            lblPrice3.Text = CalcedFinalPrice.ToString() + " تومان";


        }

        // دستگاه 4//////////////////////////////////////////////////////////////////////////
        int timePrice4 = 0;
        private void btnStart4_Click(object sender, EventArgs e)
        {
            btnStart4.Enabled = false;
            btnReset4.Enabled = false;
            BtnStop4.Enabled = true;
            Mytimer4.Enabled = true;
            ActiveControl = null;
        }
        private void BtnStop4_Click(object sender, EventArgs e)
        {
            btnStart4.Enabled = true;
            btnReset4.Enabled = true;
            BtnStop4.Enabled = false;
            Mytimer4.Enabled = false;
        }

        private void btnReset4_Click(object sender, EventArgs e)
        {
            btnReset4.Enabled = false;
            time4.Text = "00:00:00";
            lblPrice4.Text = "0 تومان";
            timePrice4 = 0;
            CalcPrice4();
            ActiveControl = null;
            errorProvider4.Clear();
            lblfinishpm4.Text = "";
        }
        private void Mytimer4_Tick(object sender, EventArgs e)
        {
            Check_Seconds4();
            timePrice4 += 1;
            CalcPrice4();
            double timeInMinutes4 = timePrice4 / 60.0;
            int stopTimeInMinutes4 = 0;
            if (!int.TryParse(txttime4.Text, out stopTimeInMinutes4))
            {

                stopTimeInMinutes4 = 0;
            }
            if (stopTimeInMinutes4 > 0 && timeInMinutes4 >= stopTimeInMinutes4)
            {
                Mytimer4.Enabled = false;
                BtnStop4.Enabled = false;
                btnStart4.Enabled = true;
                btnReset4.Enabled = true;
                lblfinishpm4.Text = "پایان وقت";
                errorProvider4.SetError(lblfinishpm4, "پایان وقت");
            }
            else
            {
                errorProvider4.Clear();
                lblfinishpm4.Text = "";
            }
        }
        void Check_Seconds4()
        {
            string sec4, min4;
            sec4 = time4.Text.Substring(6, 2);
            min4 = time4.Text.Substring(3, 2);
            if (Convert.ToInt32(sec4) < 59)
                if (Convert.ToInt32(sec4) < 9)
                    sec4 = "0" + Convert.ToString(Convert.ToInt32(sec4) + 1);
                else
                    sec4 = Convert.ToString(Convert.ToInt32(sec4) + 1);
            else
            {
                sec4 = "00";
                Check_Minutes4();
            }
            time4.Text = time4.Text.Substring(0, 6) + sec4;
        }

        void Check_Minutes4()
        {
            string min4, hour4;
            min4 = time4.Text.Substring(3, 2);
            hour4 = time4.Text.Substring(0, 2);
            if (Convert.ToInt32(min4) < 59)
                if (Convert.ToInt32(min4) < 9)
                    min4 = "0" + Convert.ToString(Convert.ToInt32(min4) + 1);
                else
                    min4 = Convert.ToString(Convert.ToInt32(min4) + 1);
            else
            {
                min4 = "00";
                if (Convert.ToInt32(hour4) < 23)
                    if (Convert.ToInt32(hour4) < 9)
                        hour4 = "0" + Convert.ToString(Convert.ToInt32(hour4) + 1);
                    else
                        hour4 = Convert.ToString(Convert.ToInt32(hour4) + 1);
                else
                    hour4 = "00";
            }
            time4.Text = hour4 + ":" + min4 + time4.Text.Substring(5, 3);
        }

        void CalcPrice4()
        {
            int PerPrice4; Int32.TryParse(txtPerPrice4.Text, out PerPrice4);
            double AllMinTime = timePrice4 / 60;
            double CalcedFinalPrice = Math.Round((PerPrice4 * AllMinTime) / 60);
            lblPrice4.Text = CalcedFinalPrice.ToString() + " تومان";


        }

        // دستگاه 5//////////////////////////////////////////////////////////////////////////
        int timePrice5 = 0;

        private void btnStart5_Click(object sender, EventArgs e)
        {

            btnStart5.Enabled = false;
            btnReset5.Enabled = false;
            BtnStop5.Enabled = true;
            Mytimer5.Enabled = true;
            ActiveControl = null;
        }

        private void BtnStop5_Click(object sender, EventArgs e)
        {
            btnStart5.Enabled = true;
            btnReset5.Enabled = true;
            BtnStop5.Enabled = false;
            Mytimer5.Enabled = false;
        }

        private void btnReset5_Click(object sender, EventArgs e)
        {
            btnReset5.Enabled = false;
            time5.Text = "00:00:00";
            lblPrice5.Text = "0 تومان";
            timePrice5 = 0;
            CalcPrice5();
            ActiveControl = null;
            errorProvider5.Clear();
            lblfinishpm5.Text = "";

        }

        private void Mytimer5_Tick(object sender, EventArgs e)
        {
            Check_Seconds5();
            timePrice5 += 1;
            CalcPrice5();
            double timeInMinutes5 = timePrice5 / 60.0;
            int stopTimeInMinutes5 = 0;
            if (!int.TryParse(txttime5.Text, out stopTimeInMinutes5))
            {

                stopTimeInMinutes5 = 0;
            }
            if (stopTimeInMinutes5 > 0 && timeInMinutes5 >= stopTimeInMinutes5)
            {
                Mytimer5.Enabled = false;
                BtnStop5.Enabled = false;
                btnStart5.Enabled = true;
                btnReset5.Enabled = true;
                lblfinishpm5.Text = "پایان وقت";
                errorProvider5.SetError(lblfinishpm5, "پایان وقت");

            }
            else
            {
                errorProvider5.Clear();
                lblfinishpm5.Text = "";
            }
        }
        void Check_Seconds5()
        {
            string sec5, min5;
            sec5 = time5.Text.Substring(6, 2);
            min5 = time5.Text.Substring(3, 2);
            if (Convert.ToInt32(sec5) < 59)
                if (Convert.ToInt32(sec5) < 9)
                    sec5 = "0" + Convert.ToString(Convert.ToInt32(sec5) + 1);
                else
                    sec5 = Convert.ToString(Convert.ToInt32(sec5) + 1);
            else
            {
                sec5 = "00";
                Check_Minutes5();
            }
            time5.Text = time5.Text.Substring(0, 6) + sec5;
        }

        void Check_Minutes5()
        {
            string min5, hour5;
            min5 = time5.Text.Substring(3, 2);
            hour5 = time5.Text.Substring(0, 2);
            if (Convert.ToInt32(min5) < 59)
                if (Convert.ToInt32(min5) < 9)
                    min5 = "0" + Convert.ToString(Convert.ToInt32(min5) + 1);
                else
                    min5 = Convert.ToString(Convert.ToInt32(min5) + 1);
            else
            {
                min5 = "00";
                if (Convert.ToInt32(hour5) < 23)
                    if (Convert.ToInt32(hour5) < 9)
                        hour5 = "0" + Convert.ToString(Convert.ToInt32(hour5) + 1);
                    else
                        hour5 = Convert.ToString(Convert.ToInt32(hour5) + 1);
                else
                    hour5 = "00";
            }
            time5.Text = hour5 + ":" + min5 + time5.Text.Substring(5, 3);
        }

        void CalcPrice5()
        {
            int PerPrice5; Int32.TryParse(txtPerPrice5.Text, out PerPrice5);
            double AllMinTime = timePrice5 / 60;
            double CalcedFinalPrice = Math.Round((PerPrice5 * AllMinTime) / 60);
            lblPrice5.Text = CalcedFinalPrice.ToString() + " تومان";
        }

        // دستگاه 6//////////////////////////////////////////////////////////////////////////
        int timePrice6 = 0;

        private void btnStart6_Click(object sender, EventArgs e)
        {
            btnStart6.Enabled = false;
            btnReset6.Enabled = false;
            BtnStop6.Enabled = true;
            Mytimer6.Enabled = true;
            ActiveControl = null;
        }

        private void BtnStop6_Click(object sender, EventArgs e)
        {

            btnStart6.Enabled = true;
            btnReset6.Enabled = true;
            BtnStop6.Enabled = false;
            Mytimer6.Enabled = false;
        }

        private void btnReset6_Click(object sender, EventArgs e)
        {

            btnReset6.Enabled = false;
            time6.Text = "00:00:00";
            lblPrice6.Text = "0 تومان";
            timePrice6 = 0;
            CalcPrice6();
            ActiveControl = null;
            errorProvider6.Clear();
            lblfinishpm6.Text = "";

        }
        private void Mytimer6_Tick(object sender, EventArgs e)
        {
            Check_Seconds6();
            timePrice6 += 1;
            CalcPrice6();
            double timeInMinutes6 = timePrice6 / 60.0;
            int stopTimeInMinutes6 = 0;
            if (!int.TryParse(txttime6.Text, out stopTimeInMinutes6))
            {

                stopTimeInMinutes6 = 0;
            }
            if (stopTimeInMinutes6 > 0 && timeInMinutes6 >= stopTimeInMinutes6)
            {
                Mytimer6.Enabled = false;
                BtnStop6.Enabled = false;
                btnStart6.Enabled = true;
                btnReset6.Enabled = true;
                lblfinishpm6.Text = "پایان وقت";
                errorProvider6.SetError(lblfinishpm6, "پایان وقت");
            }
            else
            {
                errorProvider6.Clear();
                lblfinishpm6.Text = "";
            }
        }
        void Check_Seconds6()
        {
            string sec6, min6;
            sec6 = time6.Text.Substring(6, 2);
            min6 = time6.Text.Substring(3, 2);
            if (Convert.ToInt32(sec6) < 59)
                if (Convert.ToInt32(sec6) < 9)
                    sec6 = "0" + Convert.ToString(Convert.ToInt32(sec6) + 1);
                else
                    sec6 = Convert.ToString(Convert.ToInt32(sec6) + 1);
            else
            {
                sec6 = "00";
                Check_Minutes6();
            }
            time6.Text = time6.Text.Substring(0, 6) + sec6;
        }

        void Check_Minutes6()
        {
            string min6, hour6;
            min6 = time6.Text.Substring(3, 2);
            hour6 = time6.Text.Substring(0, 2);
            if (Convert.ToInt32(min6) < 59)
                if (Convert.ToInt32(min6) < 9)
                    min6 = "0" + Convert.ToString(Convert.ToInt32(min6) + 1);
                else
                    min6 = Convert.ToString(Convert.ToInt32(min6) + 1);
            else
            {
                min6 = "00";
                if (Convert.ToInt32(hour6) < 23)
                    if (Convert.ToInt32(hour6) < 9)
                        hour6 = "0" + Convert.ToString(Convert.ToInt32(hour6) + 1);
                    else
                        hour6 = Convert.ToString(Convert.ToInt32(hour6) + 1);
                else
                    hour6 = "00";
            }
            time6.Text = hour6 + ":" + min6 + time6.Text.Substring(5, 3);
        }

        void CalcPrice6()
        {
            int PerPrice6; Int32.TryParse(txtPerPrice6.Text, out PerPrice6);
            double AllMinTime = timePrice6 / 60;
            double CalcedFinalPrice = Math.Round((PerPrice6 * AllMinTime) / 60);
            lblPrice6.Text = CalcedFinalPrice.ToString() + " تومان";


        }
        // دستگاه 7//////////////////////////////////////////////////////////////////////////

        int timePrice7 = 0;

        private void btnStart7_Click(object sender, EventArgs e)
        {
            btnStart7.Enabled = false;
            btnReset7.Enabled = false;
            BtnStop7.Enabled = true;
            Mytimer7.Enabled = true;
            ActiveControl = null;
        }

        private void BtnStop7_Click(object sender, EventArgs e)
        {
            btnStart7.Enabled = true;
            btnReset7.Enabled = true;
            BtnStop7.Enabled = false;
            Mytimer7.Enabled = false;
        }

        private void btnReset7_Click(object sender, EventArgs e)
        {
            btnReset7.Enabled = false;
            time7.Text = "00:00:00";
            lblPrice7.Text = "0 تومان";
            timePrice7 = 0;
            CalcPrice7();
            ActiveControl = null;
            errorProvider7.Clear();
            lblfinishpm7.Text = "";
        }

        private void Mytimer7_Tick(object sender, EventArgs e)
        {
            Check_Seconds7();
            timePrice7 += 1;
            CalcPrice7();
            double timeInMinutes7 = timePrice7 / 60.0;
            int stopTimeInMinutes7 = 0;
            if (!int.TryParse(txttime7.Text, out stopTimeInMinutes7))
            {

                stopTimeInMinutes7 = 0;
            }
            if (stopTimeInMinutes7 > 0 && timeInMinutes7 >= stopTimeInMinutes7)
            {
                Mytimer7.Enabled = false;
                BtnStop7.Enabled = false;
                btnStart7.Enabled = true;
                btnReset7.Enabled = true;
                lblfinishpm7.Text = "پایان وقت";
                errorProvider7.SetError(lblfinishpm7, "پایان وقت");
            }
            else
            {
                errorProvider7.Clear();
                lblfinishpm7.Text = "";
            }
        }
        void Check_Seconds7()
        {
            string sec7, min7;
            sec7 = time7.Text.Substring(6, 2);
            min7 = time7.Text.Substring(3, 2);
            if (Convert.ToInt32(sec7) < 59)
                if (Convert.ToInt32(sec7) < 9)
                    sec7 = "0" + Convert.ToString(Convert.ToInt32(sec7) + 1);
                else
                    sec7 = Convert.ToString(Convert.ToInt32(sec7) + 1);
            else
            {
                sec7 = "00";
                Check_Minutes7();
            }
            time7.Text = time7.Text.Substring(0, 6) + sec7;
        }

        void Check_Minutes7()
        {
            string min7, hour7;
            min7 = time7.Text.Substring(3, 2);
            hour7 = time7.Text.Substring(0, 2);
            if (Convert.ToInt32(min7) < 59)
                if (Convert.ToInt32(min7) < 9)
                    min7 = "0" + Convert.ToString(Convert.ToInt32(min7) + 1);
                else
                    min7 = Convert.ToString(Convert.ToInt32(min7) + 1);
            else
            {
                min7 = "00";
                if (Convert.ToInt32(hour7) < 23)
                    if (Convert.ToInt32(hour7) < 9)
                        hour7 = "0" + Convert.ToString(Convert.ToInt32(hour7) + 1);
                    else
                        hour7 = Convert.ToString(Convert.ToInt32(hour7) + 1);
                else
                    hour7 = "00";
            }
            time7.Text = hour7 + ":" + min7 + time7.Text.Substring(5, 3);
        }

        void CalcPrice7()
        {
            int PerPrice7; Int32.TryParse(txtPerPrice7.Text, out PerPrice7);
            double AllMinTime = timePrice7 / 60;
            double CalcedFinalPrice = Math.Round((PerPrice7 * AllMinTime) / 60);
            lblPrice7.Text = CalcedFinalPrice.ToString() + " تومان";
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("آیا شما مطمئن هستید که میخواهید این برنامه را ببندید؟", "خروج از برنامه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) == DialogResult.No)
            {
                e.Cancel = true;

            }
        }

        private void menumodirtime_Click(object sender, EventArgs e)
        {
            panelmodiriat.Visible = true;
            panelprofile.Visible = false;
            panelkhoraki.Visible = false;
        }
        private void menumodirkhoraki_Click(object sender, EventArgs e)
        {
            panelkhoraki.Visible = true;
            panelmodiriat.Visible = false;
            panelprofile.Visible = false;
        }
        private void menumodirprofile_Click(object sender, EventArgs e)
        {
            panelprofile.Visible = true;
            panelmodiriat.Visible = false;
            panelkhoraki.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            blhuman b1 = new blhuman();
            login l = new login();

            if (txtusername.Text.Trim().Length == 0)
            {
                lblerror.Text = "نام کاربری را وارد کنید";
                txtusername.Focus();
            }
            else if (txtpassword.Text.Trim().Length == 0)
            {
                lblerror.Text = "رمزعبور را وارد کنید";
                txtpassword.Focus();
            }
            else if (txtnewpassword.Text.Trim().Length == 0)
            {
                lblerror.Text = "رمزعبور جدید را وارد کنید";
                txtnewpassword.Focus();
            }
            else if (txtnewpassword2.Text.Trim().Length == 0)
            {
                lblerror.Text = "رمزعبور جدید را وارد کنید";
                txtnewpassword2.Focus();
            }
            else if (txtnewpassword2.Text != txtnewpassword.Text)
            {
                lblerror.Text = "رمزعبور مطابقت ندارد";
            }
            else if (txtnewpassword.Text == txtpassword.Text)
            {
                lblerror.Text = "رمزعبور شما تفییر نکرده است";
            }
            else if (b1.login(txtpassword.Text, txtusername.Text) == false)
            {
                lblerror.Text = "مشخصات شما اشتباه است";
            }
            else
            {
                blhuman blh = new blhuman();
                blh.changepassword(txtpassword.Text, txtusername.Text, txtnewpassword.Text);
                lblerror.ForeColor = Color.Green;
                lblerror.Text = "رمز عبور با موفقیت تغییر کرد";
                MessageBox.Show("رمزعبور شما با موفقیت تغییر کرد");
            }
        }
        List<personel> items = new List<personel>();
        blhuman b1 = new blhuman();
        blhuman b5 = new blhuman();
        private void BtnFood_Click(object sender, EventArgs e)
        {
            if (txtnamefood.Text.Trim().Length == 0)
            {
                label64.Text = "نام خوراکی را وارد کنید";
                txtnamefood.Focus();
            }
            else if (txtprice.Text.Trim().Length == 0)
            {
                label64.Text = "قیمت را وارد کنید";
                txtprice.Focus();
            }
            else if (guna2ComboBox1.SelectedIndex == -1)
            {
                label64.Text = "دسته بندی را انتخاب کنید";
                guna2ComboBox1.Focus();
            }
            else if (txttedad.Text.Trim().Length == 0)
            {
                label64.Text = "تعداد را وارد کنید";
                txttedad.Focus();
            }
            else
            {
                if (BtnFood.Text == "ویرایش")
                {
                    int id = int.Parse(BtnFood.Tag.ToString());
                    blhuman b11 = new blhuman();
                    b11.Update(id, new personel { name = txtnamefood.Text, price = txtprice.Text, tedad = txttedad.Text, dastebandi = guna2ComboBox1.SelectedItem.ToString()});
                    dataGridView1.DataSource = new blhuman().Read();
                    BtnFood.Text = "ثبت";
                }
                else
                {
                    blhuman b12 = new blhuman();
                    b12.register(new personel { name = txtnamefood.Text, price = txtprice.Text, tedad = txttedad.Text, dastebandi = guna2ComboBox1.SelectedItem.ToString()});
                    dataGridView1.DataSource = new blhuman().Read();
                }
            }
        }          
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text.Trim().Length == 0)
            {
                label67.Text = "کادر را پر کنید";
                txtsearch.Focus();

            }
            else
            {
              
                blhuman h = new blhuman();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = h.Read(txtsearch.Text);
                dataGridView1.Columns[0].HeaderText = "آیدی";
                dataGridView1.Columns[1].HeaderText = "نام خوراکی";
                dataGridView1.Columns[2].HeaderText = "قیمت";
                dataGridView1.Columns[3].HeaderText = "دسته بندی";
                dataGridView1.Columns[4].HeaderText = "تعداد";
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text.Trim().Length == 0)
            {
                dataGridView1.Columns[0].HeaderText = "آیدی";
                dataGridView1.Columns[1].HeaderText = "نام خوراکی";
                dataGridView1.Columns[2].HeaderText = "قیمت";
                dataGridView1.Columns[3].HeaderText = "دسته بندی";
                dataGridView1.Columns[4].HeaderText = "تعداد";
                dataGridView1.DataSource = new blhuman().Read();
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {

            if (txtremove.Text.Trim().Length == 0)
            {
                label66.Text = "آیدی را وارد کنید";
                txtremove.Focus();
            }

            else
            {
                int id = int.Parse(txtremove.Text);
                b1.Delete(id);
                items.RemoveAll(p => p.id == id);
                dataGridView1.DataSource = new blhuman().Read();
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtnamefood.Text = row.Cells["name"].Value.ToString();
                txtprice.Text = row.Cells["price"].Value.ToString();
                txttedad.Text = row.Cells["tedad"].Value.ToString();
                guna2ComboBox1.SelectedItem = row.Cells["dastebandi"].Value.ToString();
                BtnFood.Text = "ویرایش";
                BtnFood.Tag = row.Cells["id"].Value.ToString();

            }
        }

        private void btnkharid_Click(object sender, EventArgs e)
        {
            if (txtkharid.Text.Trim().Length == 0)
            {
                label73.Text = "نام خوراکی را وارد کنید";
                txtkharid.Focus();
            }

         else if (txttedadkharid.Text.Trim().Length == 0)
            {
                label73.Text = "تعداد را وارد کنید";
                txttedadkharid.Focus();
            }
            else
            {
                int selectedQuantity = int.Parse(txttedad.Text);
                int itemId = int.Parse(txtkharid.Text);

                using (var db = new db()) // ایجاد یک شی از کلاس db برای دسترسی به دیتابیس
                {
                    var item = db.personels.SingleOrDefault(i => i.id == itemId); // یافتن کالای مورد نظر با شناسه ارسال شده
                    if (item != null && int.TryParse(item.tedad, out int currentQuantity))
                    {
                        if (currentQuantity >= selectedQuantity)
                        {
                            item.tedad = (currentQuantity - selectedQuantity).ToString(); // کم کردن تعداد انتخاب شده از تعداد کل کالا
                            db.SaveChanges(); // ذخیره تغییرات در دیتابیس
                            MessageBox.Show("فروش با موفقیت انجام شد.");
                        }
                        else
                        {
                            MessageBox.Show("تعداد کالای موجود کمتر از تعداد انتخاب شده است.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("کالایی با شناسه وارد شده یافت نشد.");
                    }
                }
            }
        }
    }
}

