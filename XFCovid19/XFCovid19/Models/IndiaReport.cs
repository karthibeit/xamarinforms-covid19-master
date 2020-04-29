using System;
using System.Collections.Generic;
using System.Text;

namespace XFCovid19.Models
{
    public class IndiaReport
    {
        public Country Country { get; set; }
        public List<Statewise> Statewise { get; set; }
    }
}
