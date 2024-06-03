namespace SmallFactory.DTOs
{
    public class StorageDto
    {
        public int Id { get; set; }

        public int FactoryId { get; set; }

        public int Count { get; set; }

        public int Max { get; set; }

        public PartDto Part { get; set; }
    }
}
