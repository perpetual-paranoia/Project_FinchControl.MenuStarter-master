using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;
using HidSharp.ReportDescriptors.Units;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Mission 3
    // Description: expanding on the starter solution to fit the mission
    // Application Type: Console
    // Author: Payne, Patrick R
    // Dated Created: 9/21/2020
    // Last Modified: 10/11/2020
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

                        break;

                    case "e":

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

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
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
