using CardGames;
using System.Text;
using UnityEngine;

public class TestDeck : MonoBehaviour
{
	public const int RUNS = 10000;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		float[,] sampleData = new float[52, 17];
		const float THIRTEENTH = 1f / 13;
		for (int i = 0; i < RUNS; i++)
		{
			RuffianDeck deck = RuffianDeck.RuffianStandard();
			deck.Shuffle();
			for (int j = 0; j < deck.Cards.Length; j++)
			{
				sampleData[j, (int)(deck.Cards[j].Rank - 2)]++;
				sampleData[j, 13 + (int)deck.Cards[j].Suit]++;
			}
		}
		StringBuilder sb = new StringBuilder();
		
		for (int i = 0; i < sampleData.GetLength(0); i++)
		{
			sb.Append("Position: ");
			sb.Append(i);

			for (int j = 0; j < sampleData.GetLength(1); j++)
			{
				sampleData[i, j] /= RUNS;
				sb.Append(" | ");
				sb.Append("<color=#");
				sb.Append(ColorUtility.ToHtmlStringRGB(j < 13 ? Color.Lerp(Color.red, Color.green, 1 - Mathf.Abs((sampleData[i, j] - THIRTEENTH) * 13)) : Color.Lerp(Color.red, Color.green, 1 - Mathf.Abs((sampleData[i, j] - 0.25f) * 4))));
				sb.Append(">");
				sb.Append(sampleData[i, j].ToString("00.0%"));
				sb.Append("</color>");
			}
			sb.AppendLine();
		}
		Debug.Log(sb.ToString());
	}
}
