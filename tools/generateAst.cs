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

      defineAst(outputDir, "Expr", new List<string>(){
     "Binary   : Expr left, Token operator, Expr right",
     "Grouping : Expr expression",
     "Literal  : Object value",
     "Unary    : Token operator, Expr right"
     });
    }

    private static void defineAst(
      string outputDir, string baseName, List<string> types)

    {
      string path = outputDir + "/" + baseName + ".cs";
      StreamWriter writer = new StreamWriter(path);

      writer.WriteLine("using System;");
      writer.WriteLine("using System.Collections.Generic;");
      writer.WriteLine("");
      writer.WriteLine("namespace LUCI {");
      writer.WriteLine("");
      writer.WriteLine("abstract class " + baseName + " {");
      defineVisitor(writer, baseName, types);

      foreach(string type in types)
      {
        string className = type.Split(':')[0].Trim();
        string fields = type.Split(':')[1].Trim();
        defineType(writer, baseName, className, fields);
      }
      writer.WriteLine("}");
      writer.Close();

    }

    private static void defineType(
      StreamWriter writer, string baseName, string className, string fieldList)
      {
        writer.WriteLine("  static class " + className + " : " + baseName + " {");

        // Constructor
        writer.WriteLine("  " + className + "(" + fieldList + ") {");

        // Store parameters in fields.
        string[] fields = fieldList.Split(',');
        foreach (string field in fields)
        {
          string name = field.Split(' ')[1];
          writer.WriteLine("    this." + name + " = " + name + ";");
        }

        writer.WriteLine("    }");
        // Fields.

        writer.WriteLine();
        foreach (string field in fields)
        {
          writer.WriteLine("    const " + field + ";");

        }

        writer.WriteLine("  }");
        }


    private static void defineVisitor(StreamWriter writer, string baseName, List<string> types)
    {
      writer.WriteLine("  interface Visitor<R> {");

      foreach (string type in types)
      {
        string typeName = type.Split(':')[0].Trim();
        writer.WriteLine("    R visit" + typeName + baseName + "(" + typeName + " " + baseName.toLowerCase() + ");");
      }

      writer.println("  }");
    }
  }
}
