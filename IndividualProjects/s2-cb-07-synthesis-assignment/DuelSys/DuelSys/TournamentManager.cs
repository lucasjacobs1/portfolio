using LogicLayer;
using LogicLayer.CustomExceptions;
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
    public partial class TournamentManager : Form
    {
        private TournamentAdmin tournamentAdmin;
        private SportAdmin sportAdmin;
        private readonly BindingSource _source = new();

        public TournamentManager(TournamentAdmin tournamentAdmin, SportAdmin sportAdmin)
        {
            InitializeComponent();
            this.tournamentAdmin = tournamentAdmin;
            this.sportAdmin = sportAdmin;
            try
            {
                AddSports();
                AddTournamentSystems();
                DisplayTournaments();
            }
            catch (DatabaseFailedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddSports()
        {
            foreach (Sport sport in sportAdmin.GetAllSports())
            {
                CbxSport.Items.Add(sport.Name);
            }
        }

        private void AddTournamentSystems()
        {
            foreach (TournamentSystem tournamentSystem in tournamentAdmin.GetAllTournamentSystems())
            {
                CbxTournamentType.Items.Add(tournamentSystem.Name);
            }
        }

        private void DisplayTournaments()
        {
            dataGridViewShowTournaments.Rows.Clear();
            _source.DataSource = typeof(Tournament);
            foreach (var t in tournamentAdmin.GetAllTournaments())
            {
                _source.Add(t);
            }
            dataGridViewShowTournaments.DataSource = _source;
            dataGridViewShowTournaments.AutoGenerateColumns = true;
            dataGridViewShowTournaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearInput()
        {
            dateTimePickerStartDate.Value = DateTime.Today;
            dateTimePickerEndDate.Value = DateTime.Today;
            TbxMinimumPlayers.Text = null;
            TbxMaximumPlayers.Text = null;
            TbxLocation.Text = null;
            TbxId.Text = null;
            CbxSport.Text = null;
            CbxTournamentType.Text = null;
            RtxDescription.Text = null;

        }

        private void BtnAddTournament_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to add a tourament", "Add Tournament", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tournamentAdmin.AddTournament(new Tournament(RtxDescription.Text, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, TbxLocation.Text, Convert.ToInt32(TbxMinimumPlayers.Text), Convert.ToInt32(TbxMaximumPlayers.Text), CbxSport.SelectedIndex, CbxTournamentType.SelectedIndex)))
                    {
                        ClearInput();
                        DisplayTournaments();
                        MessageBox.Show("Added with success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (InvalidTournamentInputException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DatabaseFailedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void TournamentManager_Load(object sender, EventArgs e)
        {

        }

        private void BtnUpdateTournament_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to update tourament with id: {TbxId.Text}", "Update Tournament", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tournamentAdmin.UpdateTournament(new Tournament(Convert.ToInt32(TbxId.Text), RtxDescription.Text, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, TbxLocation.Text, Convert.ToInt32(TbxMinimumPlayers.Text), Convert.ToInt32(TbxMaximumPlayers.Text), CbxSport.SelectedIndex, CbxTournamentType.SelectedIndex)))
                    {
                        ClearInput();
                        MessageBox.Show("Updated with success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayTournaments();
                    }
                }

            }
            catch (InvalidTournamentInputException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DatabaseFailedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void BtnDeleteTournament_Click(object sender, EventArgs e)
        {
            try
            {
                int SelectedId = Convert.ToInt32(TbxId.Text);
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete tourament with id: {SelectedId}", "Delete Tournament", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    tournamentAdmin.DeleteTournament(SelectedId);
                    ClearInput();
                    DisplayTournaments();
                    MessageBox.Show("Deleted with success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (InvalidTournamentInputException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DatabaseFailedException ex)
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
                    Tournament t = tournamentAdmin.GetTournamentById(Convert.ToInt32(TbxId.Text));
                    dateTimePickerStartDate.Value = t.StartDate;
                    dateTimePickerEndDate.Value = t.EndDate;
                    TbxMinimumPlayers.Text = t.MinimumPlayers.ToString();
                    TbxMaximumPlayers.Text = t.MaximumPlayers.ToString();
                    TbxLocation.Text = t.Location;
                    RtxDescription.Text = t.Description;
                    CbxSport.SelectedIndex = t.SportId;
                    CbxTournamentType.SelectedIndex = t.TournamentTypeId;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridViewShowTournaments.Rows.Clear();
            _source.DataSource = typeof(Tournament);
            foreach (var t in tournamentAdmin.SearchTournamentsByLocation(TbxSearch.Text))
            {
                _source.Add(t);
            }
            dataGridViewShowTournaments.DataSource = _source;
            dataGridViewShowTournaments.AutoGenerateColumns = true;
            dataGridViewShowTournaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
    }
}
