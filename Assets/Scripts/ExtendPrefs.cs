using UnityEngine;

public class ExtendPrefs : MonoBehaviour
{

    public void SaveBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public bool GetBool(string key, bool defaultValue = false)
    {
        // �f�t�H���g�l��bool����int�ɕϊ�����
        int defaultInt = defaultValue ? 1 : 0;
        // PlayerPrefs����int���擾���A���ꂪ1�Ȃ�true�A����ȊO�Ȃ�false��Ԃ�
        return PlayerPrefs.GetInt(key, defaultInt) == 1;
    }
}
