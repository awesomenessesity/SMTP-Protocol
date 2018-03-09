using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;

namespace SMTP_Client
{
    public partial class Email : Form
    {
        //dont bother understanding the pattern.
        const string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
        int ip1, ip2, ip3, ip4;
        StreamReader srIn;
        StreamWriter swOut;
        string[] emails;
        TcpClient client;

        public Email()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            txtboxEmail.ScrollBars = ScrollBars.Vertical;
        }

        /// <summary>
        /// Connect button, will test if the IP inserted is valid and try to connect
        /// If connected check server response ( should be 220 - ready )
        /// </summary>
        /// <param name="sender"></param> 
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {               
            bool ip1n = int.TryParse(txtboxIP1.Text, out ip1);
            bool ip2n = int.TryParse(txtboxIP2.Text, out ip2);
            bool ip3n = int.TryParse(txtboxIP3.Text, out ip3);
            bool ip4n = int.TryParse(txtboxIP4.Text, out ip4);
            lblConnected.Text = "";
            if (ip1n && ip2n && ip3n && ip4n)
            {       // check ip1                    check ip2                check ip3                   check ip4
                if((ip1 >= 0 && ip1 < 256) && (ip2 >=0 && ip2 < 256) && (ip3 >= 0 && ip3 < 256) && (ip4 >=0 && ip4 < 256))
                {
                    //if the IP is ok try to connect.
                    IPAddress serverIP = IPAddress.Parse(txtboxIP1.Text + "." + txtboxIP2.Text + "." + txtboxIP3.Text + "." + txtboxIP4.Text);
                    int port = 25;
                    client = new TcpClient();
                    try
                    {
                        client.Connect(serverIP, port);
                    }
                    catch(Exception)
                    {
                        lblConnected.Text = "Server un-available.";
                        lblConnected.ForeColor = Color.Red;
                        lblConnected.Left = this.Width / 2 - lblConnected.Width / 2;
                        return;
                    }
                    //initialize buffers.
                    srIn = new StreamReader(client.GetStream());
                    swOut = new StreamWriter(client.GetStream());

                    //check if server available
                    string connection = srIn.ReadLine().Trim();
                    if (connection.StartsWith("220"))
                    {
                        lblConnected.Text = "Connected to Server: " + txtboxIP1.Text + "." + txtboxIP2.Text + "." + txtboxIP3.Text + "." + txtboxIP4.Text;
                        lblConnected.ForeColor = Color.Blue;
                        lblConnected.Left = this.Width / 2 - lblConnected.Width / 2;
                        btnConnect.Enabled = false;
                        txtboxIP1.Enabled = false;
                        txtboxIP2.Enabled = false;
                        txtboxIP3.Enabled = false;
                        txtboxIP4.Enabled = false;
                        btnSend.Enabled = true;
                    }
                    else
                    {
                        lblConnected.Text = "Server Protocol Issue, try connecting again.";
                        lblConnected.ForeColor = Color.Red;
                        lblConnected.Left = this.Width / 2 - lblConnected.Width / 2;
                    }
                }
                else
                {
                    lblConnected.Text = "Incorrect IP Address! Numbers only (0 - 255).";
                    lblConnected.ForeColor = Color.Red;
                    lblConnected.Left = this.Width / 2 - lblConnected.Width / 2;
                }
            }
            else
            {
                lblConnected.Text = "Incorrect IP Address! Numbers only (0 - 255).";
                lblConnected.ForeColor = Color.Red;
                lblConnected.Left = this.Width / 2 - lblConnected.Width / 2;
            }
        }

        /// <summary>
        /// add another email to send, just adjusting the textbox to the correct 
        /// way of adding emails in a single line
        /// correct way is: email1; email2; email3; ... (can be done manualy)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            txtboxTo.Text += "; ";
            txtboxTo.Focus();
            txtboxTo.SelectionStart = txtboxTo.Text.Length;
        }

        /// <summary>
        /// all the protocol and its stages + validation is here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtboxFrom.Text.Trim().Equals(""))
            {
                lblSent.Text = "Must contain \"FROM\" address.";
                lblSent.ForeColor = Color.Red;
                lblSent.Left = this.Width / 2 - lblSent.Width / 2;
                return;
            }
            else if (txtboxTo.Text.Trim().Equals(""))
            {
                lblSent.Text = "Must contain \"TO\" address.";
                lblSent.ForeColor = Color.Red;
                lblSent.Left = this.Width / 2 - lblSent.Width / 2;
                return;
            }
            //validate "from"
            if (!IsValidEmailAddress(txtboxFrom.Text))
            {
                lblSent.Text = "Invalid Email Address \"FROM\"!";
                lblSent.ForeColor = Color.Red;
                lblSent.Left = this.Width / 2 - lblSent.Width / 2;
                return;
            }

            emails = txtboxTo.Text.Trim().Split(';');
            //validate "to" emails
            foreach(string email in emails)
            {
                if (!IsValidEmailAddress(email.Trim()))
                {
                    lblSent.Text = "Invalid Email Address \"TO\"!";
                    lblSent.ForeColor = Color.Red;
                    lblSent.Left = this.Width / 2 - lblSent.Width / 2;
                    return;
                }
            }
            // @@@@@@@@ START PROTOCOL SMTP @@@@@@@ ///////////////////////////////////////////////////////////////////
            try {
                protocolSMTP();
            }
            catch(Exception exp)
            {
                MessageBox.Show("Error in sending an Email:\n" + exp.Message);
                btnSend.Enabled = false;
                btnConnect.Enabled = true;
                txtboxIP1.Enabled = true;
                txtboxIP2.Enabled = true;
                txtboxIP3.Enabled = true;
                txtboxIP4.Enabled = true;
                lblConnected.Text = "";
                txtboxTo.Text = "";
                txtboxSubject.Text = "";
                txtboxEmail.Text = "";
                lblSent.Text = "";
            }        
        }

        /// <summary>
        /// took some regular expression from the internet because for fuucks sake no1 in this entire universe knows what a valid email is.
        /// </summary>
        /// <param name="emailaddress">the email adress to check</param> 
        /// <returns>true if email is vaild, false otherwise</returns>
        private bool IsValidEmailAddress(string emailaddress)
        {
            try
            {
                //@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"
                bool isEmail = Regex.IsMatch(emailaddress, pattern, RegexOptions.IgnoreCase);
                return isEmail;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// the actual SMTP protocol from head to toe.
        /// </summary>
        private void protocolSMTP()
        {
            string reply; 
            //////// Send HELO /////////////////////////////////////////////////////////////////////////////////////
            swOut.WriteLine("HELO still.need.to.figure.out.com");
            swOut.Flush();

            //// answer from server
            reply = srIn.ReadLine().Trim();
            if (!reply.StartsWith("250"))
            {
                lblSent.Text += "Error Protocol HELO from server!\n";
                lblSent.ForeColor = Color.Red;
                lblSent.Left = this.Width / 2 - lblSent.Width / 2;
                //return;
            }

            ////// Send FROM /////////////////////////////////////////////////////////////////////////////////////////
            swOut.WriteLine("MAIL FROM:<" + txtboxFrom + ">");
            swOut.Flush();

            //// answer from server
            reply = srIn.ReadLine().Trim();
            if (!reply.StartsWith("250"))
            {
                lblSent.Text += "Error Protocol FROM from server!\n";
                lblSent.ForeColor = Color.Red;
                lblSent.Left = this.Width / 2 - lblSent.Width / 2;
                //return;
            }

            ////// send all TO's ///////////////////////////////////////////////////////////////////////////////////////
            foreach(string email in emails)
            {
                // send email
                swOut.WriteLine("RCPT TO:<" + email.Trim() + ">");
                swOut.Flush();
                //receive reply
                reply = srIn.ReadLine().Trim();
                if (!reply.StartsWith("250"))
                {
                    lblSent.Text += "Error Protocol RCPT TO from server!\n";
                    lblSent.ForeColor = Color.Red;
                    lblSent.Left = this.Width / 2 - lblSent.Width / 2;
                    //return;
                }
            }

            ///// send DATA //////////////////////////////////////////////////////////////////////////////////////////
            swOut.WriteLine("DATA");
            swOut.Flush();
            //receive reply
            reply = srIn.ReadLine().Trim();
            if (!reply.StartsWith("354"))
            {
                lblSent.Text += "Error Protocol DATA from server!\n";
                lblSent.ForeColor = Color.Red;
                lblSent.Left = this.Width / 2 - lblSent.Width / 2;
                //return;
            }

            ////// arranging the entire email to be sent by its format ///////////////////////////////////////////////////////////
            // first input the FROM, TOs
            string entireEmail = "From: <" + txtboxFrom.Text.Trim() + ">\r\nTo: ";
            if (emails.Length > 1) {
                for(int i = 0; i < emails.Length -1; i++)
                {
                    entireEmail += "<" + emails[i].Trim() + ">; ";
                }
                entireEmail += "<" + emails[emails.Length - 1].Trim() + ">\r\n";
            }
            else
            {
                entireEmail += "<" + txtboxTo.Text.Trim() + ">\r\n";
            }
            //append subject
            entireEmail += "Subject: " + txtboxSubject.Text.Trim() + "\r\n";
            //append email.
            for (int i = 0; i < txtboxEmail.Lines.Length; i++)
            {
                //testing if some1 trying to break the protocol by typing "." (end of email)
                if (txtboxEmail.Lines[i].StartsWith("."))
                {
                    entireEmail += "\r\n" + "." + txtboxEmail.Lines[i];
                }
                else
                {
                    entireEmail += "\r\n" + txtboxEmail.Lines[i];
                }
            }       
            // send the entire email.
            swOut.WriteLine(entireEmail);
            swOut.Flush();
            //finish email.
            swOut.WriteLine(".");
            swOut.Flush();

            //// check server reply
            reply = srIn.ReadLine().Trim();
            if (!reply.StartsWith("250"))
            {
                lblSent.Text += "Error Protocol DATA EMAIL from server!\n";
                lblSent.ForeColor = Color.Red;
                lblSent.Left = this.Width / 2 - lblSent.Width / 2;
                //return;
            }

            ////// finish protocol /////////////////////////////////////////////////////////////////////////////////
            swOut.WriteLine("QUIT");
            swOut.Flush();

            //check reply.
            reply = srIn.ReadLine().Trim();
            if (!reply.StartsWith("221"))
            {
                lblSent.Text += "Error Protocol DATA EMAIL from server!\n";
                lblSent.ForeColor = Color.Red;
                lblSent.Left = this.Width / 2 - lblSent.Width / 2;
                //return;
            }
            else
            {
                lblSent.Text = "Email Succssesfuly sent.";
                lblSent.ForeColor = Color.Blue;
                lblSent.Left = this.Width / 2 - lblSent.Width / 2;
            }
            swOut.Close();
            srIn.Close();
            client.Close();

            btnSend.Enabled = false;
            btnConnect.Enabled = true;
            txtboxIP1.Enabled = true;
            txtboxIP2.Enabled = true;
            txtboxIP3.Enabled = true;
            txtboxIP4.Enabled = true;
            lblConnected.Text = "";
            txtboxTo.Text = "";
            txtboxSubject.Text = "";
            txtboxEmail.Text = "";
        }
    }
}
