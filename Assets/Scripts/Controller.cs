/*下の三行は消さないでそのまま*/
using System.Collections; //コルーチンやリストなどを使えるようにするための処理　コルーチン＝mainの処理と同時に走ってくれる処理。
using System.Collections.Generic;
using UnityEngine; //デバッグログやUnity専用の機能を使えるようにする 

//public class クラス名:継承しているクラス名       UnityのスクリプトではMonoBehaviourを基本的に継承  MonoBehaviouを継承することで(MonoBehaviourクラスで定義されている変数、関数である)Start関数やUpdate関数、transform変数、gameObject変数などが使えるようになる。
public class Controller : MonoBehaviour　
{
    public float tilt; //Playerゲームオブジェクトを傾ける角度の設定値(この値の中でランダムな値を取得するので、15～30前後で設定すること)。Inspectorで変更できるようにするためpublicで宣言している。
    public float duration; //Playerゲームオブジェクトを傾ける時間の設定値(この値が大きいとずっと傾いたままになるので、一瞬になるように0.1～0.25前後で設定すること)。Inspectorで変更できるようにするためpublicで宣言している。
    public bool isTilt; //playerゲームオブジェクトが傾いているときtrue、傾いていないときfalse

    
    [UnityEngine.Header("バーの移動速度"),Range(0.05f,1.0f)]
    public float playerSpeed; //Player(バー)の移動速度

    [Header("バーの移動範囲の制限値")]
    public float limitPos = 2.9f; //InspectorのlimitPosに自分で書いた値が優先して代入される(InspectorのLimitPosに書いた値は2.9で上書きされない)
    
    // 実行時に初めに1回呼ばれる関数
    void Start() 
    {
        Vector3 pos = Vector3.right;

    }
    

    // Startが呼ばれた後に実行される関数。ずっと動いていて、イベントが起こるのを待っている。
    void Update()
    {
        //もしも左矢印キーがおされたら 　条件式としてはtrue,false　InputはUnityが持っている独自のクラス。Input.～()=Inputクラスが持っている～関数を呼び出す   GetKey(～ボタン)=～ボタンが押されたときだけtrue   GetKeyは押し続けている間で離した瞬間にfalseになる。
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
            //このコンポーネント(=スクリプト)を持っているオブジェクトのTransformコンポーネントのpositionのz座標から0.1を引きなさい．
            //transform.position -= transform.forward * 0.1f;

            //このコンポーネント(=スクリプト)を持っているオブジェクト(=Playerゲームオブジェクト)のTransformコンポーネントのpositionのz座標からplayerSpeedを引きなさい．
            transform.position -= transform.forward * playerSpeed;
        }

        //バーの移動範囲を制限(transformコンポーネントのpositionのz座標を－3.45から3.45の範囲に制限する)
        float z = Mathf.Clamp(transform.position.z, -limitPos, limitPos);

        //このコンポーネント(=スクリプト)を持っているオブジェクト(=Playerゲームオブジェクト)のTransformコンポーネントのPositionのx座標とy座標はそのままで、z座標だけ変数zの値(=バーの移動範囲である－3.45から3.45までのいずれかの値)にする。　　
        transform.position = new Vector3(transform.position.x, transform.position.y, z);


        //もしマウスの右ボタンが(押されていない状態から)押されて、isTiltがfalse(=Playerゲームオブジェクトが傾いていない)なら
        if (Input.GetMouseButtonDown(1)&& !isTilt)
        {
            //コルーチンであるTiltメソッドを実行する(＝Playerゲームオブジェクトを傾けた後、元に戻す)。
            StartCoroutine(Tilt());
        }

        //このコンポーネント(=スクリプト)を持っているオブジェクト(=Playerゲームオブジェクト)のTransformコンポーネントのPositionのx座標を-6.5、y座標とz座標はそのままにする（＝Playerゲームオブジェクトの高さを一定に保つための処理）
        transform.position = new Vector3(-6.5f, transform.position.y, transform.position.z);

    }

    ///<summary>
        ///Playerゲームオブジェクトを傾ける
        ///</summary>
        ///<returns></returns>
        private IEnumerator Tilt()
        {
        //このスクリプトがアタッチ(=適用)されているゲームオブジェクト(=Playerゲームオブジェクト)のTransformコンポーネントのRotationのXの値を0、Yの値を-tiltからtiltまでの範囲で作った乱数の値、Zの値を0とする(=Playerゲームオブジェクトを傾いている状態にする)。
        transform.eulerAngles = new Vector3(0, Random.Range(-tilt, tilt), 0);

        //playerゲームオブジェクトが傾いている状態になったのでその印としてisTiltをtrueにする。
        isTilt = true;

        //次の処理に行くまでduration(=Playerゲームオブジェクトを傾ける時間)秒待つ(=処理をduration秒停止させる)。　　
        yield return new WaitForSeconds(duration);

        //playerゲームオブジェクトを傾いていない状態にする前にisTiltをfalseにする。
        isTilt = false;

        //このスクリプトがアタッチ(=適用)されているゲームオブジェクト(=Playerゲームオブジェクト)のTransformコンポーネントのRotationのXの値を0、Yの値を0、Zの値を0とする(=Playerゲームオブジェクトを傾いていない状態にする)。
        transform.eulerAngles = Vector3.zero;

        }
       
}
