using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Data.Dtos;

public class CreateContaDto
{
    public string? NumeroConta { get; set; }
    public string? DigitoVerificador { get; set; }
    [Required]
    public int ClienteId { get; set; }

    public void GerarNumeroConta()
    {
        Random random = new Random();
        for (int i = 0; i < 4; i++)
        {
            NumeroConta += random.Next(1, 9).ToString();
        }
        
        DigitoVerificador = random.Next(1, 9).ToString();
    }
}
