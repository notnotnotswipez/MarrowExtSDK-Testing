using UnityEngine;

namespace SLZ.Marrow
{
	public class WindBuffetSFX : MonoBehaviour
	{
		public float minSpeed;

		public float maxSpeed;

		public AudioClip windBuffetClip;

		public AudioClip windBuffetSlowMo;

		private float calculate_t;

		private AudioSource _buffetSrc;

		private AudioLowPassFilter _lowPass;

		private float _minSpeedSqr;

		private float _windBuffetDue;

		private const float sleepFreq_t = 0.2f;

		private const float playFreq_t = 0.03f;

		private Vector3 _lastPosition;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateBuffet()
		{
		}
	}
}
