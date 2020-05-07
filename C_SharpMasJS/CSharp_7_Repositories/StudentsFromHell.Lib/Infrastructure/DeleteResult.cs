using Academy.Lib.Models;
using System;
using System.Collections.Generic;


namespace Academy.Lib.Infrastructure
{
	public class DeleteResult<T> where T : Entity
	{
		public ValidationResult Validation { get; set; } = new ValidationResult();

		public bool DeleteValidationSuccesful
		{
			get
			{
				return Validation.IsSuccess;
			}

			set
			{
				Validation.IsSuccess = value;
			}
		}
		public List<string> DeleteValidationMessages { get; set; } = new List<string>();

		public T Entity { get; set; }



		public DeleteResult()
		{

		}
		public DeleteResult(bool initTrue)
		{
			this.DeleteValidationSuccesful = initTrue;
		}



		public DeleteResult<TOut> Cast<TOut>() where TOut : Entity
		{
			var output = new DeleteResult<TOut>
			{
				Entity = this.Entity as TOut,
				Validation = this.Validation
			};

			return output;
		}
	}
}
