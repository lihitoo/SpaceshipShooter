using UnityEngine;

public class LockAspectRatio : MonoBehaviour
{
    void Start()
    {
        Camera.main.aspect = 9f / 16f; // Đặt tỷ lệ màn hình thành 9:16
    }
}
