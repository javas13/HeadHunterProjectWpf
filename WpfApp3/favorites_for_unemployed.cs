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
    
    public partial class favorites_for_unemployed
    {
        public int id { get; set; }
        public Nullable<int> unemployed_id { get; set; }
        public Nullable<int> vacancy_id { get; set; }
    
        public virtual unemployed unemployed { get; set; }
        public virtual vacancy vacancy { get; set; }
    }
}
