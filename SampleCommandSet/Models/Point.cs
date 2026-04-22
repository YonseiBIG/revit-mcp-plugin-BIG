using Newtonsoft.Json;

namespace SampleCommandSet.Models
{
    /// <summary>
    /// Point coordinate.
    /// </summary>
    public class Point
    {
        [JsonProperty("x")]
        public double X { get; set; }
        [JsonProperty("y")]
        public double Y { get; set; }
        [JsonProperty("z")]
        public double Z { get; set; }
    }
}
