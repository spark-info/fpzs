using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fpzs.bl
{
    public class InvokeResult
    {
        public bool State { get; set; }
        public string Message { get; set; }

        public static InvokeResult SUCCESS = new InvokeResult(true, "");

        private InvokeResult(bool state, string message)
        {
            this.State = state;
            this.Message = message;
        }

        public static InvokeResult Fail(string message)
        {
            return new InvokeResult(false,message);
        }
    }
}
