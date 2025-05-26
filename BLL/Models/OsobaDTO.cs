namespace BLL.Models
{
    public record OsobaDTO(int Id, string Imie, string Nazwisko, bool CzyWyrozniona, short Wiek);
    //public record OsobaDTO(int Id, string Imie, string Nazwisko, bool CzyWyrozniona, short Wiek) : OsobaPostDTO(Imie, Nazwisko, Wiek);
}
