using System;
using System.Collections.Generic;

namespace Solution
{
    internal abstract class EnumToStringConverter
    {
        internal string ConvertCommandSequenceEnumToString(List<COMMAND_ENUM> issuedCommandList)
        {
            string retValue = "";

            foreach (COMMAND_ENUM command in issuedCommandList)
            {
                switch (command)
                {
                    case COMMAND_ENUM.PUT_ON_FOOTWEAR:
                        retValue += GetFootWearStr();
                        break;
                    case COMMAND_ENUM.PUT_ON_HEADWEAR:
                        retValue += GetHeadWearStr();
                        break;
                    case COMMAND_ENUM.PUT_ON_SHIRT:
                        retValue += GetShirtStr();
                        break;
                    case COMMAND_ENUM.PUT_ON_PANTS:
                        retValue += GetPantsStr();
                        break;
                    case COMMAND_ENUM.LEAVE_HOUSE:
                        retValue += GetLeaveHouseStr();
                        break;
                    case COMMAND_ENUM.TAKE_OFF_PAJAMAS:
                        retValue += GetTakeOffPajamasStr();
                        break;
                    case COMMAND_ENUM.FAIL:
                        retValue += GetFailStr();
                        break;
                    default:
                        break;
                }

                if (command != COMMAND_ENUM.LEAVE_HOUSE || command != COMMAND_ENUM.FAIL)
                {
                    retValue += " ,";
                }
            }
            return retValue;
        }

        abstract protected string GetFootWearStr();
        abstract protected string GetHeadWearStr();
        abstract protected string GetSockStr();
        abstract protected string GetShirtStr();
        abstract protected string GetJacketStr();
        abstract protected string GetPantsStr();

        virtual protected string GetTakeOffPajamasStr()
        {
            return "Removing PJs";
        }

        virtual protected string GetFailStr()
        {
            return "fail";
        }

        virtual protected string GetLeaveHouseStr()
        {
            return "leaving house";
        }
    }
}
