//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp3
{
    using System;
    using System.Collections.Generic;
    
    public partial class employer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employer()
        {
            this.channels = new HashSet<channel>();
            this.favorites_for_employer = new HashSet<favorites_for_employer>();
            this.vacancies = new HashSet<vacancy>();
        }
    
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Nullable<System.DateTime> date_of_birth { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<channel> channels { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<favorites_for_employer> favorites_for_employer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vacancy> vacancies { get; set; }
    }
}
