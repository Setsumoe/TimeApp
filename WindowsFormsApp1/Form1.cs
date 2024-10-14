using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetCity();
        }
        private const string ApiUrlEU = "http://worldtimeapi.org/api/timezone/Europe/";
        private const string ApiUrlUS = "http://worldtimeapi.org/api/timezone/america/";
        private const string ApiUrlAS = "http://worldtimeapi.org/api/timezone/Asia/";
        
        private const string ApiGetIP = "http://worldtimeapi.org/api/ip";

        private void GetCity()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    string json = client.DownloadString("http://ip-api.com/json/?lang=ru");
                    dynamic result1 = JsonConvert.DeserializeObject(json);

                    string locatecity = result1.city;
                    label1.Text = "Ваш город : " + locatecity;
                }

            }
            catch (Exception ex)
            {
                label1.Text = "Ошибка при определении города: " + ex.Message;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label5.Text = DateTime.Now.ToLongTimeString();

            label6.Text = DateTime.Now.ToLongDateString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void label2_Click(object sender, EventArgs e)
        {
            string city = "Berlin";
            string timezoneUrl = ApiUrlEU + city;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(timezoneUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(json);

                        string timezone = "UTC " + result.utc_offset;
                        DateTime currentTime = DateTime.UtcNow;
                        string timeString = currentTime.ToLongTimeString();

                        DateTime parsedTime;
                        if (DateTime.TryParse(timeString, out parsedTime))
                        {
                            DateTime newTime = parsedTime.AddHours(2);
                            string formattedTime = newTime.ToLongTimeString();

                            MessageBox.Show($"Город: {city}\nЧасовой пояс: {timezone}\nТекущее время: {formattedTime}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ошибка при получении данных");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
        private async void label3_Click(object sender, EventArgs e)
        {
            string timezoneUrl = ApiGetIP;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(timezoneUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(json);

                        string getip = result.client_ip;


                        MessageBox.Show($"Ваш IP-адрес: {getip}");

                    }
                    else
                    {
                        MessageBox.Show("Ошибка при получении данных");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToLongTimeString();


            timer1.Start();
        }

        private async void label9_Click(object sender, EventArgs e)
        {
            string city = "London";
            string timezoneUrl = ApiUrlEU + city;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(timezoneUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(json);

                        string timezone = "UTC " + result.utc_offset;
                        DateTime currentTime = DateTime.UtcNow;
                        string timeString = currentTime.ToLongTimeString();

                        DateTime parsedTime;
                        if (DateTime.TryParse(timeString, out parsedTime))
                        {
                            DateTime newTime = parsedTime.AddHours(1);
                            string formattedTime = newTime.ToLongTimeString();

                            MessageBox.Show($"Город: {city}\nЧасовой пояс: {timezone}\nТекущее время: {formattedTime}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ошибка при получении данных");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
        private async void label7_Click(object sender, EventArgs e)
        {
            string city = "new_york";
            string timezoneUrl = ApiUrlUS + city;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(timezoneUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(json);

                        string timezone = "UTC " + result.utc_offset;
                        DateTime currentTime = DateTime.UtcNow;
                        string timeString = currentTime.ToLongTimeString();

                        DateTime parsedTime;
                        if (DateTime.TryParse(timeString, out parsedTime))
                        {
                            DateTime newTime = parsedTime.AddHours(-4);
                            string formattedTime = newTime.ToLongTimeString();

                            MessageBox.Show($"Город: {city}\nЧасовой пояс: {timezone}\nТекущее время: {formattedTime}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ошибка при получении данных");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
        private async void label8_Click(object sender, EventArgs e)
        {
            string city = "Tokyo";
            string timezoneUrl = ApiUrlAS + city;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(timezoneUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(json);

                        string timezone = "UTC " + result.utc_offset;
                        DateTime currentTime = DateTime.UtcNow;
                        string timeString = currentTime.ToLongTimeString();

                        DateTime parsedTime;
                        if (DateTime.TryParse(timeString, out parsedTime))
                        {
                            DateTime newTime = parsedTime.AddHours(9);
                            string formattedTime = newTime.ToLongTimeString();

                            MessageBox.Show($"Город: {city}\nЧасовой пояс: {timezone}\nТекущее время: {formattedTime}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ошибка при получении данных");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
        private async void label11_Click(object sender, EventArgs e)
        {
            string city = "Moscow";
            string timezoneUrl = ApiUrlEU + city;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(timezoneUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(json);

                        string timezone = "UTC " + result.utc_offset;
                        DateTime currentTime = DateTime.UtcNow;
                        string timeString = currentTime.ToLongTimeString();

                        DateTime parsedTime;
                        if (DateTime.TryParse(timeString, out parsedTime))
                        {
                            DateTime newTime = parsedTime.AddHours(3);
                            string formattedTime = newTime.ToLongTimeString();

                            MessageBox.Show($"Город: {city}\nЧасовой пояс: {timezone}\nТекущее время: {formattedTime}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ошибка при получении данных");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}

