using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen
{
    public partial class adicionar : Form
    {
        public adicionar()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("server=DESKTOP-CAMOLMM; database=bdever; User ID=sa; Password=lever1;"))
                {

                    string query = "INSERT INTO Persona (ci, nombre, apellido, rol, contraseña) VALUES (@ci, @nombre, @apellido, @rol, @contraseña)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    {
                        cmd.Parameters.AddWithValue("@ci", textBox1.Text);
                        cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
                        cmd.Parameters.AddWithValue("@apellido", textBox3.Text);
                        cmd.Parameters.AddWithValue("@rol", textBox4.Text);
                        cmd.Parameters.AddWithValue("@contraseña", textBox5.Text);

                        con.Open();

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Datos guardados exitosamente");
                            AdministradorForm adminForm = new AdministradorForm();
                            adminForm.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Error al guardar los datos");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
        }
    }
}
