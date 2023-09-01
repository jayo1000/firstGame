using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class JUMP : MonoBehaviour
{
    public float JumpPower = 300.0f;
    [SerializeField] private LayerMask platformLayerMask;
    BoxCollider2D boxCollider2D;
    bool die = false;
    public GameObject effect_jump;  // 추가된 부분
    public List<AudioClip> jumpEffectSounds; // 새로 추가된 내용
    public AudioSource audioSource;          // 새로 추가된 내용

    string recentCollisionObjectName = "땅"; // 새로 추가된 내용
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();  // 새로 추가된 내용
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true && die == false)
        {
            if (IsGrounded())
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower));
                GameObject effect = Instantiate(effect_jump);   // 추가된 부분
                effect.transform.position = transform.position;   // 추가된 부분
            }
        }
    }
    
    public void Die()
    {
        die = true;
    }
    public void PlayJumpEffectSound() {
        int sound_Index = UnityEngine.Random.Range(0, jumpEffectSounds.Count);
        AudioClip jump_clip = jumpEffectSounds[sound_Index];
        audioSource.clip = jump_clip;
        audioSource.Play();
    }
    public bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = 
                       Physics2D.Raycast(  
                                boxCollider2D.bounds.center,  
                                Vector2.down,              
                                boxCollider2D.bounds.extents.y + extraHeight, 
                                platformLayerMask); 

        Color rayColor; 
        if (raycastHit.collider != null)
        {
            // 새로 추가된 내용
            if(raycastHit.collider.name != "땅" &&
                raycastHit.collider.name != recentCollisionObjectName)
            {
                FindObjectOfType<ScoreText>().AddPoint();
                recentCollisionObjectName = raycastHit.collider.name;
                PlayJumpEffectSound();  // 새로 추가된 내용
            }

            rayColor = Color.green;
        }
        else 
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(   
                         boxCollider2D.bounds.center, 
                         Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight),
                         rayColor); 

        Debug.Log(raycastHit.collider);

        if (raycastHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
