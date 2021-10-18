using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    Transform T;
    float Ax, Az; //オブジェクトのx,z軸の角度の変数（y軸は今回は関係ない）
    // Start is called before the first frame update
    void Start()
    {
        
        Ax = 0;
        Az = 0;
        T = GetComponent<Transform>();　//オブジェクトのtransformコンポーネントを取得
    }

    // Update is called once per frame
    void Update()
    {
        Ax = T.localEulerAngles.x; //W,S　オブジェクトのx軸の角度をオイラー角で取得
        Az = T.localEulerAngles.z; //A,D　オブジェクトのz軸の角度をオイラー角で取得

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Debug.Log(Ax + "," + Az);

        if (Az <= 30f || 331f <= Az)
        {
            if (x == -1)
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }

            if (x == 1)
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
        }else if (Az >= 30 && 31 >= Az) // && 31の条件が無いと330度以下まで傾く
        {
            if (x == 1)
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
        }
        else if (Az <= 360 && Az >= 330)
        {
            if (x == -1)
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
        }

        if (Ax <= 30f || 331f <= Ax)
        {
            if (z == 1)
            {
                transform.Rotate(new Vector3(1, 0, 0));
            }

            if (z == -1)
            {
                transform.Rotate(new Vector3(-1, 0, 0));
            }
        }
        else if (Ax >= 30 && 31 >= Ax)
        {
            if (z == -1)
            {
                transform.Rotate(new Vector3(-1, 0, 0));
            }
        }
        else if (Ax <= 331)
        {
            if (z == 1)
            {
                transform.Rotate(new Vector3(1, 0, 0));
            }
        }
    }
}