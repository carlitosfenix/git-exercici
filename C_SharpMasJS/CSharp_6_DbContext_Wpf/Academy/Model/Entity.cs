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
    }
}
