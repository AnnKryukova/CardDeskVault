using CardDeskVault.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CardDeskVault
{
    public partial class AddEditForm : Form
    {
        public string Name;
        public int Id;
        public List<Card> Cards;

        public AddEditForm()
        {
            InitializeComponent();
            Cards = CreateCards();
            CardsTextBox.Text = GetCards();
        }
        public AddEditForm(int id, string name, List<Card> cards)
        {
            InitializeComponent();
            Id = id;
            Name = name;
            NameTextBox.Text = name;
            NameTextBox.ReadOnly = true;
            Cards = cards;
            CardsTextBox.Text = GetCards();
        }

        //для простоты чтения поделим по четверкам всю колоду
        private string GetCards()
        {
            string result = string.Empty;
            int i = 0;
            foreach (var card in Cards)
            {
                result += card.ToString() + "; ";
                if (i == 3)
                {
                    result += Environment.NewLine;
                    i = 0;
                }
                else
                    i++;
            }
            return result;     
        }

        private List<Card> CreateCards()
        {
            Cards = new List<Card>();
            foreach (Value value in Enum.GetValues(typeof(Value)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    Cards.Add(new Card
                    {
                        Suit = suit,
                        Value = value
                    });
                }
            }

            return Cards;
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            Name = NameTextBox.Text;
        }
    }
}
