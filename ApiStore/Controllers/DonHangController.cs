using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BLL;
using BLL.Interfaces;

namespace ApiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private IDonHangBLL _bll;
        public DonHangController(IDonHangBLL bll)
        {
            _bll = bll;
        }
        [Route("Create-HoaDon")]
        [HttpPost]
        public DonHangModel CreateItem([FromBody] DonHangModel model)
        {
            _bll.Create(model);
            return model;
        }
        [Route("GetID-HoaDon")]
        [HttpGet]
        public DonHangModel GetDatabyID(int id)
        {
            return _bll.GetDatabyID(id);
        }
        [Route("Update-HoaDon")]
        [HttpPost]
        public DonHangModel Update([FromBody] DonHangModel model)
        {
            _bll.Update(model);
            return model;
        }
    }
}
