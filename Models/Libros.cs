using System.ComponentModel.DataAnnotations;

public class Libros
{
    [Key]
    public int LibroId { get; set; }
    
    [Required(ErrorMessage ="Requiere el titulo")]
    public string? Titulo { get; set; }
     [Required(ErrorMessage ="Requiere ingresar el precio")]
    public double  Precio { get; set; }

}