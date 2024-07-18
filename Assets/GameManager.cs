using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : SingleTonMono<GameManager>
{
    float enemies_count;

    // Start is called before the first frame update
    private void OnEnable()
    {
        Enemy[] enemy = FindObjectsOfType<Enemy>();
        enemies_count += (from Enemy enm in enemy select enm).Count();
    }

    //[todo] �̺�Ʈ�� ����ͼ� �ϳ��� ����� ��
}
