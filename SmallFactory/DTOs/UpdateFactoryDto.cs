using System.ComponentModel.DataAnnotations;

namespace SmallFactory.DTOs
{
    public class UpdateFactoryDto
    {
        [Required(ErrorMessage = "Поле 'Название завода' обязательно для заполнения.")]
        [Length(3, 24, ErrorMessage = "Длина поля 'Название завода' должна быть между 3 и 24 символами.")]
        public string Name { get; set; }
    }
}
