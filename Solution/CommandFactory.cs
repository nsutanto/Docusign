﻿using System;
using System.Collections.Generic;

namespace Solution
{
    public class CommandFactory : ICommandFactory
    {
        private static CommandFactory instance;

        private CommandFactory() { }

        public static CommandFactory Instance
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

     
        public IDressCommand CreateDressCommand(string commandListString)
        {
            IDressCommand dressCommand = null;

            WEATHER_ENUM weather = getWeather(commandListString);

            if (weather == WEATHER_ENUM.HOT)
            {
                //dressCommand = new HotDressCommand()
            }
            else if (weather == WEATHER_ENUM.COLD)
            {
                //dressCommand = new ColdDressCommand();
            }
            else
            {
                // Do nothing
            }
            return dressCommand;
        }

        private WEATHER_ENUM getWeather(string commandListString)
        {
            string[] splitCommand = commandListString.Split(' ');

            if (splitCommand[0].ToUpper() == "HOT")
            {
                return WEATHER_ENUM.HOT;
            }
            else if (splitCommand[1].ToUpper() == "COLD")
            {
                return WEATHER_ENUM.COLD;    
            }
            else
            {
                return WEATHER_ENUM.INVALID_WEATHER;
            }
        }

        private List<COMMAND_ENUM> createCommandList(string commandListString)
        {
            string[] splitCommand = commandListString.Split(' ');
            string commands = splitCommand[1];

            string[] commandArray = commands.Trim().Split(',');

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