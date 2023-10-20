using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BLL;
using BLL.Interfaces;


namespace ApiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private  IDanhMucBLL _danhMucBLL;

        public DanhMucController(IDanhMucBLL danhmucBLL)
        {
            _danhMucBLL = danhmucBLL;
        }

        [HttpGet]
        [Route("getdanhmuccay")]
        public DanhMucModel GetDatabyID(int id)
        {
            return _danhMucBLL.GetDanhMucCay(id);
        }
    }
}
