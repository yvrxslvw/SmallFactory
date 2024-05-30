using System.ComponentModel.DataAnnotations;

namespace SmallFactory.DTOs
{
    public class UpdateMachineDto
    {
        [Range(0, 2, ErrorMessage = "Поле 'Тип станка' должно быть от 0 до 2.")]
        public int? Type { get; set; }

        public int? ReceiptId { get; set; }
    }
}
