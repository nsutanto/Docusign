using System;
using System.Collections.Generic;

namespace Solution
{
    // DressCommand parent abstract class.
    internal abstract class DressCommand
    {
        private List<COMMAND_ENUM> CommandList
        {
            get;
            set;
        }

        protected List<COMMAND_ENUM> IssuedCommandList;

        private EnumToStringConverter EnumToStringConverter;

        internal DressCommand(List<COMMAND_ENUM> commandList, EnumToStringConverter enumToStringConverter) 
        {
            CommandList = commandList;
            IssuedCommandList = new List<COMMAND_ENUM>();
            EnumToStringConverter = enumToStringConverter;
        }

        // This is the validate function
        internal string Validate()
        {
            string output = "";

            ValidateCommandSequence();

            output = EnumToStringConverter.ConvertCommandSequenceEnumToString(IssuedCommandList);

            return output;
        }

        // Make it abstract function since no default implementation and each implementation will be different
        // This is to make sure all command is executed
        abstract protected bool IsAllCommandsExecuted();

        // Validate each command. Put it to 'stack' IssuedCommandList
        // That way we can check if the command is duplicate or not
        private void ValidateCommandSequence()
        {
            bool isCommandValid = true;

            if (performPreValidation())
            {
                foreach (COMMAND_ENUM command in CommandList)
                {
                    if (!IsDuplicate(command))
                    {
                        switch (command)
                        {
                            case COMMAND_ENUM.PUT_ON_FOOTWEAR:
                                isCommandValid = ValidateFootwear();
                                break;
                            case COMMAND_ENUM.PUT_ON_HEADWEAR:
                                isCommandValid = ValidateHeadwear();
                                break;
                            case COMMAND_ENUM.PUT_ON_SOCKS:
                                isCommandValid = ValidateSocks();
                                break;
                            case COMMAND_ENUM.PUT_ON_SHIRT:
                                isCommandValid = ValidateShirt();
                                break;
                            case COMMAND_ENUM.PUT_ON_JACKET:
                                isCommandValid = ValidateJacket();
                                break;
                            case COMMAND_ENUM.PUT_ON_PANTS:
                                isCommandValid = ValidatePants();
                                break;
                            case COMMAND_ENUM.LEAVE_HOUSE:
                                // This will force the inherited class to implement
                                isCommandValid = ValidateLeaveHouse();
                                break;
                            case COMMAND_ENUM.TAKE_OFF_PAJAMAS:
                                isCommandValid = ValidateTakeOffPajamas();
                                break;
                            default:
                                IssuedCommandList.Add(COMMAND_ENUM.FAIL);
                                isCommandValid = false;
                                break;
                        }

                        if (!isCommandValid)
                        {
                            // Command is not valid. Stop
                            break;
                        }
                    }
                    else
                    {
                        // It is duplicate. Break
                        break;
                    }
                }
            }
        }

        // Check if it is duplicate command
        private bool IsDuplicate(COMMAND_ENUM command)
        {
            bool retValue = false;
            if (IssuedCommandList.Contains(command)) 
            {
                IssuedCommandList.Add(COMMAND_ENUM.FAIL);
                retValue = true;
            }
            return retValue;
        }

        // Perform initial check, to make sure the first one is take off pajamas
        virtual protected bool performPreValidation()
        {
            bool isValid = false;
            if (CommandList[0] == COMMAND_ENUM.TAKE_OFF_PAJAMAS)
            {
                isValid = true;
            }
            else
            {
                IssuedCommandList.Add(COMMAND_ENUM.FAIL);
                isValid = false;
            }

            return isValid;
        }

        // Perform Validate Footwear
        virtual protected bool ValidateFootwear()
        {
            bool isValid = false;
            // Need to wear socks and pants before footwear
            if (IssuedCommandList.Contains(COMMAND_ENUM.PUT_ON_SOCKS) &&
                IssuedCommandList.Contains(COMMAND_ENUM.PUT_ON_PANTS))
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

        // Perform validate headwear
        virtual protected bool ValidateHeadwear()
        {
            bool isValid = false;
            // Need to wear shirt before headwear
            if (IssuedCommandList.Contains(COMMAND_ENUM.PUT_ON_SHIRT))
            {
                IssuedCommandList.Add(COMMAND_ENUM.PUT_ON_HEADWEAR);
                isValid = true;
            }
            else
            {
                IssuedCommandList.Add(COMMAND_ENUM.FAIL);
                isValid = false;
            }
            return isValid;
        }

        // Perform validate socks
        virtual protected bool ValidateSocks()
        {   
            IssuedCommandList.Add(COMMAND_ENUM.PUT_ON_SOCKS);
            return true;
        }

        // Perform validate shirt
        virtual protected bool ValidateShirt()
        {
            IssuedCommandList.Add(COMMAND_ENUM.PUT_ON_SHIRT);
            return true;
        }

        // Perform validate jacket
        virtual protected bool ValidateJacket()
        {
            bool isValid = false;
            // Need to validate shirt before wearing jacket
            if (IssuedCommandList.Contains(COMMAND_ENUM.PUT_ON_SHIRT))
            {
                IssuedCommandList.Add(COMMAND_ENUM.PUT_ON_JACKET);
                isValid = true;
            }
            else
            {
                IssuedCommandList.Add(COMMAND_ENUM.FAIL);
                isValid = false;
            }
            return isValid;
        }

        // Perform validate pants
        virtual protected bool ValidatePants()
        {
            IssuedCommandList.Add(COMMAND_ENUM.PUT_ON_PANTS);
            return true;
        }
   
        // Perform validate take off pajamas
        virtual protected bool ValidateTakeOffPajamas()
        {
            IssuedCommandList.Add(COMMAND_ENUM.TAKE_OFF_PAJAMAS);
            return true;
        }

        virtual protected bool ValidateLeaveHouse()
        {
            bool isValid = false;
            // Make sure all command is executed. It will call the implementation class.
            if (IsAllCommandsExecuted())
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
