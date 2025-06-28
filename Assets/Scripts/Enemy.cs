using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    /// <summary>  
    /// プレイヤー  
    /// </summary>  
    [SerializeField] private Player player_ = null;

    /// <summary>  
    /// ワールド行列   
    /// </summary>  
    private Matrix4x4 worldMatrix_ = Matrix4x4.identity;


	/// <summary>
	/// ターゲット
	/// </summary>
	[SerializeField]
	private GameObject target_;

	/// <summary>  
	/// ターゲットとして設定する  
	/// </summary>  
	/// <param name="enable">true:設定する / false:解除する</param>  
	public void SetTarget(bool enable)
    {
        // マテリアルの色を変更する  
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.materials[0].color = enable ? Color.red : Color.white;
    }

	/// <summary>
	/// 開始処理
	/// </summary>
	public void Start()
    {
    }

    /// <summary>  
    /// 更新処理  
    /// </summary>  
    public void Update()
    {

		if (Input.GetKeyDown(KeyCode.Z))
		{
			// ターゲットまでの向きの単位ベクトル
			var toTarget = (target_.transform.position - transform.position).normalized;
			// 自身の前方を指す単位ベクトル
			var fowerd = transform.forward;

			// 単位ベクトル同士の内積で cos を求める
			var dot = Vector3.Dot(fowerd, toTarget);
		

			// cos から角度（ラジアン）を求める
			var radian = Mathf.Acos(dot);

			// 外積で回転軸を求める
			var cross = Vector3.Cross(fowerd, toTarget);
			// 回転軸が上向きか下向きかで角度を反転させる
			radian *= (cross.y / Mathf.Abs(cross.y));

			// 角度を指定して回転させる
			transform.rotation *= Quaternion.Euler(0, Mathf.Rad2Deg * radian, 0);


		}

	}
}
