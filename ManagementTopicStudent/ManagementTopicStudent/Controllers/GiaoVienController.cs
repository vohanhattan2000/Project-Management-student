using ManagementTopicStudent.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementTopicStudent.Controllers
{
    public class GiaoVienController
    {
        public static List<GiaoVien> GetGV()
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var gv = (from u in _context.GiaoViens.AsEnumerable() select u).Select(x => new GiaoVien
                {
                    MaGV = x.MaGV,
                    TenGV = x.TenGV,
                    EmailGV=x.EmailGV
                }).ToList();

                return gv;
            }
        }
        public static bool AddGV(GiaoVien gv)
        {
            try
            {
                using (var _context = new ManagementTopicStudentEntities())
                {

                    _context.GiaoViens.Add(gv);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static GiaoVien getGV(string gv)
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var db = (from u in _context.GiaoViens
                          where u.MaGV == gv
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
        public static bool DeleteGV(GiaoVien gv)
        {

            using (var _context = new ManagementTopicStudentEntities())
            {
                try
                {
                    var db = (from u in _context.GiaoViens
                              where u.MaGV == gv.MaGV
                              select u).SingleOrDefault();
                    _context.GiaoViens.Remove(db);
                    _context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Xóa giáo viên này trong form quản lý đề tài rồi xóa lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return true;
            }

        }
        public static bool UpdateGV(GiaoVien gv)
        {

            using (var _context = new ManagementTopicStudentEntities())
            {

                _context.GiaoViens.AddOrUpdate(gv);
                _context.SaveChanges();
                return true;
            }

        }
        public static List<GiaoVien> getListgiaovien()
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var gv = (from u in _context.GiaoViens.AsEnumerable()

                            select u)
                            .Select(x => new GiaoVien
                            {
                                MaGV = x.MaGV,
                                TenGV = x.TenGV,
                                EmailGV=x.EmailGV
                                
                            }).ToList();

                return gv;
            }
        }
    }
}
