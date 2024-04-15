using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstravaWeatherAPI_BAL.Models
{
    public sealed record Error(string Code, string? Description = null)
    {

    }   
}
