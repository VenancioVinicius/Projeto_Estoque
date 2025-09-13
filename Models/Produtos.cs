using System.ComponentModel.DataAnnotations.Schema;

public class Produtos
{

    public int id { get; set; }

    public string nome { get; set; }


    [ForeignKey("Medidas")]
    public Medidas medidaid { get; set; }

    public int preco { get; set; }

    public int quantidade { get; set; }

}