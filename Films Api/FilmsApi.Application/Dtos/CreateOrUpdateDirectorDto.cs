namespace FilmsApi.Application.Dtos;


    public class CreateOrUpdateDirectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public byte Star { get; set; }
    }

