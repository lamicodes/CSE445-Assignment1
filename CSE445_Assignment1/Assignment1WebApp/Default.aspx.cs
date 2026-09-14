using System;

namespace Assignment1WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCtoF_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client =
                new ServiceReference1.Service1Client();

            int c = Convert.ToInt32(txtCelsius.Text);
            int result = client.c2f(c);

            lblFahrenheit.Text = result.ToString() + " °F";

            client.Close();
        }

        protected void btnFtoC_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client =
                new ServiceReference1.Service1Client();

            int f = Convert.ToInt32(txtFahrenheit.Text);
            int result = client.f2c(f);

            lblCelsius.Text = result.ToString() + " °C";

            client.Close();
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client =
                new ServiceReference1.Service1Client();

            string result = client.sort(txtNumbers.Text);

            lblSorted.Text = result;

            client.Close();
        }
    }
}