using System.ComponentModel.DataAnnotations;

namespace CRUD.Dtos
{
    public class CommandCreateDto
    {
        //public int Id { get; set; } o ID é criado pelo próprio DB já que é uma key
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        
        [Required]
        public string Line { get; set; }
        
        [Required]
        public string Plataform { get; set; }
    }
}