using UnityEngine;
public static class Utils
{
    public static void Shuffle(int[] deck)
    {
        for (int i = 0; i < deck.Length; i++)
        {
            int temp = deck[i];
            int randomIndex = Random.Range(0, deck.Length);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public static void Shuffle(Object[] deck)
    {
        for (int i = 0; i < deck.Length; i++)
        {
            Object temp = deck[i];
            int randomIndex = Random.Range(0, deck.Length);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public static void CheckEmpty(Object target)
    {

    }
}
