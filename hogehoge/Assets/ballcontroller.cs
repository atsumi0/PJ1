using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontroller : MonoBehaviour
{
    public GameObject mainCamera;
    public int zAdjust;
    public float speed = 20; // 動く速さ
    private Rigidbody rb; // Rididbody
    private float jumpPower = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zAdjust);
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);
        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);

        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.Translate(transform.up * jumpPower);
        }
    }
}
