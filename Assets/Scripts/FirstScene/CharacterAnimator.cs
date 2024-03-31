using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetAnimation(string name)
    {
        animator.Play(name);
    }
    
}
