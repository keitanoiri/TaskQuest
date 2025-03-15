using UnityEngine;

public class ExtendPrefs : MonoBehaviour
{

    public void SaveBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public bool GetBool(string key, bool defaultValue = false)
    {
        // デフォルト値もboolからintに変換する
        int defaultInt = defaultValue ? 1 : 0;
        // PlayerPrefsからintを取得し、それが1ならtrue、それ以外ならfalseを返す
        return PlayerPrefs.GetInt(key, defaultInt) == 1;
    }
}
