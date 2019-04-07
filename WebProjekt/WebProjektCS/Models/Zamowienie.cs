//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProjektCS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zamowienie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zamowienie()
        {
            this.Dostawas = new HashSet<Dostawa>();
        }
    
        public int id_zamowienie { get; set; }
        public int id_produkt { get; set; }
        public int id_klient { get; set; }
        public int id_pracownik { get; set; }
        public System.DateTime data_zamowienia { get; set; }
        public Nullable<decimal> rabat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dostawa> Dostawas { get; set; }
        public virtual Klient Klient { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public virtual Produkt Produkt { get; set; }
    }
}