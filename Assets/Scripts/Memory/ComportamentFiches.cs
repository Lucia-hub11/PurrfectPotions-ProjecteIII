using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Codigo para el funcionamiento del juego

public class ComportamentFiches : MonoBehaviour
{
    public Ingredient mushroom;
    [SerializeField] Fiches cardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Canvas memoryCanvas;

    private List<Sprite> spritePairs;
    private List<Fiches> allCards;

    Fiches firstSelected;
    Fiches secondSelected;

    private void Start()
    {
        PrepareSprites();
        CreateCards();
    }

    private void PrepareSprites()
    {
        spritePairs = new List<Sprite>();
        for(int i=0; i<sprites.Length; i++)
        {
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }

        ShuffleSprites(spritePairs);
    }

    void CreateCards()
    {
        allCards = new List<Fiches>();

        for(int i=0; i<spritePairs.Count; i++)
        {
            Fiches card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
            card.controller = this;
            allCards.Add(card);
        }
    }

    public IEnumerator ShowCards()
    {
        Debug.Log("holiii");
        foreach (var card in allCards)
        {
            card.Show();
        }

        yield return new WaitForSeconds(10f);

        foreach (var card in allCards)
        {
            card.Hide();
            Debug.Log("las escondooo");
        }
    }

    public void SetSelected(Fiches card)
    {
        if (card.isSelected ==false)
        {
            card.Show();

            if (firstSelected ==null)
            {
                firstSelected = card;
                return;
            }

            if (secondSelected ==null)
            {
                secondSelected = card;
                StartCoroutine(CheckMatching(firstSelected, secondSelected));
            }
        }
    }

    IEnumerator CheckMatching(Fiches a, Fiches b)
    {
        yield return new WaitForSeconds(0.3f);
        if(a.iconSprite == b.iconSprite)
        {
            //no fa res, es queden emparellades
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            RestartGame();
        }

        firstSelected = null;
        secondSelected = null;
        CheckGameOver();
    }

    void RestartGame()
    {
        foreach (var card in allCards)
        {
            card.Hide();
        }
    }

    void ShuffleSprites(List<Sprite> spriteList)
    {
        for (int i = spriteList.Count -1; i>0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex];
            spriteList[randomIndex] = temp;
        }
    }

    void CheckGameOver()
    {
        foreach (var card in allCards)
        {
            if (card.isHidden())
            {
                return;
            }
        }
        memoryCanvas.enabled = false;
        mushroom.CollectIngredient();
    }
}
