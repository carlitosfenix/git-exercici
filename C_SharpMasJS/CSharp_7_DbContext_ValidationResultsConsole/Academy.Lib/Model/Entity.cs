using Academy_4_DbContext.Lib.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_4_DbContext.Lib.Model
{
    public class Entity
    {
        private Guid _id;

        public Guid Id { get => _id; set => _id = value; }

        public ValidationResult CurrentValidation { get; private set; }
        //Virtual for override
        public virtual SaveResult<T> Save<T>() where T : Entity
        {
            var output = new SaveResult<T>();

            CurrentValidation = Validate();

            if (CurrentValidation.IsSuccess)
            {
                
                if (this.Id == Guid.Empty)
                {
                    //Si es un elmento nuevo le asignamos un GUID
                    this.Id = Guid.NewGuid(); 
                }
                else
                {
                   //TODO: cuando tengamos Patrón repositorio UPDATE
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
    }
}

