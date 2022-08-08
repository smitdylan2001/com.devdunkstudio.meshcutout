using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeshCutoutSelection
{
    Touching,
    Enclosing
}

[RequireComponent(typeof(MeshFilter))]
public class CutoutMesh : MonoBehaviour
{
    #region PublicVariables
    [Tooltip("Mode used to check how the cutout is generated")]
    public MeshCutoutSelection mode = MeshCutoutSelection.Touching;

    [Tooltip("Transform of the tracked object, used for the mesh cutout generation")]
    public Transform ReferenceObject;

    [Tooltip("Distance used to calculate the mesh cutout")]
    public  float MinDist = 0f, MaxDist = float.PositiveInfinity;

    [Tooltip("Update carved mesh at start")]
    public bool GenerateOnStart = true;

    [Tooltip("Update carved mesh on Update")]
    public bool GenerateOnUpdate = false;

    [Tooltip("Update carved mesh on FixedUpdate")]
    public bool GenerateOnFixedUpdate = false;
    #endregion

    #region PrivateVariables
    private List<Vector3> _vertices;
    private List<int> _originalTris, _carvedTris;
    private Mesh _carvedMesh;
    #endregion

    #region UnityMethods
    private void Start()
    {
        GetMeshData();

        if (GenerateOnStart) UpdateCarvedMesh();
    }

    private void Update()
    {
        if (GenerateOnUpdate) UpdateCarvedMesh();
    }

    private void FixedUpdate()
    {
        if (GenerateOnFixedUpdate) UpdateCarvedMesh();
    }
    #endregion

    #region MeshCutout
    private void GetMeshData()
    {
        var mf = GetComponent<MeshFilter>();

        _carvedMesh = Mesh.Instantiate(mf.sharedMesh);
        mf.sharedMesh = _carvedMesh;

        _vertices = new List<Vector3>(_carvedMesh.vertexCount);
        _carvedMesh.GetVertices(_vertices);
        _originalTris = new List<int>((int)_carvedMesh.GetIndexCount(0));
        _carvedMesh.GetTriangles(_originalTris, 0);
        _carvedTris = new List<int>(_originalTris.Count);
    }

    private static bool CheckVertex(Vector3 v1, Vector3 refPos, float aMin, float aMax)
    {
        float sDist = (v1 - refPos).sqrMagnitude;
        return sDist > aMax || sDist < aMin;
    }

    public void UpdateCarvedMesh()
    {
        if (!ReferenceObject) throw new System.Exception("referenceObject can not be null. You have to assign it in the inspector");

        var refPos = transform.InverseTransformPoint(ReferenceObject.position);
        var sqrMin = MinDist * MinDist;
        var sqrMax = MaxDist * MaxDist;
        _carvedTris.Clear();

        for (int i = 0; i < _originalTris.Count; i += 3)
        {
            var v1 = _vertices[_originalTris[i]];
            var v2 = _vertices[_originalTris[i + 1]];
            var v3 = _vertices[_originalTris[i + 2]];
            if (mode == MeshCutoutSelection.Enclosing)
            {
                if (CheckVertex(v1, refPos, sqrMin, sqrMax) ||
                    CheckVertex(v2, refPos, sqrMin, sqrMax) ||
                    CheckVertex(v3, refPos, sqrMin, sqrMax))
                    continue;
            }
            else
            {
                if (CheckVertex(v1, refPos, sqrMin, sqrMax) &&
                    CheckVertex(v2, refPos, sqrMin, sqrMax) &&
                    CheckVertex(v3, refPos, sqrMin, sqrMax))
                    continue;
            }
            _carvedTris.Add(_originalTris[i]);
            _carvedTris.Add(_originalTris[i + 1]);
            _carvedTris.Add(_originalTris[i + 2]);
        }

        _carvedMesh.SetTriangles(_carvedTris, 0);
    }
    #endregion
}
