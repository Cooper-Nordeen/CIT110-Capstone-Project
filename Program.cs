using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinchAPI;

namespace CapstoneCode
{
    class Program
    {
        enum Sensor
        {
            Temperature,
            Light,
            Oxygen,
            Humidity,
            Nutrient,
            Co2,
        }

        static void Main(string[] args)
        {
            Finch Donnie = new Finch();

            DisplayWelcomeScreen();
            DisplayConnectFinch(Donnie);
            DisplayMonitorLevels(Donnie);
            DisplayClosingScreen(Donnie);

        }

        static string DisplayGetEmailUsername()
        {
            string userAdress;

            Console.Clear();
            DisplayHeader("Gathering Info");
            Console.Write("Please enter your email Adress:");
            userAdress = Console.ReadLine();
            DisplayContinuePrompt();
            return userAdress;
        }

        static void DisplayMonitorLevels(Finch Donnie)
        {
            string userResponse = null;
            bool exiting = false;
            double desiredTemp = 0;
            double currentTemp = 0;
            double desiredLight = 0;
            double currentLight = 0;
            double desiredOxygen = 0;
            double currentOxygen = 0;
            double desiredHumidity = 0;
            double currentHumidity = 0;
            double desiredNutrients = 0;
            double currentNutrients = 0;
            double desiredCO2 = 0;
            double currentCO2 = 0;

            DisplayHeader("\t\tInstructions menu");

            Console.WriteLine();
            Console.WriteLine("\tWhich sensors would you like to use?");
            Console.WriteLine();
            Console.WriteLine("Type yes for each sensor that you would like to use.");
            Console.WriteLine();

            List<Sensor> sensors = new List<Sensor>();

            foreach (Sensor sensor in Enum.GetValues(typeof(Sensor)))
            {
                Console.WriteLine($"{sensor}");
                if (Console.ReadLine().ToUpper() == "YES")
                {
                    sensors.Add(sensor);
                }
            }

            foreach (Sensor sensor in sensors)
            {
                switch (sensor)
                {
                    case Sensor.Temperature:
                        desiredTemp = DisplayGetDesiredTemperature();
                        break;
                    case Sensor.Light:
                        desiredLight = DisplayGetDesiredLightLevel();
                        break;
                    case Sensor.Oxygen:
                        desiredOxygen = DisplayGetDesiredOxygenLevel();
                        break;
                    case Sensor.Humidity:
                        desiredHumidity = DisplayGetDesiredHumidity();
                        break;
                    case Sensor.Nutrient:
                        desiredNutrients = DisplayGetDesiredNutrients();
                        break;
                    case Sensor.Co2:
                        desiredCO2 = DisplayGetDesiredCO2();
                        break;
                    default:
                        break;
                }

            }

            while (!exiting)
            {
                Donnie.wait(5000);
                Console.Clear();
                //Console.WriteLine("press Q to exit");
                //userResponse = Console.ReadLine().ToUpper();
                if (userResponse == "Q")
                {
                    exiting = true;
                }
                else
                {

                    foreach (Sensor sensor in sensors)
                    {

                        switch (sensor)
                        {
                            case Sensor.Temperature:
                                currentTemp = DisplayGetCurrentTemperature(Donnie);
                                break;
                            case Sensor.Light:
                                currentLight = DisplayGetLightLevel(Donnie);
                                break;
                            case Sensor.Oxygen:
                                currentOxygen = DisplayGetCurrentOxygenLevel(Donnie);
                                break;
                            case Sensor.Humidity:
                                currentHumidity = DisplayGetCurrentHumidity(Donnie);
                                break;
                            case Sensor.Nutrient:
                                currentNutrients = DisplayGetCurrentNutrientLevel(Donnie);
                                break;
                            case Sensor.Co2:
                                currentCO2 = DisplayGetCurrentCO2Level(Donnie);
                                break;
                            default:
                                break;
                        }

                    }

                    foreach (Sensor sensor in sensors)
                    {
                        switch (sensor)
                        {
                            case Sensor.Temperature:
                                Console.WriteLine($"Desired Temp:{desiredTemp}");
                                Console.WriteLine($"Currrent Temp:{currentTemp}");
                                break;
                            case Sensor.Light:
                                Console.WriteLine($"Desired Light:{desiredLight}");
                                Console.WriteLine($"Currrent Light:{currentLight}");
                                break;
                            case Sensor.Oxygen:
                                Console.WriteLine($"Desired Oxygen:{desiredOxygen}");
                                Console.WriteLine($"Currrent Oxygen:To Be Implimented");
                                break;
                            case Sensor.Humidity:
                                Console.WriteLine($"Desired Humidity:{desiredHumidity}");
                                Console.WriteLine($"Currrent Humidity:To Be Implimented");
                                break;
                            case Sensor.Nutrient:
                                Console.WriteLine($"Desired Nutrients:{desiredHumidity}");
                                Console.WriteLine($"Currrent Nutrients:To Be Implimented");
                                break;
                            case Sensor.Co2:
                                Console.WriteLine($"Desired CO2:{desiredCO2}");
                                Console.WriteLine($"Currrent CO2:To Be Implimented");
                                break;
                            default:
                                break;


                        }

                    }
                }
            }
            Console.WriteLine("Press Enter to exit monitoring");
            Console.ReadLine();

            DisplayClosingScreen(Donnie);
        }

        static double DisplayGetCurrentCO2Level(Finch donnie)
        {
            double currentCO2;

            //currentCO2 = donnie.getTemperature();
            currentCO2 = 0;
            return currentCO2;
        }

        static double DisplayGetCurrentNutrientLevel(Finch donnie)
        {
            double currentNutrients;

            //currentNutrients = donnie.getTemperature();
            currentNutrients = 0;
            return currentNutrients;
        }

        static double DisplayGetCurrentHumidity(Finch donnie)
        {
            double currentHumidity;

            //currentHumidity = donnie.getTemperature
            currentHumidity = 0;
            return currentHumidity;
        }

        static double DisplayGetCurrentOxygenLevel(Finch donnie)
        {
            double currentOxygen;

            //currentOxygen = donnie.getTemperature();
            currentOxygen = 0;
            return currentOxygen;
        }

        static double DisplayGetDesiredCO2()
        {
            double desiredCO2;
            string userResponse;
            bool validLevel = false;

            DisplayHeader("Desired CO2");

            do
            {
                Console.Write("What would you like the CO2 level to be set at?");
                userResponse = Console.ReadLine();
                double.TryParse(userResponse, out desiredCO2);
                if (desiredCO2 < 2000 && desiredCO2 > 0)
                {
                    validLevel = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid CO2 level");
                }
            } while (!validLevel);

            return desiredCO2;
        }

        static double DisplayGetDesiredNutrients()
        {
            double desirednutrients;
            string userResponse;
            bool validLevel = false;

            DisplayHeader("Desired Nutrients");

            do
            {
                Console.Write("What would you like the Nutrient Level to be set at?");
                userResponse = Console.ReadLine();
                double.TryParse(userResponse, out desirednutrients);
                if (desirednutrients < 2000 && desirednutrients > 0)
                {
                    validLevel = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid Nutrient level");
                }
            } while (!validLevel);

            return desirednutrients;
        }

        static double DisplayGetDesiredHumidity()
        {
            double desiredHumidity;
            string userResponse;
            bool validLevel = false;

            DisplayHeader("Desired Humidity");

            do
            {
                Console.Write("What would you like the humidity to be set at?");
                userResponse = Console.ReadLine();
                double.TryParse(userResponse, out desiredHumidity);
                if (desiredHumidity < 101 && desiredHumidity > 0)
                {
                    validLevel = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid humidity level");
                }
            } while (!validLevel);

            return desiredHumidity;
        }

        static double DisplayGetDesiredOxygenLevel()
        {
            double desiredOxygenLevel;
            string userResponse;
            bool validLevel = false;

            DisplayHeader("Desired Oxygen");

            do
            {
                Console.Write("What would you like the Oxygen to be set at?");
                userResponse = Console.ReadLine();
                double.TryParse(userResponse, out desiredOxygenLevel);
                if (desiredOxygenLevel < 2000 && desiredOxygenLevel > 0)
                {
                    validLevel = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid Oxygen level");
                }
            } while (!validLevel);

            return desiredOxygenLevel;
        }

        static double DisplayGetLightLevel(Finch donnie)
        {
            double currentLightLevel;

            currentLightLevel = (donnie.getLeftLightSensor() + donnie.getRightLightSensor()) / 2;
            return currentLightLevel;
        }

        static double DisplayGetDesiredLightLevel()
        {
            double desiredLightLevel;
            string userResponse;
            bool validLevel = false;

            DisplayHeader("Desired Light Level");

            do
            {
                Console.Write("What would you like the light level to be set at?");
                userResponse = Console.ReadLine();
                double.TryParse(userResponse, out desiredLightLevel);
                if (desiredLightLevel < 2000 && desiredLightLevel > 0)
                {
                    validLevel = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid light level");
                }
            } while (!validLevel);

            return desiredLightLevel;
        }

        static double DisplayGetCurrentTemperature(Finch donnie)
        {
            double currentTempC;
            double currentTempF;

            currentTempC = donnie.getTemperature();
            currentTempF = currentTempC * (9 / 5) + 32;
            return currentTempF;
        }

        static double DisplayGetDesiredTemperature()
        {
            double desiredTemp;
            string userResponse;
            bool validTemp = false;

            DisplayHeader("Desired temperature");

            do
            {
                Console.Write("What would you like the temperature to be set at?");
                userResponse = Console.ReadLine();
                double.TryParse(userResponse, out desiredTemp);
                if (desiredTemp < 121 && desiredTemp > 0)
                {
                    validTemp = true;
                }
                else
                {
                    Console.WriteLine("Please enter a value between 0 and 120 degrees");
                }
            } while (!validTemp);

            return desiredTemp;
        }

        static void DisplayConnectFinch(Finch donnie)
        {

            DisplayHeader("Climate Control Connect");

            Finch Donnie = new Finch();
            if (donnie.connect())
            {
                Console.WriteLine("\tThe Climate Controller is now connected");
                donnie.setLED(0, 255, 0);
                DisplayContinuePrompt();
            }
            else
            {
                Console.WriteLine("\tCould not connect to the Climate Controller.");
                Console.WriteLine();
                Console.WriteLine("\tPlease exit the program and fix the connection");
                Console.ReadKey();
                DisplayClosingScreen(Donnie);
            }

        }

        static void DisplayHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"\t\t {headerText}");
            Console.WriteLine();
        }

        static string DisplayWelcomeScreen()
        {
            string userName = null;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tWelcome");
            Console.WriteLine();
            Console.Write("\tPlease enter your name:");
            userName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Hello {userName}! Im glad that you chose The Greenhouse Manager to");
            Console.WriteLine("monitor your greenhouse. The purpose of this program is ");
            Console.WriteLine("to monitor all aspects within a greenhouse that can effect");
            Console.WriteLine("the efficency of your plants growth.");

            DisplayContinuePrompt();

            return userName;
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\tPress any Key to continue");
            Console.ReadLine();
        }

        static void DisplayClosingScreen(Finch Donnie)
        {
            Console.Clear();
            Donnie.disConnect();
            Console.WriteLine();
            Console.WriteLine("\t\tGoodbye");
            Console.ReadLine();

        }

    }
}
