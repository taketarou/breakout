using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//StartやUpdateといった関数が必要ないからMonoBehaviourはつけない 　unityのstaticはstart関数やupdate関数を使う必要がないスクリプトで主に使う。
public static class DataSender　
{
    //unityでは、public staticがついた変数はシーンを遷移してもその中身が保持される。ただし、public staticがついた変数はInspectorタブには表示されない(staticをつけるとInspectorタブに表示されなくなる)。
    public static string resultMessage;
    public static bool isClear;
}
