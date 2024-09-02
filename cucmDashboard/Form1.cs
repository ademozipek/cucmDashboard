using System.ComponentModel;
using System.Net;
using System.Xml.Linq;
using System.Xml;
using SEGBIS;
using System.Text;

namespace cucmDashboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Device> nameList = new List<Device>();

        private void btnListPhones_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            timer1.Enabled = true;
            timer1.Start();
            lblPhoneList.Text = "Getting phone list... Please wait...";
            GetDevices();
        }

        private HttpWebRequest CreateRisPortRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://1.1.1.1:8443/axl/");
            webRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            webRequest.Credentials = new NetworkCredential("admin", "C1sco123");
            webRequest.Headers.Add(@"SOAPAction:CUCM:DB ver=14.0");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private void GetDevices()
        {
            nameList.Clear();
            string deviceXML;

            HttpWebRequest deviceRequest = CreateRisPortRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            deviceXML = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns=\"http://www.cisco.com/AXL/API/14.0\">\r\n    <soapenv:Header/>\r\n    <soapenv:Body>\r\n  <ns:executeSQLQuery sequence=\"?\">\r\n<sql>select device.description, numplan.dnorpattern, typemodel.name from device INNER JOIN devicenumplanmap ON device.pkid = devicenumplanmap.fkdevice INNER JOIN numplan ON numplan.pkid = devicenumplanmap.fknumplan INNER JOIN typemodel ON device.tkmodel = typemodel.enum WHERE numplan.dnorpattern LIKE '%';</sql>\r\n  </ns:executeSQLQuery>\r\n    </soapenv:Body>\r\n</soapenv:Envelope>";

            soapEnvelopeXml.LoadXml(@"" + deviceXML + "");

            using (Stream stream = deviceRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            try
            {
                using (WebResponse response = deviceRequest.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        XDocument xml = XDocument.Parse(soapResult);

                        var x = from b in xml.Descendants("row").Descendants("description")

                                select b.Value;

                        var y = from b in xml.Descendants("row").Descendants("dnorpattern")

                                select b.Value;

                        var z = from b in xml.Descendants("row").Descendants("name")

                                select b.Value;


                        for (int i = 0; i < x.Count(); i++)
                        {
                            Device a = new Device(x.ElementAt(i), y.ElementAt(i), z.ElementAt(i));
                            nameList.Add(a);
                        };
                        var bindingList = new BindingList<Device>(nameList);
                        var source = new BindingSource(bindingList, null);
                        dataGridView1.DataSource = source;
                        dataGridView1.Columns[0].HeaderText = "Device Name";
                        dataGridView1.Columns[1].HeaderText = "Line";
                        dataGridView1.Columns[2].HeaderText = "Device Type";
                    }
                }
                lblPhoneList.Text = "Ready.";
                lblFilter.Visible = true;
                txtFilter.Visible = true;
                btnGroupByModel.Visible = true;
                lblCount.Text = nameList.Count().ToString();
            }
            catch (WebException ex)
            {
                MessageBox.Show("Error getting phones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            //Least 3 char.
            if (txtFilter.Text.Length > 2)
            {
                List<Device> filteredList = nameList.Where(x =>
                 x.Name.Contains(txtFilter.Text, StringComparison.CurrentCultureIgnoreCase))
                     .ToList();

                var bindingList = new BindingList<Device>(filteredList);
                var source = new BindingSource(bindingList, null);
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = source;
                lblCount.Text = filteredList.Count().ToString();
            }
            else
            {
                var bindingList = new BindingList<Device>(nameList);
                var source = new BindingSource(bindingList, null);
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = source;
            }
        }

        private void btnGroupByModel_Click(object sender, EventArgs e)
        {
            lblFilter.Visible = false;
            txtFilter.Visible = false;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.Columns.Add("Devices", "Devices");
            dataGridView1.Columns.Add("Model", "Model");
            dataGridView1.Columns.Add("Count", "Count");

            var list = nameList.GroupBy(x => new { x.Model })
                .Select(g => new
                {
                    model = g.Key.Model,
                    count = g.Count(),
                    names = string.Join(", ", g.Select(n => n.Name))
                }).ToList();

            list.ForEach(
                x => dataGridView1.Rows.Add(x.names, x.model, x.count)
                );
            lblCount.Text = list.Count().ToString();
        }
    }
}
