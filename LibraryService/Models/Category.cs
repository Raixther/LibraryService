using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryService.Models;
public class Category
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        required  public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }

