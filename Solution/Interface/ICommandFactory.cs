using System;
using System.Collections.Generic;

namespace Solution
{
    public interface ICommandFactory
    {
        IDressCommand CreateDressCommand(string commandListString);
    }
}
