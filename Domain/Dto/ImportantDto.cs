using System.Collections.Generic;

namespace Domain.Dto
{
    public class ImportantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public List<EventDto> Events { get; set; }
    }
}
