using UnityEngine;

public class CamelSpawner : MonoBehaviour
{
    public GameObject Camel;
    public GameObject Level;
    private GameObject NewCamel;

    public void Start()
    {
        Invoke("spawner", 0.0f);
        Invoke("spawner", 10.0f);
        Invoke("Start", 20.0f);
    }

    private void spawner()
    {
        if (Level.activeSelf)
        {
            NewCamel = Instantiate(Camel, transform.position, transform.rotation);
            NewCamel.transform.parent = transform.parent;
            NewCamel.LeanMoveLocalX(117.0f, 100.0f).setOnComplete(destroyer);
        }
    }

    private void destroyer()
    {
        Destroy(NewCamel);
        spawner();
    }
}
