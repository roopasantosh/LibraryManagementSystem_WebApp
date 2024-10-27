using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Transaction
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    //[DefaultValue("Assigned")]
    [StringLength(10)]
    public string TransactionType { get; set; } = string.Empty;
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedOn { get; set; }
    [Required]
    [StringLength(50)]
    public string CreatedBy { get; set; } = string.Empty;
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    [Required]
    [StringLength(50)]
    public string UpdatedBy { get; set; } = string.Empty;

    [ForeignKey("Book")]
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }
}
