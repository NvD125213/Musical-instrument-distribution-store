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
    public class DonHangBLL : IDonHangBLL
    {
        private IHoaDonResponsitory _donhangBLL;

        public DonHangBLL(IHoaDonResponsitory donhangBLL)
        {
            _donhangBLL = donhangBLL;
        }

        public bool Create(DonHangModel model)
        {
            return _donhangBLL.Create(model);
        }

        public DonHangModel GetDatabyID(int id)
        {
            return _donhangBLL.GetDatabyID(id);
        }

        public List<ThongKe> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
            throw new NotImplementedException();
        }

        public bool Update(DonHangModel model)
        {
            return _donhangBLL.Update(model);
        }
    }
}
