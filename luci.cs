using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
/// <summary>
///   The main entry point for the application
/// </summary>

namespace LUCI {

  public static class luci
  {

    static bool hadError = false;

    public static void Main(string[] args)
    {

      if (args.Length > 1)
      {
        Console.WriteLine("Usage: luci [script]");
      }
      else if (args.Length == 1)
      {
        if(args[0].EndsWith(".be"))
        {
          runFile(args[0]);
        }
        else
        {
          Console.WriteLine("Please provide a Bealzebulb script");
        }
      }
      else
      {
        runPrompt();
      }
    }

    public static void test() => Console.WriteLine("The push has worked!");

    public static void runFile(string path)
    {
      byte[] bytes = File.ReadAllBytes(path);
      run(Encoding.UTF8.GetString(bytes, 0, bytes.Length));

      if (hadError) {Environment.Exit(1);}
    }

    public static void runPrompt()
    {
      while(true)
      {
        Console.Write("> ");
        run(Console.ReadLine());
        hadError = false;
      }
    }

    public static void run(string source)
    {
      Scanner scanner = new Scanner(source);
      List<Token> tokens = scanner.scanTokens();

      foreach(Token token in tokens)
      {
        Console.WriteLine(token.toString());
      }
    }

    public static void error(int line, string message)
    {
      report(line, "", message);
    }

    private static void report(int line, string where, string message)
    {
      Console.WriteLine("[line " + line + "] Error " + where + ": " + message);
      hadError = true;
      //throw new System.Exception("[line " + line + "] Error" + where + ": " + message);
    }

  }
}
