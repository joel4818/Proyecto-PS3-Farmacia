//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFarmacia.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Detalle_Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Detalle_Pedido()
        {
            this.pedido = new HashSet<pedido>();
        }
    
        public int Codigo_Detalle { get; set; }
        public string Estado_Pedido { get; set; }
        public Nullable<double> Subtotal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedido> pedido { get; set; }
    }
}
