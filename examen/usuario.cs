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
    public partial class UsuarioForm : Form
    {
        public UsuarioForm()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter ada;
        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            string ci = textBox1.Text.Trim(); // Obtiene el CI del textBox1

            // Verifica si el CI está vacío
            if (string.IsNullOrWhiteSpace(ci))
            {
                MessageBox.Show("Por favor, ingrese un CI válido.");
                return; // Si está vacío, retorna y no ejecuta la consulta
            }

            // Conexión a la base de datos
            using (con = new SqlConnection("server=DESKTOP-CAMOLMM; database=bdever; User ID=sa; Password=lever1;"))
            {
                try
                {
                    con.Open();

                    // Consulta SQL con el CI ingresado en el textBox1
                    string query = @"
                    SELECT xp.nombre, xp.apellido, xp.rol, xc.id, xc.xi, xc.xf, xc.yi, xc.yf
                    FROM Persona xp
                    INNER JOIN tiene xt ON xp.ci = xt.ci
                    INNER JOIN Catastro xc ON xc.id = xt.id
                    WHERE xp.ci = @ci";

                    // Creación del SqlCommand para ejecutar la consulta
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ci", ci); // Parámetro para evitar inyección SQL

                        ada = new SqlDataAdapter(cmd); // Llenar el DataTable con los resultados
                        dt = new DataTable();
                        ada.Fill(dt);

                        // Verifica si hay resultados
                        if (dt.Rows.Count > 0)
                        {
                            // Cargar los resultados en el DataGridView
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron registros para el CI ingresado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + "\n" + ex.StackTrace);
                }
                finally
                {
                    con.Close(); // Asegurarse de cerrar la conexión
                }
            }
        }

    }
}
