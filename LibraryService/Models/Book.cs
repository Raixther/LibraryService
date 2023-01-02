using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryService.Models;

    public class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        required public int BookId{ get; set; }

         required public string Title { get; set; }

         required public string Description { get; set; }

         required public int PageCount{ get; set; }

         required public ICollection<Author> Authors { get; set; }

         required public ICollection<Category> Categories { get; set; }
    }

