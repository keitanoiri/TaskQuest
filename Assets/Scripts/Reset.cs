using UnityEngine;

public class Reset : MonoBehaviour
{
    public void resetplef()
    {
        PlayerPrefs.DeleteAll(); // すべての保存データを削除
    }
}
