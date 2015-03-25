namespace MS.ECP.Model
{
    using System;
    using System.Runtime.CompilerServices;

    public class MailModel
    {
        public string BCCAddress { get; set; }

        public string Body { get; set; }

        public string CCAddress { get; set; }

        public bool IsActionCode { get; set; }

        public string MailName { get; set; }

        public string SendModel { get; set; }

        public string ToAddress { get; set; }

        public string UserCode { get; set; }

        public string WebRegion { get; set; }
    }
}
