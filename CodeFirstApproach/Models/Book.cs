using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 50 characters!")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Author Name must be between 3 and 50 characters!")]
    public string Author { get; set; } = string.Empty;
    [DefaultValue(true)]
    public Boolean IsAvailable { get; set; } = true;

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    [Required]
    [StringLength(50)]
    public string CreatedBy { get; set; } = string.Empty;
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    [Required]
    [StringLength(50)]
    public string UpdatedBy { get; set; } = string.Empty;
    public int AvailableCopies { get; set; }
}
