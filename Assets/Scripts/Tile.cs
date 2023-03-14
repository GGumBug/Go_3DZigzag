using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private float       fallDownTime = 2;
    private Rigidbody   rigidbody;
    private TileSpawner tileSpawner = null;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    // [SerializeField]로 직접 할당 하지 않고 찾는 방법
    public void SetUp(TileSpawner tileSpawner)
    {
        this.tileSpawner = tileSpawner;
    }

    private void OnCollisionExit(Collision other) {
        if (other.transform.tag.Equals("Player"))
        {
            StartCoroutine("FallDownAndRespawnTile");
        }
    }

    private IEnumerator FallDownAndRespawnTile()
    {
        yield return new WaitForSeconds(0.1f);

        //물리가 적용 되도록 설정하는 것
        rigidbody.isKinematic = false;

        yield return new WaitForSeconds(fallDownTime);

        rigidbody.isKinematic = true;

        if (tileSpawner != null)
        {
            tileSpawner.SpawnTile(this.transform);
        }
        else
        {
            //처음부터 생성돼 있는 그라운드와 FirstTile은 CreateTile을 하지 않았기때문에 tileSpawner = null이고 재활용되지 않고 false된다.
            gameObject.SetActive(false);
        }
    }
}
