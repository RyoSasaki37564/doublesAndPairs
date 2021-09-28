using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hikimasu : MonoBehaviour
{
    [SerializeField] GameObject m_kakuninPanel = default; //引くかの確認パネル
    [SerializeField] GameObject m_JuurenKakunin = default;

    [SerializeField] GameObject m_ResultDsp = default; //ガチャ結果表示親
    [SerializeField] GameObject m_gachaResultPanel = default; //ガチャ結果表示パネル
    [SerializeField] LayoutGroup m_results = default;

    [SerializeField] List<GameObject> m_CanHitCharactors_SSR = new List<GameObject>(); //排出SSRキャラリスト
    [SerializeField] List<GameObject> m_CanHitCharactors_SR = new List<GameObject>(); //排出SRキャラリスト
    [SerializeField] List<GameObject> m_CanHitCharactors_R = new List<GameObject>(); //排出Rキャラリスト

    [SerializeField] LayoutGroup m_userCharaBox = default; //所持キャラボックス

    [SerializeField] Text m_MenuHeadText = default; //ソウル数の表示

    CharaID m_thisID;

    void Start()
    {
        m_ResultDsp.SetActive(false);
    }

    public virtual void Gacha()
    {
        if (MenuManager.m_soul >= 3)
        {
            m_kakuninPanel.SetActive(false);
            m_JuurenKakunin.SetActive(false);
            m_ResultDsp.SetActive(true);

            int rondom = Random.Range(0, 100);

            if (rondom < 15)
            {
                //当選キャラをリザルトに表示し、ボックスにも同じものを送る。
                int ssr = Random.Range(0, m_CanHitCharactors_SSR.Count);
                var x = Instantiate(m_CanHitCharactors_SSR[ssr]);
                x.SetActive(true);
                var y = Instantiate(x);
                y.SetActive(true);
                x.transform.SetParent(m_results.transform);
                y.transform.SetParent(m_userCharaBox.transform);
                x.transform.localScale = m_CanHitCharactors_SSR[ssr].transform.localScale;
                y.transform.localScale = m_CanHitCharactors_SSR[ssr].transform.localScale;

            }
            else if (rondom < 51)
            {
                int sr = Random.Range(0, m_CanHitCharactors_SR.Count);
                var x = Instantiate(m_CanHitCharactors_SR[sr]);
                x.SetActive(true);
                var y = Instantiate(x);
                y.SetActive(true);
                x.transform.SetParent(m_gachaResultPanel.transform);
                y.transform.SetParent(m_userCharaBox.transform);
                x.transform.localScale = m_CanHitCharactors_SR[sr].transform.localScale;
                y.transform.localScale = m_CanHitCharactors_SR[sr].transform.localScale;

            }
            else
            {
                int r = Random.Range(0, m_CanHitCharactors_R.Count);
                var x = Instantiate(m_CanHitCharactors_R[r]);
                x.SetActive(true);
                var y = Instantiate(x);
                y.SetActive(true);
                x.transform.SetParent(m_gachaResultPanel.transform);
                y.transform.SetParent(m_userCharaBox.transform);
                x.transform.localScale = m_CanHitCharactors_R[r].transform.localScale;
                y.transform.localScale = m_CanHitCharactors_R[r].transform.localScale;

            }
            MenuManager.m_soul -= 3;
            m_MenuHeadText.text = "所持ソウル: " + MenuManager.m_soul.ToString();
        }
    }

    public void SSRKakutei()
    {
        //当選キャラをリザルトに表示し、ボックスにも送る。
        int ssr = Random.Range(0, m_CanHitCharactors_SSR.Count);
        var x = Instantiate(m_CanHitCharactors_SSR[ssr]);
        x.SetActive(true);
        var y = Instantiate(x);
        y.SetActive(true);
        x.transform.SetParent(m_results.transform);
        y.transform.SetParent(m_userCharaBox.transform);
        x.transform.localScale = m_CanHitCharactors_SSR[ssr].transform.localScale;
        y.transform.localScale = m_CanHitCharactors_SSR[ssr].transform.localScale;

        MenuManager.m_soul -= 3;
        m_MenuHeadText.text = "所持ソウル: " + MenuManager.m_soul.ToString();
    }
}
