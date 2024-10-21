using UnityEngine;

public class SheepClickHandler : MonoBehaviour
{
    private AudioSource sheepAudioSource;
    //private Rigidbody sheepRigidbody;  // 用于物理跳跃

    //public float jumpForce = 5f;  // 跳跃的力度，可以在 Inspector 中调整

    void Start()
    {
        // 获取 AudioSource 组件
        sheepAudioSource = GetComponent<AudioSource>();

        if (sheepAudioSource != null)
        {
            Debug.Log("AudioSource 组件已成功获取。");
        }
        else
        {
            Debug.LogError("AudioSource 组件未找到！");
        }

        //// 获取 Rigidbody 组件，用于实现跳跃
        //sheepRigidbody = GetComponent<Rigidbody>();

        //if (sheepRigidbody != null)
        //{
        //    Debug.Log("Rigidbody 组件已成功获取。");
        //}
        //else
        //{
        //    Debug.LogError("Rigidbody 组件未找到！你可能需要为羊添加一个 Rigidbody 组件。");
        //}
    }

    void Update()
    {
        // 检测点击事件
        if (Input.GetMouseButtonDown(0))  // 0 表示鼠标左键或触摸屏幕
        {
            Debug.Log("检测到点击事件。");

            // 创建从摄像机发出的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 发射射线并检测碰撞
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("射线碰撞到了: " + hit.collider.gameObject.name);

                // 检查点击到的是否是羊
                if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                {
                    Debug.Log("点击到了羊。");

                    // 播放羊叫声
                    if (sheepAudioSource != null)
                    {
                        sheepAudioSource.Play();
                        Debug.Log("羊叫声正在播放。");
                    }

                    //// 让羊跳起来
                    //if (sheepRigidbody != null)
                    //{
                    //    // 添加向上的跳跃力
                    //    sheepRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    //    Debug.Log("羊跳起来了！");
                    //}
                }
                else
                {
                    Debug.Log("点击的不是羊。");
                }
            }
            else
            {
                Debug.Log("射线没有击中任何物体。");
            }
        }
    }
}
