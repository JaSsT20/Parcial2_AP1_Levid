using System.ComponentModel.DataAnnotations;

public class Empacado
{
    [Key]
    public int EmpacadoId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Today;
    [Required(ErrorMessage = "El campo es requerido.")]
    [StringLength(500, MinimumLength = 5, ErrorMessage = "Debe introducir un concepto valido entre {1} y {2} caracteres.")]
    public string Concepto { get; set; } = string.Empty;
    public List<EmpacadoDetalle> EmpacadoDetalles { get; set; } = new List<EmpacadoDetalle>();
}