using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BLL.Interfaces;

namespace ApiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaChiController : ControllerBase
    {
        private IDiaChiBLL _BLL;
        public DiaChiController(IDiaChiBLL BLL)
        {
            _BLL = BLL;
        }
        [Route("Get-by-id-diachi/{id}")]
        [HttpGet]
        public DiaChiModel GetDataById(int id)
        {
            return _BLL.DiaChiByID(id);
        }
        [Route("Create-diachi")]
        [HttpPost]
        public DiaChiModel CreateCus([FromBody] DiaChiModel model)
        {
            _BLL.Create(model);
            return model;
        }
        [Route("Update-Customer")]
        [HttpPost]
        public CustomerModel UpdateCus([FromBody] CustomerModel model)
        {
            _customerBLL.Update(model);
            return model;
        }
        [Route("Delete-Customer")]
        [HttpPost]
        public void DeleteCus(int id)
        {
            _customerBLL.Delete(id);

        }
    }
}
