using System;
using ObjCRuntime;

[assembly: LinkWith("PGMobileSDK.a", LinkTarget.Arm64, Frameworks = "AudioToolbox AVFoundation ExternalAccessory MediaPlayer Security CoreBluetooth", IsCxx = true)]
