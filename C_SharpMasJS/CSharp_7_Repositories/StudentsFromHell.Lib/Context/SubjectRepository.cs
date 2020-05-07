using Academy.Lib.Infrastructure;
using Academy.Lib.Models;
using System.Collections.Generic;

namespace Academy.Lib.Context
{
    public class SubjectRepository : Repository<Subject>
    {
        public static Dictionary<string, Subject> SubjectsByName { get; set; } = new Dictionary<string, Subject>();

        public override SaveResult<Subject> Add(Subject entity)
        {
            //var output = base.Add(entity);
            var output = new SaveResult<Subject>() { Entity = entity};

            if (SubjectsByName.ContainsKey(entity.Name))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Ya existe este Subject con ese name");
            }

            if (output.IsSuccess)
            {
                SubjectsByName.Add(output.Entity.Name, output.Entity);
            }

            return output;
        }

        public override SaveResult<Subject> Update(Subject entity)
        {
            //var output = base.Update(entity);
            var output = new SaveResult<Subject>() { Entity = entity };
            var check = entity.Validate(); 
            if (!check.IsSuccess)
            {
                output.IsSuccess = false;
                output.Validation.Errors = check.Errors;
            }     
            if (!SubjectsByName.ContainsKey(output.Entity.Name))
            {
                output.Validation.Errors.Add($"No se hay subject de: {output.Entity.Name} !");
            }
            if (output.IsSuccess)
            {
                SubjectsByName[output.Entity.Name] = output.Entity;
            }

            return output;
        }

        public override DeleteResult<Subject> Delete(Subject entity)
        {
            var output = new DeleteResult<Subject>() { Entity = entity };

            if (output.DeleteValidationSuccesful)
            {
                SubjectsByName.Remove(output.Entity.Name);
            }

            return output;
        }

        public Subject GetSubjectByName(string name)
        {
            if (SubjectsByName.ContainsKey(name))
                return SubjectsByName[name];

            return null;
        }
        public Dictionary<string, Subject> GetAllSubjects()
        {
            return SubjectsByName;
        }
    }
}
