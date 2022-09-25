//@CodeCopy
//MdStart
#if ACCOUNT_ON
namespace QTHungryDogs.Logic.Entities.Account
{
    [Table("Roles", Schema = "account")]
    [Index(nameof(Designation), IsUnique = true)]
    internal partial class Role : VersionEntity
    {
        [Required]
        [MaxLength(64)]
        public string Designation { get; set; } = string.Empty;
        [Required]
        [MaxLength(256)]
        public string Description { get; set; } = string.Empty;

        // Navigation properties
        [ForeignKey("IdentityId")]
        public List<Identity> Identities { get; set; } = new();
    }
}
#endif
//MdEnd
