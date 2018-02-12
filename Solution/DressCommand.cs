﻿using System;
using System.Collections.Generic;

namespace Solution
{
    public abstract class DressCommand : IDressCommand
    {
        protected List<COMMAND_ENUM> CommandList
        {
            get;
            private set;
        }

        protected List<COMMAND_ENUM> IssuedCommandList;

        public DressCommand(List<COMMAND_ENUM> commandList) 
        {
            CommandList = commandList;
            IssuedCommandList = new List<COMMAND_ENUM>();
        }

        public string Validate()
        {
            string output = "";

            bool isValid = performPreValidation();

            if (isValid)
            {
                isValid = ValidateCommandSequence();
            }

            output = ConvertCommandSequenceEnumToString();

            return output;
        }

        // Make it abstract function since no default implementation and  each implementation will be different
        abstract protected bool ValidateLeaveHouse();

        // Make it abstract function since no default implementation and  each implementation will be different
        abstract protected string ConvertCommandSequenceEnumToString();

        private bool ValidateCommandSequence()
        {
            bool isCommandValid = true;
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
            return isCommandValid;
        }

        private bool IsDuplicate(COMMAND_ENUM command)
        {
            bool retValue = true;
            if (IssuedCommandList.Contains(command)) 
            {
                IssuedCommandList.Add(COMMAND_ENUM.FAIL);
                retValue = false;
            }
            return retValue;
        }

        virtual protected bool performPreValidation()
        {
            bool isValid = false;
            if (CommandList[0] == COMMAND_ENUM.TAKE_OFF_PAJAMAS)
            {
                IssuedCommandList.Add(COMMAND_ENUM.FAIL);
                isValid = true;
            }

            return isValid;
        }

        virtual protected bool ValidateFootwear()
        {
            bool isValid = false;
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

        virtual protected bool ValidateHeadwear()
        {
            bool isValid = false;
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

        virtual protected bool ValidateSocks()
        {   
            IssuedCommandList.Add(COMMAND_ENUM.PUT_ON_SOCKS);
            return true;
        }

        virtual protected bool ValidateShirt()
        {
            IssuedCommandList.Add(COMMAND_ENUM.PUT_ON_SHIRT);
            return true;
        }

        virtual protected bool ValidateJacket()
        {
            bool isValid = false;
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

        virtual protected bool ValidatePants()
        {
            IssuedCommandList.Add(COMMAND_ENUM.PUT_ON_SHIRT);
            return true;
        }
    }
}
