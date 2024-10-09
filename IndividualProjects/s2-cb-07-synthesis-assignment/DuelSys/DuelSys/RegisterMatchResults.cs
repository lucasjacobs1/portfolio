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
    public partial class RegisterMatchResults : Form
    {
        private TournamentAdmin tournamentAdmin;
        private MatchAdmin matchAdmin;
        private readonly BindingSource _source = new();
        private List<TournamentMatch> matches = new();

        public RegisterMatchResults(TournamentAdmin tournamentAdmin, MatchAdmin matchAdmin)
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
            foreach (var t in tournamentAdmin.GetTournamentsThatAreClosed())
            {
                _source.Add(t);
            }
            dataGridViewShowTournaments.DataSource = _source;
            dataGridViewShowTournaments.AutoGenerateColumns = true;
            dataGridViewShowTournaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void DisplayUnRegisteredMatches(int tournamentId)
        {
            LbxMatches.Items.Clear();
            matches = matchAdmin.GetUnRegisteredMatchesOfTournament(tournamentId);
            foreach (var tournamentMatch in matches)
            {
                LbxMatches.Items.Add($"Tournament ID: {tournamentMatch.TournamentId}, Match ID: {tournamentMatch.Id}, PlayerHome: {tournamentMatch.PlayerHomeId}, PlayerAway: {tournamentMatch.PlayerAwayId}");
            }
        }

        private void RegisterMatchResults_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegisterMatchResult_Click(object sender, EventArgs e)
        {
            try
            {
                int index = LbxMatches.SelectedIndex;
                TournamentMatch match = matches[index];
                if (matchAdmin.AddMatchResult(new TournamentMatch(match.TournamentId, new MatchResult(match.Id, Convert.ToInt32(TbxScoreHome.Text), Convert.ToInt32(TbxScoreAway.Text)))))
                {
                    MessageBox.Show("Succesfully registered match");
                    TbxScoreAway.Text = String.Empty;
                    TbxScoreHome.Text = String.Empty;
                    DisplayUnRegisteredMatches(match.TournamentId);
                }
            }
            catch(InvalidMatchResultInputException ex)
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
                    int TournamentId = Convert.ToInt32(dataGridViewShowTournaments.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DisplayUnRegisteredMatches(TournamentId);
                }
            }
        }

        private void LbxMatches_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
