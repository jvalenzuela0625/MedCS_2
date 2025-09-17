using MedCS_2.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Domain.Common
{
    public abstract class BaseEntity<Tkey>
    {
        public Tkey Id { get; set; } = default!;

        public Guid? CreatedBy { get; set; }
        public DateTime Created { get; set; }

        public Guid? ModifiedBy { get; set; }
        public DateTime Modified { get; set; }

        public Users? CreatedByUser { get; set; }
        public Users? ModifiedByUser { get; set; }

    }
}
