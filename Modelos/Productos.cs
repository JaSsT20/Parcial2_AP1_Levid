using System.ComponentModel.DataAnnotations;

public class Productos
{
    [Key]
    public int ProductoId { get; set; }
    [Required(ErrorMessage = "La descripción es obligatoria.")]
    public string Descripcion { get; set; } = string.Empty;
    [Required(ErrorMessage = "El costo es obligatorio.")]
    [Range(1, 500000, ErrorMessage = "Valor inválido, debe estar entre {1} y {2}")]
    public float Costo { get; set; }
    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(1, 500000, ErrorMessage = "Valor inválido, debe estar entre {1} y {2}")]
    public float Precio { get; set; }
    [Required(ErrorMessage = "La existencia es obligatorio.")]
    [Range(1, 500000, ErrorMessage = "Valor inválido, debe estar entre {1} y {2}")]
    public int Existencia { get; set; }
}