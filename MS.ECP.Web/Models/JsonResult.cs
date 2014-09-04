namespace MS.ECP.Web.Models
{
    public enum BakcStatus
    {
        Ok = 0,
        AuthFalse = 1
    }



    public class JqueryResult
    {
        public JqueryResult()
        {
            Status = BakcStatus.Ok;
        }

        public bool Result { get; set; }
        public object Text { get; set; }
        public BakcStatus Status { get; set; } 
    }
}