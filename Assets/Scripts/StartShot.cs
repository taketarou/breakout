using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShot : MonoBehaviour
{
    private Rigidbody rb; //Rigidbodyクラス型の参照型変数rb
    public float addSpeed; //100が代入される

    // Start is called before the first frame update
    void Start()
    {
        //このスクリプトが適用されているゲームオブジェクト(=Ball)が持っているRigidbodyコンポーネントのID番号を返し、参照型変数rbに代入する。もし、Rigidbodyコンポーネントが存在しなかった場合、戻り値としてnullを返し、rbに代入する。
        rb = GetComponent<Rigidbody>();

        /*
        //このスクリプトが適用されているゲームオブジェクトのTransformコンポーネントの回転角情報(=Rotationの値)をx=0, y=30～120の中からランダムで取り出した値, z=0にする． 文法の詳細としては、Vector3オブジェクト(=Vector3クラスにアクセスするためのオブジェクト)を生成した後、引数を=0, 30～120の中からランダムで取り出した値, 0とし(Vector3クラスにある)Vector3コンストラクタを呼びだす(=Vector3クラスに定義されている変数x,y,zに0, 30～120の中からランダムで取り出した値,0がそれぞれ格納される？)。そして、Vector3オブジェクトのID番号を、(Monobehaviourクラスに定義されている)参照型変数transformに格納されているID番号が指すオブジェクト(=Vector3オブジェクト)に定義されている参照型変数eulerAnglesに格納する(eulerAngles.～とすることでVector3オブジェクトのID番号が指すオブジェクトであるVector3オブジェクト(=Vector3クラス)の変数～にアクセスできる)。    ベクトル2,ベクトル3,ベクトル4(引数の数によってどれを使うかが変わる)。オイラーアングルズ=InspectorタブのRotationの情報
        transform.eulerAngles = new Vector3(0, Random.Range(30, 120), 0);

        //z軸という方向(=前方向)に500の力を加えて打ち出す(値によってスピードが変わる)
        //gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 500);

        //LevelManager.level=ステージをクリアした回数(値は0から始まる) ステージ1の場合、LevelManager.levelが0なので、transform.forward*500となり、z軸という方向(=前方向)に500の力を加えて打ち出す。ステージ2の場合、LevelManager.levelが1なので、transform.forward*600となり、z軸という方向(=前方向)に600の力を加えて打ち出す。
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * (500 + (LevelManager.level * addSpeed)));
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rb.velocity.z == 0) //もしマウスの左ボタンが(押されていない状態から)押されて、かつ、BallのRigidbodyコンポーネントのinfoのVelocity(=速度ベクトル)のz軸の値が0(=ボールが動いていない)なら      rb.velocity.x== 0でも良い
        {
            //このスクリプトが適用されているゲームオブジェクト(=Ball)のTransformコンポーネントの回転角情報(=Rotationの値)をx=0, y=30～120の中からランダムで取り出した値, z=0にする． 文法の詳細としては、Vector3オブジェクト(=Vector3クラスにアクセスするためのオブジェクト)を生成した後、引数を=0, 30～120の中からランダムで取り出した値, 0とし(Vector3クラスにある)Vector3コンストラクタを呼びだす(=Vector3クラスに定義されている変数x,y,zに0, 30～120の中からランダムで取り出した値,0がそれぞれ格納される？)。そして、Vector3オブジェクトのID番号を、(Monobehaviourクラスに定義されている)参照型変数transformに格納されているID番号が指すオブジェクト(=Vector3オブジェクト)に定義されている参照型変数eulerAnglesに格納する(eulerAngles.～とすることでVector3オブジェクトのID番号が指すオブジェクトであるVector3オブジェクト(=Vector3クラス)の変数～にアクセスできる)。    ベクトル2,ベクトル3,ベクトル4(引数の数によってどれを使うかが変わる)。オイラーアングルズ=InspectorタブのRotationの情報
            transform.eulerAngles = new Vector3(0, Random.Range(30, 120), 0);

            //LevelManager.level=ステージをクリアした回数(値は0から始まる) ステージ1の場合、LevelManager.levelが0なので、transform.forward*500となり、z軸という方向(=前方向)に500の力を加えて打ち出す。ステージ2の場合、LevelManager.levelが1なので、transform.forward*600となり、z軸という方向(=前方向)に600の力を加えて打ち出す。このコードが実行されるとvelocityのx軸とz軸の値が変わる。
            rb.AddForce(transform.forward * (500 + (LevelManager.level * addSpeed)));　
        }
    }

    public void BallDestroy()
    {
        this.gameObject.SetActive(false); //このスクリプトが適用されているゲームオブジェクト(=Ballゲームオブジェクト)をゲーム画面から消す。gameObject.SetActive(false);でも同じ意味。　
    }           
}
