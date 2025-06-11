using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Renpy : MonoBehaviour
{
    [SerializeField] Image img_BG;
    [SerializeField] Image[] img_Character;

    [SerializeField] TextMeshProUGUI txt_Name;
    [SerializeField] TextMeshProUGUI txt_NameTitle;
    [SerializeField] TextMeshProUGUI txt_Dialog;

    int id = 1;

    [SerializeField] Button Btn_Next;
    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    public void OnClickButton()
    {
        id++;

        RefreshUI();
    }

    // Update is called once per frame
    public void RefreshUI()
    {
        int characterID = SData.GetDialogueData(id).Character; // 대사 테이블의 1번 ID의 캐릭터 ID를 가지고 온다

        txt_Name.text = SData.GetCharacterData(characterID).Name; // 캐릭터 테이블에서 캐릭터 ID에 해당하는 이름을 가지고 온다
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title;
        txt_Dialog.text = SData.GetDialogueData(id).Dialogue;

        img_BG.sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetDialogueData(id).BG);

        for (int i = 0; i < img_Character.Length; i++)
        {
            if (i == SData.GetDialogueData(id).Position)
            {
                img_Character[i].sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetCharacterData(characterID).Image);
                img_Character[i].gameObject.SetActive(true);
            }
            else
            {
                img_Character[i].gameObject.SetActive(false);
            }
        }


    }
}
