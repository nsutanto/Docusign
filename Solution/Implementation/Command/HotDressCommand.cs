﻿using System;
using System.Collections.Generic;

namespace Solution
{
    internal class HotDressCommand : DressCommand
    {
        internal HotDressCommand(List<COMMAND_ENUM> commandList, EnumToStringConverter enumToStringConverter) 
            : base(commandList, enumToStringConverter)
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
    }
}