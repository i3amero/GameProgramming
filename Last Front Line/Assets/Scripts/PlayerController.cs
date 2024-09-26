using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float mouseSpeed;
    float yRotation;
    float xRotation;
    Camera cam;
    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // 마우스 커서를 화면 안에서 고정
        Cursor.visible = false;                     // 마우스 커서를 보이지 않도록 설정
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseX;    // 마우스 X축 입력에 따라 수평 회전 값을 조정
        xRotation -= mouseY;    // 마우스 Y축 입력에 따라 수직 회전 값을 조정

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // 수직 회전 값을 -90도에서 90도 사이로 제한

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // 카메라의 회전을 조절
        transform.rotation = Quaternion.Euler(0, yRotation, 0);             // 플레이어 캐릭터의 회전을 조절
    }
}