using System;
using System.Collections.Generic;

namespace Solution
{
    internal class HotDressCommand : DressCommand
    {
        public HotDressCommand(List<COMMAND_ENUM> commandList) : base(commandList)
        {
            
        }

        override protected bool ValidateJacket()
        {
            IssuedCommandList.Add(COMMAND_ENUM.FAIL);
            return false;
        }

        override protected bool ValidateSocks()
        {
            IssuedCommandList.Add(COMMAND_ENUM.FAIL);
            return false;
        }

        override protected bool ValidateLeaveHouse()
        {
            // Assume leave house is the last one, so we have 4 commands
            if (IssuedCommandList.Count == 4)
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
                        retValue += "sandals";
                        break;
                    case COMMAND_ENUM.PUT_ON_HEADWEAR:
                        retValue += "sun visor";
                        break;
                    case COMMAND_ENUM.PUT_ON_SHIRT:
                        retValue += "t-shirt";
                        break;
                    case COMMAND_ENUM.PUT_ON_PANTS:
                        retValue += "shorts";
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

                if (command != COMMAND_ENUM.LEAVE_HOUSE || command != COMMAND_ENUM.FAIL)
                {
                    retValue += " ,";
                }
            }
            return retValue;
        }
    }
}
