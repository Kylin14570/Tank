/*************************
* 每个玩家都有一个heart
* 当heart被敌方击中时即为失败
*************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Heart : MonoBehaviour {
          
    public Sprite BrokenSprite;         //heart图片
    private SpriteRenderer sr;          //heart图片的控制变量
    public GameObject explosionPrefab;  //爆炸特效
    public AudioClip dieAudio;          //死亡音效

	// Use this for initialization
	void Start () 
    {
        //初始化， 获取heart对象
        sr = GetComponent<SpriteRenderer>();
	}

    //死亡方法
    public void Die()
    {
        //heart图片改为破碎模式
        sr.sprite = BrokenSprite;

        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        //产生死亡音效
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);

        //heart被毁，游戏失败
        PlayerManager.Instance.isDefeat = true;
    }
}
