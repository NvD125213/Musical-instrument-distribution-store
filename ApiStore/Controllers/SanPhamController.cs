using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BLL;
using BLL.Interfaces;

namespace ApiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {

        private ISanPhamBLL _spBLL;

        public SanPhamController(ISanPhamBLL spBLL)
        {
            _spBLL = spBLL;
        }
        [Route("Get-BanChay")]
        [HttpGet]
        public BanChayModel GetBanChay()
        {
            return _spBLL.BanChay();
        }

        [Route("Get-BanChay1")]
        [HttpGet]
        public BanChayModel GetBanChay1(BanChayModel a)
        {
            return a;
        }


    }
}
