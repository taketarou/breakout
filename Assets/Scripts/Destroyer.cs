using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public int point;
    public GameObject masterObj; //InspecterタブのMaster Objに指定したオブジェクトのID番号が格納されるが、この場合は、BoxInitスクリプトを通してMasterゲームオブジェクトのID番号が格納される。

    public int initHp; //耐久力の最大値
    private int currentHp; //耐久力の現在値

    public AudioClip hitSE; //破壊されない場合のSE
    public AudioClip DestroySE; //破壊された場合のSE。button01aというSEのID番号が格納される。

    // Start is called before the first frame update
    void Start()
    {
        //Boxの耐久力を初期化(現在値＝最大値にする)
        this.currentHp = initHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //このスクリプトが適用されているゲームオブジェクト(=ブロック)にオブジェクトがあたってきたとき、この関数は呼ばれる。あたってきたオブジェクトのID番号が引数として、参照型変数collisionに代入される。
    private void OnCollisionEnter(Collision collision) //privateなしでもいい？
    {
        //ボールが接触する度に耐久力を1ずつ減らす
        this.currentHp -= 1;

        //  壊れる場合
        if (this.currentHp <= 0)
        {
            //  破壊されるSEを再生(このスクリプトがアタッチされているブロックゲームオブジェクトのTransformコンポーネントのPositionの位置で、DestroySEに格納されているID番号が指すbutton01Aを鳴らす)
            AudioSource.PlayClipAtPoint(DestroySE, transform.position);
            // 残りのブロック数を１つ減らす(GameMasterスクリプトのboxNumを1減らす)
            masterObj.GetComponent<GameMaster>().boxNum--;
            // スコアを加算する
            FindObjectOfType<Score>().AddPoint(point);
            // このゲームオブジェクト（ブロック）を破壊する　　　　
            Destroy(this.gameObject);
        }
        //  まだ壊れない場合
        else
        {
            //  ボールを跳ね返すSEを再生
            AudioSource.PlayClipAtPoint(hitSE, transform.position);
        }

        /*異なる色のブロックを作るでは不要
        FindObjectOfType<Score>().AddPoint(point); //ScoreスクリプトのAddPoint関数を呼び出し、スコアを加算する。　FindObjectOfTypeは主にコンポーネントの型を取るときに使う。

        //masterObjが示すゲームオブジェクト(=この場合は、Masterゲームオブジェクト)のGameMasterコンポーネント(=GameMasterスクリプト)の変数boxNumを－1する。
        masterObj.GetComponent<GameMaster>().boxNum--;

        Destroy(gameObject);
        */
    }
}
