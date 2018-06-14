using System;
using ObjCRuntime;

[assembly: LinkWith("PGMobileSDK.a", LinkTarget.ArmV7, Frameworks = "AudioToolbox AVFoundation ExternalAccessory MediaPlayer Security CoreBluetooth", IsCxx = true)]
