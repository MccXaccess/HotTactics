using UnityEngine;

public class ModuleDontDestroyOnLoad : MonoBehaviour
{
    // NOTE: Make the '_objectTag' able to select tags instead of writing them.
    // NOTE: Ability to select current gameObject's tag. Bool checkbox.
    [SerializeField] private string _objectTag;

    private void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(_objectTag);

        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}