using UnityEngine;

public class CameraOrbitViewer : MonoBehaviour
{
    public Transform target;  // 拖拽赋值：场景里你的多比模型
    public float rotateSpeed = 2f;
    public float zoomSpeed = 10f;
    public float minDistance = 1f;
    public float maxDistance = 20f;

    private float distance;
    private float yaw;
    private float pitch;

    void Start()
    {
        distance = Vector3.Distance(transform.position, target.position);
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void Update()
    {
        // 左键拖拽旋转相机
        if (Input.GetMouseButton(0))
        {
            yaw += Input.GetAxis("Mouse X") * rotateSpeed;
            pitch -= Input.GetAxis("Mouse Y") * rotateSpeed;
        }
        // 滚轮缩放相机远近
        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // 更新相机位置
        Quaternion rot = Quaternion.Euler(pitch, yaw, 0);
        transform.position = target.position + rot * new Vector3(0, 0, -distance);
        transform.LookAt(target);
    }
}

