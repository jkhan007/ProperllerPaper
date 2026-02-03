using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Net.NetworkInformation;
using UnityEngine.UI;
using TMPro;


[Serializable]
public struct PlayerSkinData
{
    [SerializeField]
    private string skinName;
    [SerializeField]
    private Sprite skinSprite;
    [SerializeField]
    private float coinsSkinPrice;
    [SerializeField]
    private float inAppSkinPrice;

    public readonly string SkinName => skinName;
    public readonly Sprite SkinSprite => skinSprite;
    public readonly float CoinsSkinPrice => coinsSkinPrice;
    public readonly float InAppSkinPrice => inAppSkinPrice;
}

[Serializable]
public struct CatSkinData
{
    [SerializeField]
    private string skinName;
    [SerializeField]
    private Sprite skinSprite;
    [SerializeField]
    private float coinsSkinPrice;
    [SerializeField]
    private float inAppSkinPrice;

    public readonly string SkinName => skinName;
    public readonly Sprite SkinSprite => skinSprite;
    public readonly float CoinsSkinPrice => coinsSkinPrice;
    public readonly float InAppSkinPrice => inAppSkinPrice;
}

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject playerSkinImgPrefab;
    [SerializeField]
    private Transform playerSkinsContent;

    [SerializeField]
    private GameObject catSkinImgPrefab;
    [SerializeField]
    private Transform catSkinsContent;

    [SerializeField]
    private List<PlayerSkinData> playerSkinDatasList;
    [SerializeField]
    private List<CatSkinData> catSkinDatasList;

    [SerializeField]
    private GameObject playerSkinStoreScrollViewGO;
    [SerializeField]
    private GameObject catSkinStoreScrollViewGO;
    [SerializeField]
    private Button[] storePanelSectionBtns;
    [SerializeField]
    private Sprite[] sectionBtnSprites;
    [SerializeField]
    private Color[] storeSectionBtnStateColors;

    [SerializeField]
    private GameObject storePanelGO;
    [SerializeField]
    private GameObject leaderBoardGO;

    [SerializeField]
    private GameObject leaderBoardScoreContainerPrefab;
    [SerializeField]
    private Transform leaderBoardScoreContent;
    [SerializeField]
    private TextMeshProUGUI leaderBoardYourScoreTxt;
    [SerializeField]
    private TextMeshProUGUI leaderBoardCurrentTopScore;

    private string[] dummyleaderBoardNames;

    //private List<LeaderBoardScoreContainer> leaderBoardScoreContainersList;
    private List<PlayerSkinImg> playerSkinImgsList;
    private List<CatSkinImg> catSkinImgsList;

    private TextMeshProUGUI sectionBtn0TxtColor;
    private TextMeshProUGUI sectionBtn1TxtColor;

    private void Start()
    {
        InitializeStorePanel();
        InitializeLeaderBoardData();
    }


    #region LeaderBoard Panel

    private void InitializeLeaderBoardData()
    {
        //leaderBoardScoreContainersList = new List<LeaderBoardScoreContainer>();
        dummyleaderBoardNames = new string[] { "Aaaa", "Bbbb", "CCCC", "DDDD", "Eeee", "Fffff", "Ggggg" };
        InstantiateLeaderBoardData();
    }


    private void InstantiateLeaderBoardData()
    {
        leaderBoardYourScoreTxt.text = $"{UnityEngine.Random.Range(100, 7000)}";
        leaderBoardCurrentTopScore.text = $"{UnityEngine.Random.Range(100, 7000)}";

        for (int i = 0; i < dummyleaderBoardNames.Length; i++)
        {
            GameObject leaderBoardScoreContainerGO = Instantiate(leaderBoardScoreContainerPrefab, leaderBoardScoreContent);
            LeaderBoardScoreContainer leaderBoardScoreCtn = leaderBoardScoreContainerGO.GetComponent<LeaderBoardScoreContainer>();
            leaderBoardScoreCtn.LeaderBoardScoreCtnIndex = i;

            leaderBoardScoreCtn.PlayerPositionTxt.text = $"{leaderBoardScoreCtn.LeaderBoardScoreCtnIndex + 1}";
            leaderBoardScoreCtn.PlayerNameLeaderboardTxt.text = dummyleaderBoardNames[leaderBoardScoreCtn.LeaderBoardScoreCtnIndex];
            leaderBoardScoreCtn.PlayerLeaderBoardScoreTxt.text = $"{UnityEngine.Random.Range(100, 7000)}";
        }
    }

    #endregion

    #region Store Panel

    private void InitializeStorePanel()
    {
        playerSkinImgsList = new List<PlayerSkinImg>();
        catSkinImgsList = new List<CatSkinImg>();

        sectionBtn0TxtColor = storePanelSectionBtns[0].GetComponentInChildren<TextMeshProUGUI>();
        sectionBtn1TxtColor = storePanelSectionBtns[1].GetComponentInChildren<TextMeshProUGUI>();

        AssignSectionBtns();

        InstantiatePlayerSkinImgs();
        InstantiateCatSkinImgs();
    }

    private void InstantiatePlayerSkinImgs()
    {
        for (int i = 0; i < playerSkinDatasList.Count; i++)
        {
            GameObject playerSkinImgGO = Instantiate(playerSkinImgPrefab, playerSkinsContent);
            PlayerSkinImg playerSkin = playerSkinImgGO.GetComponent<PlayerSkinImg>();
            playerSkinImgsList.Add(playerSkin);
            playerSkin.PlayerSkinImgIndex = i;
            playerSkin.PlayerSkinSpriteImg.sprite = playerSkinDatasList[playerSkin.PlayerSkinImgIndex].SkinSprite;
            playerSkin.PlayerSkinSpriteImg.SetNativeSize();
            playerSkin.PlayerSkinSpriteImg.rectTransform.sizeDelta = new Vector2(46f, 63f);
            playerSkin.PlayerSkinNameTxt.text = playerSkinDatasList[playerSkin.PlayerSkinImgIndex].SkinName;
            playerSkin.CoinsBuyAmountTxt.text = $"{playerSkinDatasList[playerSkin.PlayerSkinImgIndex].CoinsSkinPrice}";
            playerSkin.InAppPlayerSkinBuyAmountTxt.text = $"$ {playerSkinDatasList[playerSkin.PlayerSkinImgIndex].InAppSkinPrice}";
            playerSkin.CoinsBuyBtn.onClick.RemoveAllListeners();
            playerSkin.CoinsBuyBtn.onClick.AddListener(() => PlayerSkinOnCoinsBuy());
        }
    }

    private void InstantiateCatSkinImgs()
    {
        for (int i = 0; i < catSkinDatasList.Count; i++)
        {
            GameObject catSkinImgGO = Instantiate(catSkinImgPrefab, catSkinsContent);
            CatSkinImg catSkin = catSkinImgGO.GetComponent<CatSkinImg>();
            catSkinImgsList.Add(catSkin);
            catSkin.CatSkinImgIndex = i;
            catSkin.CatSkinSpriteImg.sprite = catSkinDatasList[catSkin.CatSkinImgIndex].SkinSprite;
            catSkin.CatSkinSpriteImg.SetNativeSize();
            catSkin.CatSkinSpriteImg.rectTransform.sizeDelta = new Vector2(58f, 64f);
            catSkin.CatSkinNameTxt.text = catSkinDatasList[catSkin.CatSkinImgIndex].SkinName;
            catSkin.CoinsBuyAmountTxt.text = $"{catSkinDatasList[catSkin.CatSkinImgIndex].CoinsSkinPrice}";
            catSkin.InAppCatSkinBuyAmountTxt.text = $"$ {catSkinDatasList[catSkin.CatSkinImgIndex].InAppSkinPrice}";
            catSkin.CoinsBuyBtn.onClick.RemoveAllListeners();
            catSkin.CoinsBuyBtn.onClick.AddListener(() => CatSkinOnCoinsBuy());
        }
    }

    private void PlayerSkinOnCoinsBuy()
    {
        Debug.Log("Buy Player Skin");
    }

    private void CatSkinOnCoinsBuy()
    {
        Debug.Log("Buy Cat");
    }

    private void PlayerSkinSectionBtn()
    {
        catSkinStoreScrollViewGO.SetActive(false);
        playerSkinStoreScrollViewGO.SetActive(true);
        storePanelSectionBtns[0].image.sprite = sectionBtnSprites[0];
        storePanelSectionBtns[1].image.sprite = sectionBtnSprites[1];
        sectionBtn0TxtColor.color = storeSectionBtnStateColors[0];
        sectionBtn1TxtColor.color = storeSectionBtnStateColors[1];
    }

    private void CatSkinSectionBtn()
    {
        playerSkinStoreScrollViewGO.SetActive(false);
        catSkinStoreScrollViewGO.SetActive(true);
        storePanelSectionBtns[1].image.sprite = sectionBtnSprites[0];
        storePanelSectionBtns[0].image.sprite = sectionBtnSprites[1];
        sectionBtn1TxtColor.color = storeSectionBtnStateColors[0];
        sectionBtn0TxtColor.color = storeSectionBtnStateColors[1];
    }

    private void AssignSectionBtns()
    {
        storePanelSectionBtns[0].onClick.RemoveAllListeners();
        storePanelSectionBtns[0].onClick.AddListener(() => PlayerSkinSectionBtn());
        storePanelSectionBtns[1].onClick.RemoveAllListeners();
        storePanelSectionBtns[1].onClick.AddListener(CatSkinSectionBtn);
    }

    #endregion

    public void SetStoreActiveState(bool isActive)
    {
        storePanelGO.SetActive(isActive);
    }

    public void SetLeaderBoardActiveState(bool isActive)
    {
        leaderBoardGO.SetActive(isActive);
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(1);
    }
}
