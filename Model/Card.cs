namespace CardDeskVault.Model
{
    public class Card
    {
        public Suit Suit {  get; set; }
        public Value Value { get; set; }

        public override string ToString()
        {
            return $"{Suit} : {Value}";
        }
    }

    public enum Suit
    {
        clubs, //трефы
        diamonds, //бубны
        hearts, //червы
        spades //пики
    }

    public enum Value
    {
        two,
        three,
        four,
        five,
        six,
        sevent,
        eight, 
        nine,
        ten,
        jack,
        queen,
        king,
        ace
    }
}
