using System;

namespace PGMobile
{
	public enum AudioJackReaderType : uint
	{
		Unimag = 1,
		Ips = 2,
		AutodetectOnConnect = 3,
		None = 4,
		IpsEnterprise = 5
	}

	public enum CardReaderAutodetectResult : uint
	{
		UniMag,
		Ips,
		IpsEnterprise,
		Fail
	}

	public enum SwipeActivationResult : uint
	{
		Success = 0,
		Timeout = 1,
		Failure = 2,
		VolumeTooLow = 3
	}

	public enum SwipeReasonUnreadyForSwipe : uint
	{
		Disconnected,
		TimedOut,
		Canceled,
		Refreshing,
		SwipeDone
	}
}
