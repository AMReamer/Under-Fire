using UnityEngine;
using System.Collections;

public class Challenge : MonoBehaviour {

    //public GameObject Gravity_cirlce;
    
    //Text
    public UnityEngine.UI.Text infoText;

    //Vars
    private float timer;
    private float microTimer;
    private int round;
    private int maxRounds;
    private int difficulty;
    private int score;

    //holders
    bool holder1;

    //Bullets
    public Transform Gravity_Circle;
    public Transform Bullet;
    public Transform Wave_Bullet;
    public Transform Bar;
	// Use this for initialization
	void Start () {
        round = 0;
        difficulty = 1;
        holder1 = true; 
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        microTimer += Time.deltaTime;
        if (round == 0) tutorial();
        if (round == 1) trig();
        if (round == 2) curve();
        if (round == 3) wave();
        if (round == 4) flow();
	}

    private void endOfRound()
    {
        print("end of round " + round);
        round++;
        timer = 0;
        score++;
        holder1 = true;
    }

    private void tutorial()//round 0
    {
        if (timer > 5.0f)
        {
            infoText.text = "";
            endOfRound();
        }
        else if (timer > 4.0f) infoText.text = "Good";
        else if (timer > 2.0f && holder1) { Instantiate(Gravity_Circle, new Vector2(0, 5), Gravity_Circle.rotation); holder1 = false; }

    }

    private void curve()//round 2
    {
        if (timer < 7.0f && microTimer > 0.5f && holder1) 
        {
            microTimer = 0;
            holder1 = false;
            (Instantiate(Bullet, new Vector2(0, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
            (Instantiate(Bullet, new Vector2(1, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -4);
            (Instantiate(Bullet, new Vector2(-1, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -4);
            (Instantiate(Bullet, new Vector2(2, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2, -3);
            (Instantiate(Bullet, new Vector2(-2, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, -3);
            (Instantiate(Bullet, new Vector2(3, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(3, -2);
            (Instantiate(Bullet, new Vector2(-3, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-3, -2);
        }
        else if (timer < 7.0f && microTimer > 0.5f)
        {
            microTimer = 0;
            holder1 = true;
            (Instantiate(Bullet, new Vector2(0, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
            (Instantiate(Bullet, new Vector2(.5f, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(.5f, -4.5f);
            (Instantiate(Bullet, new Vector2(-.5f, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-.5f, -4.5f);
            (Instantiate(Bullet, new Vector2(1.5f, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1.5f, -3.5f);
            (Instantiate(Bullet, new Vector2(-1.5f, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, -3.5f);
            (Instantiate(Bullet, new Vector2(2.5f, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2.5f, -2.5f);
            (Instantiate(Bullet, new Vector2(-2.5f, 5), Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-2.5f, -2.5f);
        }

        if (timer > 10.0f) endOfRound();
    }

    private void trig()//round 1
    {
        if (timer < 5.0f && microTimer > 0.5f)
        {
            microTimer = 0;
            (Instantiate(Wave_Bullet, new Vector2(-5, 0), Wave_Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 5);
            (Instantiate(Wave_Bullet, new Vector2(-5, 0), Wave_Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2, -5);
        }
        if (timer > 10.0f) endOfRound();
    }

    private void wave()//round 3
    {
        if (timer < 5.0f)
        {
            (Instantiate(Wave_Bullet, new Vector2(-5, 0), Wave_Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 5);
            (Instantiate(Wave_Bullet, new Vector2(-5, 0), Wave_Bullet.rotation) as Transform).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2, -5);
        }
        if (timer > 10.0f) endOfRound();
    }

    private void flow()//round 4
    {
        if (timer < 5.0f && microTimer > 1f)
        {
            microTimer = 0;
            float xScale = Random.Range(0, 2.3f);
            float reflectScale = 2.3f - xScale;
            Transform temp = (Instantiate(Bar, Bar.position, Bar.rotation) as Transform);
            temp.localScale = new Vector3(xScale, Bar.localScale.y, Bar.localScale.z);
            temp.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);

            temp = (Instantiate(Bar, new Vector3(Bar.position.x-.1f,Bar.position.y*-1.0f, Bar.position.z), Quaternion.Euler(new Vector3(Bar.rotation.x, Bar.rotation.y, Bar.rotation.z+270))) as Transform);
            temp.localScale = new Vector3(reflectScale, Bar.localScale.y, Bar.localScale.z);
            temp.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
        }

        if (timer > 10.0f) endOfRound();
    }
}
