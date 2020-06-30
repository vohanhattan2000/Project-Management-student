using ManagementTopicStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTopicStudent.Controllers
{
    public class TimKiemController
    {
        public static List<DeTai> getListMaDT(string detai)
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var dt = (from u in _context.DeTais.AsEnumerable() where u.MaDT.Contains(detai) select u).Select(x => new DeTai
                {
                    MaDT = x.MaDT,
                    TenDT = x.TenDT,
                    LoaiDT = x.LoaiDT,
                    MaNhom = x.MaNhom,
                    MaGV = x.MaGV,
                    NoiDung = x.NoiDung,
                }).ToList();

                return dt;
            }
        }
        public static List<DeTai> getListTenDT(string tendetai)
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var dt = (from u in _context.DeTais.AsEnumerable() where u.TenDT.Contains(tendetai) select u).Select(x => new DeTai
                {
                    MaDT = x.MaDT,
                    TenDT = x.TenDT,
                    LoaiDT = x.LoaiDT,
                    MaNhom = x.MaNhom,
                    MaGV = x.MaGV,
                    NoiDung = x.NoiDung,
                }).ToList();

                return dt;
            }
        }
        //public static List<DeTai> TimKiemTenDeTai(string dtsearch)
        //{
        //    using (var _context = new ManagementTopicStudentEntities())
        //    {
        //        var dt = (from u in _context.DeTais.AsEnumerable()
        //                  where u.TenDT.Contains(dtsearch)
        //                  select u)
        //                    .Select(x => new DeTai
        //                    {
        //                        MaDT = x.MaDT,
        //                        TenDT = x.TenDT,
        //                        LoaiDT = x.LoaiDT,
        //                        MaNhom = x.MaNhom,
        //                        MaGV = x.MaGV,
        //                        NoiDung = x.NoiDung,
        //                    }).ToList();

        //        return dt;
        //    }
        //}
        public static List<DeTai> getListLoaiDT(string loaidt)
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var dt = (from u in _context.DeTais.AsEnumerable() where u.LoaiDT.Contains(loaidt) select u).Select(x => new DeTai
                {
                    MaDT = x.MaDT,
                    TenDT = x.TenDT,
                    LoaiDT = x.LoaiDT,
                    MaNhom = x.MaNhom,
                    MaGV = x.MaGV,
                    NoiDung = x.NoiDung,
                }).ToList();

                return dt;
            }
        }
        public static List<DeTai> getListNhomDT(string nhom)
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var dt = (from u in _context.DeTais.AsEnumerable() where u.MaNhom.Contains(nhom) select u).Select(x => new DeTai
                {
                    MaDT = x.MaDT,
                    TenDT = x.TenDT,
                    LoaiDT = x.LoaiDT,
                    MaNhom = x.MaNhom,
                    MaGV = x.MaGV,
                    NoiDung = x.NoiDung,
                }).ToList();

                return dt;
            }
        }
        public static List<DeTai> getListGiaoVienDT(string gv)
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var dt = (from u in _context.DeTais.AsEnumerable() where u.MaGV.Contains(gv) select u).Select(x => new DeTai
                {
                    MaDT = x.MaDT,
                    TenDT = x.TenDT,
                    LoaiDT = x.LoaiDT,
                    MaNhom = x.MaNhom,
                    MaGV = x.MaGV,
                    NoiDung = x.NoiDung,
                }).ToList();

                return dt;
            }
        }
        public static List<DeTai> getListNoiDungDT(string nd)
        {
            using (var _context = new ManagementTopicStudentEntities())
            {
                var dt = (from u in _context.DeTais.AsEnumerable() where u.NoiDung.Contains(nd) select u).Select(x => new DeTai
                {
                    MaDT = x.MaDT,
                    TenDT = x.TenDT,
                    LoaiDT = x.LoaiDT,
                    MaNhom = x.MaNhom,
                    MaGV = x.MaGV,
                    NoiDung = x.NoiDung,
                }).ToList();

                return dt;
            }
        }
    }
}
