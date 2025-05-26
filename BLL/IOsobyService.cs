using BLL.Models;

namespace BLL
{
    public interface IOsobyService
    {
        public IEnumerable<OsobaDTO> Get();
        public OsobaDTO GetByID(int id);
        public void Post(OsobaPostDTO osobaPostDTO);
    }
}
