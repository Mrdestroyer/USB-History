using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_History
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            GetUSB usbObj = new GetUSB();
            List<USB> listadoHistorico = usbObj.getHistoryUSB();

            for(var i = 0; i < listadoHistorico.Count; i++)
            {
                String[] data = { "123", listadoHistorico[i].nombreAmigable };
                this.tablaDatos.Rows.Add(data);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
