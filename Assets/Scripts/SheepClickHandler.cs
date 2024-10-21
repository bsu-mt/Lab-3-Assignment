using UnityEngine;

public class SheepClickHandler : MonoBehaviour
{
    private AudioSource sheepAudioSource;
    //private Rigidbody sheepRigidbody;  // ����������Ծ

    //public float jumpForce = 5f;  // ��Ծ�����ȣ������� Inspector �е���

    void Start()
    {
        // ��ȡ AudioSource ���
        sheepAudioSource = GetComponent<AudioSource>();

        if (sheepAudioSource != null)
        {
            Debug.Log("AudioSource ����ѳɹ���ȡ��");
        }
        else
        {
            Debug.LogError("AudioSource ���δ�ҵ���");
        }

        //// ��ȡ Rigidbody ���������ʵ����Ծ
        //sheepRigidbody = GetComponent<Rigidbody>();

        //if (sheepRigidbody != null)
        //{
        //    Debug.Log("Rigidbody ����ѳɹ���ȡ��");
        //}
        //else
        //{
        //    Debug.LogError("Rigidbody ���δ�ҵ����������ҪΪ�����һ�� Rigidbody �����");
        //}
    }

    void Update()
    {
        // ������¼�
        if (Input.GetMouseButtonDown(0))  // 0 ��ʾ������������Ļ
        {
            Debug.Log("��⵽����¼���");

            // ���������������������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // �������߲������ײ
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("������ײ����: " + hit.collider.gameObject.name);

                // ����������Ƿ�����
                if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                {
                    Debug.Log("���������");

                    // ���������
                    if (sheepAudioSource != null)
                    {
                        sheepAudioSource.Play();
                        Debug.Log("��������ڲ��š�");
                    }

                    //// ����������
                    //if (sheepRigidbody != null)
                    //{
                    //    // ������ϵ���Ծ��
                    //    sheepRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    //    Debug.Log("���������ˣ�");
                    //}
                }
                else
                {
                    Debug.Log("����Ĳ�����");
                }
            }
            else
            {
                Debug.Log("����û�л����κ����塣");
            }
        }
    }
}
