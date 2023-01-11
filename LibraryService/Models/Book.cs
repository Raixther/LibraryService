using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryService.Models;

    public class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int BookId{ get; set; }

         required public string Title { get; set; }

         required public string Description { get; set; }

         required public int PageCount{ get; set; }

         public ICollection<Author> Authors { get; set; } = new HashSet<Author>();

         public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
}

