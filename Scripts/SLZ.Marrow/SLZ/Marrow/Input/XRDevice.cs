using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SLZ.Marrow.Utilities;
using UnityEngine;
using UnityEngine.XR;

namespace SLZ.Marrow.Input
{
	public class XRDevice
	{
		private List<InputDevice> _xrDevices;

		protected InputDevice _xrDevice;

		private double _lastUpdateTime;

		private Vector3 _lastPosition;

		private Quaternion _lastRotation;

		public virtual InputDeviceCharacteristics Characteristics
		{
			[CompilerGenerated]
			get
			{
				return default(InputDeviceCharacteristics);
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public virtual string DeviceInfo
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public virtual bool IsConnected
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public virtual bool IsTracking
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public Vector3 Position
		{
			[CompilerGenerated]
			get
			{
				return default(Vector3);
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public Quaternion Rotation
		{
			[CompilerGenerated]
			get
			{
				return default(Quaternion);
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public Vector3 Velocity
		{
			[CompilerGenerated]
			get
			{
				return default(Vector3);
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public Vector3 AngularVelocity
		{
			[CompilerGenerated]
			get
			{
				return default(Vector3);
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public double UpdateTime
		{
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public virtual void OnFrameStart()
		{
		}

		public virtual void OnPreNewInputUpdate()
		{
		}

		public virtual void OnPostNewInputUpdate()
		{
		}

		public virtual void Refresh()
		{
		}

		public SimpleTransform GetPoseAtFixedTime(double fixedTime)
		{
			return default(SimpleTransform);
		}
	}
}
