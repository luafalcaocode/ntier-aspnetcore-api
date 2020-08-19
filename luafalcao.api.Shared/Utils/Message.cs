using System;
using System.Collections.Generic;

namespace luafalcao.api.Shared.Utils
{
    public class Message<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public IList<string> Errors = new List<string>();
        public Exception Exception { get; set; }
    }
}