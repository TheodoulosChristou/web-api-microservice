using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.General
{
    public class ErrorDetails
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
