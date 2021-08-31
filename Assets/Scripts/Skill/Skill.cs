using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] GameObject[] m_fazerSkills = new GameObject[3]; //フェイザーを格納

    public enum Faze
    {
        firstFazer, //初期フェイザー
        secondFazer, //一段階解放
        lethalFazer, //最終段階解放
    }

    public static Faze m_faze;

    // Start is called before the first frame update
    public virtual void Fazer()
    {
        switch (m_faze)
        {
            case Faze.firstFazer:
                Instantiate(m_fazerSkills[0], transform.position, transform.rotation);
                break;
            case Faze.secondFazer:
                Instantiate(m_fazerSkills[1], transform.position, transform.rotation);
                break;
            case Faze.lethalFazer:
                Instantiate(m_fazerSkills[2], transform.position, transform.rotation);
                break;
            default:
                break;
        }
    }
}
