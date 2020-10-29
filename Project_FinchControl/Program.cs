using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using FinchAPI;
using HidSharp.ReportDescriptors.Units;

namespace Project_FinchControl
{

    public enum Command
    {
        NONE, 
        MOVEFORWARD, 
        MOVEBACKWARD, 
        STOPMOTORS, 
        WAIT, 
        TURNRIGHT, 
        TURNLEFT, 
        LEDON, 
        LEDOFF, 
        GETTEMPERATURE, 
        DONE
    }

    // **************************************************
    //
    // Title: Mission 3
    // Description: expanding on the starter solution to fit the mission
    // Application Type: Console
    // Author: Payne, Patrick R
    // Dated Created: 9/21/2020
    // Last Modified: 10/28/2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":
                        DisplayDataRecorder(finchRobot);
                        break;

                    case "d":
                        LightAlarmDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {

            string menuChoice;
            bool quitMenu = false;

            (int motorspeed, int ledbrightness, double waitseconds) commandparameters;
            commandparameters.motorspeed = 0;
            commandparameters.ledbrightness = 0;
            commandparameters.waitseconds = 0;

            List<Command> commands = new List<Command>();

            do
            {
                DisplayScreenHeader("User Programming Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        commandparameters = userprogrammingdisplaygetcommandparameters();
                        break;

                    case "b":
                        userprogrammingdisplaygetfinchcommands(commands);
                        break;

                    case "c":
                        userprogrammingdisplayfinchcommands(commands);
                        break;

                    case "d":
                        userprogrammingdisplayexecutefinchcommands(finchRobot, commands, commandparameters);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        static void userprogrammingdisplayexecutefinchcommands(
            Finch finchRobot, 
            List<Command> commands, 
            (int motorspeed, int ledbrightness, double waitseconds) commandparameters)
        {
            int motorspeed = commandparameters.motorspeed;
            int ledbrightness = commandparameters.ledbrightness;
            int waitmilliseconds = (int)(commandparameters.waitseconds * 1000);
            string commandfeedback = "";
            const int TURNING_MOTOR_SPEED = 100;

            DisplayScreenHeader("Execute Finch Commands");

            Console.WriteLine("\tThe Finch robot is ready to execute the list of commands.");
            DisplayContinuePrompt();

            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;

                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorspeed, motorspeed);
                        commandfeedback = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorspeed, -motorspeed);
                        commandfeedback = Command.MOVEBACKWARD.ToString();
                        break;

                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        commandfeedback = Command.STOPMOTORS.ToString();
                        break;

                    case Command.WAIT:
                        finchRobot.wait(waitmilliseconds);
                        commandfeedback = Command.WAIT.ToString();
                        break;

                    case Command.TURNRIGHT:
                        finchRobot.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        commandfeedback = Command.TURNRIGHT.ToString();
                        break;

                    case Command.TURNLEFT:
                        finchRobot.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        commandfeedback = Command.TURNLEFT.ToString();
                        break;

                    case Command.LEDON:
                        finchRobot.setLED(ledbrightness, ledbrightness, ledbrightness);
                        commandfeedback = Command.LEDON.ToString();
                        break;

                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        commandfeedback = Command.LEDOFF.ToString();
                        break;

                    case Command.GETTEMPERATURE:
                        commandfeedback = $"Temperature: {finchRobot.getTemperature().ToString("n2")}\n";
                        break;

                    case Command.DONE:
                        commandfeedback = Command.DONE.ToString();
                        break;

                    default:

                        break;

                }

                Console.WriteLine($"\t{commandfeedback}");
            }

            DisplayMenuPrompt("User Programming");
        }

        static void userprogrammingdisplayfinchcommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Robot Commands");

            foreach (Command command in commands)
            {
                Console.WriteLine($"\t{command}");
            }

            DisplayMenuPrompt("User Programming");
        }

        static void userprogrammingdisplaygetfinchcommands(List<Command> commands)
        {
            Command command = Command.NONE;

            DisplayScreenHeader("Finch Robot Commands");

            int commandcount = 1;
            Console.WriteLine("\tList of Available Commands");
            Console.WriteLine();
            Console.WriteLine("\t-");
            foreach (string commandname in Enum.GetNames(typeof(Command)))
            {
                Console.WriteLine($"- {commandname.ToLower()}  -");
                if (commandcount % 5 == 0) Console.Write("-\n\t-");
                commandcount++;
            }
            Console.WriteLine();

            while (command != Command.DONE)
            {
                Console.Write("\tEnter Command:");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine("\t\t********************************************");
                    Console.WriteLine("\t\tPlease enter a command from the list above.");
                    Console.WriteLine("\t\t********************************************");
                }
            }

            DisplayMenuPrompt("User Programming");
        }


        static (int motorspeed, int ledbrightness, double waitseconds) userprogrammingdisplaygetcommandparameters()
        {
            DisplayScreenHeader("Command Parameters");

            (int motorspeed, int ledbrightness, double waitseconds) commandparameters;
            commandparameters.motorspeed = 0;
            commandparameters.ledbrightness = 0;
            commandparameters.waitseconds = 0;

            GetValidInteger("\tEnter Motor Speed [1 - 255]:", 1, 255, out commandparameters.motorspeed);
            GetValidInteger("\tEnter LED Brightness [1 - 255]:", 1, 255, out commandparameters.ledbrightness);
            GetValidDouble("\tEnter Wait in Seconds:", 0, 10, out commandparameters.waitseconds);

            Console.WriteLine();
            Console.WriteLine($"Motor Speed: {commandparameters.motorspeed}");
            Console.WriteLine($"LED Brightness: {commandparameters.ledbrightness}");
            Console.WriteLine($"Wait command duration {commandparameters.waitseconds}");

            DisplayMenuPrompt("User Programming");

            return commandparameters;
        }

        static void GetValidDouble(string v1, int v2, int v3, out double waitseconds)
        {
            
        }

        static void GetValidInteger(string v1, int v2, int v3, out int motorspeed)
        {
            
        }


        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        /// 

        #region ALARM SYSTEM
        static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdvalue = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Light Alarm Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sonsors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Maximum/Minimum Threshold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor();
                        break;

                    case "b":
                        rangeType = LightAlarmDisplaySetRangeType();
                        break;

                    case "c":
                        minMaxThresholdvalue = lightalarmsetminmaxthresholdvalue(rangeType, finchRobot);
                        break;

                    case "d":
                        timeToMonitor = lightalarmsetTimeToMonitor();
                        break;

                    case "e":
                        LightAlarmSetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdvalue, timeToMonitor);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        static void LightAlarmSetAlarm(
            Finch finchRobot, 
            string sensorsToMonitor, 
            string rangeType, 
            int minMaxThresholdvalue, 
            int timeToMonitor)
        {
            int secondselapsed = 0;
            bool thresholdexceeded = false;
            int currentlightsensorvalue = 0;

            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"\tSensors to monitor: {sensorsToMonitor}");
            Console.WriteLine($"\tRange type: {rangeType}");
            Console.WriteLine($"\tMin/max threshold: {minMaxThresholdvalue}");
            Console.WriteLine($"\tTime to monitor: {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("\tPress any key to begin monitoring.");
            Console.ReadKey();
            Console.WriteLine();

            while ((secondselapsed < timeToMonitor) && !thresholdexceeded)
            {
                switch (sensorsToMonitor)
                {
                    case "left":
                        currentlightsensorvalue = finchRobot.getLeftLightSensor();
                        break;

                    case "right":
                        currentlightsensorvalue = finchRobot.getRightLightSensor();
                        break;

                    case "both":
                        currentlightsensorvalue = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor()) / 2;
                        break;
                }

                switch (rangeType)
                {
                    case "minimum":
                        if (currentlightsensorvalue < minMaxThresholdvalue)
                        {
                            thresholdexceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentlightsensorvalue > minMaxThresholdvalue)
                        {
                            thresholdexceeded = true;
                        }
                        break;
                }

                finchRobot.wait(1000);
                secondselapsed++;

            }

            if (thresholdexceeded)
            {
                Console.WriteLine($"\tThe {rangeType} value of {minMaxThresholdvalue} was exceeded by the current light sensor value of {currentlightsensorvalue}.");
            }
            else
            {
                Console.WriteLine($"\tThe {rangeType} value of {minMaxThresholdvalue} was not exceeded.");
            }

            DisplayMenuPrompt("Light Alarm Menu");

        }

        static int lightalarmsetTimeToMonitor()
        {
            int timetomonitor;
            bool validresponse;

            DisplayScreenHeader("Time to Monitor");



            do
            {
                validresponse = true;

                Console.Write($"\tTime to monitor:");
                int.TryParse(Console.ReadLine(), out timetomonitor);

                if (timetomonitor < 0)
                {
                    validresponse = false;

                    Console.WriteLine("\tPlease enter a valid time amount.");
                    Console.WriteLine();

                }

            } while (!validresponse);


            Console.WriteLine($"\tThe time to monitor is {timetomonitor}");
            Console.WriteLine();


            DisplayMenuPrompt("Light Alarm Menu");

            return timetomonitor;
        }

        static int lightalarmsetminmaxthresholdvalue(string rangeType, Finch finchRobot)
        {
            int minMaxThresholdvalue;
            bool validresponse;

            DisplayScreenHeader("Minimum/Maximum Threshold Value");

            Console.WriteLine($"\tLeft light sensor ambient value: {finchRobot.getLeftLightSensor()}");
            Console.WriteLine($"\tRight light sensor ambient value: {finchRobot.getRightLightSensor()}");
            Console.WriteLine();

            do
            {
                validresponse = true;

                Console.Write($"\tEnter the {rangeType} light sensor value:");
                int.TryParse(Console.ReadLine(), out minMaxThresholdvalue);

                if (minMaxThresholdvalue < 0 && minMaxThresholdvalue > 255)
                {
                    validresponse = false;

                    Console.WriteLine("Please enter a value between 1 and 255.");
                    Console.WriteLine();

                }

            } while (!validresponse);


            Console.WriteLine("\t" + rangeType + " threshold value is " + minMaxThresholdvalue + ".");
            Console.WriteLine();


            DisplayMenuPrompt("Light Alarm Menu");

            return minMaxThresholdvalue;
        }

        static string LightAlarmDisplaySetSensorsToMonitor()
        {
            string sensorstomonitor;
            bool validresponse;

            DisplayScreenHeader("Sonsors to Monitor");

            do
            {

                validresponse = true;

                Console.Write("\tSensors to Monitor [Left, Right, Both]:");
                sensorstomonitor = Console.ReadLine().ToLower();

                if (sensorstomonitor != "left" && sensorstomonitor != "right" && sensorstomonitor != "both")
                {
                    validresponse = false;

                    Console.WriteLine();
                    Console.WriteLine("\tIt looks Like you might not have put in a valid answer, please try again.");
                }

            } while (!validresponse);

            if (sensorstomonitor == "left" || sensorstomonitor == "right")
            {
                Console.WriteLine("\tThe sensor to monitor is the " + sensorstomonitor + " one.");
            }
            else if (sensorstomonitor == "both")
            {
                Console.WriteLine("\tBoth of the sensors will be monitored.");
            }

            DisplayMenuPrompt("Light Alarm Menu");

            return sensorstomonitor;
        }

        static string LightAlarmDisplaySetRangeType()
        {
            string sensorrangetype;
            bool validresponse;

            DisplayScreenHeader("Range Type");


            do
            {

                validresponse = true;

                Console.Write("\tRange Type [Minimum or Maximum]:");
                sensorrangetype = Console.ReadLine().ToLower();

                if (sensorrangetype != "minimum" && sensorrangetype != "maximum")
                {

                    validresponse = false;

                    Console.WriteLine();
                    Console.WriteLine("\tIt looks Like you might not have put in a valid answer, please try again.");

                }

            } while (!validresponse);

            if (sensorrangetype == "minimum" || sensorrangetype == "maximum")
            {
                Console.WriteLine("\tThe sensor range type will be " + sensorrangetype + ".");
            }


            DisplayMenuPrompt("Light Alarm Menu");

            return sensorrangetype;
        }
        #endregion

        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) New Light and Sound");
                Console.WriteLine("\tc) Dance");
                Console.WriteLine("\td) Mixing It Up");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayNewLightAndSound(myFinch);
                        break;

                    case "c":
                        DisplayDance(myFinch);
                        break;

                    case "d":
                        DisplayMixingItUp(myFinch);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        static void megalovania(Finch finchRobot)
        {
            int note_one = 144;
            int note_two = 288;

            finchRobot.noteOn(294);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(294);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(440);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_two);
            finchRobot.noteOn(415);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(392);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(294);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(329);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(262);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(262);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(440);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_two);
            finchRobot.noteOn(415);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(392);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(294);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(392);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(247);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(247);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(440);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_two);
            finchRobot.noteOn(415);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(392);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(294);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(392);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(233);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(233);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(440);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_two);
            finchRobot.noteOn(415);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(392);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(294);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(392);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(294);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(294);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(440);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_two);
            finchRobot.noteOn(415);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(392);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(294);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(392);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(262);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(262);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(440);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_two);
            finchRobot.noteOn(415);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(392);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(294);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(349);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(392);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(247);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(247);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_one);
            finchRobot.noteOn(440);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
            finchRobot.wait(note_two);
            finchRobot.noteOn(415);
            finchRobot.wait(note_one);
            finchRobot.noteOff();
        }

        static void DisplayMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing It Up");

            Console.WriteLine("\tThe Finch will now preform its greatest achievement yet");
            DisplayContinuePrompt();

            megalovania(finchRobot);

            for (int yes = 0; yes < 4; yes++)
            {
                finchRobot.setLED(yes, 75, 35);
                finchRobot.setLED(55, yes, 25);
                finchRobot.setLED(25, 75, yes);
                finchRobot.setLED(0, yes, 25);
                finchRobot.setLED(yes, 75, 0);
                finchRobot.setMotors(-255, 255);
                finchRobot.wait(1000);
                finchRobot.setMotors(255, -255);
                finchRobot.wait(1000);
                finchRobot.setMotors(0, 0);
            }


            DisplayMenuPrompt("Talent Show Menu");
        }

        static void DisplayDance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("\tThe Finch will now preform a little dance for you");
            DisplayContinuePrompt();

            finchRobot.setMotors(0, 225);
            finchRobot.wait(520);
            finchRobot.setMotors(225, 0);
            finchRobot.wait(2080);
            finchRobot.setMotors(-225,0);
            finchRobot.wait(1560);
            finchRobot.setMotors(-225, 225);
            finchRobot.wait(1040);
            finchRobot.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }

        static void DisplayNewLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("New Light and Sound");

            Console.WriteLine("\tThe Finch will now show it's new and improved glowing talent");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, 0, 0);
                finchRobot.setLED(0, lightSoundLevel, 0);
                finchRobot.setLED(0, 0, lightSoundLevel);
                finchRobot.setLED(0, lightSoundLevel, 0);
                finchRobot.setLED(lightSoundLevel, 0, 0);
                finchRobot.noteOn(lightSoundLevel * 120);
            }

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }

            DisplayMenuPrompt("Talent Show Menu");
        }

        static void DisplayDataRecorder(Finch finchrobot)
        {
            int numberofdatapoints = 0;
            double datapointfrequency = 0;
            double[] temperatures = null;

            {
                Console.CursorVisible = true;

                bool quitMenu = false;
                string menuChoice;

                do
                {
                    DisplayScreenHeader("Data Recorder Menu");

                    //
                    // get user menu choice
                    //
                    Console.WriteLine("\ta) Number of Data Points");
                    Console.WriteLine("\tb) Frequency of Data Points");
                    Console.WriteLine("\tc) Get Data");
                    Console.WriteLine("\td) Show Data");
                    Console.WriteLine("\tq) Main Menu");
                    Console.Write("\t\tEnter Choice:");
                    menuChoice = Console.ReadLine().ToLower();

                    //
                    // process user menu choice
                    //
                    switch (menuChoice)
                    {
                        case "a":
                            numberofdatapoints = DataRecorderDisplayGetNumberofDataPoints();
                            break;

                        case "b":
                            datapointfrequency = DataRecorderDisplayGetDataPointFrequency();
                            break;

                        case "c":
                            temperatures = DataRecorderDisplayGetData(numberofdatapoints, datapointfrequency, finchrobot);
                            break;

                        case "d":
                            DataRecorderDisplayData(temperatures);
                            break;

                        case "q":
                            quitMenu = true;
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter a letter for the menu choice.");
                            DisplayContinuePrompt();
                            break;
                    }

                } while (!quitMenu);
            }
        }

        static void DataRecorderDisplayData(double[] temperatures)
        {

            DataRecorderDisplayTable(temperatures);

            DisplayContinuePrompt();
        }

        static void DataRecorderDisplayTable(double[] temperatures)
        {
            DisplayScreenHeader("Show Data");

            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temp".PadLeft(15)
                );
            Console.WriteLine(
                "-----------".PadLeft(15) +
                "-----------".PadLeft(15)
                );

            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                    (index + 1).ToString().PadLeft(15) +
                    temperatures[index].ToString("n2").PadLeft(15)
                    );
            }
        }

        static double[] DataRecorderDisplayGetData(int numberofdatapoints, double datapointfrequency, Finch finchrobot)
        {
            double[] temperatures = new double[numberofdatapoints];

            DisplayScreenHeader("Get Data");

            Console.WriteLine($"\tNumber of Data Points: {numberofdatapoints}");
            Console.WriteLine($"\tData Point Frequency: {datapointfrequency}");
            Console.WriteLine();
            Console.WriteLine("\tThe Finch robot is ready to begin recording the temperature data.");
            DisplayContinuePrompt();

            for (int index = 0; index < numberofdatapoints; index++)
            {
                temperatures[index] = finchrobot.getTemperature();
                Console.WriteLine($"\tReading {index + 1}: {temperatures[index].ToString("n2")}");
                int waitinseconds = (int)(datapointfrequency * 1000);
                finchrobot.wait(waitinseconds);
            }

            DisplayContinuePrompt();

            return temperatures;
        }

        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double datapointfrequency;
            bool validresponse;

            DisplayScreenHeader("Data Point Frequency");

            do
            {
                validresponse = true;
                Console.Write("\tData Point Frequency: ");
                datapointfrequency = double.Parse(Console.ReadLine());

                if (datapointfrequency < 0)
                {
                    validresponse = false;

                    Console.WriteLine();
                    Console.WriteLine("Please input a valid data point frequency.");

                }

            } while (!validresponse);


            DisplayContinuePrompt();

            return datapointfrequency;
        }

        static int DataRecorderDisplayGetNumberofDataPoints()
        {
            int numberofdatapoints;
            bool validresponse;

            DisplayScreenHeader("Number of Data Points");

            do
            {
                validresponse = true;
                Console.Write("\tNumber of Data Points: ");
                numberofdatapoints = int.Parse(Console.ReadLine());

                if (numberofdatapoints < 1)
                {
                    validresponse = false;

                    Console.WriteLine();
                    Console.WriteLine("Please input a valid number of data points.");

                }

            } while (!validresponse);


            DisplayContinuePrompt();

            return numberofdatapoints;
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
