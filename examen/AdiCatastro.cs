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
    public partial class AdiCatastro : Form
    {
        public AdiCatastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Establecer la conexión a la base de datos
                using (SqlConnection con = new SqlConnection("server=DESKTOP-CAMOLMM; database=bdever; User ID=sa; Password=lever1;"))
                {
                    // Crear la consulta SQL para insertar los datos en la tabla Terreno
                    string query = "INSERT INTO Catastro (id, superficie, xi, xf, yi, yf) VALUES (@id, @superficie, @xi, @xf, @yi, @yf)";

                    // Crear el comando SQL con los parámetros
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Obtener los valores de los TextBox
                        cmd.Parameters.AddWithValue("@id", textBox1.Text);
                        cmd.Parameters.AddWithValue("@superficie", textBox2.Text);
                        cmd.Parameters.AddWithValue("@xi", textBox3.Text);
                        cmd.Parameters.AddWithValue("@xf", textBox4.Text);
                        cmd.Parameters.AddWithValue("@yi", textBox5.Text);
                        cmd.Parameters.AddWithValue("@yf", textBox6.Text);

                        // Abrir la conexión
                        con.Open();

                        // Ejecutar la consulta
                        int result = cmd.ExecuteNonQuery();

                        // Verificar si se insertó el registro correctamente
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
