public interface IPrinter
{
    void Print(string path);
}
public class Printer : IPrinter
{

    public void Print(string path)
    {
        System.Console.WriteLine($"Printing .....{path}");
    }
}

public interface IScanner
{
    void Scan(string path);
}
public class Scanner : IScanner
{

    public void Scan(string path)
    {
        System.Console.WriteLine($"Scanning .....{path}");
    }
}

public class PrintScanner : IPrinter, IScanner
{
    public void Print(string path)
    {
        System.Console.WriteLine($"Printing from PrintScanner .....{path}");
    }

    public void Scan(string path)
    {
        System.Console.WriteLine($"Scanning from PrintScanner .....{path}");
    }
}
public static class TaskManager
{
    public static void ExecuctePrintTask(IPrinter printer, string documentPath)
    {
        printer.Print(documentPath);
    }
    public static void ExecucteScanTask(IScanner scanner, string documentPath)
    {
        scanner.Scan(documentPath);
    }
}

public class Program
{
    static void Main()
    {
        Printer printerObj = new Printer();
        Scanner scannerObj = new Scanner();
        PrintScanner printScannerObj = new PrintScanner();

        TaskManager.ExecuctePrintTask(printerObj, "Test.doc");
        TaskManager.ExecucteScanTask(scannerObj, "MyImage.png");
        TaskManager.ExecuctePrintTask(printScannerObj, "NewDoc.doc");
        TaskManager.ExecucteScanTask(printScannerObj, "YourImage.png");
    }
}
