using UnityEngine;
using PathCreation;
using PathCreation.Examples;
using PathCreationEditor;

[RequireComponent(typeof(RoadMeshCreator))]
public class RoadBorders : MonoBehaviour
{
    private const string ROAD_MESH_HOLDER = "Road Mesh Holder";

    private GameObject _roadMesh;
    private RoadMeshCreator _meshCreator;
    private GameObject[] _borders = new GameObject[2];
    private float _upOffset = 0.05f;
    private Vector3 _scale = new Vector3(0.1f, 1.0f, 1.0f);

    private void Awake()
    {
        _meshCreator = GetComponent<RoadMeshCreator>();
        _roadMesh = transform.Find(ROAD_MESH_HOLDER).gameObject;
    }

    public void Create()
    {
        float sideOffset = _meshCreator.roadWidth;
        _borders[0] = GetNewBorder(sideOffset, "Right Border");
        _borders[1] = GetNewBorder(-sideOffset, "Left Border");
    }    

    public void Destroy()
    {
        foreach(GameObject border in _borders)
            if (border != null)
                Destroy(border.gameObject);
    }

    private GameObject GetNewBorder(float sideOffset, string borderName)
    {
        GameObject border = Instantiate(_roadMesh);
        border.transform.position = new Vector3(sideOffset, _upOffset, 0.0f);
        border.transform.localScale = _scale;
        border.transform.SetParent(this.transform);
        border.name = borderName;
        return border;
    }
}
