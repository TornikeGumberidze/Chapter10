using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared;

public class Category
{
    public int CategoryId { get; set; }
    [StringLength(15)]
    [Required]
    public string? CategoryName { get; set; }
    [Column(TypeName = "NTEXT")]
    public string? Description { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public Category()
    {
        // to enable developers to add products to a Category we must
        // initialize the navigation property to an empty collection
        Products = new HashSet<Product>();
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in Products)
        {
            sb.Append(item.ToString() + '\n');
        }
        string st = sb.ToString();
        return $"Category {CategoryName} has id {CategoryId} description: \t{Description}. \n{CategoryName} has the following products: \n" + sb;
    }

}
