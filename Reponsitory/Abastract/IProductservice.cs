using web_api.Models;

namespace web_api.Reponsitory.Abastract
{
    public interface IProductservice
    {
        List<HangHoaModel> GetAll(int s);

    }
}
