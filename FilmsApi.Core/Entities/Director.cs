using System.Text.Json.Serialization;


namespace FilmsApi.Core
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public byte Star { get; set; }
        public List<Film> Films { get; set; } = new List<Film>();

    }
}
