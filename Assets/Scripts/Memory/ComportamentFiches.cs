using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentFiches : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;

    private List<Sprite> spritePairs;

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
