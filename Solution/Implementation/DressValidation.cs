using System;
namespace Solution
{
    public class DressValidation : IDressValidation
    {
        public DressValidation()
        {
            
        }

        public string Validate(string commandLineString)
        {
            DressCommand dressCommand = CommandFactory.Instance.CreateDressCommand(commandLineString);

            string output = dressCommand.Validate();

            return output;
        }
    }
}
