using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
public class Required : System.Attribute
{
    public string ErrorMessage { get; set; }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
public class Range: System.Attribute
{
    private ushort start;
    private ushort end;

    public Range(ushort start, ushort end)
    {
        this.start = start;
        this.end = end;
    }

    public string ErrorMessage { get; set; }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
public class MaxLength : System.Attribute
{
    private ushort maxlen;

    public MaxLength(ushort maxlen)
    {
        this.maxlen = maxlen;
    }
    public string ErrorMessage { get; set; }
}
class Device
{

    [Required(ErrorMessage = "ID Property Requires Value")]

    public string Id { get; set; }
    [Range(10, 100, ErrorMessage = "Code Value Must Be Within 10-100")]
    public int Code { get; set; }

    [MaxLength(100, ErrorMessage = "Max of 100 Charcters are allowed")]
    public string Description { get; set; }

}

class ObjectValidator
{

    public bool Validate(Device deviceobj, out List<string> errorList)
    {
        errorList = new List<string>();
        Device deviceObj = new Device();
        if (!Required(deviceObj.Id, new Required(), out string idError))
        {
            errorList.Add($"ID: {idError}");
        }

        if (!Range(deviceObj.Code, new Range(10,100), out string codeError))
        {
            errorList.Add($"Code: {codeError}");
        }

        if (!MaxLength(deviceObj.Description, new MaxLength(100), out string lengthError))
        {
            errorList.Add($"Length: {lengthError}");
        }
    }
}

class Program
{
    static void Main()
    {
        Device deviceObj = new Device();
        List<string> errors;
        bool isValid = ObjectValidator.Validate(deviceObj, out errors);
        if (!isValid)
        {
            foreach (string item in errors)
            {
                System.Console.WriteLine(item);

            }
        }
    }
}
