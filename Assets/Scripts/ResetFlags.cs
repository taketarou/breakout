﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFlags : MonoBehaviour
{
    void Start()
    {
        LevelManager.isStart = false;              //  isStartのフラグをfalseにする。isStartはStatic変数(＝クラス変数)なので、インスタンス化(＝オブジェクトを生成)しなくても(＝newを使わなくても)、他のクラスから、「クラス名.変数名」でアクセスすることが可能。
    }
}
