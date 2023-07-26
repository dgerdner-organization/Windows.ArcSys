namespace WebApiDemo.Dto
{
    public class AddressDto
    {
     public string Type { get; set; }

     public string Name { get; set; }

         public string Address1 { get; set; }

       public string Contact { get; set; }

        public string City { get; set; }

      public string State { get; set; }

         public string PostCode { get; set; }

        /// <summary>
        ///     two-character code (ISO2)
        /// </summary>
 
        public string CountryCode { get; set; }

         public string WorkTelephoneNumber { get; set; }

        public string Email { get; set; }

        public string DepartmentOfDefenseActivityAddressCode { get; set; }
    }
}
