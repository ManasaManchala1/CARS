namespace CARS.Entities
{
    internal class Victims
    {
        int victimID;
        string firstName;
        string lastName;
        string dateOfBirth;
        string gender;
        string contactInformation;
        public int VictimID {  get { return victimID; } set {  victimID = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string DateOfBirth { get {  return dateOfBirth; } set {  dateOfBirth = value; } }
        public string Gender { get {  return gender; } set {  gender = value; } }
        public string ContactInformation { get {  return contactInformation; } set {  contactInformation = value; } }
        public Victims(int victimID,string firstName, string lastName,string dateOfBirth,string gender,string contactInformation)
        {
            VictimID = victimID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ContactInformation = contactInformation;


        }
    }
}
