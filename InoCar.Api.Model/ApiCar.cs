using System.Globalization;

namespace InoCar.Api.Model
{
    public class ApiCar
    {

      public int Id { get; set; }
        public int CertificateId { get; set; }
        public string StateNumber { get; set; }
      public string Mark { get; set; }
      public string Model { get; set; }
      public int Year { get; set; }
      public int? Transmission { get; set; }
      public string? EngineType { get; set; }
      public string? Drive { get; set; }
      public int Mileage { get; set; }

    }


}