using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health=2;	//敌人的生命值
	public AudioClip enemyHurtAudio;	//敌人的受伤音效

	private Collider collider;			//敌人的Collider组件
	private Rigidbody rigidbody;		//敌人的rigidbody组件

	//初始化，获取敌人的组件
	void Start(){
		collider = GetComponent<Collider> ();	//获取敌人的Collider组件
		rigidbody = GetComponent<Rigidbody> ();	//获取敌人的Rigidbody组件
	}

	//敌人受伤函数，用于PlayerAttack脚本中调用
	public void TakeDamage(int damage){	
		health -= damage;			//敌人受伤扣血
		if (enemyHurtAudio != null)	//在敌人位置处播放敌人受伤音效
			AudioSource.PlayClipAtPoint (enemyHurtAudio, transform.position);
		if (health <= 0) {			//当敌人生命值小于等于0时，表明敌人已死亡
			Destroy (gameObject, 1.5f);			//3秒后删除敌人对象
		}
	}
}
