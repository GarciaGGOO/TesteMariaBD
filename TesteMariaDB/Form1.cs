using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TesteMariaDB
{
    public partial class Form1 : Form
    {
        private DateTime startTime;
        private bool populating = false;
        private System.Windows.Forms.Timer formTimer;
        private string nomeTabela = "dados2";
        private string nomeBanco = "armazenamentobd";
        private int totalInsercoes = 0; // Variável para acompanhar o número total de inserções
        private int insercoesConcluidas = 0; // Variável para acompanhar o número de inserções concluídas


        public Form1()
        {
            InitializeComponent();
            formTimer = new System.Windows.Forms.Timer();
            formTimer.Interval = 100;
            formTimer.Tick += cronometro_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblResultado.Text = "Aguardando conexão...";
            lblCronometro.Text = "00:00:00.000";
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            string conexao = GetConnectionString();
            try
            {
                using (var conexaoConnection = new MySqlConnection(conexao))
                {
                    conexaoConnection.Open();
                    lblResultado.Text = "Conectado";
                }
            }
            catch (MySqlException ex)
            {
                lblResultado.Text = $"Erro: {ex.Message}";
            }
        }

        private async void btnPopular_Click(object sender, EventArgs e)
        {
            if (populating)
            {
                MessageBox.Show("População em andamento. Por favor, aguarde.");
                return;
            }

            populating = true;
            startTime = DateTime.UtcNow;
            formTimer.Start();

            string conexao = GetConnectionString();

            try
            {
                using (var conexaoConnection = new MySqlConnection(conexao))
                {
                    conexaoConnection.Open();
                    totalInsercoes = 5 * 365 * 1440 * 4 * 13; // Total de inserções
                    //totalInsercoes = 100;
                    progressBar.Maximum = totalInsercoes; // Definindo o máximo da barra de progresso

                    await Task.Run(() => PopularDados(conexaoConnection));
                    AtualizarLabel(lblResultado, "Tabela populada com sucesso.");
                    MostrarResultados(conexaoConnection);
                }
            }
            catch (MySqlException ex)
            {
                AtualizarLabel(lblResultado, $"Erro: {ex.Message}");
            }
            finally
            {
                populating = false;
                formTimer.Stop();
            }
        }

        private void PopularDados(MySqlConnection conexaoConnection)
        {
            Random random = new Random();

            int totalEstacoes = 4;
            int totalCameras = 13;
            int totalMinutos = 5 * 365 * 1440;
            int totalIteracoes = totalEstacoes * totalCameras * totalMinutos;
            //int totalIteracoes = 100;

            using (var transaction = conexaoConnection.BeginTransaction())
            {
                for (int i = 0; i < totalIteracoes; i++)
                {
                    int estacao = (i / (totalCameras * totalMinutos)) % totalEstacoes + 1;
                    int camera = (i / totalMinutos) % totalCameras + 1;
                    int minuto = i % totalMinutos;

                    DateTime data_hora = new DateTime(2024, 1, 1, 0, 0, 0).AddMinutes(minuto);
                    double temp_maxima = Math.Round(random.NextDouble() * 999.9, 1);
                    double temp_minima = Math.Round(random.NextDouble() * 999.9, 1);
                    double temp_media = Math.Round((temp_maxima + temp_minima) / 2, 1);
                    double temp_externa = Math.Round(random.NextDouble() * 999.9, 1);
                    DateTime hora_final = DateTime.UtcNow;

                    string query = $"INSERT INTO {nomeTabela} (id_area, data_hora, temp_maxima, temp_minima, temp_media, temp_externa, hora_final) " +
                                   "VALUES (@id_area, @data_hora, @temp_maxima, @temp_minima, @temp_media, @temp_externa, @hora_final)";

                    using (var cmd = new MySqlCommand(query, conexaoConnection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id_area", estacao);
                        cmd.Parameters.AddWithValue("@data_hora", data_hora);
                        cmd.Parameters.AddWithValue("@temp_maxima", temp_maxima);
                        cmd.Parameters.AddWithValue("@temp_minima", temp_minima);
                        cmd.Parameters.AddWithValue("@temp_media", temp_media);
                        cmd.Parameters.AddWithValue("@temp_externa", temp_externa);
                        cmd.Parameters.AddWithValue("@hora_final", hora_final);

                        cmd.ExecuteNonQuery();
                    }

                    insercoesConcluidas++; // Incrementando o número de inserções concluídas
                    AtualizarProgressBar(insercoesConcluidas); // Atualizando a barra de progresso
                    AtualizarLabel(lblContador, $"{insercoesConcluidas} de {totalInsercoes}"); // Atualizando o contador
                }

                transaction.Commit();
            }
        }

        private void MostrarResultados(MySqlConnection conexaoConnection)
        {
            AtualizarTextBox(txtResultados, "");

            // Consulta para a última hora
            string queryUltimaHora = $"SELECT COUNT(*) FROM {nomeTabela} WHERE data_hora >= NOW() - INTERVAL 1 HOUR";
            long countUltimaHora = ExecuteCountQuery(conexaoConnection, queryUltimaHora);
            AtualizarTextBox(txtResultados, $"Dados na última hora: {countUltimaHora}{Environment.NewLine}");

            // Consulta para a primeira hora
            string queryPrimeiraHora = $"SELECT COUNT(*) FROM {nomeTabela} WHERE data_hora >= (SELECT MIN(data_hora) FROM {nomeTabela}) AND data_hora < (SELECT MIN(data_hora) FROM {nomeTabela}) + INTERVAL 1 HOUR";
            long countPrimeiraHora = ExecuteCountQuery(conexaoConnection, queryPrimeiraHora);
            AtualizarTextBox(txtResultados, $"Dados na primeira hora: {countPrimeiraHora}{Environment.NewLine}");

            // Consulta para o primeiro mês
            string queryPrimeiroMes = $"SELECT COUNT(*) FROM {nomeTabela} WHERE data_hora >= (SELECT MIN(data_hora) FROM {nomeTabela}) AND data_hora < (SELECT MIN(data_hora) FROM {nomeTabela}) + INTERVAL 1 MONTH";
            long countPrimeiroMes = ExecuteCountQuery(conexaoConnection, queryPrimeiroMes);
            AtualizarTextBox(txtResultados, $"Dados no primeiro mês: {countPrimeiroMes}{Environment.NewLine}");

            // Consulta para o primeiro ano
            string queryPrimeiroAno = $"SELECT COUNT(*) FROM {nomeTabela} WHERE data_hora >= (SELECT MIN(data_hora) FROM {nomeTabela}) AND data_hora < (SELECT MIN(data_hora) FROM {nomeTabela}) + INTERVAL 1 YEAR";
            long countPrimeiroAno = ExecuteCountQuery(conexaoConnection, queryPrimeiroAno);
            AtualizarTextBox(txtResultados, $"Dados no primeiro ano: {countPrimeiroAno}{Environment.NewLine}");

            // Consulta para os últimos 5 anos
            string queryUltimosCincoAnos = $"SELECT COUNT(*) FROM {nomeTabela} WHERE data_hora >= NOW() - INTERVAL 5 YEAR";
            long countUltimosCincoAnos = ExecuteCountQuery(conexaoConnection, queryUltimosCincoAnos);
            AtualizarTextBox(txtResultados, $"Dados nos últimos 5 anos: {countUltimosCincoAnos}{Environment.NewLine}");
        }

        private long ExecuteCountQuery(MySqlConnection conexaoConnection, string query)
        {
            using (var cmd = new MySqlCommand(query, conexaoConnection))
            {
                return (long)cmd.ExecuteScalar();
            }
        }

        private void cronometro_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.UtcNow - startTime;
            lblCronometro.Text = $"{elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}.{elapsed.Milliseconds:D3}";
        }

        private string GetConnectionString()
        {
            string server = "localhost";
            string user = "root";
            string pwd = "root";
            string database = nomeBanco;
            return $"server={server};user={user};pwd={pwd};database={database};SslMode=none;";
        }

        private void AtualizarLabel(Label label, string texto)
        {
            if (label.InvokeRequired)
            {
                label.Invoke((MethodInvoker)delegate { label.Text = texto; });
            }
            else
            {
                label.Text = texto;
            }
        }

        private void AtualizarTextBox(System.Windows.Forms.TextBox textBox, string texto)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke((MethodInvoker)delegate { textBox.AppendText(texto); });
            }
            else
            {
                textBox.AppendText(texto);
            }
        }


        private void AtualizarProgressBar(int valor)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke((MethodInvoker)delegate { progressBar.Value = valor; });
            }
            else
            {
                progressBar.Value = valor;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
