using System;

class TotalResistanceCalculator
{
    static void Main()
    {
        bool continueCalculation;
        do
        {
            Console.WriteLine("Total Resistance Calculator for a Group of Resistors");
            Console.WriteLine("Select the connection type:");
            Console.WriteLine("1. Series Connection");
            Console.WriteLine("2. Parallel Connection");

            int connectionType;
            while (true)
            {
                Console.Write("Enter your choice (1 or 2): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out connectionType) && (connectionType == 1 || connectionType == 2))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please enter 1 or 2 only.");
                }
            }

            int resistorCount;
            while (true)
            {
                Console.Write("Enter the number of resistors to calculate: ");
                string countInput = Console.ReadLine();
                if (int.TryParse(countInput, out resistorCount) && resistorCount > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number! Please enter a positive integer.");
                }
            }

            double[] resistors = new double[resistorCount];

            for (int i = 0; i < resistorCount; i++)
            {
                while (true)
                {
                    Console.Write($"Enter the value of resistor #{i + 1} (Ohms): ");
                    string valInput = Console.ReadLine();
                    if (double.TryParse(valInput, out resistors[i]) && resistors[i] > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid value! Please enter a positive number.");
                    }
                }
            }

            double totalResistance = 0;
            if (connectionType == 1) // Series
            {
                for (int i = 0; i < resistorCount; i++)
                {
                    totalResistance += resistors[i];
                }
            }
            else // Parallel
            {
                double reciprocalSum = 0;
                for (int i = 0; i < resistorCount; i++)
                {
                    reciprocalSum += 1 / resistors[i];
                }
                totalResistance = 1 / reciprocalSum;
            }

            Console.WriteLine($"\nTotal Resistance is: {totalResistance:F2} Ohms");

            string repeat;
            do
            {
                Console.Write("Would you like to calculate another resistance? (y/n): ");
                repeat = Console.ReadLine().Trim().ToLower();
            }
            while (repeat != "y" && repeat != "n");

            continueCalculation = repeat == "y";
            Console.WriteLine();
        } while (continueCalculation);

        Console.WriteLine("Thank you for using the Total Resistance Calculator.");
    }
}