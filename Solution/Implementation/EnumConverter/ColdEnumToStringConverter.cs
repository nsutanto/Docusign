using System;
namespace Solution
{
    internal class ColdEnumToStringConverter : EnumToStringConverter
    {
        override protected string GetFootWearStr()
        {
            return "boots";
        }
        override protected string GetHeadWearStr()
        {
            return "hat";
        }
        override protected string GetSockStr()
        {
            return "socks";
        }
        override protected string GetShirtStr()
        {
            return "shirt";
        }
        override protected string GetJacketStr()
        {
            return "jacket";
        }
        override protected string GetPantsStr()
        {
            return "pants";
        }
     
    }
}
