using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRegistry.Models
{
    /// <summary>
    /// Режимы сортировки животных
    /// </summary>
    public enum AnimalSortState
    {
        ClassAsc,
        ClassDesc,
        GenderAsc,
        GenderDesc,
        NameAsc,
        NameDesc,
        LocationAsc,
        LocationDesc,
        WeightAsc,
        WeightDesc,
        DateOfWeighingAsc,
        DateOfWeighingDesc
    }
}
