using PasswordHasher;
using System.Text;
using TextCopy;

ConsoleKeyInfo keyInfo;

var passSb = new StringBuilder();
Console.Write("Type the password: ");

do
{
    keyInfo = Console.ReadKey(true);

    if (keyInfo.Key == ConsoleKey.Backspace && passSb.Length > 0)
    {
        Console.Write("\b \b");
        passSb.Remove(passSb.Length - 1, 1);
    }
    else if (!char.IsControl(keyInfo.KeyChar) && char.IsAscii(keyInfo.KeyChar))
    {
        passSb.Append(keyInfo.KeyChar);
        Console.Write('*');
    }
} while (keyInfo.Key != ConsoleKey.Enter);
Console.Write('\n');


var saltSb = new StringBuilder();
Console.Write("Type Salt (leave blank to default): ");

do
{
    keyInfo = Console.ReadKey(true);

    if (keyInfo.Key == ConsoleKey.Backspace && saltSb.Length > 0)
    {
        Console.Write("\b \b");
        saltSb.Remove(saltSb.Length - 1, 1);
    }
    else if (!char.IsControl(keyInfo.KeyChar) && char.IsAscii(keyInfo.KeyChar))
    {
        saltSb.Append(keyInfo.KeyChar);
        Console.Write('*');
    }
} while (keyInfo.Key != ConsoleKey.Enter);
Console.Write('\n');


var hashed = PBKDF2.GeneratePasswordHash(passSb.ToString(), 
    saltSb.Length == 0 ? "ZLww18fZEObdjY5yw1Zs" : saltSb.ToString());  // default salt -> ZLww18fZEObdjY5yw1Zs
var cb = new Clipboard();
await cb.SetTextAsync(hashed);
Console.WriteLine("Hashed password copied to the clipboard.");

var remain = 10; // clipboard's lifetime

for (var i = 0; i < remain; i++)
{
    Console.WriteLine($"Remain time: {remain - i}s");
    await Task.Delay(1000);
    ConsoleHelper.RemoveLastLine();
}

await cb.SetTextAsync("");
Console.WriteLine("Clipboard cleared.");