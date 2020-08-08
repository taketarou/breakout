using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //これがあることで、UnityEngine.UI.Textと書かなくてもよくなる

public class TextDataFetcher : MonoBehaviour
{
    public Text resultMessageText;//Testクラス型の参照型変数resultMessageTextには、このスクリプトが適用されているゲームオブジェクト(=Masterオブジェクト)のInspecterタブのResultMessageTextに指定したオブジェクト(＝結果を入れる方のTextゲームオブジェクト)のID番号が格納される。
    public AudioClip[] audioClips;
    public AudioSource audioSource; 

    void Start()
    {
        resultMessageText.text = DataSender.resultMessage; //resultMessageTextに格納されているID番号が指すオブジェクト(＝結果を入れる方のTextゲームオブジェクト)の参照型変数textに、DataSenderクラスの参照型変数resultmessageに格納されているID番号が指すオブジェクト(＝新しい文字列が記載されているオブジェクト)のID番号を代入する。これによって、結果を入れる方のTextゲームオブジェクトの文字列が新しい文字列に入れ替わる。

        if (DataSender.isClear)
        {
            audioSource.clip = audioClips[0];
        }
        else
        {
            audioSource.clip = audioClips[1];
        }

        audioSource.Play();
        
    }


    void Update()
    {

    }
}
