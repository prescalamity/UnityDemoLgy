using System.Collections;
using System.Collections.Generic;

public class txt
{


    public static string DropdownStr
    {
        get {

            if (dropdownStr == null) dropdownStr = _dropdownStr.Replace("\r", "").Replace("\n", "");

            return dropdownStr; 
        }

        private set { }
        
    }

    //public static string DropdownStr
    //{
    //    get => dropdownStr;
    //    set => dropdownStr = value;
    //}

    private static string dropdownStr = null;
    private static string _dropdownStr = @"
None,
PowerPanel,
GetPkgName,
RecordSoundPanel,
OpenPhotoLibraryPanel,
OpenCameraPanel,
openCameraPanel,
openPhotoLibraryPanel,
GetNumberOfCPUCores,
GetCPUMaxFreqKHz,
GetSdcardRootPath,
GetSDCardAvailaleSize,
CheckSDCardUsable,
GetVailMemory,
GetScreenWidth,
GetScreenHeight,
GetScreenMetricsWidth,
GetScreenMetricsHeight,
GettInches,
JumpToLink,
GetAndroidVersion,
IsInternetConnected,
GetPackageVersion,
CloseProgress,
GetManufacturer,
PopUpdateAlertView,
ReadBytesFromAssets,
ReadObbBytesFromAssets4K,
ExportResourceFile2OtherPath,
ExportResourceFile,
ExportResourceDirectory,
GetPakFiles,
IsOpenObb,
GetSettingFlag,
GetVideoState,
TestMulteCallback,
";





}
