//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagementTopicStudent.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TienDo
    {
        public string MaTienDo { get; set; }
        public string TrangThai { get; set; }
        public string TaiLieu { get; set; }
        public Nullable<System.DateTime> ThoiGianKT { get; set; }
        public string NhanXet { get; set; }
        public string MaDT { get; set; }
        public string MaNhom { get; set; }
    
        public virtual DeTai DeTai { get; set; }
        public virtual Nhom Nhom { get; set; }
    }
}