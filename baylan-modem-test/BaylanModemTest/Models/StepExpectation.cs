using System;
using System.Collections.Generic;

namespace BaylanModemTest.Models
{
    internal class StepExpectation
    {
        public string ContainsText { get; }
        public Dictionary<string, string> Fields { get; }

        public StepExpectation(string containsText, Dictionary<string, string> fields = null)
        {
            ContainsText = containsText ?? string.Empty;
            Fields = fields ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }
    }
}
