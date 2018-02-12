using System;
using System.Collections.Generic;

namespace Solution
{
    internal class ColdDressCommand : DressCommand
    {
        public ColdDressCommand(List<COMMAND_ENUM> commandList) : base(commandList)
        {
        
        }

        override protected bool ValidateLeaveHouse()
        {
            // Assume leave house is the last one, so we have 6 commands
            if (IssuedCommandList.Count == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        override protected string ConvertCommandSequenceEnumToString()
        {
            string retValue = "";

            foreach (COMMAND_ENUM command in IssuedCommandList)
            {
                switch (command)
                {
                    case COMMAND_ENUM.PUT_ON_FOOTWEAR:
                        retValue += "boots";
                        break;
                    case COMMAND_ENUM.PUT_ON_HEADWEAR:
                        retValue += "hat";
                        break;
                    case COMMAND_ENUM.PUT_ON_SOCKS:
                        retValue += "socks";
                        break;
                    case COMMAND_ENUM.PUT_ON_SHIRT:
                        retValue += "shirt";
                        break;
                    case COMMAND_ENUM.PUT_ON_JACKET:
                        retValue += "jacket";
                        break;
                    case COMMAND_ENUM.PUT_ON_PANTS:
                        retValue += "pants";
                        break;
                    case COMMAND_ENUM.LEAVE_HOUSE:
                        retValue += "leaving house";
                        break;
                    case COMMAND_ENUM.TAKE_OFF_PAJAMAS:
                        retValue += "Removing PJs";
                        break;
                    case COMMAND_ENUM.FAIL:
                        retValue += "fail";
                        break;
                    default:
                        break;
                }

                if (command != COMMAND_ENUM.LEAVE_HOUSE)
                {
                    retValue += " ,";
                }
            }

            return retValue;
        }
    }
}
