using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //これがあることで、UnityEngine.UI.Textと書かなくてもよくなる

public class TextDataFetcher : MonoBehaviour
{
    public Text resultMessageText;//Testクラス型の参照型変数resultMessageTextには、このスクリプトが適用されているオブジェクト(=Masterオブジェクト)のInspecterタブのResultMessageTextに指定したオブジェクト(＝結果を入れる方のTextゲームオブジェクト)のID番号が格納される。
    public AudioClip[] audioClips;//AudioClipクラス型の配列audioClipsの要素には、このスクリプトを適用したMasterオブジェクトのInspectorタブのAudio ClipsのElement0、Element1に指定した音楽のID番号が格納される
    public AudioSource audioSource; //AudioSourceクラス型の参照型変数audioSourceには、このスクリプトを適用したMasterゲームオブジェクトのInspectorタブのAudio Sourceに指定したAudioオブジェクトのID番号が格納される

    void Start()
    {
        resultMessageText.text = DataSender.resultMessage; //resultMessageTextに格納されているID番号が指すオブジェクト(＝結果を入れる方のTextゲームオブジェクト)の参照型変数textに、DataSenderクラスの参照型変数resultmessageに格納されているID番号が指すオブジェクト(＝新しい文字列が記載されているオブジェクト)のID番号を代入する。これによって、結果を入れる方のTextゲームオブジェクトの文字列が新しい文字列に入れ替わる。

        //もしDataSenderクラスの変数isClearがtrueなら
        if (DataSender.isClear)
        {
            audioSource.clip = audioClips[0]; //(配列audioClipsの先頭アドレス+0番目のアドレスの中身である)Element0のID番号を参照型変数clipに格納する 
        }
        //もしDataSenderクラスの変数isClearがfalseなら
        else
        {
            audioSource.clip = audioClips[1]; //(配列audioClipsの先頭アドレス+1番目のアドレスの中身である)Element1のID番号を参照型変数clipに格納する 
        }
  
        audioSource.Play();//参照型変数clipに格納されているID番号が指し示す音楽を再生する

    }


    void Update()
    {

    }
}
