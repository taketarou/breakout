/*下の三行は消さないでそのまま*/
using System.Collections; //コルーチンやリストなどを使えるようにするための処理　コルーチン＝mainの処理と同時に走ってくれる処理。
using System.Collections.Generic;
using UnityEngine; //デバッグログやUnity専用の機能を使えるようにする 

//public class クラス名:継承しているクラス名       UnityのスクリプトではMonoBehaviourを基本的に継承  MonoBehaviouを継承することで(MonoBehaviourクラスで定義されている変数、関数である)Start関数やUpdate関数、transform変数、gameObject変数などが使えるようになる。
public class Controller : MonoBehaviour　
{
    
    [Header("バーの移動速度"),Range(0.1f,1.0f)]
    public float playerSpeed; //Player(バー)の移動速度

    [Header("バーの移動範囲の制限値")]
    public float limitPos = 4.25f;

    // 実行時に初めに1回呼ばれる関数
    void Start() 
    {


    }

    // Startが呼ばれた後に実行される関数。ずっと動いていて、イベントが起こるのを待っている。
    void Update()
    {
        //もしも左矢印キーがおされたら 　条件式としてはtrue,false　InputはUnityが持っている独自のクラス。Input.～()=Inputクラスが持っている～関数を呼び出す   GetKey(～ボタン)=～ボタンが押されたときだけtrue   getKeyは押し続けている間で離した瞬間にfalseになる。
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //このコンポーネント(=スクリプト)を持っているオブジェクトのTransformコンポーネントのpositionのz座標に0.1を足しなさい． tansform.forward=xが0、yも0、zが1という情報が入っている　　　fはフロート型。C#だと小数点の後ろにはfをつける。　transformにはこのスクリプトを適用したオブジェクトの情報が入っている。
            //transform.position += transform.forward * 0.1f;
            
            //このコンポーネント(=スクリプト)を持っているオブジェクトのTransformコンポーネントのpositionのz座標にplayerSpeedを足しなさい． tansform.forward=xが0、yも0、zが1という情報が入っている　　　fはフロート型。C#だと小数点の後ろにはfをつける。　transformにはこのスクリプトを適用したオブジェクトの情報が入っている。
            transform.position += transform.forward * playerSpeed;
        }
        //もし左矢印キーが押されず、右矢印キーが押されていたら 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //このコンポーネント(=スクリプト)を持っているオブジェクトのtransformコンポーネントのpositionのz座標から0.1を引きなさい．
            //transform.position -= transform.forward * 0.1f;
            
            //このコンポーネント(=スクリプト)を持っているオブジェクトのtransformコンポーネントのpositionのz座標からplayerSpeedを引きなさい．
            transform.position -= transform.forward * playerSpeed;
        }

        //バーの移動範囲を制限(transformコンポーネントのpositionのz座標を－4.25から4.25の範囲に制限する)
        float z = Mathf.Clamp(transform.position.z, -limitPos, limitPos);

        //位置情報の更新
        transform.position = new Vector3(transform.position.x, transform.position.y, z);

    }
}
