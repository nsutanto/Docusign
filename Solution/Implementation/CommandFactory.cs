using System;
using System.Collections.Generic;

namespace Solution
{
    internal class CommandFactory
    {
        private const string HOT_STR = "HOT";
        private const string COLD_STR = "COLD";

        private static CommandFactory instance;

        private CommandFactory() { }

        internal static CommandFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommandFactory();
                }
                return instance;
            }
        }
             
        internal DressCommand CreateDressCommand(string commandListString)
        {
            DressCommand dressCommand = null;

            WEATHER_ENUM weather = getWeather(commandListString);
            List<COMMAND_ENUM> commandList = createCommandList(commandListString);

            if (weather == WEATHER_ENUM.HOT)
            {
                // Create hot string converter
                HotEnumToStringConverter hotEnumStringConverter = new HotEnumToStringConverter();
                // Create hot dress command
                dressCommand = new HotDressCommand(commandList, hotEnumStringConverter);    
            }
            else if (weather == WEATHER_ENUM.COLD)
            {
                // Create cold string converter
                ColdEnumToStringConverter coldEnumStringConverter = new ColdEnumToStringConverter();
                // Create cold dress command
                dressCommand = new ColdDressCommand(commandList, coldEnumStringConverter);
            }
            else
            {
                // Do nothing
            }
            return dressCommand;
        }

        // Check weather, if it is hot or cold.
        private WEATHER_ENUM getWeather(string commandListString)
        {
            string[] splitCommand = commandListString.Split(' ');
            string weather = splitCommand[0].ToUpper();

            if (weather == HOT_STR)
            {
                return WEATHER_ENUM.HOT;
            }
            else if (weather == COLD_STR)
            {
                return WEATHER_ENUM.COLD;    
            }
            else
            {
                return WEATHER_ENUM.INVALID_WEATHER;
            }
        }

        // Convert string to list of command_enum
        private List<COMMAND_ENUM> createCommandList(string commandListString)
        {
            // Get the first index of white space to get the substring of commands (remove HOT or COLD)
            int indexFirstSpace = commandListString.IndexOf(' ');
            // Get the commands (remove HOT or COLD)
            string commands = commandListString.Substring(indexFirstSpace + 1);
            // Trim white space
            commands = commands.Replace(" ", string.Empty);
            // Split from comma to create array of commands
            string[] commandArray = commands.Split(',');

            List<COMMAND_ENUM> commandList = new List<COMMAND_ENUM>();

            foreach (string command in commandArray)
            {
                switch (command)
                {
                    case "1":
                        commandList.Add(COMMAND_ENUM.PUT_ON_FOOTWEAR);
                        break;
                    case "2":
                        commandList.Add(COMMAND_ENUM.PUT_ON_HEADWEAR);
                        break;
                    case "3":
                        commandList.Add(COMMAND_ENUM.PUT_ON_SOCKS);
                        break;
                    case "4":
                        commandList.Add(COMMAND_ENUM.PUT_ON_SHIRT);
                        break;
                    case "5":
                        commandList.Add(COMMAND_ENUM.PUT_ON_JACKET);
                        break;
                    case "6":
                        commandList.Add(COMMAND_ENUM.PUT_ON_PANTS);
                        break;
                    case "7":
                        commandList.Add(COMMAND_ENUM.LEAVE_HOUSE);
                        break;
                    case "8":
                        commandList.Add(COMMAND_ENUM.TAKE_OFF_PAJAMAS);
                        break;
                    default:
                        break;                
                }
            }

            return commandList;

        }
    }
}
