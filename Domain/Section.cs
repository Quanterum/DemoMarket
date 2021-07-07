using System.Collections.Generic;
using Domain.Common;
using Domain.Common.Interfaces;

namespace Domain
{
    public class Section : BaseEntity
    {
        private List<ICategory> Categories { get; set; }
    }
}