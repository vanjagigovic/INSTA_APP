//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INSTA_APP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class poklon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public poklon()
        {
            this.poklon_za_profil = new HashSet<poklon_za_profil>();
        }
    
        public int ID_poklon { get; set; }
        public string poklon1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<poklon_za_profil> poklon_za_profil { get; set; }
    }
}
