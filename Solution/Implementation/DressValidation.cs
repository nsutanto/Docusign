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
            string output = "";
            try
            {
                DressCommand dressCommand = CommandFactory.Instance.CreateDressCommand(commandLineString);

                if (dressCommand != null)
                {
                    output = dressCommand.Validate();
                }
                else
                {
                    // not sure what is the requirement for invalid inputs.. Make it fail for now.
                    output = "fail";
                }
            }
            catch (Exception ex)
            {
                // Got exception... let's just output it for now
                output = ex.Message;
            }

            return output;
        }
    }
}
