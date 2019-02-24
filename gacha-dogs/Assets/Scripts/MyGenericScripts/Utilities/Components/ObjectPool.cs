using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic class to create a pool of game objects by a prefab.
/// </summary>
public class ObjectPool<TObject> : MonoBehaviour, IObjectPool
    where TObject : ObjectInPool
{
    #region Settings
    [Header("Tag Settings")]
    public GameObject rootObject;
    public string poolName;

    [Header("Pool Settings")]
    public GameObject prefab;
    public int initialPoolCount = 10;
    public bool createMoreObjects = true;
    #endregion

    protected List<TObject> _pool;
    private GameObject _root;

    #region Properties
    /// <summary>
    /// The position of this gameobject.
    /// </summary>
    public Vector3 Position
    {
        get { return transform.position; }
    }

    /// <summary>
    /// Returns the list of objects in this pool.
    /// </summary>
    public List<TObject> List
    {
        get { return _pool; }
    }
    #endregion

    private void Awake()
    {
        _pool = new List<TObject>(); Construct();
    }

    private void Start()
    {
        _root = new GameObject("Pool_" + poolName);
        if (rootObject != null)
            _root.transform.parent = rootObject.transform;
        for (int i = 0; i < initialPoolCount; i++)
            Create();
        Initialize();
    }

    /// <summary>
    /// This is called before the pool is created.
    /// </summary>
    protected virtual void Construct()
    {

    }

    /// <summary>
    /// This is called after the pool is creted.
    /// </summary>
    protected virtual void Initialize()
    {

    }

    /// <summary>
    /// Instances the game object.
    /// </summary>
    protected virtual TObject Create()
    {
        GameObject gameObject = Instantiate(prefab);
        gameObject.transform.SetParent(_root.transform);
        gameObject.SetActive(false);

        TObject component = gameObject.GetComponent<TObject>();
        if (component == null)
            component = gameObject.AddComponent<TObject>();
        component.InPool = true;
        component.Pool = this;

        _pool.Add(component);
        return component;
    }

    /// <summary>
    /// Returns a game object of the pool.
    /// </summary>
    public TObject Pop()
    {
        foreach (TObject item in _pool)
            if (item.InPool)
                return item;

        if (createMoreObjects)
            return Create();
        return null;
    }

    private void OnDestroy()
    {
        Destroy(_root);
    }
}

/// <summary>
/// Abstract class to save the object to be instanced by the object pool.
/// </summary>
public abstract class ObjectInPool : MonoBehaviour
{
    /// <summary>
    /// When true, the object hasn't been instanced.
    /// </summary>
    public bool InPool { get; set; }

    /// <summary>
    /// Pool assigned to this game object.
    /// </summary>
    public IObjectPool Pool { get; set; }

    /// <summary>
    /// Spawn the game object.
    /// </summary>
    public virtual void WakeUp()
    {
        InPool = false; gameObject.SetActive(true);
    }

    /// <summary>
    /// Despawn the game object.
    /// </summary>
    public virtual void Sleep()
    {
        InPool = true; gameObject.SetActive(false);
    }
}

/// <summary>
/// Interface to define a generic object pool.
/// </summary>
public interface IObjectPool
{
    /// <summary>
    /// Position of game object.
    /// </summary>
    Vector3 Position { get; }
}