using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms.DataVisualization.Charting;
using orgColor = System.Drawing;

namespace WISH_client
{
    /// <summary>
    /// Detta dokument innehar alla events som finns i klassen MainProgram.
    /// </summary>
    public partial class MainProgram : Form
    {
        /// <summary>
        /// Eventet då Timer1 når sitt inställda värde för tick. 
        /// </summary>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                UpdateGUIwithListData();
            }
            catch
            {
                Reset();
                MessageBox.Show("Kunde inte uppdatera GUI, återställning har skett.", "ERROR!", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Eventet då Timer1 når sitt inställda värde för tick. 
        /// </summary>
        private void Timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                _player.TickUpdate();
                SendCommands();
            }
            catch (ArgumentException msg)
            {
                Reset();
                MessageBox.Show("Fel har inträffat med orsak: " + msg.Message + " , programmet återställs.", "ERROR!", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Eventet som körs då bt tagit emot data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Args"></param>
        void bt_DataReceived(object sender, BtDataReceivedEventArgs Args)
        {
            //Om detta fungerar så låser den locker under tiden eventet körs.
            //Samma lås finns i UpdateGUIwithListData() då _lastData ska accessas. 
            lock (locker)
            {
                _lastData.Clear();
                for (int i = 0; i < Args.btData.Length - 1; i = i + 2)
                {
                    byte type = Args.btData[i];
                    int data = ConvertDataToInt(type, Args.btData[i + 1]);
                    _lastData.Add(new int[2] { Convert.ToInt32(type), data });
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAutomatic_Click(object sender, EventArgs e)
        {
            //Skicka bt_data för aktivering av autonomt läge
            _bt.transmit_byte(new byte[2] { 0x00, 0xFF });
            _timer2.Stop();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            PlayerIndex temp = ((Players)cmbPlayers.SelectedItem).Player;

            if (GamePad.GetState(temp).IsConnected)
            {
                _player = new Xboxkontroll(temp);
                //Skicka bt_data för aktivering av manuellt läge
                _bt.transmit_byte(new byte[2] { 0, 0 });
                _timer2.Start();
            }
            else
            { MessageBox.Show("Kan inte få kontakt med den valda kontrollen", "ERROR!", MessageBoxButtons.OK); }
        }

        /// <summary>
        /// Skickar nödstopp till roboten. 
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            _bt.transmit_byte(new byte[2] { 4, 0 });
            _timer2.Stop();
        }

        /// <summary>
        /// Då Start-knappen för bluetooth-kommunikationen klickas på kontrolleras att en COM port är vald. 
        /// </summary>
        private void btnComStart_Click(object sender, EventArgs e)
        {
            if (cmbComPorts.SelectedIndex == -1)
            {
                MessageBox.Show("Vänligen välj en COM port", "Fel", MessageBoxButtons.OK);
                return;
            }

            if (OpenConnection(cmbComPorts.Text))
            {
                btnComStart.Enabled = false;
                btnComStop.Enabled = true;
                btnAutomatic.Enabled = true;
                btnManual.Enabled = true;
                cmbPlayers.Enabled = true;
                cmbChart.Enabled = true;
                btnSendControls.Enabled = true;
                txtKd.Enabled = true;
                txtKp.Enabled = true;
                lblPlayer.Enabled = true;
                _timer1.Start();
            }
        }

        /// <summary>
        /// Eventet då Uppdatera knappen vid listan med COM-porten trycks på. 
        /// Anropar uppdatering av listan
        /// </summary>
        private void btnCOMUpdate_Click(object sender, EventArgs e)
        {
            UpdateComPorts();
        }

        /// <summary>
        /// Eventet då STOP-knappen för Bluetooth trycks på.
        /// </summary>
        private void btnCOMStop_Click(object sender, EventArgs e)
        {
            btnComStop.Enabled = false;
            btnComStart.Enabled = true;
            _timer1.Stop();
            _timer2.Stop();
            CloseConnection();
        }

        /// <summary>
        /// Metod som har hand om vad som ska göras när användaren ändrar värde i comboboxen
        /// där man väljer vilken chartdata som ska visas. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            _chart.Series.Clear();
            _chart.ChartAreas.Clear();
            _chartArea.AxisY.Maximum = ((NameAndSensor)cmbChart.SelectedItem).Sensor.YMax;
            _chartArea.AxisY.Minimum = ((NameAndSensor)cmbChart.SelectedItem).Sensor.YMin;
            _chartArea.AxisY.Interval = ((NameAndSensor)cmbChart.SelectedItem).Sensor.Interval;
            _chart.ChartAreas.Add(_chartArea);

            _chart.DataSource = ((NameAndSensor)cmbChart.SelectedItem).Sensor.SensorData;
            _chart.Series.Add("Sensordatan");
            _chart.Series[0].XValueMember = "X";
            _chart.Series[0].YValueMembers = "Y";
            _chart.DataBind();

            _chart.Series[0].ChartType = SeriesChartType.Line;
            _chart.Series[0].Color = orgColor.Color.Black;
            _chart.Series[0].BorderWidth = 2;
        }

        /// <summary>
        /// Sänder iväg Kp och Kd via Bluetoothen. 
        /// Felkontroll inkluderad då den anropar ReadControlValues().
        /// </summary>
        private void btnSendControls_Click(object sender, EventArgs e)
        {
            Byte Kd = 0;
            Byte Kp = 0;
            if (ReadControlValues(out Kp, out Kd))
                _bt.transmit_byte(new byte[4] { 33, Kp, 34, Kd });
        }
    }
}
