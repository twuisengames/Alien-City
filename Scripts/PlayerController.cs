using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	private Animator anim;
	private Rigidbody2D rb2d;

	public Transform posPe;
	[HideInInspector] public bool tocaChao = false;

	public GameObject tiro1pref;
	public float Velocidade;
	public float ForcaPulo = 1000f;
	[HideInInspector] public bool viradoDireita = true;

	public Image vida;
	private MensagemControle MC;

	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

		GameObject mensagemControleObject = GameObject.FindWithTag ("MensagemControle");
		if (mensagemControleObject != null) {
			MC = mensagemControleObject.GetComponent<MensagemControle> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Implementar Pulo Aqui! 
	}

	void FixedUpdate()
	{
		float translationY = 0;
		float translationX = Input.GetAxis ("Horizontal") * Velocidade;
		transform.Translate (translationX, translationY, 0);
		transform.Rotate (0, 0, 0);
		if (translationX != 0) {
			anim.SetBool ("corre", true);
		} else {
			anim.SetBool ("atirando1", false);
			anim.SetTrigger("parado");
		}

		//Programar o pulo Aqui!!
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb2d.AddForce (new Vector4 (0.0f, 1.0f) * 1500);
			anim.SetTrigger ("pula");
		}

		if (translationX > 0 && !viradoDireita) {
			Flip ();
		} else if (translationX < 0 && viradoDireita) {
			Flip();
		}
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			anim.SetBool ("atirando1", true);
			GameObject tiro1 = new GameObject ();
			tiro1 = Instantiate(tiro1pref,transform.localPosition, transform.localRotation);
			if (viradoDireita) {
				tiro1.GetComponent<tiro1> ().veltiro1 = 1000;
			} else {
				tiro1.GetComponent<tiro1> ().veltiro1 = -1000;
				Vector3 escala;
				escala = tiro1.transform.localScale;
				escala.x *= -1;
				tiro1.transform.localScale = escala;
			}
		}
	}
	void Flip()
	{
		viradoDireita = !viradoDireita;
		Vector3 escala = transform.localScale;
		escala.x *= -1;
		transform.localScale = escala;
	}

	public void SubtraiVida()
	{
		vida.fillAmount-=0.1f;
		if (vida.fillAmount <= 0) {
			MC.GameOver();
			Destroy(gameObject);
		}
	}
	
}
