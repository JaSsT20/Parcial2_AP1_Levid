using System.ComponentModel.DataAnnotations;

public class Empacado
{
    [Key]
    public int EmpacadoId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Today;
    public string Concepto { get; set; } = string.Empty;
    public List<EmpacadoDetalle> EmpacadoDetalles { get; set; } = new List<EmpacadoDetalle>();
}