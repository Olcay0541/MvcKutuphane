//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblUyeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblUyeler()
        {
            this.TblCezalar = new HashSet<TblCezalar>();
            this.TblHareketler = new HashSet<TblHareketler>();
        }
    
        public int UyeID { get; set; }
        public string UyeAd { get; set; }
        public string UyeSoyad { get; set; }
        public string Mail { get; set; }
        public string UyeKullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Fotoğraf { get; set; }
        public string Telefon { get; set; }
        public string Okul { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblCezalar> TblCezalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblHareketler> TblHareketler { get; set; }
    }
}