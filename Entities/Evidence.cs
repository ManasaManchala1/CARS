namespace CARS.Entities
{
    internal class Evidence
    {
        int evidenceID;
        string description;
        string locationFound;
        int incidentID;
        public int EvidenceID { get { return evidenceID; } set { evidenceID = value; } }
        public int IncidentID {  get { return incidentID; } set {  incidentID = value; } }
        public string LocationFound { get {  return locationFound; } set {  locationFound = value; } }
        public string Description { get { return description; } set { description = value; } }
        public Evidence(int evidenceID,string description,string locationFound,int incidentID) {
            EvidenceID = evidenceID;
            Description = description;
            LocationFound = locationFound;
            IncidentID = incidentID;
        }
    }
}
