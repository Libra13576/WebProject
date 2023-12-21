using System;
using System.ComponentModel.DataAnnotations;

public class WebProject.ModelViews
{
	public RegisterVM
	{
		[Require(ErrorMessage = "Username cannot blank.")]
		public string Username { get; set; }
		
		[Require(ErrorMessage = "Email cannot blank.")]
		[EmailAdress(ErroMessage= "Invalid Email.")]
		public string CustomerEmail { get; set; }

		[Require(ErrorMessage = "Username cannot blank.")]
		[Compare("CustomerPassword", ErrorMessage= "Password must match")]
		public string CustomerPassword { get; set; }

		public string RePassword { get; set; }

		public string? CustomerAddress { get; set; }

		public string? CustomerPhone { get; set; }
	}
}
