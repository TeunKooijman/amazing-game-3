using AmazingGame3.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Pastel;
using System.Text.RegularExpressions;

namespace AmazingGame3.Cli
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await GameFactory
                .CreateInstance(new LocalConsole(new ColorParser()))
                .GetRequiredService<GameEngine>()
                .RunAsync();
        }
    }

    public class LocalConsole : IRemoteConsole
    {
        private IColorParser ColorParser { get; }

        public LocalConsole(IColorParser colorParser)
        {
            ColorParser = colorParser;
        }

        public Task ClearAsync()
        {
            Console.Clear();
            return Task.CompletedTask;
        }

        public Task<string?> ReadLineAsync()
        {
            return Task.FromResult(Console.ReadLine());
        }
        public Task WriteLineAsync(string line)
        {
            line = ColorParser.Parse(line, (line, match, text, color) => line.Replace(match, text.Pastel(color)));
            line = line.Replace("⠀", " ");
            while(true)
            {
                Match match = GameEngine.COLOR_REGEX.Match(line);
                if(match.Success == false)
                {
                    break;
                }

                Group[] groups = match.Groups.Values.ToArray();
                Group wholeElement = groups[0];
                Group openingBracket = groups[1];
                Group valueText = groups[2];
                Group closingBracket = groups[3];

                line = line.Replace(wholeElement.Value, valueText.Value.Pastel(openingBracket.Value));
            }

            Console.WriteLine(line);
            return Task.CompletedTask;
        }
    }
}