using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShot : MonoBehaviour
{
    //private Rigidbody rb; //Rigidbodyクラス型の参照型変数rb

    [Header("ボールを打ち出す力の大きさ")]
    public float addSpeed; //100が代入される

    [Header("ボールが打ち出されているか否か")]
    public bool isShooted = false;

    // Start is called before the first frame update
    void Start()
    {
        //このスクリプトが適用されているゲームオブジェクト(=Ball)が持っているRigidbodyコンポーネントのID番号を返し、参照型変数rbに代入する。もし、Rigidbodyコンポーネントが存在しなかった場合、戻り値としてnullを返し、rbに代入する。
        //rb = GetComponent<Rigidbody>();

        //このスクリプトが適用されているゲームオブジェクト(=Ball)の親オブジェクトをPlayerというタグがついたゲームオブジェクト(=Playerゲームオブジェクト)とする（これによりPlayerが動くとBallも一緒に動くようになる)。
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);

        Debug.Log(this.gameObject.name); //このスクリプトがアタッチされているゲームオブジェクトの名前をコンソールビューに出す。

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
        /*
        if (Input.GetMouseButtonDown(0) && rb.velocity.z == 0) //もしマウスの左ボタンが(押されていない状態から)押されて、かつ、BallのRigidbodyコンポーネントのinfoのVelocity(=速度ベクトル)のz軸の値が0(=ボールが動いていない)なら      rb.velocity.x== 0でも良い
        {
        */
        if(Input.GetMouseButtonDown(0)&& !isShooted) { 
            //このスクリプトが適用されているゲームオブジェクト(=Ball)とその親オブジェクト(=Player)の親子関係を解消する
            transform.parent = null;

            //Main Cameraゲームオブジェクトから、ゲーム実行中にマウスクリックした位置（＝現在のマウスの位置）までRayを発射し、そのRayをstruct Ray型の構造体変数rayに代入する。　
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //struct Ray型の構造体変数rayに入っているRayを赤色でSceneビューに1秒間描く。
            Debug.DrawRay(ray.origin,ray.direction,Color.red,1.0f);

            //struct RaycastHit型の構造体変数rayCastHit(=struct RaycastHit型の構造体rayCastHit)の宣言。この時点で構造体のメモリが確保される。
            RaycastHit rayCastHit;

            //rayに格納されているRayがオブジェクトの持つコライダーとぶつかっている場合にはtrueを返し、ぶつかっていない場合にはfalseを返す。また、戻り値がtrueの場合には、Rayがぶつかっているオブジェクトの座標(struct RaycastHit型)をstruct RaycastHit型の構造体変数rayCastHitに格納する。
            if (Physics.Raycast(ray, out rayCastHit))
            {
                //Raycastメソッドの戻り値がtrueの場合（＝Rayがオブジェクトの持つコライダーとぶつかっている場合）のみ、if文内の処理が実行される。

                //struct Vector3型の構造体変数rayHitPosition(=struct Vector3型の構造体rayHitPosition)を宣言し、そこに、Rayがぶつかっているオブジェクト(=Yukaゲームオブジェクト)のX座標と、このスクリプトがアタッチされているゲームオブジェクト(=Ballゲームオブジェクト)のTransformコンポーネントのPosition(=位置)のY座標と、Rayがぶつかっているオブジェクト(=Yukaゲームオブジェクト)のZ座標の3つの値を持つ新規のベクトル(Vector型)を代入する。
                Vector3 rayHitPosition = new Vector3(rayCastHit.point.x, this.transform.position.y, rayCastHit.point.z);

                Debug.Log(rayHitPosition);
                Debug.Log(this.transform.position);

                //YukaゲームオブジェクトのX,Z座標とBallゲームオブジェクトのY座標の3つの値を持つベクトルが代入されているrayHitPositionから、このスクリプトがアタッチされているゲームオブジェクト(=Ballゲームオブジェクト)のTransformコンポーネントのPosition(=位置)の値を持つベクトルを引いた結果(=Ballからゲーム実行中にマウスクリックした位置までの距離)のベクトルを正規化し、それをstruct Vector3型の構造体変数normalDirectionに代入する。
                Vector3 normalDirection = (rayHitPosition - this.transform.position).normalized;

                Debug.Log(normalDirection.magnitude);



                /*
                Vector3 pos = new Vector3(3.0f, 4.0f, 5.0f);
                Vector3 nlz = pos.normalized;

                Debug.Log(pos);
                Debug.Log(nlz);
                Debug.Log(pos.normalized);
                Debug.Log(pos.normalized.x);
                */

                //
                this.GetComponent<Rigidbody>().AddForce(normalDirection * (500 + (LevelManager.level * addSpeed)));

                //
                isShooted = true;


                /*
                //このスクリプトが適用されているゲームオブジェクト(=Ball)のTransformコンポーネントの回転角情報(=Rotationの値)をx=0, y=30～120の中からランダムで取り出した値, z=0にする． 文法の詳細としては、Vector3オブジェクト(=Vector3クラスにアクセスするためのオブジェクト)を生成した後、引数を=0, 30～120の中からランダムで取り出した値, 0とし(Vector3クラスにある)Vector3コンストラクタを呼びだす(=Vector3クラスに定義されている変数x,y,zに0, 30～120の中からランダムで取り出した値,0がそれぞれ格納される？)。そして、Vector3オブジェクトのID番号を、(Monobehaviourクラスに定義されている)参照型変数transformに格納されているID番号が指すオブジェクト(=Vector3オブジェクト)に定義されている参照型変数eulerAnglesに格納する(eulerAngles.～とすることでVector3オブジェクトのID番号が指すオブジェクトであるVector3オブジェクト(=Vector3クラス)の変数～にアクセスできる)。    ベクトル2,ベクトル3,ベクトル4(引数の数によってどれを使うかが変わる)。オイラーアングルズ=InspectorタブのRotationの情報
                transform.eulerAngles = new Vector3(0, Random.Range(30, 120), 0);

                //LevelManager.level=ステージをクリアした回数(値は0から始まる) ステージ1の場合、LevelManager.levelが0なので、transform.forward*500となり、z軸という方向(=前方向)に500の力を加えて打ち出す。ステージ2の場合、LevelManager.levelが1なので、transform.forward*600となり、z軸という方向(=前方向)に600の力を加えて打ち出す。このコードが実行されるとvelocityのx軸とz軸の値が変わる。
                rb.AddForce(transform.forward * (500 + (LevelManager.level * addSpeed)));　
                */
            }
        }
    }

    public void BallDestroy()
    {
        this.gameObject.SetActive(false); //このスクリプトが適用されているゲームオブジェクト(=Ballゲームオブジェクト)をゲーム画面から消す。gameObject.SetActive(false);でも同じ意味。　
    }           
}