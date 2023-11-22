using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Data
{
    public class Group_role
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group? group { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role? role { get; set; }
    }
}
