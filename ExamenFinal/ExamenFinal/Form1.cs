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

namespace ExamenFinal
{
    public partial class Form1 : Form
    {
        string archivoAlumnos = "archivoAlumnos.txt";
        public Form1()
        {
            InitializeComponent();
            CargarAlumnos();
            lts_alumnos.SelectedIndexChanged += lts_alumnos_SelectedIndexChanged;
        }

        public void CargarAlumnos()
        {
            lts_alumnos.Items.Clear();
            if (File.Exists(archivoAlumnos))
            {
                using (StreamReader reader = new StreamReader(archivoAlumnos))
                {
                    string lineas;

                    while ((lineas = reader.ReadLine()) != null)
                    {
                        string[] linea = lineas.Split(',');
                        Alumno alumno = new Alumno
                        {
                            Carne = linea[0],
                            Nombre = linea[1],
                            Celular = linea[2],
                        };
                        lts_alumnos.Items.Add(alumno);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Archivo no existia, se creo uno nuevo");
            }

        }



        private void lts_alumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lts_alumnos.SelectedItem != null)
            {
                Alumno alumno = (Alumno)lts_alumnos.SelectedItem;
                txt_Carne.Text = alumno.Carne.ToString();
                txt_nombre.Text = alumno.Nombre.ToString();
                txt_celular.Text = alumno.Celular.ToString();
            }
        }

        public void limpiarCtls()
        {
            txt_Carne.Clear();
            txt_nombre.Clear();
            txt_celular.Clear();
        }

        private void btn__guardar_Click(object sender, EventArgs e)
        {
            string carne; string nombre; string celular;
            carne = txt_Carne.Text;
            nombre = txt_nombre.Text;
            celular = txt_celular.Text;
            
            if (string.IsNullOrEmpty(carne) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(celular))
            {
                MessageBox.Show("Datos faltantes, valide datos", "Error");

            }
            else
            {
                using (StreamWriter writer = new StreamWriter(archivoAlumnos,true))
                {
                    writer.WriteLine($"{carne},{nombre},{celular}");
                }
                CargarAlumnos();
                limpiarCtls();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if(lts_alumnos.SelectedItem  != null)
            {
                Alumno alumno = (Alumno)lts_alumnos.SelectedItem; 
                string[] dataEliminar = File.ReadAllLines(archivoAlumnos);

                dataEliminar = dataEliminar.Where(x => !x.Contains(alumno.Carne)).ToArray();
                File.WriteAllLines(archivoAlumnos, dataEliminar);
                CargarAlumnos();
                limpiarCtls();
            }
            else
            {
                MessageBox.Show("Primero seleccione el registro a eliminar");
            }
            
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if(lts_alumnos.SelectedItem != null) 
            {
                Alumno alumno = (Alumno)lts_alumnos.SelectedItem;
                string carne; string nombre; string celular;
                carne = txt_Carne.Text;
                nombre = txt_nombre.Text;
                celular = txt_celular.Text;

                if (string.IsNullOrEmpty(carne) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(celular))
                {
                    MessageBox.Show("Datos faltantes, valide datos", "Error");
                }
                else
                {
                    string[] dataUpdate = File.ReadAllLines(archivoAlumnos);
                    string lineaCambios;
                    lineaCambios = $"{carne},{nombre},{celular}";

                    for(int i = 0; i < dataUpdate.Length; i++)
                    {
                        if (dataUpdate[i].Contains(alumno.Carne))
                        {
                            dataUpdate[i] = lineaCambios; 
                        }
                    }
                    File.WriteAllLines(archivoAlumnos,dataUpdate);
                    CargarAlumnos();
                    limpiarCtls();
                }
            }

            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn__guardar.Enabled = false; 
            btn_eliminar.Enabled = false;
            btn_actualizar.Enabled = true;
            txt_Carne.Enabled = false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn__guardar.Enabled=false;
            btn_actualizar.Enabled=false;
            btn_eliminar.Enabled = true;

        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn__guardar.Enabled = true;
            txt_Carne.Enabled = true;
            btn_eliminar.Enabled = false;
            btn_actualizar.Enabled = false;
        }
    }

    public class Alumno
    {
        public string Carne { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }

        public override string ToString()
        {
            return $"{Carne},{Nombre},{Celular}";
        }
    }
}
