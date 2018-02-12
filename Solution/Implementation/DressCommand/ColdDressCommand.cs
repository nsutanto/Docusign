using System;
using System.Collections.Generic;

namespace Solution
{
    // Cold command implementations
    internal class ColdDressCommand : DressCommand
    {
        internal ColdDressCommand(List<COMMAND_ENUM> commandList, EnumToStringConverter enumToStringConverter) 
            : base(commandList, enumToStringConverter)
        {
        
        }

        override protected bool ValidateLeaveHouse()
        {
            bool isValid = false;
            // Assume leave house is the last one, so we have 7 commands
            if (IssuedCommandList.Count == 7)
            {
                IssuedCommandList.Add(COMMAND_ENUM.LEAVE_HOUSE);
                isValid = true;
            }
            else
            {
                IssuedCommandList.Add(COMMAND_ENUM.FAIL);
                isValid = false;
            }
            return isValid;
        }
    }
}
