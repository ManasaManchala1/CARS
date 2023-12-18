namespace CARS.Exceptions
{
    public class ReportNotFoundException:ApplicationException
    {
        public string Mssg {  get; set; }
        public ReportNotFoundException(string mssg):base(mssg) { 
            Mssg = mssg;
        }
    }
}
