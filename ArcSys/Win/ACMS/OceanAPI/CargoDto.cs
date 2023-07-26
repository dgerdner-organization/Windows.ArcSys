namespace WebApiDemo.Dto
{
    /// <summary>
    ///     List of Cargo Details
    /// </summary>
    public class CargoDto
    {
        /// <summary>
        ///     CargoId
        /// </summary>

        public string SerialNumber { get; set; }

        public string HandlingIndicatorCode { get; set; }

        public double Weight { get; set; }

         public double Length { get; set; }

         public double Width { get; set; }

         public double Height { get; set; }

         public string KindOfPackage { get; set; }

        public string CommodityCode { get; set; }

        public string DescriptionOfGoods { get; set; }

        public string Model { get; set; }

    public string PerCode { get; set; }
    }
}
