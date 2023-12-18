namespace CARS.Exceptions
{
    public class IncidentTypeNotFoundException:ApplicationException
    {
        public string Mssg {  get; set; }

        public IncidentTypeNotFoundException(string mssg):base(mssg){
            Mssg=mssg;
        }
    }
}
