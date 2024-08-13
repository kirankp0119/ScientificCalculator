using System;
using AdvancedScientificCalculator; // Adjust if your namespace is different

class Program
{
    static void Main(string[] args)
    {
        // Define your MySQL connection string
        string connectionString = "Server=localhost;Port=3307;Database=CalculatorDB;User ID=root;Password=root;";

        // Create an instance of HistoryManager with the connection string
        var historyManager = new HistoryManager(connectionString);

        // Example calculations using a hypothetical AdvancedCalculator class
        var calculator = new AdvancedCalculator(); // Ensure you have this class implemented

        // Perform calculations
        double sinResult = calculator.Sin(30); // Replace with actual method if available
        double logResult = calculator.Log(100); // Replace with actual method if available

        // Save calculations to the database
        historyManager.SaveCalculation("Sin(30)", sinResult.ToString());
        historyManager.SaveCalculation("Log(100)", logResult.ToString());

        // Print recent calculations
        historyManager.PrintRecentCalculations();
    }
}
