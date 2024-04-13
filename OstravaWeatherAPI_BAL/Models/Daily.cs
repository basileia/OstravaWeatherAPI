using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstravaWeatherAPI_BAL.Models
{
    public class Daily
    {
        public List<String> Time { get; set; }
        public List<float> Temperature_2m_max { get; set; }
        public List<float> Temperature_2m_min { get; set; }
        public List<float> Rain_sum { get; set; }
    }
}
