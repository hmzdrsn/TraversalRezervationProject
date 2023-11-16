using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ReservationDTOs
{
    public class ReservationListDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public DateTime Date  { get; set; }
        public string PersonCount  { get; set; }
        public string? Description{ get; set; }
        public string Status{ get; set; }
    }
}
