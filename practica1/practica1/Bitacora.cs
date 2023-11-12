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

namespace practica1
{
    public partial class Bitacora : Form
    {   
        
        public Bitacora()
        {
            InitializeComponent();
            cargarBitacora();
        }

        public void cargarBitacora()
        {   
            Form1 form1 = new Form1();
            lts_empleados.Items.Clear();
            if (File.Exists(form1.archivoBitacora))
            {
                using(StreamReader reader = new StreamReader(form1.archivoBitacora))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        lts_empleados.Items.Add(linea);
                    }
                }
            }
        }
        private void Bitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show(); 
        }
    }
}
