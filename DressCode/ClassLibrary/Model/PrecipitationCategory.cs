using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSMHI.Model
{
    public class PrecipitationCategory
    {
        public static Dictionary<int, string> PrecipitationCategoryDictionary = new Dictionary<int, string>()
        {
            {0, "No precipitation" },
            {1, "Snow"},
            {2, "Snow and rain"},
            {3, "Rain"},
            {4, "Drizzle"},
            {5, "Freezing rain"},
            {6, "Freezing drizzle"}
        };
    }
}
