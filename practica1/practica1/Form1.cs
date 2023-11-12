using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica1
{
    public partial class Form1 : Form
    {
        string archivoEmpleados = "controlEmpleados.txt";
        public string archivoBitacora = "bitacoraCambios.txt";
        List<Empleado> empleados = new List<Empleado>();
        public Form1()
        {
            InitializeComponent();
            CargarArchivo();
            lts_empleados.SelectedIndexChanged += lts_empleados_SelectedIndexChanged;
        }

        public void CargarArchivo()
        {
            lts_empleados.Items.Clear();

            if (File.Exists(archivoEmpleados))
            {
                using (StreamReader reader = new StreamReader(archivoEmpleados))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        string[] lines = linea.Split(',');
                        Empleado empleado = new Empleado
                        {
                            Codigo = lines[0],
                            Nombre = lines[1],
                            Apellido = lines[2],
                            Sueldo = Convert.ToDouble(lines[3]),
                        };
                        lts_empleados.Items.Add(empleado);
                        //
                        empleados.Add(empleado);
                    }
                }
            }
            else
            {
                MessageBox.Show("No Existe el Archivo, se creará uno nuevo", "Error");
            }
        }

        public bool buscar(string codigo)
        {
            for(int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].Nombre == codigo)
                {
                    MessageBox.Show($"{empleados[i].Nombre},{empleados[i].Apellido}");
                    return true;
                }
            }
            return false;
        } 

        private void lts_empleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lts_empleados.SelectedItem != null)
            {
                Empleado empleado = (Empleado)lts_empleados.SelectedItem;
                txt_codigo.Text = empleado.Codigo.ToString();
                txt_nombre.Text = empleado.Nombre;
                txt_apellido.Text = empleado.Apellido;
                txt_sueldo.Text = empleado.Sueldo.ToString();

            }
        }


        //eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            if(lts_empleados.SelectedItem != null)
            {
                Empleado empleado = (Empleado)lts_empleados.SelectedItem; 
                string[] dataTemp = File.ReadAllLines(archivoEmpleados);
                
                dataTemp = dataTemp.Where(x => !x.Contains(empleado.Codigo)).ToArray();
                empleados.Remove(empleado);
                File.WriteAllLines(archivoEmpleados, dataTemp);
                using (StreamWriter writer1 = new StreamWriter(archivoBitacora, true))
                {
                    writer1.WriteLine($"Detalle: Se eliminó el registro, Codigo:{empleado.Codigo}");
                }
                CargarArchivo(); 
                limpiarCtls();
            }
            else
            {
                MessageBox.Show("Seleccione registro antes de eliminar", "Error");
            }
        }
        
        //Actualizar
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (lts_empleados.SelectedItem != null)
            {
                Empleado empleado = (Empleado)lts_empleados.SelectedItem; 
                string lineaCambios;
                string codigo = txt_codigo.Text.Trim();
                string nombre = txt_nombre.Text.Trim();
                string apellido = txt_apellido.Text.Trim();
                double sueldo = Convert.ToDouble(txt_sueldo.Text);

                if (string.IsNullOrEmpty(codigo)||string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || Double.TryParse(txt_sueldo.Text,out sueldo) == false)
                {
                    MessageBox.Show("Campos vacios, seleccione registro antes de actualizar", "Error al Actualizar");
                } 
                
                lineaCambios = $"{codigo},{nombre},{apellido},{sueldo}";
                string[] consultarToUpdate = File.ReadAllLines(archivoEmpleados);

                for (int i = 0; i < consultarToUpdate.Length; i++)
                {
                    if (consultarToUpdate[i].Contains(empleado.Codigo))
                    {
                        consultarToUpdate[i] = lineaCambios;
                    }
                }
                File.WriteAllLines(archivoEmpleados, consultarToUpdate);
                using (StreamWriter writer = new StreamWriter(archivoBitacora, true))
                {
                    writer.WriteLine($"Detalle: Actualización del registro Codigo:{codigo} Cambios:{nombre},{apellido},{sueldo}");
                }
                
                for (int i = 0; i < empleados.Count; i++)
                {
                    if (empleados[i].Codigo == codigo)
                    {
                        empleados[i].Codigo = codigo;
                        empleados[i].Nombre = nombre;
                        empleados[i].Apellido = apellido;
                        empleados[i].Sueldo = sueldo;
                    }
                }
                CargarArchivo(); 
                limpiarCtls();
            }
            else
            {
                MessageBox.Show("Antes de Actualizar seleccione el registros");
            }
        }


        //Guardar
        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = txt_codigo.Text.Trim();
            string nombre = txt_nombre.Text.Trim();
            string apellido = txt_apellido.Text.Trim();
            double sueldo;

            if (string.IsNullOrEmpty(codigo)||string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || double.TryParse(txt_sueldo.Text.Trim(), out sueldo) == false)
            {
                MessageBox.Show("Faltan Datos, valide datos ingresados", "Error al Guardar");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(archivoEmpleados, true))
                {
                    writer.WriteLine($"{codigo},{nombre},{apellido},{sueldo}");
                }
                using(StreamWriter writer1 = new StreamWriter(archivoBitacora, true))
                {
                    writer1.WriteLine($"Detalle: Insersión del registro, Código:{codigo}, Nombre:{nombre},Apellido:{apellido},Sueldo:{sueldo}");
                }
                limpiarCtls();
                CargarArchivo();
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_guardar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_buscar.Enabled = false;
            btn_actualiar.Enabled = true;
            txt_codigo.Enabled = false;
            txt_nombre.Enabled = true;
            txt_apellido.Enabled = true;
            txt_sueldo.Enabled = true;
            limpiarCtls(); 
        }

        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btn_actualiar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_buscar.Enabled = false;
            btn_guardar.Enabled = true;
            txt_codigo.Enabled = true;
            txt_nombre.Enabled = true;
            txt_apellido.Enabled=true;
            txt_sueldo.Enabled=true;
            limpiarCtls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_actualiar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_buscar.Enabled = false;
        }

        public void limpiarCtls()
        {
            txt_codigo.Clear();
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_sueldo.Clear();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_actualiar.Enabled = false; 
            btn_guardar.Enabled = false;
            btn_buscar.Enabled=false;
            btn_eliminar.Enabled = true;
            limpiarCtls();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bitacora bitacora = new Bitacora();
            bitacora.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            txt_nombre.Enabled = false;
            txt_apellido.Enabled = false;
            txt_sueldo.Enabled = false;
            btn_guardar.Enabled = false;
            btn_actualiar.Enabled=false;
            btn_eliminar.Enabled=false;
            txt_codigo.Enabled = true;
            btn_buscar.Enabled = true;
            limpiarCtls();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string codigo = txt_codigo.Text.Trim();
            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Ingrese el codigo que desea buscar");
            }
            else
            {
                if (!buscar(codigo))
                {
                    MessageBox.Show("El codigo no existe");
                };
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }

    public class Empleado
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double Sueldo { get; set; }

        public override string ToString()
        {

            return $"{Codigo},{Nombre},{Apellido},{Sueldo}";
        }
    }
}
