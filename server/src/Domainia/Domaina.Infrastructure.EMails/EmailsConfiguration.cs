namespace Domaina.Infrastructure.EMails
{
    public class EmailsConfiguration
    {
        //public EmailsConfiguration(string regiatrationEmailFromId,
        //    string deliveryMethod,
        //    string pickupDirectoryLocation)
        //{
        //    RegiatrationEmailFromId = regiatrationEmailFromId;
        //    DeliveryMethod = deliveryMethod;
        //    PickupDirectoryLocation = pickupDirectoryLocation;
        //}

        public string RegiatrationEmailFromId { get; set; }
        public string DeliveryMethod { get; set; }
        public string PickupDirectoryLocation { get; set; }
    }
}