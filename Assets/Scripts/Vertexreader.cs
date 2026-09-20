using UnityEngine;

public class vertexreader : MonoBehaviour
{
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null)
        {
            Debug.Log($"{gameObject.name} 没有MeshFilter组件");
            return;
        }
        Mesh mesh = mf.mesh;
        Vector3[] vertices = mesh.vertices;
        Debug.Log($"===== 模型【{gameObject.name}】，顶点总数：{vertices.Length} =====");
        // 只打印前10个顶点，防止控制台刷屏
        for (int i = 0; i < Mathf.Min(10, vertices.Length); i++)
        {
            Debug.Log($"【{gameObject.name}】顶点[{i}] 局部坐标: {vertices[i]}");
        }
    }
}
