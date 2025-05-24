namespace FilmsApi.Application.Dtos;


public class CreateOrUpdateFilmDto
{
    public string Name { get; set; }

    public decimal Time { get; set; }

    public byte Star { get; set; }

    public int DirectorId { get; set; }

}

