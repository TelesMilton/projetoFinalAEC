using System.ComponentModel.DataAnnotations;

namespace projetoFinalAEC.Models
{
    public abstract class Entidade
    {
        [Key]
        public int Id { get; set; }
    }
}