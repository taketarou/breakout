/*下の三行は消さないでそのまま*/
using System.Collections; //コルーチンやリストなどを使えるようにするための処理　コルーチン＝mainの処理と同時に走ってくれる処理。
using System.Collections.Generic;
using UnityEngine; //デバッグログやUnity専用の機能を使えるようにする 

//public class クラス名:継承しているクラス名       UnityのスクリプトではMonoBehaviourを基本的に継承  MonoBehaviouを継承することで(MonoBehaviourクラスで定義されている変数、関数である)Start関数やUpdate関数、transform変数、gameObject変数などが使えるようになる。
public class Controller : MonoBehaviour　
{

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
            //このコンポーネント(=スクリプト)を持っているオブジェクトのTransformコンポーネントのpositionの値のz方向に0.1足しなさい． tansform.forward=xが0、yも0、zが1という情報が入っている　　　fはフロート型。C#だと小数点の後ろにはfをつける。　transformにはこのスクリプトを適用したオブジェクトの情報が入っている。
            transform.position += transform.forward * 0.1f;
        }
        //もし左矢印キーが押されず、右矢印キーが押されていたら 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //このコンポーネント(=スクリプト)を持っているオブジェクトのtransformコンポーネントのpositionの値をz方向に0.1引きなさい．
            transform.position -= transform.forward * 0.1f;
        }
    }
}
