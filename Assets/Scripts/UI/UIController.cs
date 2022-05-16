using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] protected Text scoreField;

    protected const string scoreFieldTextForm = "Score: ";

    public void UpdateScoreTextField(int scoreNumber)
    {
        scoreField.text = scoreFieldTextForm + scoreNumber.ToString();
    }
}
