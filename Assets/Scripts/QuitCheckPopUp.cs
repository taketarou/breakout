using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitCheckPopUp : MonoBehaviour //QuitCheckPopUpプレハブにアタッチされるスクリプト
{
    public Button btnQuitGame;        //btnQuitGameゲームオブジェクト（＝ゲーム終了ボタン）にくっついているButtonコンポーネントのID番号が代入される。
    public Button btnClosePopup;      //btnClosePopUpゲームオブジェクト（＝ゲームに戻るボタン）にくっついているButtonコンポーネントのID番号が代入される。

    void Start()
    {
        //btnQuitGame.onClick.AddListener(GameMaster.QuitGame); //btnQuitGameゲームオブジェクト（＝ゲーム終了ボタン）にくっついているButtonコンポーネント中の「On Click()」という項目中の「None」に「btnQuitGameゲームオブジェクト」を、「No Function」に「GameMasterスクリプトのQuitGame関数」を代入する(これにより、btnQuitGameゲームオブジェクト（＝ゲーム終了ボタン）がクリックされたとき、GameMasterスクリプトのQuitGame関数が呼び出されるようになる)。
        btnQuitGame.onClick.AddListener(QuitGameManager.QuitGame); //Titleシーン以外のシーンだと効かなくなる。

        btnClosePopup.onClick.AddListener(OnClickClosePopUp); //btnClosePopUpゲームオブジェクト（＝ゲームに戻るボタン）にくっついているButtonコンポーネント中の「On Click()」という項目中の「None」に「btnClosePopUpゲームオブジェクト」を、「No Function」に「OnClickClosePopUp関数」を代入する(これにより、btnClosePopUpゲームオブジェクト（＝ゲームに戻るボタン）がクリックされたとき、OnClickClosePopUp関数が呼び出されるようになる)。

        // ゲーム内時間の流れを停止 
        Time.timeScale = 0;
    }

    /// <summary>
    /// ポップアップを閉じてゲームに戻る
    /// </summary>
    private void OnClickClosePopUp()
    {
        // ゲーム内時間の流れを再開する
        Time.timeScale = 1.0f;
        Destroy(gameObject); //この処理により、ポップアップが消え、ポップアップのID番号が代入されているGameMasterスクリプトのquitCheckPopUp変数の中身もnullとなる。
    }
}
