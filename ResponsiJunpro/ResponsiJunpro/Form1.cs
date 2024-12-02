using Npgsql;
using System.Data;
using System.Linq.Expressions;
using System.Windows.Forms;


namespace ResponsiJunpro
{
    public partial class Form1 : Form
    {

        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Nazril0908;Database=ResponsiJunpro";
        private NpgsqlConnection connection;
        private DataGridViewRow selectedRow;

        public Form1()
        {
            InitializeComponent();
            connection = new NpgsqlConnection(connectionString);

            LoadKaryawan();
            LoadDepartemen();
        }


        private void dgvKaryawan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedRow = dgvKaryawan.Rows[e.RowIndex];

            string idKaryawan = selectedRow.Cells["id_karyawan"]?.Value?.ToString();
            if (idKaryawan != null)
            {
                Console.WriteLine($"id_karyawan: {idKaryawan}");
                tbNama.Text = selectedRow.Cells["nama"]?.Value?.ToString() ?? "";
                string idDep = selectedRow.Cells["id_dep"]?.Value?.ToString();

                if (idDep != null && cbDepartemen.Items.Cast<DataRowView>().Any(item => item["id_dep"].ToString() == idDep))
                {
                    cbDepartemen.SelectedValue = idDep;
                    Console.WriteLine($"id_dep: {idDep}");
                }
                else
                {
                    Console.WriteLine("id_dep tidak valid.");
                }
            }
            else
            {
                Console.WriteLine("id_karyawan tidak ditemukan.");
            }
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT add_karyawan(@nama, @id_dep)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nama", tbNama.Text);
                    cmd.Parameters.AddWithValue("@id_dep", cbDepartemen.SelectedValue);

                    connection.Open();
                    int result = (int)cmd.ExecuteScalar();
                    connection.Close();

                    if (result == 201)
                        MessageBox.Show("Karyawan berhasil ditambahkan.");
                    else
                        MessageBox.Show("Karyawan sudah ada.");
                }
                LoadKaryawan();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRow == null)
                {
                    MessageBox.Show("Pilih data karyawan terlebih dahulu.");
                    return;
                }

                string query = "SELECT delete_karyawan(@id_karyawan)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    string idKaryawan = selectedRow.Cells["id_karyawan"].Value.ToString();
                    cmd.Parameters.AddWithValue("@id_karyawan", idKaryawan);

                    connection.Open();
                    int result = (int)cmd.ExecuteScalar();
                    connection.Close();

                    if (result == 204)
                        MessageBox.Show("Karyawan berhasil dihapus.");
                    else if (result == 404)
                        MessageBox.Show("Karyawan tidak ditemukan.");
                }
                LoadKaryawan();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }



        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadKaryawan();
        }

        private void LoadDepartemen()
        {
            try
            {
                string query = "SELECT id_dep, nama_dep FROM departemen";
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    cbDepartemen.DataSource = dataTable;
                    cbDepartemen.DisplayMember = "id_dep"; // Menampilkan id_dep
                    cbDepartemen.ValueMember = "id_dep";  // Nilai yang dipilih tetap id_dep
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void LoadKaryawan()
        {
            try
            {
                string query = "SELECT id_karyawan, nama, id_dep FROM karyawan";
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvKaryawan.DataSource = dataTable;
                    dgvKaryawan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Pastikan baris DataGridView telah dipilih
                if (selectedRow == null) return;

                string idKaryawan = selectedRow.Cells["id_karyawan"]?.Value?.ToString();
                if (string.IsNullOrEmpty(idKaryawan)) return;

                string namaBaru = tbNama.Text;
                string idDepBaru = cbDepartemen.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(namaBaru) || string.IsNullOrEmpty(idDepBaru)) return;

                string query = $"UPDATE karyawan SET nama = @nama, id_dep = @id_dep WHERE id_karyawan = '{idKaryawan}'";  // Menambahkan tanda kutip manual

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nama", namaBaru);
                    cmd.Parameters.AddWithValue("@id_dep", idDepBaru);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        LoadKaryawan(); // Refresh data pada DataGridView
                        MessageBox.Show("Data karyawan berhasil diperbarui.", "Update Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data karyawan tidak ditemukan atau tidak ada perubahan.", "Update Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
