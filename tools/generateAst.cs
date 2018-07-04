using System;
using System.Collections.Generic;
using System.IO;

namespace LUCItools
{
  public class generateAst
  {
    /// <summary>
    ///   The main entry point for the application
    /// </summary>
    public static void Main(string[] args)
    {
      if(args.Length != 1)
      {
        Console.WriteLine("Usage: generate_ast [output directory]");
        Environment.Exit(1);
      }

      string outputDir = args[0];

      defineAst(outputDir, "Expr", Arrays.asList(
     "Binary   : Expr left, Token operator, Expr right",
     "Grouping : Expr expression",
     "Literal  : Object value",
     "Unary    : Token operator, Expr right"
     ));
    }

    private static void defineAst(
      string outputDir, string baseName, List<string> types)
    )
    {
      string path = outputDir + "/" + baseName + ".cs";
      StreamWriter writer = new StreamWriter(path, "UTF-8");

    }
  }
}
