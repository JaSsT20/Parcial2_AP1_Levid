using System.ComponentModel.DataAnnotations;

public class Productos
{
    [Key]
    public int ProductoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public float Costo { get; set; }
    public float Precio { get; set; }
    public int Existencia { get; set; }
}