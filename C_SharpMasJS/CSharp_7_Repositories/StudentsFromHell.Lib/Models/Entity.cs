using Academy.Lib.Context;
using Academy.Lib.Infrastructure;
using System;

namespace Academy.Lib.Models
{
    public abstract class  Entity
    {
        public Guid Id { get; set; }

        public ValidationResult CurrentValidation { get; private set; }

        public virtual SaveResult<T> Save<T>() where T : Entity
        {
            var output = new SaveResult<T>();

            CurrentValidation = Validate();

            if (CurrentValidation.IsSuccess)
            {
                var repo = new Repository<T>();

                if (this.Id == Guid.Empty)
                {
                    this.Id = Guid.NewGuid();
                    output = repo.Add(this as T);
                }
                else
                {
                    output = repo.Update(this as T);
                }
            }

            output.Validation = CurrentValidation;

            return output;
        }

        public virtual ValidationResult Validate()
        {
            var output = new ValidationResult()
            {
                IsSuccess = true
            };

            return output;
        }

        public virtual DeleteResult<T> Delete<T>() where T : Entity
        {
            var result = new DeleteResult<T>();
            CurrentValidation = Validate();
            var repo = new Repository<T>();

            if (CurrentValidation.IsSuccess)
            {
                result = repo.Delete(this as T);
            }

            result.Validation = CurrentValidation;
            return result;
        }

        
    }

}
