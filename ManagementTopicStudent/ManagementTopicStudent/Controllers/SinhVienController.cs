using ManagementTopicStudent.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTopicStudent.Controllers
{
    public class SinhVienController
    {
        public static List<SinhVien> getListSV()
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var sv = (from u in _context.SinhViens.AsEnumerable() select u).Select(x => new SinhVien
                {
                    MaSV = x.MaSV,
                    TenSV = x.TenSV,
                    NgaySinh = x.NgaySinh,
                    GioiTinh = x.GioiTinh,
                    DiaChi = x.DiaChi,
                    DienThoai = x.DienThoai,
                    EmailSV = x.EmailSV,
                    MaNhom = x.MaNhom
                }).ToList();

                return sv;
            }
        }
        public static List<Nhom> getListNhom()
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var nhom = (from u in _context.Nhoms.AsEnumerable()
                           
                            select u)
                            .Select(x => new Nhom
                            {
                                TenNhom = x.TenNhom,
                                MaNhom = x.MaNhom
                            }).ToList();

                return nhom;
            }
        }
        public static bool AddSV(SinhVien sv)
        {
            try
            {
                using (var _context = new ManagementTopicStudentEntities())
                {

                    _context.SinhViens.Add(sv);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static SinhVien getSV(string sv)
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var db = (from u in _context.SinhViens
                          where u.MaSV == sv
                          select u).ToList();
                if (db.Count == 1)
                {
                    return db[0];
                }
                else
                {
                    return null;
                }
            }
        }
        public static bool DeleteSV(SinhVien sv)
        {

            using (var _context = new ManagementTopicStudentEntities())
            {
                var db = (from u in _context.SinhViens
                              where u.MaSV == sv.MaSV
                              select u).SingleOrDefault();
                //Xóa nhóm này khỏi các sinh viên(Xóa IcolectionSV)
                _context.SinhViens.Remove(db);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool UpdateSV(SinhVien sv)
        {

            using (var _context = new ManagementTopicStudentEntities())
            {

                _context.SinhViens.AddOrUpdate(sv);
                _context.SaveChanges();
                return true;
            }

        }
        
    }
}
