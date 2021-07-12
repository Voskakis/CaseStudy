using System.Collections.Generic;

namespace BackLayers.Models
{
    public class MyUser
    {
        public string MyUserId { get; set; }
        public ICollection<Click> Clicks { get; set; }
    }
}