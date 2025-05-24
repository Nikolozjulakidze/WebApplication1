using System.Text.Json.Serialization;

namespace FilmsApi.Core
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Time { get; set; }
        public byte Star { get; set; }
        public int DirectorId { get; set; }
        public Director? Director { get; set; }
      

}
}
