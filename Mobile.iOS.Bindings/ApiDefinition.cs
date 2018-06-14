using System;
using ObjCRuntime;
using Foundation;
using UIKit;
using ExternalAccessory;

namespace PGMobile
{
	// @interface PGSwipeController : NSObject <PGAudioJackConnectionDetectorDelegate>
	[BaseType(typeof(NSObject))]
	interface PGSwipeController : PGAudioJackConnectionDetectorDelegate
	{
		[Wrap("WeakDelegate")]
		PGSwipeDelegate Delegate { get; [Bind("setDelegate:")] set; }

		// @property (assign, nonatomic, setter = setDelegate:) id<PGSwipeDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; [Bind("setDelegate:")] set; }

		// @property (assign, nonatomic, setter = setAudioJackReaderType:) AudioJackReaderType audioJackReaderType;
		[Export("audioJackReaderType", ArgumentSemantic.Assign)]
		AudioJackReaderType AudioJackReaderType { get; [Bind("setAudioJackReaderType:")] set; }

		// @property (readonly, retain, nonatomic) PGSwipeIpsEnterprise * ipsEnterpriseReader;
		[Export("ipsEnterpriseReader", ArgumentSemantic.Retain)]
		PGSwipeIpsEnterprise IpsEnterpriseReader { get; }

		// -(id)initWithDelegate:(id<PGSwipeDelegate>)delegate;
		[Export("initWithDelegate:")]
		IntPtr Constructor(PGSwipeDelegate @delegate);

		// -(id)initWithDelegate:(id<PGSwipeDelegate>)delegate audioReader:(AudioJackReaderType)audioJackReaderType;
		[Export("initWithDelegate:audioReader:")]
		IntPtr Constructor(PGSwipeDelegate @delegate, AudioJackReaderType audioJackReaderType);

		// -(void)setAudioJackReaderType:(AudioJackReaderType)audioJackReaderType messageOptions:(PGSwipeUniMagMessageOptions *)messageOptions;
		[Export("setAudioJackReaderType:messageOptions:")]
		void SetAudioJackReaderType(AudioJackReaderType audioJackReaderType, NSObject unused);

		// -(void)beginAutodetectAudioJackCardReader;
		[Export("beginAutodetectAudioJackCardReader")]
		void BeginAutodetectAudioJackCardReader();
	}

	// @protocol PGAudioJackConnectionDetectorDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface PGAudioJackConnectionDetectorDelegate
	{
		// @optional -(void)audioJackObjectAttached;
		[Export("audioJackObjectAttached")]
		void AudioJackObjectAttached();

		// @optional -(void)audioJackObjectDetached;
		[Export("audioJackObjectDetached")]
		void AudioJackObjectDetached();
	}

	// @interface PGSwipeIpsEnterprise : PGSwipeDevice <PGAudioJackConnectionDetectorDelegate>
	[BaseType(typeof(PGSwipeDevice))]
	interface PGSwipeIpsEnterprise : PGAudioJackConnectionDetectorDelegate
	{
		// -(id)initWithDelegate:(id<PGSwipeDelegate>)delegate;
		[Export("initWithDelegate:")]
		IntPtr Constructor(PGSwipeDelegate @delegate);

		// -(void)shutdown;
		[Export("shutdown")]
		void Shutdown();

		// -(void)beginTestCommunication:(id<IpsEnterpriseCommunicationTestDelegate>)delegate;
		[Export("beginTestCommunication:")]
		void BeginTestCommunication(IpsEnterpriseCommunicationTestDelegate @delegate);
	}

	// @protocol IpsEnterpriseCommunicationTestDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IpsEnterpriseCommunicationTestDelegate
	{
		// @required -(void)ipsEnterpriseCommunicationTestCompleteWithResult:(BOOL)success;
		[Abstract]
		[Export("ipsEnterpriseCommunicationTestCompleteWithResult:")]
		void IpsEnterpriseCommunicationTestCompleteWithResult(bool success);
	}

	// @protocol PGSwipeDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface PGSwipeDelegate
	{
		// @optional -(void)didSwipeCard:(PGSwipedCard *)card device:(PGSwipeDevice *)sender;
		[Export("didSwipeCard:device:")]
		void DidSwipeCard(PGSwipedCard card, PGSwipeDevice sender);

		// @optional -(void)deviceBecameReadyForSwipe:(PGSwipeDevice *)sender;
		[Export("deviceBecameReadyForSwipe:")]
		void DeviceBecameReadyForSwipe(PGSwipeDevice sender);

		// @optional -(void)deviceBecameUnreadyForSwipe:(PGSwipeDevice *)sender reason:(SwipeReasonUnreadyForSwipe)reason;
		[Export("deviceBecameUnreadyForSwipe:reason:")]
		void DeviceBecameUnreadyForSwipe(PGSwipeDevice sender, SwipeReasonUnreadyForSwipe reason);

		// @optional -(void)deviceConnected:(PGSwipeDevice *)sender;
		[Export("deviceConnected:")]
		void DeviceConnected(PGSwipeDevice sender);

		// @optional -(void)deviceDisconnected:(PGSwipeDevice *)sender;
		[Export("deviceDisconnected:")]
		void DeviceDisconnected(PGSwipeDevice sender);

		// @optional -(void)deviceActivationFinished:(PGSwipeDevice *)sender result:(SwipeActivationResult)result;
		[Export("deviceActivationFinished:result:")]
		void DeviceActivationFinished(PGSwipeDevice sender, SwipeActivationResult result);

		// @optional -(void)deviceDeactivated:(PGSwipeDevice *)sender;
		[Export("deviceDeactivated:")]
		void DeviceDeactivated(PGSwipeDevice sender);

		// @optional -(void)deviceAutodetectStarted;
		[Export("deviceAutodetectStarted")]
		void DeviceAutodetectStarted();

		// @optional -(void)deviceAutodetectComplete:(CardReaderAutodetectResult)result;
		[Export("deviceAutodetectComplete:")]
		void DeviceAutodetectComplete(CardReaderAutodetectResult result);
	}

	// @interface PGSwipedCard : PGCard
	[BaseType(typeof(PGCard))]
	interface PGSwipedCard
	{
		// @property (retain, nonatomic) NSString * track1;
		[Export("track1", ArgumentSemantic.Retain)]
		string Track1 { get; set; }

		// @property (retain, nonatomic) NSString * track2;
		[Export("track2", ArgumentSemantic.Retain)]
		string Track2 { get; set; }

		// @property (retain, nonatomic) NSString * track3;
		[Export("track3", ArgumentSemantic.Retain)]
		string Track3 { get; set; }

		// @property (retain, nonatomic) NSString * maskedCardNumber;
		[Export("maskedCardNumber", ArgumentSemantic.Retain)]
		string MaskedCardNumber { get; set; }

		// @property (retain, nonatomic) NSString * expirationDate;
		[Export("expirationDate", ArgumentSemantic.Retain)]
		string ExpirationDate { get; set; }

		// @property (retain, nonatomic) NSString * cardholderName;
		[Export("cardholderName", ArgumentSemantic.Retain)]
		string CardholderName { get; set; }

		// -(id)initWithTrack1:(NSString *)track1 track2:(NSString *)track2 track3:(NSString *)track3 cvv:(NSString *)cvv;
		[Export("initWithTrack1:track2:track3:cvv:")]
		IntPtr Constructor(string track1, string track2, string track3, string cvv);

		// -(NSString *)getDirectPostStringWithCVVIncluded:(BOOL)cvvIncluded;
		[Export("getDirectPostStringWithCVVIncluded:")]
		string GetDirectPostStringWithCVVIncluded(bool cvvIncluded);
	}

	// @interface PGSwipeDevice : NSObject
	[BaseType(typeof(NSObject))]
	interface PGSwipeDevice
	{
		// @property (readonly, nonatomic) _Bool isConnected;
		[Export("isConnected")]
		bool IsConnected { get; }

		// @property (readonly, nonatomic) _Bool isActivated;
		[Export("isActivated")]
		bool IsActivated { get; }

		// @property (readonly, nonatomic) _Bool isReadyForSwipe;
		[Export("isReadyForSwipe")]
		bool IsReadyForSwipe { get; }

		[Wrap("WeakDelegate")]
		PGSwipeDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<PGSwipeDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// -(id)initWithDelegate:(id<PGSwipeDelegate>)delegate;
		[Export("initWithDelegate:")]
		IntPtr Constructor(PGSwipeDelegate @delegate);
	}

	// @interface PGCard : NSObject
	[BaseType(typeof(NSObject))]
	interface PGCard
	{
		// @property (retain, nonatomic) NSString * cvv;
		[Export("cvv", ArgumentSemantic.Retain)]
		string Cvv { get; set; }

		// -(NSString *)getDirectPostStringWithCVVIncluded:(BOOL)cvvIncluded;
		[Export("getDirectPostStringWithCVVIncluded:")]
		string GetDirectPostStringWithCVVIncluded(bool cvvIncluded);
	}
}
