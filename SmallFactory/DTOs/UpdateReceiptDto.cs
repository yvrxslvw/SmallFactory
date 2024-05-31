using System.ComponentModel.DataAnnotations;

namespace SmallFactory.DTOs
{
    public class UpdateReceiptDto
    {
        [Range(0, 2, ErrorMessage = "Поле 'Тип производства' должно быть от 0 до 2.")]
        public int? ProductionType { get; set; }

        public int? ResultPartId { get; set; }

        public int? Material1Id { get; set; }

        public int? Material2Id { get; set; }

        public int? Material3Id { get; set; }

        public int? Material4Id { get; set; }

        public double? ProductionRate { get; set; }
    }
}
