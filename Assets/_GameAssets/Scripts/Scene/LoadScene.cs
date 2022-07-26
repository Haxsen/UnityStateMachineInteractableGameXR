using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public void LoadSomeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}