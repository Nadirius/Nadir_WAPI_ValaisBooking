using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Picture")]
    public class Picture
    {
        #region Picture persisted properties

            #region Data base normalisation properties

                #region PK Picture - Identity

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdPicture { get; set; }

                #endregion

                #region FK to Room - Picture belongs to one Room

        [ForeignKey("Room")]
        public int? IdRoom { get; set; }

                #endregion

            #endregion

            #region Picture state properties

        [Required(ErrorMessage ="Picture url is required")]
        [Url]
        [MaxLength(255)]
        public string Url { get; set; }

            #endregion

        #endregion

        #region Picture Runtime Links

            #region Picture belongs to one Rooom

        public Room Room { get; set; }

            #endregion

        #endregion

    }
}