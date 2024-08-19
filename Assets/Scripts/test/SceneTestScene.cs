/**

在Unity中，如果你想加载一场不在"Build Settings"（构建设置）列表中的场景，你可以使用SceneManager.LoadScene的Scene类型的方式来加载场景。
通常情况下，只有在"Build Settings"中列出的场景才能在运行时被直接加载。然而，有一些解决方案可以实现加载未在构建设置中的场景。
将场景打包为 AssetBundle。打包后，你可以在运行时从 AssetBundle 中加载场景。

 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTestScene : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SceneTestScene.Start");

        //SceneManager.LoadSceneAsync("UITestScene", LoadSceneMode.Additive);
        //SceneManager.LoadScene("UITestScene", LoadSceneMode.Additive);
        //SceneManager.LoadScene("Assets/Scenes/UITestScene.unity");



    }



    // Update is called once per frame
    void Update()
    {
        
    }



}
