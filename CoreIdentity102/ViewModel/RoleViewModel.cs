using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreIdentity102.ViewModel
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "{0} alani zorunludur"), DisplayName("Role Adi")]
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
