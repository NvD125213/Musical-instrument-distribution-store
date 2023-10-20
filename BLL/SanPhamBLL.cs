using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using BLL.Interfaces;
using DataModel;
using DAL.Interface;
using DAL;

namespace BLL
{
    public class SanPhamBLL : ISanPhamBLL
    {

        private ISanPhamResponsitory _spRes;

        public SanPhamBLL(ISanPhamResponsitory spRes)
        {
            _spRes = spRes;
        }
        public BanChayModel BanChay()
        {
            return _spRes.GetBanChay();
        }
    }
}
