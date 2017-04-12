using System.Collections.Generic;

namespace Rest.ClientRuntime.Test.JsonRpc
{
    public sealed class Request : Message
    {
        public string method { get; set; }
        public Dictionary<string, object> @params { get; set; }
        
        public Request(int id, string method, Dictionary<string, object> @params): base(id)
        {
            this.method = method;
            this.@params = @params;
        }
    }
}
