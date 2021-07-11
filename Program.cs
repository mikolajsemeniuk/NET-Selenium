namespace sel
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();

            startup
                .LaunchWebsite()
                .SearchProducts()
                .Delay(3000)
                .QuitDriver();
        }
    }
}
