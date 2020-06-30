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
    public class DeTaiController
    {
        public static List<DeTai> getListDT()
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var dt = (from u in _context.DeTais.AsEnumerable() select u).Select(x => new DeTai
                {
                    MaDT = x.MaDT,
                    TenDT = x.TenDT,
                    LoaiDT = x.LoaiDT,
                    MaNhom=x.MaNhom,
                    MaGV = x.MaGV,
                    NoiDung = x.NoiDung,                   
                }).ToList();

                return dt;
            }
        }
        public static bool AddDT(DeTai dt)
        {
            try
            {
                using (var _context = new ManagementTopicStudentEntities())
                {

                    _context.DeTais.Add(dt);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static DeTai getDT(string dt)
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var db = (from u in _context.DeTais
                          where u.MaDT == dt
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
        public static bool DeleteDT(DeTai dt)
        {

            using (var _context = new ManagementTopicStudentEntities())
            {
                try
                {


                    var db = (from u in _context.DeTais
                              where u.MaDT == dt.MaDT
                              select u).SingleOrDefault();
                    _context.DeTais.Remove(db);
                    _context.SaveChanges();
                    
                }
                catch
                {
                    MessageBox.Show("Xóa đề tài này trong form Tiến độ rồi xóa lại!","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                return true;
            }
        }
        public static bool UpdateDT(DeTai dt)
        {

            using (var _context = new ManagementTopicStudentEntities())
            {

                _context.DeTais.AddOrUpdate(dt);
                _context.SaveChanges();
                return true;
            }

        }
        public static List<DeTai> getListDeTaicb()
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var nhom = (from u in _context.DeTais.AsEnumerable()

                            select u)
                            .Select(x => new DeTai
                            {
                                MaDT = x.MaDT,
                                TenDT = x.TenDT,
                                LoaiDT = x.LoaiDT,
                                MaNhom = x.MaNhom,
                                MaGV = x.MaGV,
                                NoiDung = x.NoiDung
                            }).ToList();

                return nhom;
            }
        }
    }
}
