using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace Final.ViewModels
{
    public class MemberLoginVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
		public MemberLoginVM(string userName, string password)
		{
			Username = userName;
			
			Password = password;
			
		}
	}
	
}
