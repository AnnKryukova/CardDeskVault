using CardDeskVault.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CardDeskVault
{
    public partial class StartForm : Form
    {
        private List<CardDesk> CardDesks = new List<CardDesk>();
        public StartForm()
        {
            InitializeComponent();

            foreach (var cardDesk in CardDesks)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells["IdColumn"].Value = cardDesk.Id;
                row.Cells["NameColumn"].Value = cardDesk.Name;
                CardDeskVaultDataGridView.Rows.Add(row);
            }
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm();
            if (addEditForm.ShowDialog() == DialogResult.OK)
            {
                var cardDesk = new CardDesk()
                {
                    Id = GetNewId(),
                    Name = addEditForm.Name,
                    Cards = addEditForm.Cards
                };
                CardDesks.Add(cardDesk);

                CardDeskVaultDataGridView.Rows.Add(new object[] { cardDesk.Id, cardDesk.Name });
            }

            addEditForm.Close();
        }

        private void ViewButtonClick(object sender, EventArgs e)
        {
            if (CardDeskVaultDataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = CardDeskVaultDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = CardDeskVaultDataGridView.Rows[selectedrowindex];
                int id = Convert.ToInt32(selectedRow.Cells["IdColumn"].Value);
                string name = Convert.ToString(selectedRow.Cells["NameColumn"].Value);
                AddEditForm addEditForm = new AddEditForm(id, name, GetCardsById(id));
                addEditForm.Show();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать колоду из списка!");
            }
        }
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            if (CardDeskVaultDataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = CardDeskVaultDataGridView.SelectedCells[0].RowIndex; 
                DataGridViewRow selectedRow = CardDeskVaultDataGridView.Rows[selectedrowindex];
                int id = Convert.ToInt32(selectedRow.Cells["IdColumn"].Value);
                CardDeskVaultDataGridView.Rows.RemoveAt(selectedrowindex);
                CardDesks.RemoveAt(CardDesks.FindIndex(x => x.Id == id));
            }
            else
            {
                MessageBox.Show("Необходимо выбрать колоду из списка!");
            }
        }

        private void MixButtonClick(object sender, EventArgs e)
        {
            if (CardDeskVaultDataGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = CardDeskVaultDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = CardDeskVaultDataGridView.Rows[selectedrowindex];
                int id = Convert.ToInt32(selectedRow.Cells["IdColumn"].Value);
                MixForm mixForm = new MixForm(CardDesks.Where(x => x.Id == id).Select(x => x.Cards).First());
                if (mixForm.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("Колода перетасована");
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать колоду из списка!");
            }
        }

        private int GetNewId()
        {
            if (CardDesks.Count == 0) return 1;
            return CardDesks.Max(x => x.Id) + 1;
        }

        private List<Card> GetCardsById(int id)
        {
            return CardDesks.Where(x => x.Id == id).Select(x => x.Cards).FirstOrDefault();
        }
    }
}
