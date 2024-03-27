using System.Collections.Generic;

namespace CardDeskVault.Model
{
    class CardDesk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
    }
}
