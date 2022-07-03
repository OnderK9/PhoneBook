using Newtonsoft.Json;
using PhoneBook.Core.Helper;
using PhoneBook.Core.RabbitMQ;
using PhoneBook.Core.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook.BackgroundService
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            Control.CheckForIllegalCrossThreadCalls = false;
            StartListening();
        }

        private void StartListening()
        {
            txtLog.Text = "Started Listening... ";
            RabbitMQListener listener = new RabbitMQListener();
            listener.OnReportMessageRequestReceived += Listener_OnReportMessageRequestReceived;
        }

        private void Listener_OnReportMessageRequestReceived(RabbitMQPackage package)
        {
            txtLog.AppendText(Environment.NewLine);
            txtLog.AppendText("Received Request: " + package.Data);
            string service = txtURL.Text;
            string path = "?reportId=" + package.Data;
            HttpHelper helper = new HttpHelper();
            string url = service + path;
            txtLog.AppendText(Environment.NewLine);
            txtLog.AppendText("Http URL: " + url);
            txtLog.AppendText(Environment.NewLine);
            txtLog.AppendText("Service calling: ");
            ServiceResultView result = helper.Get<ServiceResultView>(url).Result;
            txtLog.AppendText(Environment.NewLine);
            txtLog.AppendText("Service result: ");
            txtLog.AppendText(Environment.NewLine);
            txtLog.AppendText(JsonConvert.SerializeObject(result));
            //httpcall
            txtLog.AppendText(Environment.NewLine);
            txtLog.AppendText("Message Waiting...");

        }
    }
}
