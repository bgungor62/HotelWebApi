using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.About
{
    public class UpdateAboutDto
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
