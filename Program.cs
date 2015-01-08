using PreMailer.Net;
using System;
using System.IO;

namespace CssInline
{
    /// <summary>
    /// Simple program to provide console access to the PreMailer inlining tool
    /// </summary>
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 2 || args.Length > 3) {
                Console.WriteLine("CssInline input output <ignore>");
                return -1;
            }

            string ignoreElements = args.Length == 3 ? args[2] : null;
            string html = File.ReadAllText(args[0]);

            InlineResult result = PreMailer.Net.PreMailer.MoveCssInline(html, false, ignoreElements);

            File.WriteAllText(args[1], result.Html);
            
            if (result.Warnings.Count == 0) {
                Console.WriteLine("Success");
            }
            else {
                Console.WriteLine("The operation completed but with warnings");
                foreach (string warning in result.Warnings) {
                    Console.WriteLine(warning);
                }
            }

            return 0;
        }
    }
}
