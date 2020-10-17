using UnityEngine;

public class ChangeColorOnHit : MonoBehaviour
{
    //Hierarchyからカラーをセットするために配列を用意する
    //public Color[] blockColors;

    //HierarchyからカラーをセットするためにMaterialクラス型の配列を用意する。blockColors[0]には灰色を表すGrayMaterialのID番号、blockColors[1]には青色を表すBlueMaterialのID番号が代入される。
    public Material[] blockColors; //配列blockColorsの要素数は2

    /// <summary>
    /// ブロックの色を変更するメソッド。配列のSizeで指定した数が、色の変わる順番と内容になる
    /// </summary>
    /// <param name="index">ブロックの残りのHP</param>
    /// <returns>色</returns>
    public Material ChangeMaterialColor(int index) //indexにはcureentHp(=2、または1)が代入される。
    {
        //  ブロックの色を配列に登録されているIndexの色に変更する。indexが2のときにはBlueMaterial、1のときにはGrayMaterialを返す。
        return blockColors[index-1]; 
    }
}
