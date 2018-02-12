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
    }
}
