#SingleEntry for Windows Mobile

This simple app demonstrates the usage of ScanAPI SDK for a Windows
Mobile application.

##Prerequisites
This project is compiled using Visual Studio 2008.

The Nuget Command Line utility is required for installing the ScanAPI
NuGet. This utility can be found at http://docs.nuget.org/consume/installing-nuget
and select Command-Line Utility.

The ScanAPI SDK is a private NuGet that needs to be downloaded from Socket 
Mobile.
Check the Socket Mobile store: 
http://socketstore.com/collections/sdks-support-options-developer-tools

##Installation

To install the NuGet, in order to have the sample working out of the box, the 
ScanAPI Nuget should be installed by following these steps:

1. Copy the SocketMobile.ScanAPI.10.2.xxx.x.nupkg somewhere reacheable by the
development machine

2. Add a NuGet source to the location where the 
SocketMobile.ScanAPI.10.2.xxx.x.nupkg is located. The command line for 
accomplishing this could be:
```
nuget sources add -Name "ScanAPI SDK" -Source "C:\Users\<username>\Documents\ScanAPI-Downloads"
```

3. Install the NuGet where this sample code is. If you have cloned this sample 
code under your Documents folder then in that directory type the following 
command:
```
nuget install -OutputDirectory packages SocketMobile.ScanAPI
```

This creates a packages directory in the Documents folder that contains the
ScanAPI NuGet.

So the Documents directory output should be something like:
```
\Documents
    \ScanAPI-Downloads
		SocketMobile.ScanAPI.10.2.xxx.x.nupkg
	\singleentry-windowsmobile
		... 
	\packages
		\SocketMobile.ScanAPI.10.2.xxx.x
```

SingleEntry has a link to ScanApiHelper.cs that is located in the NuGet content
folder.

##Note
When running the application the ScanApiManagedWM.DLL and the ScanAPIWM.DLL must
be copied at the same location than the exe.

## Documentation
Check the ScanAPI online documentation for further information.
This documentation can be reached from Socket Mobile Developer portal at:
 http://www.socketmobile.com/developers/welcome
 
## ScanAPI Configuration
ScanAPI requires at least one Bluetooth INBOUND port in order to open without 
error.

This ScanAPI configuration can be set by using the kSktScanPropIdConfiguration 
with the string value set as follow: "SerialPorts=COM3:" by example.

To retrieve the current configuration, a Get kSktScanPropIdConfiguration 
property with a string value set to "SerialPorts" will return the COM port 
ScanAPI is actually trying to listen to.

This configuration is stored on the disk to a shared location like by example on
a Windows 7 host: \ProgramData\Socket Mobile\ScanAPI\ScanAPI.xml.

It is not recommended to modify this ScanAPI.xml file directly as its format can
change or this file can be replaced in different version. The best for modifying
this configuration is to use the ScanAPI API.

## ScanAPI Usage
This SingleEntry sample app is using ScanApiHelper which simplifies the ScanAPI
integration in an app.

ScanApiHelper is actually a data member of the SingleEntry Form object. In the 
constructor of the Form, the ScanApiHelper instance is allocated.
The Form actually derives from the ScanApiHelperNotification interface in order
to implement the various notifications coming from ScanAPI.
Once ScanApiHelper instance is created the ScanApiHelper SetNotification is 
called with this Form reference as argument.

Upon the Form Load, ScanApiHelper is open and a ScanAPI consumer timer is set.
Each time this timer elapses, its handler calls ScanApiHelper DoScanAPIReceive 
in order to receive any notification from ScanAPI.

Then most of the implementation is done in the notification handlers. 
The first notification received is OnScanApiInitializeComplete. This indicates 
the first open has successfully initialized ScanAPI. The Bluetooth INBOUND port
has be open correctly and ScanAPI is listening to it.

If a scanner is connecting to this host, then the OnDeviceArrival notification 
is invoked.

If the scanner decodes successfully a barcode, the OnDecodedData notification is 
invoked with the decoded data as argument.

If the scanner disconnects from the host then the app receives the 
OnDeviceRemoval notification.

ScanApiHelper provides few PostSetxxx and PostGetxxx methods to send a request 
to get the friendly name, the Bluetooth address of the device, or to get and set 
the barcode symbologies by example.

Each of these PostSetxxx / PostGetxxx accepts a callback as argument that is 
invoked upon completion of the request.

The close process is a 2-step process: first call the ScanApiHelper close method
and then wait for the OnScanApiTerminated notification, which can then close the
form.


