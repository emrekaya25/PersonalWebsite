using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entity.CustomException
{
	public class FieldValidationException : Exception
	{
		public FieldValidationException(List<string> messageList)
		{
			base.Data["FieldValidationMessage"] = messageList;
		}
	}
}
