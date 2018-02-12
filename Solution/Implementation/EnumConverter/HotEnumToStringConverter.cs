using System;
using System.Collections.Generic;

namespace Solution
{
    internal class HotEnumToStringConverter : EnumToStringConverter
    {
        override protected string GetFootWearStr()
        {
            return "sandals";
        }
        override protected string GetHeadWearStr()
        {
            return "sun visor";
        }
        override protected string GetSockStr()
        {
            // No sock. It should be handle by fail string
            return "";
        }
        override protected string GetShirtStr()
        {
            return "t-shirt";
        }
        override protected string GetJacketStr()
        {
            // No jacket. It should be handle by fail string
            return "";
        }
        override protected string GetPantsStr()
        {
            return "shorts";
        }
    }
}
