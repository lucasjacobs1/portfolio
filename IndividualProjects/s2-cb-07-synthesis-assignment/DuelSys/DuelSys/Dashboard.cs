using LogicLayer;
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
    public partial class Dashboard : Form
    {
        private TournamentAdmin tournamentAdmin;
        private MatchAdmin matchAdmin;
        private SportAdmin sportAdmin;
        public Dashboard(TournamentAdmin tournamentAdmin, MatchAdmin matchAdmin, SportAdmin sportAdmin)
        {
            InitializeComponent();
            this.tournamentAdmin = tournamentAdmin;
            this.matchAdmin = matchAdmin;
            this.sportAdmin = sportAdmin;
            TournamentManager();
        }

        private void timerDate_Tick(object sender, EventArgs e)
        {
            LblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            LblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void BtnTournamentManager_Click(object sender, EventArgs e)
        {
            TournamentManager();
        }

        private void TournamentManager()
        {
            PnlView.Height = BtnTournamentManager.Height;
            PnlView.Top = BtnTournamentManager.Top;
            LblTitle.Text = $"Tournament manager";
            this.PnlMainContent.Controls.Clear();
            TournamentManager dashboard = new TournamentManager(this.tournamentAdmin, this.sportAdmin) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dashboard.FormBorderStyle = FormBorderStyle.None;
            this.PnlMainContent.Controls.Add(dashboard);
            dashboard.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {

        }

        private void BtnGenerateTournamentSchedule_Click(object sender, EventArgs e)
        {
            PnlView.Height = BtnGenerateTournamentSchedule.Height;
            PnlView.Top = BtnGenerateTournamentSchedule.Top;
            LblTitle.Text = $"Generate Tournament Schedule";
            this.PnlMainContent.Controls.Clear();
            GenerateTournamentSchedule dashboard = new GenerateTournamentSchedule(tournamentAdmin, matchAdmin) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dashboard.FormBorderStyle = FormBorderStyle.None;
            this.PnlMainContent.Controls.Add(dashboard);
            dashboard.Show();
        }

        private void BtnRegisterMatchResults_Click(object sender, EventArgs e)
        {
            PnlView.Height = BtnRegisterMatchResults.Height;
            PnlView.Top = BtnRegisterMatchResults.Top;
            LblTitle.Text = $"Register match results";
            this.PnlMainContent.Controls.Clear();
            RegisterMatchResults registerMatchResults = new RegisterMatchResults(tournamentAdmin, matchAdmin) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            registerMatchResults.FormBorderStyle = FormBorderStyle.None;
            this.PnlMainContent.Controls.Add(registerMatchResults);
            registerMatchResults.Show();
        }
    }
}
