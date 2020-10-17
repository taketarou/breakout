using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BoxプレファブとHardBoxプレファブにアタッチされるスクリプト(Awakeメソッドが存在するBoxInitスクリプトが実行されてからこのスクリプトが実行される。その場合、BoxInitスクリプトによってBoxプレファブのCloneとHardBoxプレファブのClone(Destroyerスクリプトがアタッチされている)が生成されているので、Destryoerスクリプトのフィールドには各CloneのDestroyerコンポーネント欄の項目に指定されている値が代入される)
public class Destroyer : MonoBehaviour
{
    public int point;
    public GameObject masterObj; //InspecterタブのMaster Objに指定したオブジェクトのID番号が格納されるが、この場合は、BoxInitスクリプトを通してMasterゲームオブジェクトのID番号が格納される。

    public int initHp; //耐久力の最大値　Box(Clone)の場合1、HardBox(Clone)の場合2が代入される。
    private int currentHp; //耐久力の現在値

    public AudioClip hitSE; //破壊されない場合のSE
    public AudioClip DestroySE; //破壊された場合のSE。button01aというSEのID番号が格納される。

    public Renderer rend; //ブロックの色の変更用。Box(Clone)のID番号、または、HardBox(Clone)のID番号が代入される。
    private ChangeColorOnHit changeColorOnHit; //色を変更するChangeColorOnHitクラスの情報を代入する参照型変数

    // Start is called before the first frame update
    void Start()
    {
        //Boxの耐久力を初期化(現在値＝最大値にする)
        this.currentHp = initHp;

        //Masterゲームオブジェクトが持っているChangeColorOnHitコンポーネント(=ChangeColorOnHitスクリプト)を取得し、そのID番号をchangeColorOnHit変数に代入する。
        changeColorOnHit = masterObj.GetComponent<ChangeColorOnHit>();

        //ChangeColorOnHitコンポーネント(=ChangeColorOnHitスクリプト)のChangeMaterialColor関数を呼び出し、その戻り値(=BlueMaterial、またはGrayMaterial)をBox(Clone)または、HardBox(Clone)のMesh RendererコンポーネントのMaterialsのElement0に代入する。
        rend.material= changeColorOnHit.ChangeMaterialColor(currentHp);
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

        //  壊れる場合(=現在の耐久力が0以下の場合)
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
        //  まだ壊れない場合(=現在の耐久力が1以上の場合)
        else
        {
            //  ボールを跳ね返すSEを再生
            AudioSource.PlayClipAtPoint(hitSE, transform.position);

            //ChangeBlockColorメソッドを呼び出し、ブロックの色を変更
            ChangeBlockColor();
        }

        /*異なる色のブロックを作るでは不要
        FindObjectOfType<Score>().AddPoint(point); //ScoreスクリプトのAddPoint関数を呼び出し、スコアを加算する。　FindObjectOfTypeは主にコンポーネントの型を取るときに使う。

        //masterObjが示すゲームオブジェクト(=この場合は、Masterゲームオブジェクト)のGameMasterコンポーネント(=GameMasterスクリプト)の変数boxNumを－1する。
        masterObj.GetComponent<GameMaster>().boxNum--;

        Destroy(gameObject);
        */
    }


    private void ChangeBlockColor()
    {
        rend.material = changeColorOnHit.ChangeMaterialColor(currentHp);　//ChangeColorOnHitコンポーネント(=ChangeColorOnHitスクリプト)のChangeMaterialColor関数を呼び出し、その戻り値(=BlueMaterial、またはGrayMaterial)をBox(Clone)または、HardBox(Clone)のMesh RendererコンポーネントのMaterialsのElement0に代入する。
    }
}
