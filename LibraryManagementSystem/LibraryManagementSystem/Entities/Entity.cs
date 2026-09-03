namespace LibraryManagementSystem.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        private string GetValidStringInput(string message)
        {
            string? input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();
                Console.WriteLine("Input cannot be empty. Please try again.");
            } while (true);
        }

    }
}
