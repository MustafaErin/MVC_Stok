//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Stok.Models.Entitiy
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblUrunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblUrunler()
        {
            this.TblSatıs = new HashSet<TblSatıs>();
        }
    
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public Nullable<int> Category { get; set; }
        public string Fiyat { get; set; }
        public string Marka { get; set; }
        public Nullable<int> Stok { get; set; }
    
        public virtual TblCategory TblCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSatıs> TblSatıs { get; set; }
    }
}
