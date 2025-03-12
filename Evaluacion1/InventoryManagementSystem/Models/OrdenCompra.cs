namespace InventoryManagementSystem.Models
{
    public class OrdenCompra
    {
        public int OrdenCompraId { get; set; }
        public int ProveedorId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaOrden { get; set; }

        public Proveedor Proveedor { get; set; }
        public Producto Producto { get; set; }
    }
}
