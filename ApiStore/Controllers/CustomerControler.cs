using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BLL.Interfaces;

namespace ApiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerControler : ControllerBase
    {
        private ICustomerBLL _customerBLL;
        public CustomerControler(ICustomerBLL customerBLL)
        {
            _customerBLL = customerBLL;
        }
        [Route("Get-by-id-customer/{id}")]
        [HttpGet]
        public CustomerModel GetDataById(int id)
        {
            return _customerBLL.GetDataByID(id);
        }
        [Route("Create-Customer")]
        [HttpPost]
        public CustomerModel CreateCus([FromBody] CustomerModel model)
        {
            _customerBLL.Create(model);
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
