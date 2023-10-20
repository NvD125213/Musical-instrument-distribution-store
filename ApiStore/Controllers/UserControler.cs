using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BLL.Interfaces;

namespace ApiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControler : ControllerBase
    {
        private IUserBLL _userBLL;
        public UserControler(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _userBLL.GetUser(model.TenDN, model.MatKhau);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.Ten, email = user.Email, token = user.token });
        }
        [Route("Update-User")]
        [HttpPost]
        public UserModel UpdateItem([FromBody] UserModel model)
        {
            _userBLL.UpdateUser(model);
            return model;
        }
        [Route("Register-User")]
        [HttpPost]
        public IActionResult Register([FromBody] UserModel model)
        {
            if(_userBLL.CreateUser(model))
            {
                return Ok("Tạo tài khoản thành công!");
            }    
            else
            {
                return BadRequest("Tài khoản đã tồn tại!");
            }    
        }

    }
}
