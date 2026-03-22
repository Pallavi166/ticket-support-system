using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TicketSupport.Desktop
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            Load += DashboardForm_Load;
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await LoadTickets();
        }
        private async Task LoadTickets()
        {


            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => true;

            HttpClient client = new HttpClient(handler);


            var response = await client.GetAsync("https://localhost:7130/api/Tickets/list/1/Admin");

            if (response.IsSuccessStatusCode)
            {

                var json = await response.Content.ReadAsStringAsync();
                var tickets = JsonConvert.DeserializeObject<List<object>>(json);

                dgvTickets.DataSource = null;
                dgvTickets.DataSource = tickets;
            }

        }



        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
                    (message, cert, chain, errors) => true;

                HttpClient client = new HttpClient(handler);

                var ticket = new
                {
                    ticketNumber = "",
                    subject = "Test Ticket",
                    description = "API Test",
                    status = "Open",
                    priority = "High",
                    createdBy = 1,
                    createdDate = DateTime.Now,
                    assignedTo = 0,
                    ticketId = 0
                };

                var json = JsonConvert.SerializeObject(ticket);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7130/api/Tickets/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Ticket Created Successfully");
                    await LoadTickets();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnAssign_Click(object sender, EventArgs e)
        {
            if (dgvTickets.CurrentRow == null)
            {
                MessageBox.Show("Please select a ticket first");
                return;
            }

            var ticketId = dgvTickets.CurrentRow.Cells["ticketId"].Value.ToString();

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => true;

            HttpClient client = new HttpClient(handler);

            var url = $"https://localhost:7130/api/Tickets/assign?ticketId={ticketId}&adminId=1";



            var response = await client.PostAsync(url, null);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Ticket Assigned Successfully");
                await LoadTickets();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show(error);
            }
        }


        private async void btnStatus_Click(object sender, EventArgs e)
        {

            if (dgvTickets.CurrentRow == null)
            {
                MessageBox.Show("Please select a ticket first");
                return;
            }

            //var ticketValue = dgvTickets.CurrentRow.Cells["ticketId"].Value;
            //if (ticketValue == null)
            //{
            //    MessageBox.Show("Ticket Id not found");
            //    return;
            //}
            int ticketId = Convert.ToInt32(dgvTickets.CurrentRow.Cells["ticketId"].Value);

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => true;

            HttpClient client = new HttpClient(handler);

            string url = $"https://localhost:7130/api/Tickets/status?ticketId={ticketId}&status=Closed&userId=1";

            var response = await client.PostAsync(url, null);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Status Updated Successfully");
                await LoadTickets();
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("API Error: " + response.StatusCode + "\n" + error);
            }
        }

        private async void btnComment_Click(object sender, EventArgs e)
        {


            if (dgvTickets.CurrentRow == null)
            {
                MessageBox.Show("Please select a ticket first");
                return;
            }

            int ticketId = Convert.ToInt32(dgvTickets.CurrentRow.Cells["ticketId"].Value);

            string comment = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter your comment", "Add Comment", "");

            if (string.IsNullOrEmpty(comment))
                return;

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => true;

            HttpClient client = new HttpClient(handler);

            var data = new
            {
                commentId=0,
                commentText=comment,
                commentedBy=1,
                ticketId = ticketId,
                createdDate=DateTime.Now
               
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7130/api/Tickets/comment", content);

            if (response.IsSuccessStatusCode)
                MessageBox.Show("Comment Added Successfully");
            else
                MessageBox.Show("Failed to add comment");
        }
    }
    }




       


