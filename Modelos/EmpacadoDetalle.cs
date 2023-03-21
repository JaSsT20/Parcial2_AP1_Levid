using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class EmpacadoDetalle
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("ProductoId")]
    public int ProductoId { get; set; }
    [ForeignKey("EmpacadoId")]
    public int EmpacadoId { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(1, 800000, ErrorMessage = "El rango es entre {1} y {2}")]
    public int Cantidad { get; set; }

}