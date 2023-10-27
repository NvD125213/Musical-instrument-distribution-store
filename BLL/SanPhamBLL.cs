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

        public SanPhamModel GetSanPhambyID(int id)
        {
            return _spRes.GetSanPhambyID(id);
        }

        public List<SanPhamModel> SearchTheoDM(int pageIndex, int pageSize, out long total, string tensp, int danhmuc)
        {
            return _spRes.SearchTheoDM(pageIndex,pageSize, out total, tensp, danhmuc);
        } 

        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, int giaMax, int giaMin)
        {
            return _spRes.SearchTheoGia(pageIndex,pageSize, out total, giaMax, giaMin);
            
        }
    }
}
