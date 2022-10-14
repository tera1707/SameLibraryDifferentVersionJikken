using ClassLibraryInterface;
using System.Reflection;

namespace SameLibraryDifferentVersionJikken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter..");
            Console.WriteLine("0:LogWriter1   1:LogWriter2");
            var kind = Console.ReadLine();

            var myAssembly = Assembly.GetEntryAssembly();
            var exeDir = Path.GetDirectoryName(myAssembly?.Location) ?? "";
#if DEBUG
            var config = "Debug";
#else
            var config = "Release";
#endif
            if (kind == "0")
            {
                var libDir = Path.Combine(exeDir, "lib1", "x64", config);
                var libPath = Path.Combine(libDir, "ClassLibrary1.dll");
                var asm = Assembly.LoadFrom(libPath);
                var obj = asm?.CreateInstance("ClassLibrary1.LogWriter1") as ILogWriter1;
                obj?.Write("AAAA");
            }
            else
            {
                var libDir = Path.Combine(exeDir, "lib2", "x64", config);
                var libPath = Path.Combine(libDir, "ClassLibrary2.dll");
                var asm = Assembly.LoadFrom(libPath);
                var obj = asm?.CreateInstance("ClassLibrary2.LogWriter2") as ILogWriter2;
                obj?.Write("BBBB");
            }
        }
    }
}