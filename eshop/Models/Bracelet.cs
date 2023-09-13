using System.ComponentModel.DataAnnotations;

namespace test_2.Models;

public class Bracelet
{
    [Key]
    public int BraceletId { get; set; }

    public string Image { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; } 
    public string Description { get; set; } // avec le type de métal, de pierre ainsi que l'entretien
    public string Warranty { get; set; } // garantie
    public string Expedition { get; set; } // livraison
   
}