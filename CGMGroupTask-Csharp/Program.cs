
using CGMGroupTask_Csharp.Services;

Console.WriteLine("Hello, World!");


MainService mainService = new MainService();

while (true)
{
    Console.WriteLine("\n");
    Console.WriteLine("Choose an option: \n1. Ask a question\n2. Add a question");
    string choice = Console.ReadLine().Trim();

    if (choice == "1")
    {
        Console.WriteLine("Enter your question:");
        string question = Console.ReadLine().Trim();
        mainService.GetQuestion(question);
    }
    else if (choice == "2")
    {
        Console.WriteLine("Enter your question and answers (e.g., What is Peters favorite food? \"Pizza\" \"Spaghetti\"):");
        string input = Console.ReadLine().Trim();
        mainService.AddQuestion(input);
    }
    else
    {
        Console.WriteLine("Invalid option. Please select 1 or 2.");
    }
}