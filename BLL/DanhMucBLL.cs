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
    public class DanhMucBLL : IDanhMucBLL
    {
        private IDanhMucResponsitory _danhMucDAL;

        public DanhMucBLL(IDanhMucResponsitory danhmucDAL)
        {
            _danhMucDAL = danhmucDAL;
        }

        public DanhMucModel GetDanhMucCay(int id)
        {
            return _danhMucDAL.GetData(id);
        }
    }
}
