namespace CARS.Entities
{
    public class Cases
    {
        public int CaseID { get; set; }
        public string Description {  get; set; }
        public List<Incidents> RelatedIncidents { get; set; }
        public Cases() { }
        public override string ToString()
        {
            return $"CaseId:{CaseID},Description:{Description}";
        }
    }
}
