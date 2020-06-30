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
    public class NhomController
    {
        public static List<Nhom> GetNhoms()
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var nhom = (from u in _context.Nhoms.AsEnumerable() select u).Select(x => new Nhom
                {
                    MaNhom = x.MaNhom,
                    TenNhom = x.TenNhom
                }).ToList();

                return nhom;
            }
        }
        public static bool AddNhom(Nhom nhom)
        {
            try
            {
                using (var _context = new ManagementTopicStudentEntities())
                {

                    _context.Nhoms.Add(nhom);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteNhom(Nhom nhom)
        {

            using (var _context = new ManagementTopicStudentEntities())
            {
                var dbnhom = (from u in _context.Nhoms
                              where u.MaNhom == nhom.MaNhom
                              select u).SingleOrDefault();
                //Xóa nhóm này khỏi các sinh viên(Xóa IcolectionSV)
                try
                {
                    _context.Nhoms.Remove(dbnhom);
                    _context.SaveChanges();
                    
                }
                catch
                {
                    MessageBox.Show("Hãy xóa những sinh viên và đề tài thuộc nhóm này trước rồi xóa lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                return true;
            }
        }
        public static Nhom getNhom(string nhom)
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var db = (from u in _context.Nhoms
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
        public static bool UpdateNhom(Nhom nhom)
        {
            
                using (var _context = new ManagementTopicStudentEntities())
                {

                    _context.Nhoms.AddOrUpdate(nhom);
                    _context.SaveChanges();
                    return true;
                }
           
        }
    }
}
