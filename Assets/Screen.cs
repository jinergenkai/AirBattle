using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("va cham");
        // Xử lý khi viên đạn va chạm với viền màn hình
        if (other.CompareTag("Bullet")) // Kiểm tra nếu va chạm là viên đạn
        {
            Destroy(other.gameObject); // Tiêu diệt viên đạn khi nó va chạm với viền màn hình
        }
    }
}
