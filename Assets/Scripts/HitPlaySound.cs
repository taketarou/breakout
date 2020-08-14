using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlaySound : MonoBehaviour
{

    public AudioClip sound; //AudioClipクラス型の参照型変数soundにはこのスクリプトが適用されているゲームオブジェクトのInspectorタブのSoundに指定したsoundのID番号が代入される。

    //このスクリプトが適用されているゲームオブジェクトにオブジェクトがあたってきたとき、この関数は呼ばれる。あたってきたオブジェクトのID番号が引数として、参照型変数collisionに代入される。
    void OnCollisionEnter(Collision collision)
    {
        //このスクリプトが適用されているゲームオブジェクトと同じ位置で、soundに格納されているID番号が指すオブジェクト(=効果音)を鳴らす(繰り返しなし)
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

}
