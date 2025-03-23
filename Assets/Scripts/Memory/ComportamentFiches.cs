using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentFiches : MonoBehaviour
{
    [SerializeField] Fiches cardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;

    private List<Sprite> spritePairs;

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
        for(int i=0; i<spritePairs.Count; i++)
        {
            Fiches card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
            card.controller = this;
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
                firstSelected = null;
                secondSelected = null;
            }
        }
    }

    IEnumerator CheckMatching(Fiches a, Fiches b)
    {
        yield return new WaitForSeconds(0.3f);
        if(a.iconSprite == b.iconSprite)
        {

        }
        else
        {
            a.Hide();
            b.Hide();
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
}
