/**

��Unity�У�����������һ������"Build Settings"���������ã��б��еĳ����������ʹ��SceneManager.LoadScene��Scene���͵ķ�ʽ�����س�����
ͨ������£�ֻ����"Build Settings"���г��ĳ�������������ʱ��ֱ�Ӽ��ء�Ȼ������һЩ�����������ʵ�ּ���δ�ڹ��������еĳ�����
���������Ϊ AssetBundle������������������ʱ�� AssetBundle �м��س�����

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
