using Domain.Models.Common;

namespace Domain.Models
{
    public class Libro : ModelBase
    {
        public string? Title { get; set; }
        public string? Autor { get; set; }
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public double? Price { get; set; }
    }
}
