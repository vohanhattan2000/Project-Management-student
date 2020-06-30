using ManagementTopicStudent.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTopicStudent.Controllers
{
    public class TienDoController
    {
        public static DeTai layDeTai(string nhom)
        {
            using (var _context= new ManagementTopicStudentEntities())
            {
                var db= (from u in _context.DeTais
                         where u.MaNhom == nhom
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
        public static List<TienDo> getListTienDo()
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var db = (from u in _context.TienDoes.AsEnumerable() select u).Select(x => new TienDo
                {
                    MaTienDo = x.MaTienDo,
                    MaDT = x.MaDT,
                    MaNhom = x.MaNhom,
                    TaiLieu = x.TaiLieu,
                    TrangThai = x.TrangThai,
                    ThoiGianKT = x.ThoiGianKT,
                    NhanXet=x.NhanXet
                    
                }).ToList();

                return db;
            }
        }
        public static bool AddTienDo(TienDo td)
        {
            try
            {
                using (var _context = new ManagementTopicStudentEntities())
                {

                    _context.TienDoes.Add(td);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static TienDo getTienDo(string td)
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var db = (from u in _context.TienDoes
                          where u.MaTienDo == td
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
        public static bool DeleteTienDo(TienDo td)
        {

            using (var _context = new ManagementTopicStudentEntities())
            {
                var db = (from u in _context.TienDoes
                          where u.MaTienDo == td.MaTienDo
                          select u).SingleOrDefault();               
                _context.TienDoes.Remove(db);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool UpdateTienDo(TienDo td)
        {

            using (var _context = new ManagementTopicStudentEntities())
            {

                _context.TienDoes.AddOrUpdate(td);
                _context.SaveChanges();
                return true;
            }

        }
    }
}