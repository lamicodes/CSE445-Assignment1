using System;
using System.Windows.Forms;

namespace Assignment1Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            webBrowser1.ScriptErrorsSuppressed = true;

            // Browser buttons
            btnBack.Click += btnBack_Click;
            btnForward.Click += btnForward_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnHome.Click += btnHome_Click;
            btnGo.Click += btnGo_Click;

            // Calculator buttons
            btnAdd.Click += btnAdd_Click;
            btnSubtract.Click += btnSubtract_Click;
            btnMultiply.Click += btnMultiply_Click;
            btnDivide.Click += btnDivide_Click;

            // Encryption buttons
            btnEncrypt.Click += btnEncrypt_Click;
            btnDecrypt.Click += btnDecrypt_Click;
        }

        // Opens the URL entered by the user.
        private void btnGo_Click(object sender, EventArgs e)
        {
            string url = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a URL.");
                return;
            }

            if (!url.StartsWith("http://") &&
                !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }

            Uri validUrl;

            if (Uri.TryCreate(url, UriKind.Absolute, out validUrl))
            {
                webBrowser1.Navigate(validUrl);
            }
            else
            {
                MessageBox.Show("Please enter a valid URL.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        // Adds two floating-point numbers.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (GetCalculatorNumbers(out double num1, out double num2))
            {
                lblCalcResult.Text = "Result: " + (num1 + num2);
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if (GetCalculatorNumbers(out double num1, out double num2))
            {
                lblCalcResult.Text = "Result: " + (num1 - num2);
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (GetCalculatorNumbers(out double num1, out double num2))
            {
                lblCalcResult.Text = "Result: " + (num1 * num2);
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (GetCalculatorNumbers(out double num1, out double num2))
            {
                if (num2 == 0)
                {
                    lblCalcResult.Text = "Result: Cannot divide by zero.";
                    return;
                }

                lblCalcResult.Text = "Result: " + (num1 / num2);
            }
        }

        // Validates the calculator input.
        private bool GetCalculatorNumbers(out double num1, out double num2)
        {
            num1 = 0;
            num2 = 0;

            bool firstValid = double.TryParse(txtNum1.Text, out num1);
            bool secondValid = double.TryParse(txtNum2.Text, out num2);

            if (!firstValid || !secondValid)
            {
                lblCalcResult.Text = "Result: Please enter valid numbers.";
                return false;
            }

            return true;
        }

        // Encrypts text using the ASU encryption service.
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEncryptInput.Text))
            {
                MessageBox.Show("Please enter text to encrypt.");
                return;
            }

            try
            {
                EncryptionService.ServiceClient client =
                    new EncryptionService.ServiceClient(
                        "BasicHttpsBinding_IService");

                string result = client.Encrypt(txtEncryptInput.Text);

                txtEncryptResult.Text = result;

                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Encryption service error: " + ex.Message);
            }
        }

        // Decrypts text using the ASU encryption service.
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEncryptInput.Text))
            {
                MessageBox.Show("Please enter text to decrypt.");
                return;
            }

            try
            {
                EncryptionService.ServiceClient client =
                    new EncryptionService.ServiceClient(
                        "BasicHttpsBinding_IService");

                string result = client.Decrypt(txtEncryptInput.Text);

                txtEncryptResult.Text = result;

                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Decryption service error: " + ex.Message);
            }
        }

        // Keep these because Visual Studio may already have controls linked to them.
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}