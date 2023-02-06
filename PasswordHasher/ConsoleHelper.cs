using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHasher;

internal static class ConsoleHelper
{
    internal static void RemoveLastLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, Console.CursorTop);
    }
}
