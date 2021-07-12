using System;

namespace BackLayers.Models
{
    public class Click
    {
        public int ClickId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public DateTime Time { get; set; }
        public string Color { get; set; }
        public int Diameter { get; set; }
    }
}