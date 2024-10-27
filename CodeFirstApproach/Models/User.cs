using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [StringLength(200)]
    public string? Email { get; set; } = string.Empty;

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
    [StringLength(10)]
    public string Status { get; set; } = string.Empty;

    [StringLength(50)]
    [Required]
    public string Password { get; set; } = string.Empty;

    [StringLength(10)]
    [Required]   
    public string UserRole { get; set; }= string.Empty;
}
