using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SLZ.Data;
using SLZ.Marrow.Data;
using SLZ.Marrow.Pool;
using SLZ.Marrow.Utilities;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace SLZ.VFX
{
	public class DecalProjector : SpawnEvents
	{
		private struct decalBitField96
		{
			private BitField64 internal64;

			private BitField32 internal32;

			public void SetBits(int index, bool value)
			{
			}

			public bool IsSet(int index)
			{
				return false;
			}
		}

		public enum DecalProjectionMethod
		{
			GridRaycastProjection = 0,
			RadialRaycastProjection = 1
		}

		[StructLayout(2)]
		public struct DecalVertex
		{
			public float3 vertex;

			public uint normal;

			public uint tangent;

			public half4 color;

			public half2 uv;
		}

		private struct DebugRayInfo
		{
			public Vector3 Origin;

			public Vector3 HitPoint;
		}

		private static ComponentCache<DecalProjector> _cache;

		[ColorUsage(true, true)]
		[Tooltip("Vertex Color")]
		public Color vertexColor;

		[Tooltip("Collider that will be raycast to")]
		[Header("Raycast Settings")]
		public Collider targetCollider;

		[Header("General Settings")]
		public Material decalMaterial;

		[Tooltip("Offset from surface normal (m)")]
		public float offset;

		[Tooltip("Diameter or width (m)")]
		public float decalSize;

		[Tooltip("The distance the raycasts (m)")]
		public float raycastDistance;

		[Header("Mesh mode Settings")]
		public DecalProjectionMethod projectionMethod;

		[Header("Grid Settings")]
		[Range(1f, 8f)]
		public int gridResolution;

		[Header("Radial Settings")]
		[Range(3f, 16f)]
		public int radialSegments;

		[Range(1f, 5f)]
		public int radialSubdivisions;

		[Header("Atlas Settings")]
		public DecalAtlasData atlasData;

		public int atlasSelection;

		public bool randomizeSelection;

		[Header("Generated Decal")]
		[SerializeField]
		internal MeshFilter meshFilter;

		[SerializeField]
		internal MeshRenderer meshRenderer;

		[SerializeField]
		private Mesh mesh;

		internal bool isEnqueued;

		internal int poolIndex;

		public const int maxDecalVerts = 80;

		private const MeshUpdateFlags noValidationFlag = MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds;

		private static readonly ProfilerMarker s_CreateRadialLayout;

		private static readonly ProfilerMarker s_CreateGridLayout;

		private static readonly ProfilerMarker s_CreateVerts;

		private static readonly ProfilerMarker s_CreateTris;

		private static readonly ProfilerMarker s_ApplyMeshData;

		private NativeArray<DecalVertex> tempMeshBuffer;

		private NativeArray<ushort> tempIdxBuffer;

		private static readonly VertexAttributeDescriptor[] decalVtxLayout;

		private readonly List<DebugRayInfo> _debugRayInfos;

		public static ComponentCache<DecalProjector> Cache => null;

		protected override void Awake()
		{
		}

		public override void OnPoolDeInitialize()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private Mesh CreateDecalMesh()
		{
			return null;
		}

		public void SetColliderColorAndCreate(Collider hitCollider, Color color)
		{
		}

		public void SetVariablesAndCreate(SurfaceData.MaterialLevel decalMaterialLevel, Collider hitCollider, Color colorTint)
		{
		}

		[ContextMenu("Apply Decal")]
		public void ApplyDecal()
		{
		}

		private void ApplyDecalImmediate(NativeArray<DecalVertex> vertexBuffer, NativeArray<ushort> indexBuffer)
		{
		}

		private static Vector2 LerpVector2Components(Vector2 a, Vector2 b, Vector2 t)
		{
			return default(Vector2);
		}

		[MethodImpl(256)]
		private static uint ConvertFloat4ToSNorm4(float4 value)
		{
			return 0u;
		}

		[MethodImpl(256)]
		private static uint ConvertFloat3ToSNorm4(float3 value)
		{
			return 0u;
		}

		private void CreateConformedMesh(float size, NativeArray<DecalVertex> vertexBuffer, NativeArray<ushort> indexBuffer)
		{
		}

		private void CreateRadialLayout(float size, NativeArray<DecalVertex> vertexBuffer, NativeArray<ushort> indexBuffer)
		{
		}

		private void AddGeoFrom4Hits(NativeArray<ushort> indexBuffer, ref int indexPtr, Span<ushort> ccwIndices, Span<bool> ccwHits)
		{
		}

		private void RandomizeSelection()
		{
		}
	}
}
