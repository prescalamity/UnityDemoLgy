using System.Collections;
using System.Collections.Generic;

public class txt
{


    public static string TxtStr
    {
        get {

            if (txtStr == null) txtStr = _txtStr.Replace("\r", "").Replace("\n", "");

            return txtStr; 
        }

        private set { }
        
    }

    //public static string DropdownStr
    //{
    //    get => dropdownStr;
    //    set => dropdownStr = value;
    //}

    private static string txtStr = null;
    private static string _txtStr = @"
SelectAndClickTestButton,
NoMore,
";





}
