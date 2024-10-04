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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        SqlConnection con;
        SqlDataAdapter ada;
        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text.Trim(); 
            string contraseña = textBox2.Text.Trim(); 
            string rol = textBox3.Text.Trim();
            using (con = new SqlConnection("server=DESKTOP-CAMOLMM; database=bdever; User ID=sa; Password=lever1;"))
            {
                try
                {
                    con.Open();


                    string query = "SELECT COUNT(*) FROM Persona WHERE ci = @usuario AND contraseña = @contraseña";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contraseña", contraseña);

                        if (rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                        {

                            AdministradorForm adminForm = new AdministradorForm();
                            adminForm.Show();
                            this.Hide(); 
                        }
                        else if (rol.Equals("Usuario", StringComparison.OrdinalIgnoreCase))
                        {

                            UsuarioForm usuarioForm = new UsuarioForm();
                            usuarioForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Rol no reconocido.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + "\n" + ex.StackTrace);
                }
                finally
                {
                    con.Close();
                }
            }
        }





    }
}