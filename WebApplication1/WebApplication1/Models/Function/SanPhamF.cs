using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entities;

namespace TH13Chieu.Models.Functions
{
    public class SanPhamF
    {
        private Model1 context;

        public SanPhamF()
        {
            context = new Model1();
        }

        // Trả về danh muc
        public IQueryable<SanPham> DSSanPham
        {
            get { return context.SanPhams; }
        }

        // Trả về một đối tượng danh mục, khi biết Khóa
        public SanPham FindEntity(string MaSP)
        {
            SanPham dbEntry = context.SanPhams.Find(MaSP);
            return dbEntry;
        }

        // Thêm một đối tượng
        public bool Insert(SanPham model)
        {
            SanPham dbEntry = context.SanPhams.Find(model.MaSp);

            if (dbEntry != null)
            {
                return false;

            }
            context.SanPhams.Add(model);

            context.SaveChanges();

            return true;
        }

        // Sửa một đối tượng
        public bool Update(SanPham model)
        {
            SanPham dbEntry = context.SanPhams.Find(model.MaSp);
            //   LoaiBanDoc dbEntry = context.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.TenSp = model.TenSp;
            dbEntry.GiaSp = model.GiaSp;
            dbEntry.MaDm = model.MaDm;
            dbEntry.MoTa = model.MoTa;
            
            // Sửa các trường khác cũng như vậy
            context.SaveChanges();

            return true;
        }

        // Xóa một đối tượng
        public bool Delete(string MaSP)
        {
            SanPham dbEntry = context.SanPhams.Find(MaSP);
            if (dbEntry == null)
            {
                return false;
            }
            context.SanPhams.Remove(dbEntry);

            context.SaveChanges();
            return true;
        }
    }
}