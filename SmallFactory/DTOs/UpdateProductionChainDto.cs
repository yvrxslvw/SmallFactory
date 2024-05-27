using System.ComponentModel.DataAnnotations;

namespace SmallFactory.DTOs
{
    public class UpdateProductionChainDto
    {
        [Required(ErrorMessage = "Поле 'Название производственной цепочки' обязательно для заполнения.")]
        [Length(3, 24, ErrorMessage = "Поле 'Название производственной цепочки' должно быть длиной между 3 и 24 символами.")]
        public string Name { get; set; }
    }
}
