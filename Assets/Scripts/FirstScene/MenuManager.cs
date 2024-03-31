using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] Button continueButton;
    [SerializeField] CharacterAnimator animator;
    void Start()
    {
        continueButton.interactable = false;
        continueButton.onClick.AddListener(OnContinue);
    }

    public void OnButtonClick(string animationName)
    {
        animator.SetAnimation(animationName);
        continueButton.interactable = true;
    }

    public void OnContinue()
    {
        SceneManager.LoadScene(1);
    }
}
