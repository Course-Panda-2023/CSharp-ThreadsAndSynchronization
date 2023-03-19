using ParallelConsoleLogging;

PrinterAChar printer = new PrinterAChar();

// Instantiate a Config object and get its command keys
Config config = new Config();
var commandKeys = config.Commands.Keys.ToList();

// Print the command keys to the console with their index
for (int i = 0; i < commandKeys.Count; i++)
{
    Console.WriteLine($"{i + 1}. {commandKeys[i]}");
}

// Read user input and execute the corresponding command
string? userInput = Console.ReadLine()?.Trim();
if (!string.IsNullOrEmpty(userInput))
{
    Command command = config.GetCommand(userInput);
    command.Execute(printer);
}

Console.ReadLine();