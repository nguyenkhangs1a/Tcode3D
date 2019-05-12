using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour { 
    public enum CharacterType
    {
        enemy,
        player
    }
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private CharacterType _type;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float _speedAngle;
    [SerializeField]
    private int _dame=2;
    [SerializeField]
    private int _health = 5;
    private Rigidbody _rig;
    protected Transform _transf;
    private bool canjump=true;


    private int maxHealth;

    private bool canfire = true;

    private bool _isdead = false;

    [SerializeField]
    private GameObject PrefabEffect;
    [SerializeField]
    private GameObject _pBullet;
    [SerializeField]
    private Transform _pShot;//hieu ung no~
    // Use this for initialization

    IEnumerator Delay()
    {
        canjump = false;
        _rig.AddForce(Vector3.up * jumpForce );
        yield return new WaitForSeconds(1f);
        canjump = true;
        
    }
    void Start()
    {
        _rig = GetComponent<Rigidbody>();
        _transf = this.transform;

        maxHealth = this._health;
        startCharacter();

    }

    // Update is called once per frame
    void Update()
    {
    }
    public CharacterType characterType
    {
        get { return this._type; }
        set { this._type = value; }
    }
    public void movingForward()
    {
        Vector3 vel = _rig.velocity;
        Vector3 v3 = _transf.forward * speed * Time.deltaTime;
        v3.y = vel.y;
        _rig.velocity = v3;
    }
    public void moveback()
    {
        Vector3 vel = _rig.velocity;
        Vector3 v3 = -_transf.forward * speed * Time.deltaTime;
        v3.y = vel.y;
        _rig.velocity = v3;

    }
    public void rotationRight()
    {
        Vector3 r = new Vector3(0, (_speedAngle * Time.deltaTime), 0);
        _transf.Rotate(r,Space.World);
    }
    public void rotationleft()
    {
        Vector3 r = new Vector3(0, -(_speedAngle * Time.deltaTime), 0);
        _transf.Rotate(r, Space.World);
    }
    public void jump()
    {
        if (canjump)
        {
            StartCoroutine(Delay());
        }
    }
    public virtual bool hit(int dame)
    {
        return false;
    }
    public virtual  void dead()
    {

    }
    public virtual void fire()
    {

    }
    public bool isPlayer()
    {
        return _type == CharacterType.player;
    }
    public bool isEnemy()
    {
        return _type == CharacterType.enemy;
    }

    public int UpdateHealth(int amout)
    {
        this._health -= amout;
        return this._health;
    }

    public int GetDame()
    {
        return _dame;
    }
    public float GetPercenHealth()
    {
        //Debug.Log("maxHP=" + maxHealth);
        //Debug.Log("HP=" + _health);
        return (float)_health / (float) maxHealth;//maxHealth;
    }
    public bool Iscanfire
    {
        get{return this.canfire;}
        set { this.canfire = value; }
    }
    public bool Isdead
    {
        get { return this._isdead; }
        set { this._isdead = value; }
    }

    public void CreatEffectWithTime(float timeLife)
    {
        GameObject obj = Instantiate(PrefabEffect, _transf.position,Quaternion.identity);
        Destroy(obj, timeLife);
    }

     public  void CreatBullet()
    {
        GameObject obj = Instantiate(_pBullet, _pShot.position, _transf.rotation);
        Bulletter bullet = obj.GetComponent<Bulletter>();
        bullet.SetParent(this);
    }
    public virtual void startCharacter()
     {

     }
}
