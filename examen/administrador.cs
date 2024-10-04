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
    public partial class AdministradorForm : Form
    {
        public AdministradorForm()
        {
            InitializeComponent();
        }

        private void AdministradorForm_Load(object sender, EventArgs e)
        {
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            dataGridView1.RowValidated += new DataGridViewCellEventHandler(dataGridView1_RowValidated);
            dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            dataGridView2.RowValidated += new DataGridViewCellEventHandler(dataGridView1_RowValidated);
        }
        SqlConnection con;
        SqlDataAdapter ada;
        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("server=DESKTOP-CAMOLMM; database=bdever; User ID=sa; Password=lever1;");
                {
                    ada = new SqlDataAdapter("SELECT * FROM Persona", con);
                    SqlCommandBuilder builder = new SqlCommandBuilder(ada);

                    dt = new DataTable();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de materias: " + ex.Message);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    int id = Convert.ToInt32(row.Cells["ci"].Value);
                    string nombre = row.Cells["nombre"].Value.ToString();
                    string apellido = row.Cells["apellido"].Value.ToString();
                    string rol = row.Cells["rol"].Value.ToString();
                    string contraseña = row.Cells["contraseña"].Value.ToString();

                    SqlConnection con = new SqlConnection("server=DESKTOP-CAMOLMM; database=bdever; User ID=sa; Password=lever1;");
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Persona SET nombre = @nombre, apellido = @apellido, rol=@rol, contraseña=@contraseña WHERE id = @id", con);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@rol", rol);
                        cmd.Parameters.AddWithValue("@contraseña", contraseña);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dt != null && dt.GetChanges() != null)
                {
                    ada.Update(dt);
                    dt.AcceptChanges();
                }
            }
            catch (Exception ex)
            { }
        }


        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    string superficie = row.Cells["superficie"].Value.ToString();
                    string xi = row.Cells["xi"].Value.ToString();
                    string xf = row.Cells["xf"].Value.ToString();
                    string yi = row.Cells["xi"].Value.ToString();
                    string yf = row.Cells["xf"].Value.ToString();

                    SqlConnection con = new SqlConnection("server=DESKTOP-CAMOLMM; database=bdever; User ID=sa; Password=lever1;");
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Catastro SET id = @id, superficie = @superficie, xi=@xi, xf=@xf, yi=@yi, yf=@yf WHERE id = @id", con);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@superficie", superficie);
                        cmd.Parameters.AddWithValue("@xi", xi);
                        cmd.Parameters.AddWithValue("@xf", xf);
                        cmd.Parameters.AddWithValue("@yi", yi);
                        cmd.Parameters.AddWithValue("@yf", yf);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        private void dataGridView2_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dt != null && dt.GetChanges() != null)
                {
                    ada.Update(dt);
                    dt.AcceptChanges();
                }
            }
            catch (Exception ex)
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("server=DESKTOP-CAMOLMM; database=bdever; User ID=sa; Password=lever1;");
                {
                    ada = new SqlDataAdapter("SELECT * FROM Catastro", con);
                    SqlCommandBuilder builder = new SqlCommandBuilder(ada);

                    dt = new DataTable();
                    ada.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de materias: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adicionar adi = new adicionar();
            adi.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdiCatastro adi = new AdiCatastro();
            adi.Show();
            this.Hide();
        }


    }
}
