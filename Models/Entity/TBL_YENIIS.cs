//------------------------------------------------------------------------------
// <auto-generated>
//    Bu kod bir şablondan oluşturuldu.
//
//    Bu dosyada el ile yapılan değişiklikler uygulamanızda beklenmedik davranışa neden olabilir.
//    Kod yeniden oluşturulursa, bu dosyada el ile yapılan değişikliklerin üzerine yazılacak.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_YENIIS
    {
        public TBL_YENIIS()
        {
            this.TBL_SATISLAR = new HashSet<TBL_SATISLAR>();
        }
    
        public int FLOWERID { get; set; }
        public string FLOWERNAME { get; set; }
        public Nullable<decimal> FIYAT { get; set; }
        public Nullable<byte> STOK { get; set; }
        public string PHOTO { get; set; }
    
        public virtual ICollection<TBL_SATISLAR> TBL_SATISLAR { get; set; }
    }
}
