using System.ComponentModel.DataAnnotations;

namespace SmallFactory.DTOs
{
    public class CreateProductionChainDto
    {
        [Required(ErrorMessage = "Поле 'Название производственной цепочки' обязательно для заполнения.")]
        [Length(3, 24, ErrorMessage = "Поле 'Название производственной цепочки' должно быть длиной между 3 и 24 символами.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле 'ID завода' обязательно для заполнения.")]
        public int? FactoryId { get; set; }
    }
}
