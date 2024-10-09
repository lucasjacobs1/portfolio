using LogicLayer;
using LogicLayer.CustomExceptions;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuelSys
{
    public partial class GenerateTournamentSchedule : Form
    {
        private TournamentAdmin tournamentAdmin;
        private MatchAdmin matchAdmin;
        private readonly BindingSource _source = new();


        public GenerateTournamentSchedule(TournamentAdmin tournamentAdmin, MatchAdmin matchAdmin)
        {
            InitializeComponent();
            this.tournamentAdmin = tournamentAdmin;
            this.matchAdmin = matchAdmin;
            try
            {
                DisplayTournaments();
            }
            catch (DatabaseFailedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayTournaments()
        {
            dataGridViewShowTournaments.Rows.Clear();
            _source.DataSource = typeof(Tournament);
            foreach (var t in tournamentAdmin.GetTournamentsThatAreOpen())
            {
                _source.Add(t);
            }
            dataGridViewShowTournaments.DataSource = _source;
            dataGridViewShowTournaments.AutoGenerateColumns = true;
            dataGridViewShowTournaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void GenerateTournamentSchedule_Load(object sender, EventArgs e)
        {

        }

        private void BtnGenerateSchedule_Click(object sender, EventArgs e)
        {
          
            try
            {
                matchAdmin.GenerateMatches(Convert.ToInt32(TbxId.Text));
                LbxMatches.Items.Clear();
                List<TournamentMatch> tournamentMatches = matchAdmin.GetAllMatchesOfATournament(Convert.ToInt32(TbxId.Text));
                foreach (var match in tournamentMatches)
                {
                    LbxMatches.Items.Add($"Id: {match.Id}, Tournament:{match.TournamentId}, Home: {match.PlayerHomeId} -- Away: {match.PlayerAwayId}");
                }
                DisplayTournaments();
                MessageBox.Show("Succesfully generated matches");

            }
            catch (TournamentGeneratorFailedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(DatabaseFailedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewShowTournaments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    TbxId.Text = dataGridViewShowTournaments.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
        }

        private void TbxId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
