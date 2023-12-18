namespace CARS.Exceptions
{
    internal class IncidentAlreadyExistException : ApplicationException
    {
        public string Mssg { get; set; }
        public IncidentAlreadyExistException(string mssg) : base(mssg)
        {
            Mssg = mssg;
        }
    }
}
