using System;
using System.Collections.Generic;

namespace Solution
{
    // Hot Command implementation
    internal class HotDressCommand : DressCommand
    {
        internal HotDressCommand(List<COMMAND_ENUM> commandList, EnumToStringConverter enumToStringConverter) 
            : base(commandList, enumToStringConverter)
        {
            
        }

        // No jacket during summer
        override protected bool ValidateJacket()
        {
            IssuedCommandList.Add(COMMAND_ENUM.FAIL);
            return false;
        }

        // No socks during summer
        override protected bool ValidateSocks()
        {
            IssuedCommandList.Add(COMMAND_ENUM.FAIL);
            return false;
        }

        // Perform Validate Footwear
        override protected bool ValidateFootwear()
        {
            bool isValid = false;
            // Need to wear socks and pants before footwear
            if (IssuedCommandList.Contains(COMMAND_ENUM.PUT_ON_PANTS))
            {
                IssuedCommandList.Add(COMMAND_ENUM.PUT_ON_FOOTWEAR);
                isValid = true;
            }
            else
            {
                IssuedCommandList.Add(COMMAND_ENUM.FAIL);
                isValid = false;
            }
            return isValid;
        }

        override protected bool ValidateLeaveHouse()
        {
            bool isValid = false;
            // Assume leave house is the last one, so we have 5 commands
            if (IssuedCommandList.Count == 5)
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
