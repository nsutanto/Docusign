using System;
using System.Collections.Generic;

namespace Solution
{
    internal class HotDressCommand : DressCommand, IDressCommand
    {
        public HotDressCommand(List<COMMAND_ENUM> commandList) : base(commandList)
        {
        }

        public bool Validate()
        {
            if (!CheckInitialState()) 
            {
                return false;
            }

            if (CommandList.Contains(COMMAND_ENUM.PUT_ON_SOCKS) || 
                (CommandList.Contains(COMMAND_ENUM.PUT_ON_JACKET))) 
            {
                return false;
            }



            return true;
        }

    }
}
