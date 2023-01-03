using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Models;

    public class Author
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        required public int AuthorId { get; set; }
        required public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();

   }

