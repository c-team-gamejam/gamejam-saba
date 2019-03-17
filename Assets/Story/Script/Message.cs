using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;
public class Message : MonoBehaviour
{

    [SerializeField]
    GameObject image;
    //　メッセージUI
    private Text messageText;
    //　表示するメッセージ
    private string message;
    //　1回のメッセージの最大文字数
    [SerializeField]
    private int maxTextLength = 90;
    //　1回のメッセージの現在の文字数
    private int textLength = 0;
    //　メッセージの最大行数
    [SerializeField]
    private int maxLine = 3;
    //　現在の行
    private int nowLine = 0;
    //　テキストスピード
    [SerializeField]
    private float textSpeed = 0.05f;
    //　経過時間
    private float elapsedTime = 0f;
    //　今見ている文字番号
    private int nowTextNum = 0;
    //　マウスクリックを促すアイコン
    private Image clickIcon;
    //　クリックアイコンの点滅秒数
    [SerializeField]
    private float clickFlashTime = 0.2f;
    //　1回分のメッセージを表示したかどうか
    private bool isOneMessage = false;
    //　メッセージをすべて表示したかどうか
    private bool isEndMessage = false;

    private bool yesPttaern = false;
    private bool noPttaern = false;

    GameManager gameManager;
    ChapterData chapterData;
    ChapterData.ChapterInfo textList;
    private List<string> textScripts;
    private List<string> yesPattern;
    private List<string> noPattern;
    IEnumerator DisplayText()
    {

         gameManager = GameManager.Instance;
         chapterData = gameManager.ChapterData;
         textList = chapterData.ChapterDataList.Find((chapter) => chapter.Title == gameManager.currentChapter);
         textScripts = textList.TextResourses;
         yesPattern = textList.YesPatternText;
         noPattern = textList.NoPatternText;

        clickIcon = image.GetComponent<Image>();
        clickIcon.enabled = false;
        messageText = GetComponentInChildren<Text>();
        messageText.text = "";
        //SetMessage
        //(
        // textScripts[0]
        //);

        foreach (var text in textScripts)
        {
            SetMessagePanel(text);

            yield return new WaitUntil(() =>
            {
                if (isEndMessage)
                {
                    Debug.Log("true");
                    return true;
                }
                Debug.Log("false");
                return false;
            });
        }
        if (yesPttaern)
        {
            foreach (var yes in yesPattern)
            {
                SetMessagePanel(yes);
                yield return new WaitUntil(() =>
                {
                    if (isEndMessage)
                    {
                        Debug.Log("true");
                        return true;
                    }
                    Debug.Log("false");
                    return false;
                });
            }

        }
        if (noPttaern)
        {
            foreach (var no in noPattern)
            {
                SetMessagePanel(no);
                yield return new WaitUntil(() =>
                {
                    if (isEndMessage)
                    {
                        Debug.Log("true");
                        return true;
                    }
                    Debug.Log("false");
                    return false;
                });
            }
        }
    }

    bool Flag()
    {

        return false;
    }

   public void YesButton()
    {
        yesPttaern = true;
    }

   public void NoButton()
    {
        noPttaern = true;
    }


   public void Start()
    {
        StartCoroutine(DisplayText());

    }
   public void Update()
    {
        //　メッセージが終わっていない、または設定されている
        if (isEndMessage || message == null)
        {
            return;
        }

        //　1回に表示するメッセージを表示していない	
        if (!isOneMessage)
        {

            //　テキスト表示時間を経過したら
            if (elapsedTime >= textSpeed)
            {
                messageText.text += message[nowTextNum];
                //　改行文字だったら行数を足す
                if (message[nowTextNum] == '\n')
                {
                    nowLine++;
                }
                nowTextNum++;
                textLength++;
                elapsedTime = 0f;

                //　メッセージを全部表示、または行数が最大数表示された
                if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine)
                {
                    isOneMessage = true;
                }
            }
            elapsedTime += Time.deltaTime;

            //　メッセージ表示中にマウスの左ボタンを押したら一括表示
            if (Input.GetMouseButtonDown(0))
            {
                //　ここまでに表示しているテキストを代入
                var allText = messageText.text;

                //　表示するメッセージ文繰り返す
                for (var i = nowTextNum; i < message.Length; i++)
                {
                    allText += message[i];

                    if (message[i] == '\n')
                    {
                        nowLine++;
                    }
                    nowTextNum++;
                    textLength++;

                    //　メッセージがすべて表示される、または１回表示限度を超えた時
                    if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine)
                    {
                        messageText.text = allText;
                        isOneMessage = true;
                        break;
                    }
                }
            }
            //　1回に表示するメッセージを表示した
        }
        else
        {

            elapsedTime += Time.deltaTime;

            //　クリックアイコンを点滅する時間を超えた時、反転させる
            if (elapsedTime >= clickFlashTime)
            {
                clickIcon.enabled = !clickIcon.enabled;
                elapsedTime = 0f;
            }

            //　マウスクリックされたら次の文字表示処理
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(messageText.text.Length);
                messageText.text = "";
                nowLine = 0;
                clickIcon.enabled = false;
                elapsedTime = 0f;
                textLength = 0;
                isOneMessage = false;


                //　メッセージが全部表示されていたらゲームオブジェクト自体の削除
                if (nowTextNum >= message.Length)
                {
                    nowTextNum = 0;
                    isEndMessage = true;
                    // transform.GetChild(0).gameObject.SetActive(false);
                    //　それ以外はテキスト処理関連を初期化して次の文字から表示させる
                }
            }
        }
    }

    void SetMessage(string message)
    {
        this.message = message;
    }
    //　他のスクリプトから新しいメッセージを設定
    public void SetMessagePanel(string message)
    {
        SetMessage(message);
        transform.GetChild(0).gameObject.SetActive(true);
        isEndMessage = false;
    }
}