using System;
using System.Collections.Generic;

namespace Solution
{
    internal class ColdDressCommand : DressCommand, IDressCommand
    {
        public ColdDressCommand(List<COMMAND_ENUM> commandList) : base(commandList)
        {
        
        }

        public bool Validate()
        {
            return true;
        }
    }
}
