using System.ComponentModel.DataAnnotations;

namespace SmallFactory.DTOs
{
    public class UpdatePartDto
    {
        [Required(ErrorMessage = "Поле 'Название детали' обязательно для заполнения.")]
        [Length(3, 24, ErrorMessage = "Поле 'Название детали' должно быть длиной от 3 до 24 символов.")]
        public string Name { get; set; }
    }
}
