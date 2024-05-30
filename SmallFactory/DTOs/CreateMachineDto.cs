using System.ComponentModel.DataAnnotations;

namespace SmallFactory.DTOs
{
    public class CreateMachineDto
    {
        [Required(ErrorMessage = "Поле 'ID производственной цепочки' обязательно для заполнения.")]
        public int ProductionChainId { get; set; }

        [Required(ErrorMessage = "Поле 'Тип станка' обязательно для заполнения.")]
        [Range(0, 2, ErrorMessage = "Поле 'Тип станка' должно быть от 0 до 2.")]
        public int Type { get; set; }

        [Required(ErrorMessage = "Поле 'ID рецепта' обязательно для заполнения.")]
        public int ReceiptId { get; set; }
    }
}
