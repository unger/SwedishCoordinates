using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCoordinates.Positions
{
    using SwedishCoordinates.Classes;

    public class WebMercatorPosition : Position
    {
        public WebMercatorPosition(double y, double x)
            : base(y, x, Grid.WebMercator)
        {
        }
    }
}
