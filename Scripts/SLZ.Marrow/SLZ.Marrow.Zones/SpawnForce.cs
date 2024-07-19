 
using SLZ.Marrow.Interaction;
using SLZ.Marrow.Warehouse;
 
using UnityEngine;
using MathUtils = SLZ.Marrow.Utilities.MathUtils;
 
#if UNITY_EDITOR
using UnityEditor;

#endif
namespace SLZ.Marrow.Zones
{
    [RequireComponent(typeof(CrateSpawner))]
    [AddComponentMenu("MarrowSDK/Spawn Force")]
    public class SpawnForce : SpawnDecorator
    {
        [Tooltip("If true force will be applied once awakened from hibernation," + " or use ApplyForce() on a trigger to explicitly add forces anytime after entity is awakened")]
        public bool applyForceOnSpawn = true;
        [Tooltip("Initial direct velocity change on spawn (meters/second)")]
        public Vector3 spawnVelocity = Vector3.zero;
        [Tooltip("Initial direct angular velocity change on spawn (radians/second)")]
        public Vector3 spawnAngularVelocity = Vector3.zero;
        [Tooltip("Minimum Angular Velocity Magnitude")]
        public float minSpawnAngularVelocity = 0;
        [Tooltip("Maximum Angular Velocity Magnitude")]
        public float maxSpawnAngularVelocity = 0;
        [Tooltip("Additional time in Seconds after spawn to trigger force (seconds)")]
        public float additionalDelay = 0;
        public bool drawVelocity = false;
        MarrowEntity entity;
        public static bool drawVelocityStatic = true;
#if UNITY_EDITOR
        private GUIStyle richTextStyle;
#endif
        [ContextMenu("ApplyForce")]
        public void ApplyForce()
        {
            UnityEngine.Debug.Log("Hollowed Method: SLZ.Marrow.Zones.SpawnForce.ApplyForce()");
            throw new System.NotImplementedException();
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (richTextStyle == default)
            {
                richTextStyle = new GUIStyle();
                richTextStyle.richText = true;
            }

            if (drawVelocity || drawVelocityStatic)
            {
                if (spawnVelocity.sqrMagnitude > MathUtils.Epsilon)
                {
                    var handlesMatrix = Handles.matrix;
                    var handlesColor = Handles.color;
                    var spawnVelocityMagnitude = spawnVelocity.magnitude;
                    var rotation = Quaternion.LookRotation(spawnVelocity);
                    Handles.matrix = Matrix4x4.TRS(transform.position, transform.rotation * rotation, Vector3.one);
                    Handles.color = Color.cyan;
                    Handles.DrawLine(Vector3.zero, Vector3.forward * spawnVelocityMagnitude, 6f);
                    Handles.color = Color.black;
                    Handles.DrawLine(Vector3.zero, Vector3.forward * spawnVelocityMagnitude, 4f);
                    Handles.color = Color.cyan;
                    Handles.ConeHandleCap(0, Vector3.forward * spawnVelocityMagnitude, Quaternion.identity, 0.06f, EventType.Repaint);
                    Handles.color = Color.black;
                    Handles.ConeHandleCap(0, Vector3.forward * spawnVelocityMagnitude, Quaternion.identity, 0.045f, EventType.Repaint);
                    Handles.Label(Vector3.forward * spawnVelocityMagnitude / 2f + Vector3.up * 0.1f, $"<color=#fff><b>{spawnVelocityMagnitude:F1}</b> (<i>m/s</i>)</color>", richTextStyle);
                    Handles.matrix = handlesMatrix;
                    Handles.color = handlesColor;
                }

                if (spawnAngularVelocity.sqrMagnitude > MathUtils.Epsilon)
                {
                    var handlesMatrix = Handles.matrix;
                    var handlesColor = Handles.color;
                    Handles.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
                    Vector3 normal = spawnAngularVelocity.normalized;
                    float angle = spawnAngularVelocity.magnitude * Mathf.Rad2Deg;
                    var right = -Vector3.Normalize(Vector3.Cross(normal, Vector3.up));
                    float dot = Vector3.Dot(normal, Vector3.up);
                    if (1 - Mathf.Abs(dot) < MathUtils.Epsilon)
                    {
                        right = Vector3.Cross(Vector3.forward, normal);
                    }

                    float angleMult = 1 + angle / 180 / 5f;
                    Handles.color = Color.magenta;
                    Handles.DrawWireArc(Vector3.zero, normal, -right, Mathf.Clamp(angle, 0f, 360f), 0.5f, 6f * angleMult);
                    Handles.color = Color.black;
                    Handles.DrawWireArc(Vector3.zero, normal, -right, Mathf.Clamp(angle, 0f, 360f), 0.5f, 5f * angleMult);
                    Quaternion arcRotation = Quaternion.AngleAxis(angle % 360f, normal);
                    Vector3 endpointPosition = arcRotation * (-right * 0.5f);
                    Vector3 tangentDirection = Quaternion.AngleAxis((angle + 90f) % 360f, normal) * -right;
                    Quaternion handleRotation = Quaternion.LookRotation(tangentDirection, normal);
                    Handles.color = Color.magenta;
                    Handles.DrawLine(Vector3.zero, normal / 10f);
                    Handles.color = Color.magenta;
                    Handles.ConeHandleCap(0, endpointPosition, handleRotation, 0.06f * angleMult, EventType.Repaint);
                    Handles.color = Color.black;
                    Handles.ConeHandleCap(0, endpointPosition, handleRotation, 0.045f * angleMult, EventType.Repaint);
                    Handles.Label(endpointPosition + Vector3.up * 0.2f, $"<color=#fff><b>{angle:N0}</b> (<i>deg/s</i>)</color>", richTextStyle);
                    Handles.matrix = handlesMatrix;
                    Handles.color = handlesColor;
                }
            }
        }
#endif
    }
}