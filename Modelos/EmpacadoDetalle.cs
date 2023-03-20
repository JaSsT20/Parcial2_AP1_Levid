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
    public int Cantidad { get; set; }

}