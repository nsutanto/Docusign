using System;
using System.Collections.Generic;

namespace Solution
{
    internal abstract class DressCommand
    {
        protected List<COMMAND_ENUM> CommandList
        {
            get;
            private set;
        }

        public DressCommand(List<COMMAND_ENUM> commandList) 
        {
            CommandList = commandList;
        }

        virtual protected bool CheckInitialState()
        {
            if (CommandList[0] != COMMAND_ENUM.TAKE_OFF_PAJAMAS)
            {
                return false;
            }
            return true;
        }
    }
}
