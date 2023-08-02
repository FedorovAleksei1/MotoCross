using System;

namespace Domain.Dto
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateAnd { get; set; }
        public int ImportantId { get; set; }
        public string DateRange { get {
                var endDate = DateAnd.HasValue ? "-" + DateAnd.Value.Day.ToString() : "";
                return DateStart.Day + endDate;
            } }
    
    public string DayOfWeekRange { get; set; }
        public string? InfoEvent { get; set; }
        public string BasePhoto64 { get; set; }
        public int? PhotoId { get; set; }
        public PhotoDto Photo { get; set; }
        public ImportantDto Important { get; set; }
    }
}
