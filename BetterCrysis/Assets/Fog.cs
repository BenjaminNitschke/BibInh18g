using UnityEngine;

public class Fog : MonoBehaviour
{
	void Start ()
	{
		material = GetComponent<Renderer>().material;
		initialColor = material.color;
	}
	private Material material;
	private Color initialColor;
	public Color FogColor = new Color(0.8f, 0.8f, 0.8f);
	public float MaxFogDistance = 50;
	public GameObject Camera;
	
	void Update ()
	{
		// Per vertex fog
		//var mesh = GetComponent<MeshFilter>().mesh;
		//var colors = new Color[mesh.vertexCount];
		//for (int num = 0; num < mesh.vertexCount; num++)
		//{
		//	var distance = Vector3.Distance(Camera.transform.position,
		//		transform.position + mesh.vertices[num]);
		//	colors[num] = Color.Lerp(initialColor, FogColor, distance/MaxFogDistance);
		//}
		//mesh.colors = colors;
		//mesh.UploadMeshData(false);

		// Per object fog
		var distance = Vector3.Distance(Camera.transform.position, transform.position);
		material.color = Color.Lerp(initialColor, FogColor,
			1 - (1-(distance/MaxFogDistance))*(1-(distance/MaxFogDistance)));
	}
}
