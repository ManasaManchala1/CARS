using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    internal class Cases
    {
        public int CaseID {  get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public List<Incidents> RelatedIncidents { get; set; }
        public Cases() { }
        public override string ToString()
        {
            return $"CaseId:{CaseID},Description:{Description},Status:{Status}";
        }
    }
}
