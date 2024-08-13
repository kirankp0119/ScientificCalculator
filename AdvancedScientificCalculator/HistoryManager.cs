using MySql.Data.MySqlClient;
using System;

namespace AdvancedScientificCalculator
{
    internal class HistoryManager
    {
        private readonly string _connectionString;

        public HistoryManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SaveCalculation(string calculation, string result)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO CalculationHistory (Calculation, Result) VALUES (@calculation, @result)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@calculation", calculation);
                        command.Parameters.AddWithValue("@result", result);
                        command.ExecuteNonQuery();
                    }
                }
                ManageHistoryLimit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the calculation: {ex.Message}");
            }
        }

        private void ManageHistoryLimit()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"
                        DELETE FROM CalculationHistory 
                        WHERE Id NOT IN (
                            SELECT Id FROM (
                                SELECT Id FROM CalculationHistory ORDER BY Timestamp DESC LIMIT 50
                            ) AS subquery
                        )";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while managing the history limit: {ex.Message}");
            }
        }

        public void PrintRecentCalculations()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT Calculation, Result, Timestamp FROM CalculationHistory ORDER BY Timestamp DESC";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string calculation = reader["Calculation"] as string ?? "Unknown";
                            string result = reader["Result"] as string ?? "Unknown";
                            DateTime timestamp = reader["Timestamp"] != DBNull.Value ? (DateTime)reader["Timestamp"] : DateTime.MinValue;
                            Console.WriteLine($"[{timestamp}] {calculation} = {result}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while printing recent calculations: {ex.Message}");
            }
        }
    }
}