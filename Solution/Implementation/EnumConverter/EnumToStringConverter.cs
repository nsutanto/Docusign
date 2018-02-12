using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    internal abstract class EnumToStringConverter
    {
        internal string ConvertCommandSequenceEnumToString(List<COMMAND_ENUM> issuedCommandList)
        {
            StringBuilder outputStr = new StringBuilder();
        
            foreach (COMMAND_ENUM command in issuedCommandList)
            {
                switch (command)
                {
                    case COMMAND_ENUM.PUT_ON_FOOTWEAR:
                        outputStr.Append(GetFootWearStr());
                        break;
                    case COMMAND_ENUM.PUT_ON_HEADWEAR:
                        outputStr.Append(GetHeadWearStr());
                        break;
                    case COMMAND_ENUM.PUT_ON_SOCKS:
                        outputStr.Append(GetSockStr());
                        break;
                    case COMMAND_ENUM.PUT_ON_SHIRT:
                        outputStr.Append(GetShirtStr());
                        break;
                    case COMMAND_ENUM.PUT_ON_JACKET:
                        outputStr.Append(GetJacketStr());
                        break;
                    case COMMAND_ENUM.PUT_ON_PANTS:
                        outputStr.Append(GetPantsStr());
                        break;
                    case COMMAND_ENUM.LEAVE_HOUSE:
                        outputStr.Append(GetLeaveHouseStr());
                        break;
                    case COMMAND_ENUM.TAKE_OFF_PAJAMAS:
                        outputStr.Append(GetTakeOffPajamasStr());
                        break;
                    case COMMAND_ENUM.FAIL:
                        outputStr.Append(GetFailStr());
                        break;
                    default:
                        break;
                }

                if (command == COMMAND_ENUM.LEAVE_HOUSE || command == COMMAND_ENUM.FAIL)
                {
                    // Do nothing, because it would be the last command
                }
                else
                {
                    // Add comma and space
                    outputStr.Append(", ");
                }
            }
            return outputStr.ToString();
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
