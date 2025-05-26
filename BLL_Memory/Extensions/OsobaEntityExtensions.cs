using BLL.Models;
using DAL;

namespace BLL_Memory.Extensions
{
    internal static class OsobaEntityExtensions
    {
        public static OsobaDTO ToOsobaDTO(this OsobaEntity osobaEntity)
        {
            return new OsobaDTO(osobaEntity.Id, osobaEntity.Imię, osobaEntity.Nazwisko, osobaEntity.CzyWyróżniona, osobaEntity.Wiek);
        }
    }
}
