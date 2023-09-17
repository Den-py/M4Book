using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Book.Model
{
    public class Audiobook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        
        public double DurationToDouble()
        {
            return (Duration.Hours + Duration.Minutes / 100.0 + Duration.Seconds / 10000.0) * (Duration > TimeSpan.Zero ? 1 : -1);
        }
    }
}
