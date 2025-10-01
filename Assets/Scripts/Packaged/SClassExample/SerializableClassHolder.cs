using UnityEngine;

public class SerializableClassHolder : MonoBehaviour
{
    public MySerializableClass mySClassInstance;
    public MySerializableClass anotherSClassInstance;
    
    public MySerializableClass[] anArrayOfSClassInstances;

    private void Start()
    {
        mySClassInstance.DoStuff();
        //...
    }   
}