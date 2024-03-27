using CardDeskVault.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CardDeskVault
{
    public partial class MixForm : Form
    {
        List<Card> Cards = new List<Card>();
        public MixForm(List<Card> cards)
        {
            InitializeComponent();
            Cards = cards;
            AlgorithmComboBox.SelectedIndex = 0;
            DialogResult = DialogResult.None;
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (AlgorithmComboBox.SelectedIndex > -1)
            {
                MixCards();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать алгоритм перетасовки!");
                return;
            }
        }

        private void MixCards()
        {
            Random random = new Random();
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var t = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = t;
            }
        }
    }
}
