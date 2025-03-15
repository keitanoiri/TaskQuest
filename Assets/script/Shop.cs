using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Shop : ExtendPrefs
{
    public GameObject gachaBall; // ガチャのボールと報酬画像オブジェクト
    public RawImage rewardImage; // 報酬の画像オブジェクト (RawImageを使用する)
    public List<Sprite> numberImages; // 1〜10までの数字の画像リスト
    public ParticleSystem particleSystem; // パーティクルシステム
    public int random = 10; // ランダムに選ぶ数字の上限値（1〜10）
    public float scaleSpeed = 1.0f; // スケール変更の速度
    public float rotationSpeed = 360.0f; // 回転の速度
    public float rotationDuration = 2.0f; // 回転の持続時間
    public float dropDistance = 1.0f; // ガチャボールの落下距離
    public float dropDuration = 0.5f; // ガチャボールの落下時間

    [SerializeField] GameManager manager;
    [SerializeField] int value;

    private bool isAnimating = false; // アニメーション中のフラグ


    void Update()
    {
        // 画面クリックを検知
        if (Input.GetMouseButtonDown(0))
        {
            // Reward Imageを非表示にする
            rewardImage.gameObject.SetActive(false);
            Debug.Log("Reward Imageを非表示にしました。");
        }
    }

    // ボタンが押されたときに呼び出される関数
    public void OnBuy()
    {
        if(manager.Money > 0){
        Debug.Log("ガチャを購入しました。");
        manager.Money -= value;
        if (!isAnimating)
        {
            StartCoroutine(PlayAnimation());
        }
        }
    }

    // アニメーションを再生するコルーチン
    private IEnumerator PlayAnimation()
    {
        Debug.Log("PlayAnimation開始");
        isAnimating = true;

        // ガチャボールと報酬画像を非表示にする
        gachaBall.SetActive(false);
        rewardImage.gameObject.SetActive(false);
        rewardImage.transform.localScale = Vector3.zero;
        Debug.Log("ガチャボールと報酬画像を非表示にしました。");

        // ガチャボールを表示して回転アニメーションを開始
        gachaBall.SetActive(true);
        Debug.Log("ガチャボールを表示しました。");
        yield return StartCoroutine(RotateObject());

        // ランダムな報酬画像を設定
        int randomIndex = Random.Range(0, random);
        rewardImage.texture = numberImages[randomIndex].texture;
        Debug.Log($"ランダムな報酬画像を設定しました: {numberImages[randomIndex].name}");

        // 少し待機してから落下アニメーションを開始
        yield return new WaitForSeconds(0.5f);

        // パーティクルエフェクトを再生する
        if (particleSystem != null)
        {
            particleSystem.Play();
            Debug.Log("パーティクルエフェクトを再生しました。");
        }

        // 報酬画像のスケール変更アニメーションを開始
        yield return StartCoroutine(ShowRandomReward());

        // 画像の名前と1をSaveBoolメソッドに渡す
        SaveBool(numberImages[randomIndex].name, true);
        Debug.Log($"報酬画像の名前をSaveBoolメソッドに渡しました: {numberImages[randomIndex].name}");

        isAnimating = false;
        Debug.Log("PlayAnimation終了");
    }

    // オブジェクトを回転させるコルーチン
    private IEnumerator RotateObject()
    {
        Debug.Log("RotateObject開始");
        float rotationTimer = 0f;

        while (rotationTimer < rotationDuration)
        {
            gachaBall.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            rotationTimer += Time.deltaTime;
            yield return null;
        }
        Debug.Log("RotateObject終了");
    }



    // ランダムな報酬画像を表示し、スケール変更アニメーションを開始するコルーチン
    private IEnumerator ShowRandomReward()
    {
        Debug.Log("ShowRandomReward開始");

        // 報酬画像を表示
        rewardImage.gameObject.SetActive(true);
        Debug.Log("報酬画像を表示しました。");

        // スケール変更アニメーションを開始
        while (rewardImage.transform.localScale.x < 1)
        {
            float newScale = Mathf.MoveTowards(rewardImage.transform.localScale.x, 1, Time.deltaTime * scaleSpeed);
            rewardImage.transform.localScale = new Vector3(newScale, newScale, 1);
            yield return null;
        }

        Debug.Log("ShowRandomReward終了");
    }
}
