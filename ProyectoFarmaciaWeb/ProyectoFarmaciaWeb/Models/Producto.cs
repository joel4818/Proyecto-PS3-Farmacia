//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFarmaciaWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.Venta = new HashSet<Venta>();
        }
    
        public int Codigo_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public Nullable<System.DateTime> Fecha_Vencimiento { get; set; }
        public Nullable<int> Stock { get; set; }
        public Nullable<double> Precio_Unitario { get; set; }
        public Nullable<int> Codigo_Categoria { get; set; }
        public Nullable<int> Codigo_Proveedor { get; set; }
        public string Descripcion { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }
    }
}