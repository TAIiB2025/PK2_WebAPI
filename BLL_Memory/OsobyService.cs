using BLL;
using BLL.Models;
using BLL_Memory.Extensions;
using DAL;

namespace BLL_Memory
{
    public class OsobyService : IOsobyService
    {
        private static int IdGen = 1;
        private static readonly List<OsobaEntity> osobyDbSet = 
            [
                new OsobaEntity() 
                {
                    Id = IdGen++,
                    Imię = "Adam",
                    Nazwisko = "Kowalski",
                    CzyWyróżniona = true,
                    Wiek = 45
                },
                new OsobaEntity()
                {
                    Id = IdGen++,
                    Imię = "Anna",
                    Nazwisko = "Nowak",
                    CzyWyróżniona = false,
                    Wiek = 33
                },                
                new OsobaEntity()
                {
                    Id = IdGen++,
                    Imię = "Jan",
                    Nazwisko = "Iksiński",
                    CzyWyróżniona = false,
                    Wiek = 18
                },                
                new OsobaEntity()
                {
                    Id = IdGen++,
                    Imię = "Marek",
                    Nazwisko = "Darek",
                    CzyWyróżniona = true,
                    Wiek = 60
                },                
                new OsobaEntity()
                {
                    Id = IdGen++,
                    Imię = "Joanna",
                    Nazwisko = "Krzyż",
                    CzyWyróżniona = false,
                    Wiek = 20
                },
            ];

        public IEnumerable<OsobaDTO> Get()
        {
            //return osobyDbSet.Select(os => new OsobaDTO(os.Id, os.Imię, os.Nazwisko, os.CzyWyróżniona, os.Wiek));
            return osobyDbSet.Select(os => os.ToOsobaDTO());
        }

        public OsobaDTO GetByID(int id)
        {
            OsobaEntity? osobaEntity = osobyDbSet.Find(os => os.Id == id);
            if(osobaEntity is null)
            {
                throw new ApplicationException($"Nie znaleziono osoby o ID = {id}");
            }

            //return new OsobaDTO(osobaEntity.Id, osobaEntity.Imię, osobaEntity.Nazwisko, osobaEntity.CzyWyróżniona, osobaEntity.Wiek);           
            return osobaEntity.ToOsobaDTO();
        }

        public void Post(OsobaPostDTO osobaPostDTO)
        {
            OsobaEntity osobaEntity = new()
            {
                Imię = osobaPostDTO.Imie,
                Nazwisko = osobaPostDTO.Nazwisko,
                CzyWyróżniona = false,
                Wiek = osobaPostDTO.Wiek,
                Id = IdGen++
            };

            osobyDbSet.Add(osobaEntity);
        }
    }
}
