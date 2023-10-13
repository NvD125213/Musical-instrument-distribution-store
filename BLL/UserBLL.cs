
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using BLL.Interfaces;
using DataModel;
using DAL.Interface;

namespace BLL
{
    public class UserBLL : IUserBLL
    {
        private IUserRespository _res;

        private string secret;
        public UserBLL(IUserRespository res, IConfiguration config)
        {

            _res = res;
            secret = config["AppSettings:Secret"];
        }

       

        public bool CreateUser(UserModel model)
        {
            return _res.CreateUser(model);
          
        }

      
        public UserModel GetUser(string tendn, string matkhau)
        {
            var user = _res.GetUser(tendn, matkhau);
            if (user == null)
                return null;

            // Tạo 1 biến chứa các phương thức tạo và ký Jwt
            var tokenHandler = new JwtSecurityTokenHandler();

            // Tạo chuỗi bí mật từ biến secret
            var key = Encoding.ASCII.GetBytes(secret); 

            var tokenDescriptor = new SecurityTokenDescriptor // Định nghĩa một SecurityTokenDescriptor: Các thông tin cần thiết để tạo Jwt, claim (quyền)
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Ten.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7), // Thời gian hết hạn
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256) // khóa bí mật mã hóa mật khẩu
            };
            var token = tokenHandler.CreateToken(tokenDescriptor); // Tạo 1 token từ tokenDescriptor
            user.token = tokenHandler.WriteToken(token); // Ghi vào trường token của userModel
            return user;
        }

        public bool UpdateUser(UserModel model)
        {
            return _res.UpdateUser(model);
        }
    }
}
