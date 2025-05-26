namespace DAL
{
    public class OsobaEntity
    {
        public int Id { get; set; }
        public required string Imię { get; set; }
        public required string Nazwisko { get; set; }
        public short Wiek {  get; set; }
        public bool CzyWyróżniona { get; set; }

    }
}
