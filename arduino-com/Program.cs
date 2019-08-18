using System;
using System.IO.Ports;

namespace arduino_com
{
    class Program
    {
        private static bool _loop = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            Console.WriteLine("Send 'E' to Exit");

            while (_loop)
            {
                Console.WriteLine("Enter string");
                var input = Console.ReadLine();
                SendCommand(input);
            }
        }

        /// <summary>
        /// Sends a command to arduino
        /// </summary>
        /// <param name="input"></param>
        private static void SendCommand(string input)
        {
            try
            {

                if (!string.IsNullOrEmpty(input))
                {
                    if (input.ToLower() == "e")
                    {
                        Environment.Exit(0);
                    }

                    var serialPort = new SerialPort { PortName = "COM8", BaudRate = 9600 };
                    Console.WriteLine($"COM PORT: {serialPort.PortName} BaudRate: {serialPort.BaudRate}");
                    serialPort.Open();
                    serialPort.WriteLine($"{input}\n");
                    Console.WriteLine($"Received: {serialPort.ReadLine()}");
                    serialPort.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
