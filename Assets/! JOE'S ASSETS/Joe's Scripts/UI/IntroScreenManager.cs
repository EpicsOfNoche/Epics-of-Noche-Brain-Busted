using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScreenManager : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private string animationName = "IntroScreen";

    [Header("On Finish")]
    [SerializeField] private string nextSceneName = "MainMenu";

    private void Update()
    {
        WaitForAnimationToFinish();
    }

    private void WaitForAnimationToFinish()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1f) Done();
    }

    private void Done()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}