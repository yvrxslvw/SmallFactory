using System.ComponentModel.DataAnnotations;

namespace SmallFactory.DTOs
{
    public class CreateReceiptDto
    {
        [Required(ErrorMessage = "Поле 'Тип производства' обязательно для заполнения.")]
        [Range(0, 2, ErrorMessage = "Поле 'Тип производства' должно быть от 0 до 2.")]
        public int ProductionType { get; set; }

        [Required(ErrorMessage = "Поле 'ID производимой детали' обязательно для заполнения.")]
        public int ResultPartId { get; set; }

        [Required(ErrorMessage = "Поле 'ID материала 1' обязательно для заполнения.")]
        public int Material1Id { get; set; }

        [Required(ErrorMessage = "Поле 'ID материала 2' обязательно для заполнения.")]
        public int Material2Id { get; set; }

        [Required(ErrorMessage = "Поле 'ID материала 3' обязательно для заполнения.")]
        public int Material3Id { get; set; }

        [Required(ErrorMessage = "Поле 'ID материала 4' обязательно для заполнения.")]
        public int Material4Id { get; set; }

        [Required(ErrorMessage = "Поле 'Скорость производства' обязательно для заполнения.")]
        public double ProductionRate { get; set; }
    }
}
