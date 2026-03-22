using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace TicketSupport.Desktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
           HttpClient client = new HttpClient(handler);

                var loginData = new
                {
                    username = txtUsername.Text,
                    password = txtPassword.Text
                };

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(loginData);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7130/api/Auth/login", content);
            var result = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Login Successful");

                    DashboardForm dashboard = new DashboardForm();
                    dashboard.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }

        }
    }

